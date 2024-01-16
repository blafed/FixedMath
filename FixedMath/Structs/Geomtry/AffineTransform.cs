namespace FixedMath.Geomtry
{
    ///<summary>
    /// A transformation composed of a linear transformation and a translation.
    ///</summary>
    public struct AffineTransform
    {
        ///<summary>
        /// Translation in the affine transform.
        ///</summary>
        public FixVector3 Translation;
        /// <summary>
        /// Linear transform in the affine transform.
        /// </summary>
        public FixMatrix3x3 LinearTransform;

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(in FixVector3 translation)
        {
            LinearTransform = FixMatrix3x3.Identity;
            Translation = translation;
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(FixVector3 translation)
            : this(in translation)
        {
        }

        ///<summary>
        /// Constructs a new affine tranform.
        ///</summary>
        ///<param name="orientation">Orientation to use as the linear transform.</param>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(in FixQuaternion orientation, in FixVector3 translation)
        {
            FixMatrix3x3.CreateFromQuaternion(in orientation, out LinearTransform);
            Translation = translation;
        }

        ///<summary>
        /// Constructs a new affine tranform.
        ///</summary>
        ///<param name="orientation">Orientation to use as the linear transform.</param>
        ///<param name="translation">Translation to use in the transform.</param>
        public AffineTransform(FixQuaternion orientation, FixVector3 translation)
            : this(in orientation, in translation)
        {
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="scaling">Scaling to apply in the linear transform.</param>
        ///<param name="orientation">Orientation to apply in the linear transform.</param>
        ///<param name="translation">Translation to apply.</param>
        public AffineTransform(in FixVector3 scaling, in FixQuaternion orientation, in FixVector3 translation)
        {
            //Create an SRT transform.
            FixMatrix3x3.CreateScale(in scaling, out LinearTransform);
            FixMatrix3x3 rotation;
            FixMatrix3x3.CreateFromQuaternion(in orientation, out rotation);
            FixMatrix3x3.Multiply(in LinearTransform, in rotation, out LinearTransform);
            Translation = translation;
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="scaling">Scaling to apply in the linear transform.</param>
        ///<param name="orientation">Orientation to apply in the linear transform.</param>
        ///<param name="translation">Translation to apply.</param>
        public AffineTransform(FixVector3 scaling, FixQuaternion orientation, FixVector3 translation)
            : this(in scaling, in orientation, in translation)
        {
        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="linearTransform">The linear transform component.</param>
        ///<param name="translation">Translation component of the transform.</param>
        public AffineTransform(in FixMatrix3x3 linearTransform, in FixVector3 translation)
        {
            LinearTransform = linearTransform;
            Translation = translation;

        }

        ///<summary>
        /// Constructs a new affine transform.
        ///</summary>
        ///<param name="linearTransform">The linear transform component.</param>
        ///<param name="translation">Translation component of the transform.</param>
        public AffineTransform(FixMatrix3x3 linearTransform, FixVector3 translation)
            : this(in linearTransform, in translation)
        {
        }

        ///<summary>
        /// Gets or sets the 4x4 matrix representation of the affine transform.
        /// The linear transform is the upper left 3x3 part of the 4x4 matrix.
        /// The translation is included in the matrix's Translation property.
        ///</summary>
        public FixMatrix4x4 Matrix
        {
            get
            {
                FixMatrix4x4 toReturn;
                FixMatrix3x3.ToMatrix4X4(in LinearTransform, out toReturn);
                toReturn.Translation = Translation;
                return toReturn;
            }
            set
            {
                FixMatrix3x3.CreateFromMatrix(in value, out LinearTransform);
                Translation = value.Translation;
            }
        }


        ///<summary>
        /// Gets the identity affine transform.
        ///</summary>
        public static AffineTransform Identity
        {
            get
            {
                var t = new AffineTransform { LinearTransform = FixMatrix3x3.Identity, Translation = new FixVector3() };
                return t;
            }
        }

        ///<summary>
        /// Transforms a vector by an affine transform.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to apply.</param>
        ///<param name="transformed">Transformed position.</param>
        public static void Transform(in FixVector3 position, in AffineTransform transform, out FixVector3 transformed)
        {
            FixMatrix3x3.Transform(in position, in transform.LinearTransform, out transformed);
            FixVector3.Add(in transformed, in transform.Translation, out transformed);
        }

        ///<summary>
        /// Transforms a vector by an affine transform's inverse.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to invert and apply.</param>
        ///<param name="transformed">Transformed position.</param>
        public static void TransformInverse(in FixVector3 position, in AffineTransform transform, out FixVector3 transformed)
        {
            FixVector3.Subtract(in position, in transform.Translation, out transformed);
            FixMatrix3x3 inverse;
            FixMatrix3x3.Invert(in transform.LinearTransform, out inverse);
            FixMatrix3x3.TransformTranspose(in transformed, in inverse, out transformed);
        }

        ///<summary>
        /// Inverts an affine transform.
        ///</summary>
        ///<param name="transform">Transform to invert.</param>
        /// <param name="inverse">Inverse of the transform.</param>
        public static void Invert(in AffineTransform transform, out AffineTransform inverse)
        {
            FixMatrix3x3.Invert(in transform.LinearTransform, out inverse.LinearTransform);
            FixMatrix3x3.Transform(in transform.Translation, in inverse.LinearTransform, out inverse.Translation);
            FixVector3.Negate(in inverse.Translation, out inverse.Translation);
        }

        /// <summary>
        /// Multiplies a transform by another transform.
        /// </summary>
        /// <param name="a">First transform.</param>
        /// <param name="b">Second transform.</param>
        /// <param name="transform">Combined transform.</param>
        public static void Multiply(in AffineTransform a, in AffineTransform b, out AffineTransform transform)
        {
            FixMatrix3x3 linearTransform;//Have to use temporary variable just in case a or b reference is transform.
            FixMatrix3x3.Multiply(in a.LinearTransform, in b.LinearTransform, out linearTransform);
            FixVector3 translation;
            FixMatrix3x3.Transform(in a.Translation, in b.LinearTransform, out translation);
            FixVector3.Add(in translation, in b.Translation, out transform.Translation);
            transform.LinearTransform = linearTransform;
        }

        ///<summary>
        /// Multiplies a rigid transform by an affine transform.
        ///</summary>
        ///<param name="a">Rigid transform.</param>
        ///<param name="b">Affine transform.</param>
        ///<param name="transform">Combined transform.</param>
        public static void Multiply(in RigidTransform a, in AffineTransform b, out AffineTransform transform)
        {
            FixMatrix3x3 linearTransform;//Have to use temporary variable just in case b reference is transform.
            FixMatrix3x3.CreateFromQuaternion(in a.Orientation, out linearTransform);
            FixMatrix3x3.Multiply(in linearTransform, in b.LinearTransform, out linearTransform);
            FixVector3 translation;
            FixMatrix3x3.Transform(in a.Position, in b.LinearTransform, out translation);
            FixVector3.Add(in translation, in b.Translation, out transform.Translation);
            transform.LinearTransform = linearTransform;
        }


        ///<summary>
        /// Transforms a vector using an affine transform.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="affineTransform">Transform to apply.</param>
        ///<returns>Transformed position.</returns>
        public static FixVector3 Transform(FixVector3 position, AffineTransform affineTransform)
        {
            FixVector3 toReturn;
            Transform(in position, in affineTransform, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates an affine transform from a rigid transform.
        /// </summary>
        /// <param name="rigid">Rigid transform to base the affine transform on.</param>
        /// <param name="affine">Affine transform created from the rigid transform.</param>
        public static void CreateFromRigidTransform(in RigidTransform rigid, out AffineTransform affine)
        {
            affine.Translation = rigid.Position;
            FixMatrix3x3.CreateFromQuaternion(in rigid.Orientation, out affine.LinearTransform);
        }

        /// <summary>
        /// Creates an affine transform from a rigid transform.
        /// </summary>
        /// <param name="rigid">Rigid transform to base the affine transform on.</param>
        /// <returns>Affine transform created from the rigid transform.</returns>
        public static AffineTransform CreateFromRigidTransform(RigidTransform rigid)
        {
            AffineTransform toReturn;
            toReturn.Translation = rigid.Position;
            FixMatrix3x3.CreateFromQuaternion(in rigid.Orientation, out toReturn.LinearTransform);
            return toReturn;
        }

    }
}