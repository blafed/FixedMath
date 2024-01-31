/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/Quaternion.cs
*/
using System;

namespace FixedMath
{
    /// <summary>
    /// Provides XNA-like quaternion support.
    /// </summary>
    public struct FixQuaternion : IEquatable<FixQuaternion>
    {
        /// <summary>
        /// X component of the quaternion.
        /// </summary>
        public Fix64 x;

        /// <summary>
        /// Y component of the quaternion.
        /// </summary>
        public Fix64 y;

        /// <summary>
        /// Z component of the quaternion.
        /// </summary>
        public Fix64 z;

        /// <summary>
        /// W component of the quaternion.
        /// </summary>
        public Fix64 w;

        /// <summary>
        /// Constructs a new Quaternion.
        /// </summary>
        /// <param name="x">X component of the quaternion.</param>
        /// <param name="y">Y component of the quaternion.</param>
        /// <param name="z">Z component of the quaternion.</param>
        /// <param name="w">W component of the quaternion.</param>
        public FixQuaternion(Fix64 x, Fix64 y, Fix64 z, Fix64 w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Adds two quaternions together.
        /// </summary>
        /// <param name="a">First quaternion to add.</param>
        /// <param name="b">Second quaternion to add.</param>
        /// <param name="result">Sum of the addition.</param>
        public static void Add(in FixQuaternion a, in FixQuaternion b, out FixQuaternion result)
        {
            result.x = a.x + b.x;
            result.y = a.y + b.y;
            result.z = a.z + b.z;
            result.w = a.w + b.w;
        }

        /// <summary>
        /// Multiplies two quaternions.
        /// </summary>
        /// <param name="a">First quaternion to multiply.</param>
        /// <param name="b">Second quaternion to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(in FixQuaternion a, in FixQuaternion b, out FixQuaternion result)
        {
            Fix64 x = a.x;
            Fix64 y = a.y;
            Fix64 z = a.z;
            Fix64 w = a.w;
            Fix64 bX = b.x;
            Fix64 bY = b.y;
            Fix64 bZ = b.z;
            Fix64 bW = b.w;
            result.x = x * bW + bX * w + y * bZ - z * bY;
            result.y = y * bW + bY * w + z * bX - x * bZ;
            result.z = z * bW + bZ * w + x * bY - y * bX;
            result.w = w * bW - x * bX - y * bY - z * bZ;
        }

        /// <summary>
        /// Scales a quaternion.
        /// </summary>
        /// <param name="q">Quaternion to multiply.</param>
        /// <param name="scale">Amount to multiply each component of the quaternion by.</param>
        /// <param name="result">Scaled quaternion.</param>
        public static void Multiply(in FixQuaternion q, Fix64 scale, out FixQuaternion result)
        {
            result.x = q.x * scale;
            result.y = q.y * scale;
            result.z = q.z * scale;
            result.w = q.w * scale;
        }

        /// <summary>
        /// Multiplies two quaternions together in opposite order.
        /// </summary>
        /// <param name="a">First quaternion to multiply.</param>
        /// <param name="b">Second quaternion to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Concatenate(in FixQuaternion a, in FixQuaternion b, out FixQuaternion result)
        {
            Fix64 aX = a.x;
            Fix64 aY = a.y;
            Fix64 aZ = a.z;
            Fix64 aW = a.w;
            Fix64 bX = b.x;
            Fix64 bY = b.y;
            Fix64 bZ = b.z;
            Fix64 bW = b.w;

            result.x = aW * bX + aX * bW + aZ * bY - aY * bZ;
            result.y = aW * bY + aY * bW + aX * bZ - aZ * bX;
            result.z = aW * bZ + aZ * bW + aY * bX - aX * bY;
            result.w = aW * bW - aX * bX - aY * bY - aZ * bZ;


        }

        /// <summary>
        /// Multiplies two quaternions together in opposite order.
        /// </summary>
        /// <param name="a">First quaternion to multiply.</param>
        /// <param name="b">Second quaternion to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixQuaternion Concatenate(FixQuaternion a, FixQuaternion b)
        {
            FixQuaternion result;
            Concatenate(in a, in b, out result);
            return result;
        }

        /// <summary>
        /// Quaternion representing the identity transform.
        /// </summary>
        public static FixQuaternion Identity
        {
            get
            {
                return new FixQuaternion(F64.C0, F64.C0, F64.C0, F64.C1);
            }
        }




        /// <summary>
        /// Constructs a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="r">Rotation matrix to create the quaternion from.</param>
        /// <param name="q">Quaternion based on the rotation matrix.</param>
        public static void CreateFromRotationMatrix(in FixMatrix3x3 r, out FixQuaternion q)
        {
            Fix64 trace = r.m11 + r.m22 + r.m33;
#if !WINDOWS
            q = new FixQuaternion();
#endif
            if (trace >= F64.C0)
            {
                var S = Fix64.Sqrt(trace + F64.C1) * F64.C2; // S=4*qw 
                var inverseS = F64.C1 / S;
                q.w = F64.C0p25 * S;
                q.x = (r.m23 - r.m32) * inverseS;
                q.y = (r.m31 - r.m13) * inverseS;
                q.z = (r.m12 - r.m21) * inverseS;
            }
            else if ((r.m11 > r.m22) & (r.m11 > r.m33))
            {
                var S = Fix64.Sqrt(F64.C1 + r.m11 - r.m22 - r.m33) * F64.C2; // S=4*qx 
                var inverseS = F64.C1 / S;
                q.w = (r.m23 - r.m32) * inverseS;
                q.x = F64.C0p25 * S;
                q.y = (r.m21 + r.m12) * inverseS;
                q.z = (r.m31 + r.m13) * inverseS;
            }
            else if (r.m22 > r.m33)
            {
                var S = Fix64.Sqrt(F64.C1 + r.m22 - r.m11 - r.m33) * F64.C2; // S=4*qy
                var inverseS = F64.C1 / S;
                q.w = (r.m31 - r.m13) * inverseS;
                q.x = (r.m21 + r.m12) * inverseS;
                q.y = F64.C0p25 * S;
                q.z = (r.m32 + r.m23) * inverseS;
            }
            else
            {
                var S = Fix64.Sqrt(F64.C1 + r.m33 - r.m11 - r.m22) * F64.C2; // S=4*qz
                var inverseS = F64.C1 / S;
                q.w = (r.m12 - r.m21) * inverseS;
                q.x = (r.m31 + r.m13) * inverseS;
                q.y = (r.m32 + r.m23) * inverseS;
                q.z = F64.C0p25 * S;
            }
        }

        /// <summary>
        /// Creates a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="r">Rotation matrix used to create a new quaternion.</param>
        /// <returns>Quaternion representing the same rotation as the matrix.</returns>
        public static FixQuaternion CreateFromRotationMatrix(FixMatrix3x3 r)
        {
            FixQuaternion toReturn;
            CreateFromRotationMatrix(in r, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Constructs a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="r">Rotation matrix to create the quaternion from.</param>
        /// <param name="q">Quaternion based on the rotation matrix.</param>
        public static void CreateFromRotationMatrix(in FixMatrix4x4 r, out FixQuaternion q)
        {
            FixMatrix3x3 downsizedMatrix;
            FixMatrix3x3.CreateFromMatrix(in r, out downsizedMatrix);
            CreateFromRotationMatrix(in downsizedMatrix, out q);
        }

        /// <summary>
        /// Creates a quaternion from a rotation matrix.
        /// </summary>
        /// <param name="r">Rotation matrix used to create a new quaternion.</param>
        /// <returns>Quaternion representing the same rotation as the matrix.</returns>
        public static FixQuaternion CreateFromRotationMatrix(FixMatrix4x4 r)
        {
            FixQuaternion toReturn;
            CreateFromRotationMatrix(in r, out toReturn);
            return toReturn;
        }


        /// <summary>
        /// Ensures the quaternion has unit length.
        /// </summary>
        /// <param name="quaternion">Quaternion to normalize.</param>
        /// <returns>Normalized quaternion.</returns>
        public static FixQuaternion Normalize(FixQuaternion quaternion)
        {
            FixQuaternion toReturn;
            Normalize(in quaternion, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Ensures the quaternion has unit length.
        /// </summary>
        /// <param name="quaternion">Quaternion to normalize.</param>
        /// <param name="toReturn">Normalized quaternion.</param>
        public static void Normalize(in FixQuaternion quaternion, out FixQuaternion toReturn)
        {
            Fix64 inverse = F64.C1 / Fix64.Sqrt(quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w);
            toReturn.x = quaternion.x * inverse;
            toReturn.y = quaternion.y * inverse;
            toReturn.z = quaternion.z * inverse;
            toReturn.w = quaternion.w * inverse;
        }

        /// <summary>
        /// Scales the quaternion such that it has unit length.
        /// </summary>
        public void Normalize()
        {
            Fix64 inverse = F64.C1 / Fix64.Sqrt(x * x + y * y + z * z + w * w);
            x *= inverse;
            y *= inverse;
            z *= inverse;
            w *= inverse;
        }

        /// <summary>
        /// Computes the squared length of the quaternion.
        /// </summary>
        /// <returns>Squared length of the quaternion.</returns>
        public Fix64 LengthSquared()
        {
            return x * x + y * y + z * z + w * w;
        }

        /// <summary>
        /// Computes the length of the quaternion.
        /// </summary>
        /// <returns>Length of the quaternion.</returns>
        public Fix64 Length()
        {
            return Fix64.Sqrt(x * x + y * y + z * z + w * w);
        }


        /// <summary>
        /// Blends two quaternions together to get an intermediate state.
        /// </summary>
        /// <param name="start">Starting point of the interpolation.</param>
        /// <param name="end">Ending point of the interpolation.</param>
        /// <param name="interpolationAmount">Amount of the end point to use.</param>
        /// <param name="result">Interpolated intermediate quaternion.</param>
        public static void Slerp(in FixQuaternion start, FixQuaternion end, Fix64 interpolationAmount, out FixQuaternion result)
        {
            Fix64 cosHalfTheta = start.w * end.w + start.x * end.x + start.y * end.y + start.z * end.z;
            if (cosHalfTheta < F64.C0)
            {
                //Negating a quaternion results in the same orientation, 
                //but we need cosHalfTheta to be positive to get the shortest path.
                end.x = -end.x;
                end.y = -end.y;
                end.z = -end.z;
                end.w = -end.w;
                cosHalfTheta = -cosHalfTheta;
            }
            // If the orientations are similar enough, then just pick one of the inputs.
            if (cosHalfTheta > F64.C1m1em12)
            {
                result.w = start.w;
                result.x = start.x;
                result.y = start.y;
                result.z = start.z;
                return;
            }
            // Calculate temporary values.
            Fix64 halfTheta = Fix64.Acos(cosHalfTheta);
            Fix64 sinHalfTheta = Fix64.Sqrt(F64.C1 - cosHalfTheta * cosHalfTheta);

            Fix64 aFraction = Fix64.Sin((F64.C1 - interpolationAmount) * halfTheta) / sinHalfTheta;
            Fix64 bFraction = Fix64.Sin(interpolationAmount * halfTheta) / sinHalfTheta;

            //Blend the two quaternions to get the result!
            result.x = (Fix64)(start.x * aFraction + end.x * bFraction);
            result.y = (Fix64)(start.y * aFraction + end.y * bFraction);
            result.z = (Fix64)(start.z * aFraction + end.z * bFraction);
            result.w = (Fix64)(start.w * aFraction + end.w * bFraction);




        }

        /// <summary>
        /// Blends two quaternions together to get an intermediate state.
        /// </summary>
        /// <param name="start">Starting point of the interpolation.</param>
        /// <param name="end">Ending point of the interpolation.</param>
        /// <param name="interpolationAmount">Amount of the end point to use.</param>
        /// <returns>Interpolated intermediate quaternion.</returns>
        public static FixQuaternion Slerp(FixQuaternion start, FixQuaternion end, Fix64 interpolationAmount)
        {
            FixQuaternion toReturn;
            Slerp(in start, end, interpolationAmount, out toReturn);
            return toReturn;
        }


        /// <summary>
        /// Computes the conjugate of the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to conjugate.</param>
        /// <param name="result">Conjugated quaternion.</param>
        public static void Conjugate(in FixQuaternion quaternion, out FixQuaternion result)
        {
            result.x = -quaternion.x;
            result.y = -quaternion.y;
            result.z = -quaternion.z;
            result.w = quaternion.w;
        }

        /// <summary>
        /// Computes the conjugate of the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to conjugate.</param>
        /// <returns>Conjugated quaternion.</returns>
        public static FixQuaternion Conjugate(FixQuaternion quaternion)
        {
            FixQuaternion toReturn;
            Conjugate(in quaternion, out toReturn);
            return toReturn;
        }



        /// <summary>
        /// Computes the inverse of the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to invert.</param>
        /// <param name="result">Result of the inversion.</param>
        public static void Inverse(in FixQuaternion quaternion, out FixQuaternion result)
        {
            Fix64 inverseSquaredNorm = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
            result.x = -quaternion.x * inverseSquaredNorm;
            result.y = -quaternion.y * inverseSquaredNorm;
            result.z = -quaternion.z * inverseSquaredNorm;
            result.w = quaternion.w * inverseSquaredNorm;
        }

        /// <summary>
        /// Computes the inverse of the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to invert.</param>
        /// <returns>Result of the inversion.</returns>
        public static FixQuaternion Inverse(FixQuaternion quaternion)
        {
            FixQuaternion result;
            Inverse(in quaternion, out result);
            return result;

        }

        /// <summary>
        /// Tests components for equality.
        /// </summary>
        /// <param name="a">First quaternion to test for equivalence.</param>
        /// <param name="b">Second quaternion to test for equivalence.</param>
        /// <returns>Whether or not the quaternions' components were equal.</returns>
        public static bool operator ==(FixQuaternion a, FixQuaternion b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        }

        /// <summary>
        /// Tests components for inequality.
        /// </summary>
        /// <param name="a">First quaternion to test for equivalence.</param>
        /// <param name="b">Second quaternion to test for equivalence.</param>
        /// <returns>Whether the quaternions' components were not equal.</returns>
        public static bool operator !=(FixQuaternion a, FixQuaternion b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        }

        /// <summary>
        /// Negates the components of a quaternion.
        /// </summary>
        /// <param name="a">Quaternion to negate.</param>
        /// <param name="b">Negated result.</param>
        public static void Negate(in FixQuaternion a, out FixQuaternion b)
        {
            b.x = -a.x;
            b.y = -a.y;
            b.z = -a.z;
            b.w = -a.w;
        }

        /// <summary>
        /// Negates the components of a quaternion.
        /// </summary>
        /// <param name="q">Quaternion to negate.</param>
        /// <returns>Negated result.</returns>
        public static FixQuaternion Negate(FixQuaternion q)
        {
            Negate(in q, out var result);
            return result;
        }

        /// <summary>
        /// Negates the components of a quaternion.
        /// </summary>
        /// <param name="q">Quaternion to negate.</param>
        /// <returns>Negated result.</returns>
        public static FixQuaternion operator -(FixQuaternion q)
        {
            Negate(in q, out var result);
            return result;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(FixQuaternion other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj is FixQuaternion)
            {
                return Equals((FixQuaternion)obj);
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode() + z.GetHashCode() + w.GetHashCode();
        }

        /// <summary>
        /// Transforms the vector using a quaternion.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void Transform(in FixVector3 v, in FixQuaternion rotation, out FixVector3 result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            Fix64 x2 = rotation.x + rotation.x;
            Fix64 y2 = rotation.y + rotation.y;
            Fix64 z2 = rotation.z + rotation.z;
            Fix64 xx2 = rotation.x * x2;
            Fix64 xy2 = rotation.x * y2;
            Fix64 xz2 = rotation.x * z2;
            Fix64 yy2 = rotation.y * y2;
            Fix64 yz2 = rotation.y * z2;
            Fix64 zz2 = rotation.z * z2;
            Fix64 wx2 = rotation.w * x2;
            Fix64 wy2 = rotation.w * y2;
            Fix64 wz2 = rotation.w * z2;
            //Defer the component setting since they're used in computation.
            Fix64 transformedX = v.x * (F64.C1 - yy2 - zz2) + v.y * (xy2 - wz2) + v.z * (xz2 + wy2);
            Fix64 transformedY = v.x * (xy2 + wz2) + v.y * (F64.C1 - xx2 - zz2) + v.z * (yz2 - wx2);
            Fix64 transformedZ = v.x * (xz2 - wy2) + v.y * (yz2 + wx2) + v.z * (F64.C1 - xx2 - yy2);
            result.x = transformedX;
            result.y = transformedY;
            result.z = transformedZ;

        }

        /// <summary>
        /// Transforms the vector using a quaternion.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector3 Transform(FixVector3 v, FixQuaternion rotation)
        {
            FixVector3 toReturn;
            Transform(in v, in rotation, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using a quaternion. Specialized for x,0,0 vectors.
        /// </summary>
        /// <param name="x">X component of the vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformX(Fix64 x, in FixQuaternion rotation, out FixVector3 result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            Fix64 y2 = rotation.y + rotation.y;
            Fix64 z2 = rotation.z + rotation.z;
            Fix64 xy2 = rotation.x * y2;
            Fix64 xz2 = rotation.x * z2;
            Fix64 yy2 = rotation.y * y2;
            Fix64 zz2 = rotation.z * z2;
            Fix64 wy2 = rotation.w * y2;
            Fix64 wz2 = rotation.w * z2;
            //Defer the component setting since they're used in computation.
            Fix64 transformedX = x * (F64.C1 - yy2 - zz2);
            Fix64 transformedY = x * (xy2 + wz2);
            Fix64 transformedZ = x * (xz2 - wy2);
            result.x = transformedX;
            result.y = transformedY;
            result.z = transformedZ;

        }

        /// <summary>
        /// Transforms a vector using a quaternion. Specialized for 0,y,0 vectors.
        /// </summary>
        /// <param name="y">Y component of the vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformY(Fix64 y, in FixQuaternion rotation, out FixVector3 result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            Fix64 x2 = rotation.x + rotation.x;
            Fix64 y2 = rotation.y + rotation.y;
            Fix64 z2 = rotation.z + rotation.z;
            Fix64 xx2 = rotation.x * x2;
            Fix64 xy2 = rotation.x * y2;
            Fix64 yz2 = rotation.y * z2;
            Fix64 zz2 = rotation.z * z2;
            Fix64 wx2 = rotation.w * x2;
            Fix64 wz2 = rotation.w * z2;
            //Defer the component setting since they're used in computation.
            Fix64 transformedX = y * (xy2 - wz2);
            Fix64 transformedY = y * (F64.C1 - xx2 - zz2);
            Fix64 transformedZ = y * (yz2 + wx2);
            result.x = transformedX;
            result.y = transformedY;
            result.z = transformedZ;

        }

        /// <summary>
        /// Transforms a vector using a quaternion. Specialized for 0,0,z vectors.
        /// </summary>
        /// <param name="z">Z component of the vector to transform.</param>
        /// <param name="rotation">Rotation to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformZ(Fix64 z, in FixQuaternion rotation, out FixVector3 result)
        {
            //This operation is an optimized-down version of v' = q * v * q^-1.
            //The expanded form would be to treat v as an 'axis only' quaternion
            //and perform standard quaternion multiplication.  Assuming q is normalized,
            //q^-1 can be replaced by a conjugation.
            Fix64 x2 = rotation.x + rotation.x;
            Fix64 y2 = rotation.y + rotation.y;
            Fix64 z2 = rotation.z + rotation.z;
            Fix64 xx2 = rotation.x * x2;
            Fix64 xz2 = rotation.x * z2;
            Fix64 yy2 = rotation.y * y2;
            Fix64 yz2 = rotation.y * z2;
            Fix64 wx2 = rotation.w * x2;
            Fix64 wy2 = rotation.w * y2;
            //Defer the component setting since they're used in computation.
            Fix64 transformedX = z * (xz2 + wy2);
            Fix64 transformedY = z * (yz2 - wx2);
            Fix64 transformedZ = z * (F64.C1 - xx2 - yy2);
            result.x = transformedX;
            result.y = transformedY;
            result.z = transformedZ;

        }


        /// <summary>
        /// Multiplies two quaternions.
        /// </summary>
        /// <param name="a">First quaternion to multiply.</param>
        /// <param name="b">Second quaternion to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixQuaternion operator *(FixQuaternion a, FixQuaternion b)
        {
            FixQuaternion toReturn;
            Multiply(in a, in b, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates a quaternion from an axis and angle.
        /// </summary>
        /// <param name="axis">Axis of rotation.</param>
        /// <param name="angle">Angle to rotate around the axis.</param>
        /// <returns>Quaternion representing the axis and angle rotation.</returns>
        public static FixQuaternion CreateFromAxisAngle(FixVector3 axis, Fix64 angle)
        {
            Fix64 halfAngle = angle * F64.C0p5;
            Fix64 s = Fix64.Sin(halfAngle);
            FixQuaternion q;
            q.x = axis.x * s;
            q.y = axis.y * s;
            q.z = axis.z * s;
            q.w = Fix64.Cos(halfAngle);
            return q;
        }

        /// <summary>
        /// Creates a quaternion from an axis and angle.
        /// </summary>
        /// <param name="axis">Axis of rotation.</param>
        /// <param name="angle">Angle to rotate around the axis.</param>
        /// <param name="q">Quaternion representing the axis and angle rotation.</param>
        public static void CreateFromAxisAngle(in FixVector3 axis, Fix64 angle, out FixQuaternion q)
        {
            Fix64 halfAngle = angle * F64.C0p5;
            Fix64 s = Fix64.Sin(halfAngle);
            q.x = axis.x * s;
            q.y = axis.y * s;
            q.z = axis.z * s;
            q.w = Fix64.Cos(halfAngle);
        }

        /// <summary>
        /// Constructs a quaternion from yaw, pitch, and roll.
        /// </summary>
        /// <param name="yaw">Yaw of the rotation.</param>
        /// <param name="pitch">Pitch of the rotation.</param>
        /// <param name="roll">Roll of the rotation.</param>
        /// <returns>Quaternion representing the yaw, pitch, and roll.</returns>
        public static FixQuaternion CreateFromYawPitchRoll(Fix64 yaw, Fix64 pitch, Fix64 roll)
        {
            FixQuaternion toReturn;
            CreateFromYawPitchRoll(yaw, pitch, roll, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Constructs a quaternion from yaw, pitch, and roll.
        /// </summary>
        /// <param name="yaw">Yaw of the rotation.</param>
        /// <param name="pitch">Pitch of the rotation.</param>
        /// <param name="roll">Roll of the rotation.</param>
        /// <param name="q">Quaternion representing the yaw, pitch, and roll.</param>
        public static void CreateFromYawPitchRoll(Fix64 yaw, Fix64 pitch, Fix64 roll, out FixQuaternion q)
        {
            Fix64 halfRoll = roll * F64.C0p5;
            Fix64 halfPitch = pitch * F64.C0p5;
            Fix64 halfYaw = yaw * F64.C0p5;

            Fix64 sinRoll = Fix64.Sin(halfRoll);
            Fix64 sinPitch = Fix64.Sin(halfPitch);
            Fix64 sinYaw = Fix64.Sin(halfYaw);

            Fix64 cosRoll = Fix64.Cos(halfRoll);
            Fix64 cosPitch = Fix64.Cos(halfPitch);
            Fix64 cosYaw = Fix64.Cos(halfYaw);

            Fix64 cosYawCosPitch = cosYaw * cosPitch;
            Fix64 cosYawSinPitch = cosYaw * sinPitch;
            Fix64 sinYawCosPitch = sinYaw * cosPitch;
            Fix64 sinYawSinPitch = sinYaw * sinPitch;

            q.x = cosYawSinPitch * cosRoll + sinYawCosPitch * sinRoll;
            q.y = sinYawCosPitch * cosRoll - cosYawSinPitch * sinRoll;
            q.z = cosYawCosPitch * sinRoll - sinYawSinPitch * cosRoll;
            q.w = cosYawCosPitch * cosRoll + sinYawSinPitch * sinRoll;

        }

        /// <summary>
        /// Computes the angle change represented by a normalized quaternion.
        /// </summary>
        /// <param name="q">Quaternion to be converted.</param>
        /// <returns>Angle around the axis represented by the quaternion.</returns>
        public static Fix64 GetAngleFromQuaternion(in FixQuaternion q)
        {
            Fix64 qw = Fix64.Abs(q.w);
            if (qw > F64.C1)
                return F64.C0;
            return F64.C2 * Fix64.Acos(qw);
        }

        /// <summary>
        /// Computes the axis angle representation of a normalized quaternion.
        /// </summary>
        /// <param name="q">Quaternion to be converted.</param>
        /// <param name="axis">Axis represented by the quaternion.</param>
        /// <param name="angle">Angle around the axis represented by the quaternion.</param>
        public static void GetAxisAngleFromQuaternion(in FixQuaternion q, out FixVector3 axis, out Fix64 angle)
        {
#if !WINDOWS
            axis = new FixVector3();
#endif
            Fix64 qw = q.w;
            if (qw > F64.C0)
            {
                axis.x = q.x;
                axis.y = q.y;
                axis.z = q.z;
            }
            else
            {
                axis.x = -q.x;
                axis.y = -q.y;
                axis.z = -q.z;
                qw = -qw;
            }

            Fix64 lengthSquared = axis.LengthSquared();
            if (lengthSquared > F64.C1em14)
            {
                FixVector3.Divide(in axis, Fix64.Sqrt(lengthSquared), out axis);
                angle = F64.C2 * Fix64.Acos(Fix64.Clamp(qw, -1, F64.C1));
            }
            else
            {
                axis = FixVector3.Up;
                angle = F64.C0;
            }
        }

        /// <summary>
        /// Computes the quaternion rotation between two normalized vectors.
        /// </summary>
        /// <param name="v1">First unit-length vector.</param>
        /// <param name="v2">Second unit-length vector.</param>
        /// <param name="q">Quaternion representing the rotation from v1 to v2.</param>
        public static void GetQuaternionBetweenNormalizedVectors(in FixVector3 v1, in FixVector3 v2, out FixQuaternion q)
        {
            Fix64 dot;
            FixVector3.Dot(in v1, in v2, out dot);
            //For non-normal vectors, the multiplying the axes length squared would be necessary:
            //Fix64 w = dot + (Fix64)Math.Sqrt(v1.LengthSquared() * v2.LengthSquared());
            if (dot < F64.Cm0p9999) //parallel, opposing direction
            {
                //If this occurs, the rotation required is ~180 degrees.
                //The problem is that we could choose any perpendicular axis for the rotation. It's not uniquely defined.
                //The solution is to pick an arbitrary perpendicular axis.
                //Project onto the plane which has the lowest component magnitude.
                //On that 2d plane, perform a 90 degree rotation.
                Fix64 absX = Fix64.Abs(v1.x);
                Fix64 absY = Fix64.Abs(v1.y);
                Fix64 absZ = Fix64.Abs(v1.z);
                if (absX < absY && absX < absZ)
                    q = new FixQuaternion(F64.C0, -v1.z, v1.y, F64.C0);
                else if (absY < absZ)
                    q = new FixQuaternion(-v1.z, F64.C0, v1.x, F64.C0);
                else
                    q = new FixQuaternion(-v1.y, v1.x, F64.C0, F64.C0);
            }
            else
            {
                FixVector3 axis;
                FixVector3.Cross(in v1, in v2, out axis);
                q = new FixQuaternion(axis.x, axis.y, axis.z, dot + F64.C1);
            }
            q.Normalize();
        }

        //The following two functions are highly similar, but it's a bit of a brain teaser to phrase one in terms of the other.
        //Providing both simplifies things.

        /// <summary>
        /// Computes the rotation from the start orientation to the end orientation such that end = Quaternion.Concatenate(start, relative).
        /// </summary>
        /// <param name="start">Starting orientation.</param>
        /// <param name="end">Ending orientation.</param>
        /// <param name="relative">Relative rotation from the start to the end orientation.</param>
        public static void GetRelativeRotation(in FixQuaternion start, in FixQuaternion end, out FixQuaternion relative)
        {
            FixQuaternion startInverse;
            Conjugate(in start, out startInverse);
            Concatenate(in startInverse, in end, out relative);
        }


        /// <summary>
        /// Transforms the rotation into the local space of the target basis such that rotation = Quaternion.Concatenate(localRotation, targetBasis)
        /// </summary>
        /// <param name="rotation">Rotation in the original frame of reference.</param>
        /// <param name="targetBasis">Basis in the original frame of reference to transform the rotation into.</param>
        /// <param name="localRotation">Rotation in the local space of the target basis.</param>
        public static void GetLocalRotation(in FixQuaternion rotation, in FixQuaternion targetBasis, out FixQuaternion localRotation)
        {
            FixQuaternion basisInverse;
            Conjugate(in targetBasis, out basisInverse);
            Concatenate(in rotation, in basisInverse, out localRotation);
        }

        /// <summary>
        /// Gets a string representation of the quaternion.
        /// </summary>
        /// <returns>String representing the quaternion.</returns>
        public override string ToString()
        {
            return "{ X: " + x + ", Y: " + y + ", Z: " + z + ", W: " + w + "}";
        }
    }
}
