

namespace FixedMath.Geomtry
{
    ///<summary>
    /// Transform composed of a rotation and translation.
    ///</summary>
    public struct RigidTransform
    {
        ///<summary>
        /// Translation component of the transform.
        ///</summary>
        public FixVector3 Position;
        ///<summary>
        /// Rotation component of the transform.
        ///</summary>
        public FixQuaternion Orientation;

        ///<summary>
        /// Constructs a new rigid transform.
        ///</summary>
        ///<param name="position">Translation component of the transform.</param>
        ///<param name="orientation">Rotation component of the transform.</param>
        public RigidTransform(FixVector3 position, FixQuaternion orientation)
        {
            Position = position;
            Orientation = orientation;
        }

        ///<summary>
        /// Constructs a new rigid transform.
        ///</summary>
        ///<param name="position">Translation component of the transform.</param>
        public RigidTransform(FixVector3 position)
        {
            Position = position;
            Orientation = FixQuaternion.Identity;
        }

        ///<summary>
        /// Constructs a new rigid transform.
        ///</summary>
        ///<param name="orienation">Rotation component of the transform.</param>
        public RigidTransform(FixQuaternion orienation)
        {
            Position = new FixVector3();
            Orientation = orienation;
        }

        /// <summary>
        /// Gets the orientation matrix created from the orientation of the rigid transform.
        /// </summary>
        public FixMatrix4x4 OrientationMatrix
        {
            get
            {
                FixMatrix4x4 toReturn;
                FixMatrix4x4.CreateFromQuaternion(ref Orientation, out toReturn);
                return toReturn;
            }
        }
        ///<summary>
        /// Gets the 4x4 matrix created from the rigid transform.
        ///</summary>
        public FixMatrix4x4 Matrix
        {
            get
            {
                FixMatrix4x4 toReturn;
                FixMatrix4x4.CreateFromQuaternion(ref Orientation, out toReturn);
                toReturn.Translation = Position;
                return toReturn;
            }
        }



        ///<summary>
        /// Gets the identity rigid transform.
        ///</summary>
        public static RigidTransform Identity
        {
            get
            {
                var t = new RigidTransform { Orientation = FixQuaternion.Identity, Position = new FixVector3() };
                return t;
            }
        }

        /// <summary>
        /// Inverts a rigid transform.
        /// </summary>
        /// <param name="transform">Transform to invert.</param>
        /// <param name="inverse">Inverse of the transform.</param>
        public static void Invert(ref RigidTransform transform, out RigidTransform inverse)
        {
            FixQuaternion.Conjugate(ref transform.Orientation, out inverse.Orientation);
            FixQuaternion.Transform(ref transform.Position, ref inverse.Orientation, out inverse.Position);
            FixVector3.Negate(ref inverse.Position, out inverse.Position);
        }

        ///<summary>
        /// Concatenates a rigid transform with another rigid transform.
        ///</summary>
        ///<param name="a">The first rigid transform.</param>
        ///<param name="b">The second rigid transform.</param>
        ///<param name="combined">Concatenated rigid transform.</param>
        public static void Multiply(ref RigidTransform a, ref RigidTransform b, out RigidTransform combined)
        {
            FixVector3 intermediate;
            FixQuaternion.Transform(ref a.Position, ref b.Orientation, out intermediate);
            FixVector3.Add(ref intermediate, ref b.Position, out combined.Position);
            FixQuaternion.Concatenate(ref a.Orientation, ref b.Orientation, out combined.Orientation);

        }

        ///<summary>
        /// Concatenates a rigid transform with another rigid transform's inverse.
        ///</summary>
        ///<param name="a">The first rigid transform.</param>
        ///<param name="b">The second rigid transform whose inverse will be concatenated to the first.</param>
        ///<param name="combinedTransform">Combined rigid transform.</param>
        public static void MultiplyByInverse(ref RigidTransform a, ref RigidTransform b, out RigidTransform combinedTransform)
        {
            Invert(ref b, out combinedTransform);
            Multiply(ref a, ref combinedTransform, out combinedTransform);
        }

        ///<summary>
        /// Transforms a position by a rigid transform.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to apply.</param>
        ///<param name="result">Transformed position.</param>
        public static void Transform(ref FixVector3 position, ref RigidTransform transform, out FixVector3 result)
        {
            FixVector3 intermediate;
            FixQuaternion.Transform(ref position, ref transform.Orientation, out intermediate);
            FixVector3.Add(ref intermediate, ref transform.Position, out result);
        }


        ///<summary>
        /// Transforms a position by a rigid transform's inverse.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to invert and apply.</param>
        ///<param name="result">Transformed position.</param>
        public static void TransformByInverse(ref FixVector3 position, ref RigidTransform transform, out FixVector3 result)
        {
            FixQuaternion orientation;
            FixVector3 intermediate;
            FixVector3.Subtract(ref position, ref transform.Position, out intermediate);
            FixQuaternion.Conjugate(ref transform.Orientation, out orientation);
            FixQuaternion.Transform(ref intermediate, ref orientation, out result);
        }


    }
}
