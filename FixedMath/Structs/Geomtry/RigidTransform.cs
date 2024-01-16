/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/RigidTransform.cs
*/

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
                FixMatrix4x4.CreateFromQuaternion(in Orientation, out toReturn);
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
                FixMatrix4x4.CreateFromQuaternion(in Orientation, out toReturn);
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
        public static void Invert(in RigidTransform transform, out RigidTransform inverse)
        {
            FixQuaternion.Conjugate(in transform.Orientation, out inverse.Orientation);
            FixQuaternion.Transform(in transform.Position, in inverse.Orientation, out inverse.Position);
            FixVector3.Negate(in inverse.Position, out inverse.Position);
        }

        ///<summary>
        /// Concatenates a rigid transform with another rigid transform.
        ///</summary>
        ///<param name="a">The first rigid transform.</param>
        ///<param name="b">The second rigid transform.</param>
        ///<param name="combined">Concatenated rigid transform.</param>
        public static void Multiply(in RigidTransform a, in RigidTransform b, out RigidTransform combined)
        {
            FixVector3 intermediate;
            FixQuaternion.Transform(in a.Position, in b.Orientation, out intermediate);
            FixVector3.Add(in intermediate, in b.Position, out combined.Position);
            FixQuaternion.Concatenate(in a.Orientation, in b.Orientation, out combined.Orientation);

        }

        ///<summary>
        /// Concatenates a rigid transform with another rigid transform's inverse.
        ///</summary>
        ///<param name="a">The first rigid transform.</param>
        ///<param name="b">The second rigid transform whose inverse will be concatenated to the first.</param>
        ///<param name="combinedTransform">Combined rigid transform.</param>
        public static void MultiplyByInverse(in RigidTransform a, in RigidTransform b, out RigidTransform combinedTransform)
        {
            Invert(in b, out combinedTransform);
            Multiply(in a, in combinedTransform, out combinedTransform);
        }

        ///<summary>
        /// Transforms a position by a rigid transform.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to apply.</param>
        ///<param name="result">Transformed position.</param>
        public static void Transform(in FixVector3 position, in RigidTransform transform, out FixVector3 result)
        {
            FixVector3 intermediate;
            FixQuaternion.Transform(in position, in transform.Orientation, out intermediate);
            FixVector3.Add(in intermediate, in transform.Position, out result);
        }


        ///<summary>
        /// Transforms a position by a rigid transform's inverse.
        ///</summary>
        ///<param name="position">Position to transform.</param>
        ///<param name="transform">Transform to invert and apply.</param>
        ///<param name="result">Transformed position.</param>
        public static void TransformByInverse(in FixVector3 position, in RigidTransform transform, out FixVector3 result)
        {
            FixQuaternion orientation;
            FixVector3 intermediate;
            FixVector3.Subtract(in position, in transform.Position, out intermediate);
            FixQuaternion.Conjugate(in transform.Orientation, out orientation);
            FixQuaternion.Transform(in intermediate, in orientation, out result);
        }


    }
}
