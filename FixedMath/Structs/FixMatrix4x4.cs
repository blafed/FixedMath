
using System;

namespace FixedMath
{
    /// <summary>
    /// Provides XNA-like 4x4 matrix math.
    /// </summary>
    public struct FixMatrix4x4
    {
        /// <summary>
        /// Value at row 1, column 1 of the matrix.
        /// </summary>
        public Fix64 m11;

        /// <summary>
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public Fix64 m12;

        /// <summary>
        /// Value at row 1, column 3 of the matrix.
        /// </summary>
        public Fix64 m13;

        /// <summary>
        /// Value at row 1, column 4 of the matrix.
        /// </summary>
        public Fix64 m14;

        /// <summary>
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public Fix64 m21;

        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public Fix64 m22;

        /// <summary>
        /// Value at row 2, column 3 of the matrix.
        /// </summary>
        public Fix64 m23;

        /// <summary>
        /// Value at row 2, column 4 of the matrix.
        /// </summary>
        public Fix64 m24;

        /// <summary>
        /// Value at row 3, column 1 of the matrix.
        /// </summary>
        public Fix64 m31;

        /// <summary>
        /// Value at row 3, column 2 of the matrix.
        /// </summary>
        public Fix64 m32;

        /// <summary>
        /// Value at row 3, column 3 of the matrix.
        /// </summary>
        public Fix64 m33;

        /// <summary>
        /// Value at row 3, column 4 of the matrix.
        /// </summary>
        public Fix64 m34;

        /// <summary>
        /// Value at row 4, column 1 of the matrix.
        /// </summary>
        public Fix64 m41;

        /// <summary>
        /// Value at row 4, column 2 of the matrix.
        /// </summary>
        public Fix64 m42;

        /// <summary>
        /// Value at row 4, column 3 of the matrix.
        /// </summary>
        public Fix64 m43;

        /// <summary>
        /// Value at row 4, column 4 of the matrix.
        /// </summary>
        public Fix64 m44;

        /// <summary>
        /// Constructs a new 4 row, 4 column matrix.
        /// </summary>
        /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
        /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
        /// <param name="m13">Value at row 1, column 3 of the matrix.</param>
        /// <param name="m14">Value at row 1, column 4 of the matrix.</param>
        /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
        /// <param name="m23">Value at row 2, column 3 of the matrix.</param>
        /// <param name="m24">Value at row 2, column 4 of the matrix.</param>
        /// <param name="m31">Value at row 3, column 1 of the matrix.</param>
        /// <param name="m32">Value at row 3, column 2 of the matrix.</param>
        /// <param name="m33">Value at row 3, column 3 of the matrix.</param>
        /// <param name="m34">Value at row 3, column 4 of the matrix.</param>
        /// <param name="m41">Value at row 4, column 1 of the matrix.</param>
        /// <param name="m42">Value at row 4, column 2 of the matrix.</param>
        /// <param name="m43">Value at row 4, column 3 of the matrix.</param>
        /// <param name="m44">Value at row 4, column 4 of the matrix.</param>
        public FixMatrix4x4(Fix64 m11, Fix64 m12, Fix64 m13, Fix64 m14,
                      Fix64 m21, Fix64 m22, Fix64 m23, Fix64 m24,
                      Fix64 m31, Fix64 m32, Fix64 m33, Fix64 m34,
                      Fix64 m41, Fix64 m42, Fix64 m43, Fix64 m44)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;

            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m24 = m24;

            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
            this.m34 = m34;

            this.m41 = m41;
            this.m42 = m42;
            this.m43 = m43;
            this.m44 = m44;
        }

        /// <summary>
        /// Gets or sets the translation component of the transform.
        /// </summary>
        public FixVector3 Translation
        {
            get
            {
                return new FixVector3()
                {
                    x = m41,
                    y = m42,
                    z = m43
                };
            }
            set
            {
                m41 = value.x;
                m42 = value.y;
                m43 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the backward vector of the matrix.
        /// </summary>
        public FixVector3 Backward
        {
            get
            {
#if !WINDOWS
                FixVector3 vector = new FixVector3();
#else
                Vector3 vector;
#endif
                vector.x = m31;
                vector.y = m32;
                vector.z = m33;
                return vector;
            }
            set
            {
                m31 = value.x;
                m32 = value.y;
                m33 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the down vector of the matrix.
        /// </summary>
        public FixVector3 Down
        {
            get
            {
#if !WINDOWS
                FixVector3 vector = new FixVector3();
#else
                Vector3 vector;
#endif
                vector.x = -m21;
                vector.y = -m22;
                vector.z = -m23;
                return vector;
            }
            set
            {
                m21 = -value.x;
                m22 = -value.y;
                m23 = -value.z;
            }
        }

        /// <summary>
        /// Gets or sets the forward vector of the matrix.
        /// </summary>
        public FixVector3 Forward
        {
            get
            {
#if !WINDOWS
                FixVector3 vector = new FixVector3();
#else
                Vector3 vector;
#endif
                vector.x = -m31;
                vector.y = -m32;
                vector.z = -m33;
                return vector;
            }
            set
            {
                m31 = -value.x;
                m32 = -value.y;
                m33 = -value.z;
            }
        }

        /// <summary>
        /// Gets or sets the left vector of the matrix.
        /// </summary>
        public FixVector3 Left
        {
            get
            {
#if !WINDOWS
                FixVector3 vector = new FixVector3();
#else
                Vector3 vector;
#endif
                vector.x = -m11;
                vector.y = -m12;
                vector.z = -m13;
                return vector;
            }
            set
            {
                m11 = -value.x;
                m12 = -value.y;
                m13 = -value.z;
            }
        }

        /// <summary>
        /// Gets or sets the right vector of the matrix.
        /// </summary>
        public FixVector3 Right
        {
            get
            {
#if !WINDOWS
                FixVector3 vector = new FixVector3();
#else
                Vector3 vector;
#endif
                vector.x = m11;
                vector.y = m12;
                vector.z = m13;
                return vector;
            }
            set
            {
                m11 = value.x;
                m12 = value.y;
                m13 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the up vector of the matrix.
        /// </summary>
        public FixVector3 Up
        {
            get
            {
#if !WINDOWS
                FixVector3 vector = new FixVector3();
#else
                Vector3 vector;
#endif
                vector.x = m21;
                vector.y = m22;
                vector.z = m23;
                return vector;
            }
            set
            {
                m21 = value.x;
                m22 = value.y;
                m23 = value.z;
            }
        }


        /// <summary>
        /// Computes the determinant of the matrix.
        /// </summary>
        /// <returns></returns>
        public Fix64 Determinant()
        {
            //Compute the re-used 2x2 determinants.
            Fix64 det1 = m33 * m44 - m34 * m43;
            Fix64 det2 = m32 * m44 - m34 * m42;
            Fix64 det3 = m32 * m43 - m33 * m42;
            Fix64 det4 = m31 * m44 - m34 * m41;
            Fix64 det5 = m31 * m43 - m33 * m41;
            Fix64 det6 = m31 * m42 - m32 * m41;
            return
                (m11 * ((m22 * det1 - m23 * det2) + m24 * det3)) -
                (m12 * ((m21 * det1 - m23 * det4) + m24 * det5)) +
                (m13 * ((m21 * det2 - m22 * det4) + m24 * det6)) -
                (m14 * ((m21 * det3 - m22 * det5) + m23 * det6));
        }

        /// <summary>
        /// Transposes the matrix in-place.
        /// </summary>
        public void Transpose()
        {
            Fix64 intermediate = m12;
            m12 = m21;
            m21 = intermediate;

            intermediate = m13;
            m13 = m31;
            m31 = intermediate;

            intermediate = m14;
            m14 = m41;
            m41 = intermediate;

            intermediate = m23;
            m23 = m32;
            m32 = intermediate;

            intermediate = m24;
            m24 = m42;
            m42 = intermediate;

            intermediate = m34;
            m34 = m43;
            m43 = intermediate;
        }

        /// <summary>
        /// Creates a matrix representing the given axis and angle rotation.
        /// </summary>
        /// <param name="axis">Axis around which to rotate.</param>
        /// <param name="angle">Angle to rotate around the axis.</param>
        /// <returns>Matrix created from the axis and angle.</returns>
        public static FixMatrix4x4 CreateFromAxisAngle(FixVector3 axis, Fix64 angle)
        {
            FixMatrix4x4 toReturn;
            CreateFromAxisAngle(ref axis, angle, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates a matrix representing the given axis and angle rotation.
        /// </summary>
        /// <param name="axis">Axis around which to rotate.</param>
        /// <param name="angle">Angle to rotate around the axis.</param>
        /// <param name="result">Matrix created from the axis and angle.</param>
        public static void CreateFromAxisAngle(ref FixVector3 axis, Fix64 angle, out FixMatrix4x4 result)
        {
            Fix64 xx = axis.x * axis.x;
            Fix64 yy = axis.y * axis.y;
            Fix64 zz = axis.z * axis.z;
            Fix64 xy = axis.x * axis.y;
            Fix64 xz = axis.x * axis.z;
            Fix64 yz = axis.y * axis.z;

            Fix64 sinAngle = Fix64.Sin(angle);
            Fix64 oneMinusCosAngle = F64.C1 - Fix64.Cos(angle);

            result.m11 = F64.C1 + oneMinusCosAngle * (xx - F64.C1);
            result.m21 = -axis.z * sinAngle + oneMinusCosAngle * xy;
            result.m31 = axis.y * sinAngle + oneMinusCosAngle * xz;
            result.m41 = F64.C0;

            result.m12 = axis.z * sinAngle + oneMinusCosAngle * xy;
            result.m22 = F64.C1 + oneMinusCosAngle * (yy - F64.C1);
            result.m32 = -axis.x * sinAngle + oneMinusCosAngle * yz;
            result.m42 = F64.C0;

            result.m13 = -axis.y * sinAngle + oneMinusCosAngle * xz;
            result.m23 = axis.x * sinAngle + oneMinusCosAngle * yz;
            result.m33 = F64.C1 + oneMinusCosAngle * (zz - F64.C1);
            result.m43 = F64.C0;

            result.m14 = F64.C0;
            result.m24 = F64.C0;
            result.m34 = F64.C0;
            result.m44 = F64.C1;
        }

        /// <summary>
        /// Creates a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to convert.</param>
        /// <param name="result">Rotation matrix created from the quaternion.</param>
        public static void CreateFromQuaternion(ref FixQuaternion quaternion, out FixMatrix4x4 result)
        {
            Fix64 qX2 = quaternion.x + quaternion.x;
            Fix64 qY2 = quaternion.y + quaternion.y;
            Fix64 qZ2 = quaternion.z + quaternion.z;
            Fix64 XX = qX2 * quaternion.x;
            Fix64 YY = qY2 * quaternion.y;
            Fix64 ZZ = qZ2 * quaternion.z;
            Fix64 XY = qX2 * quaternion.y;
            Fix64 XZ = qX2 * quaternion.z;
            Fix64 XW = qX2 * quaternion.w;
            Fix64 YZ = qY2 * quaternion.z;
            Fix64 YW = qY2 * quaternion.w;
            Fix64 ZW = qZ2 * quaternion.w;

            result.m11 = F64.C1 - YY - ZZ;
            result.m21 = XY - ZW;
            result.m31 = XZ + YW;
            result.m41 = F64.C0;

            result.m12 = XY + ZW;
            result.m22 = F64.C1 - XX - ZZ;
            result.m32 = YZ - XW;
            result.m42 = F64.C0;

            result.m13 = XZ - YW;
            result.m23 = YZ + XW;
            result.m33 = F64.C1 - XX - YY;
            result.m43 = F64.C0;

            result.m14 = F64.C0;
            result.m24 = F64.C0;
            result.m34 = F64.C0;
            result.m44 = F64.C1;
        }

        /// <summary>
        /// Creates a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to convert.</param>
        /// <returns>Rotation matrix created from the quaternion.</returns>
        public static FixMatrix4x4 CreateFromQuaternion(FixQuaternion quaternion)
        {
            FixMatrix4x4 toReturn;
            CreateFromQuaternion(ref quaternion, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Multiplies two matrices together.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Combined transformation.</param>
        public static void Multiply(ref FixMatrix4x4 a, ref FixMatrix4x4 b, out FixMatrix4x4 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31 + a.m14 * b.m41;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32 + a.m14 * b.m42;
            Fix64 resultM13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33 + a.m14 * b.m43;
            Fix64 resultM14 = a.m11 * b.m14 + a.m12 * b.m24 + a.m13 * b.m34 + a.m14 * b.m44;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31 + a.m24 * b.m41;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32 + a.m24 * b.m42;
            Fix64 resultM23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33 + a.m24 * b.m43;
            Fix64 resultM24 = a.m21 * b.m14 + a.m22 * b.m24 + a.m23 * b.m34 + a.m24 * b.m44;

            Fix64 resultM31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31 + a.m34 * b.m41;
            Fix64 resultM32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32 + a.m34 * b.m42;
            Fix64 resultM33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33 + a.m34 * b.m43;
            Fix64 resultM34 = a.m31 * b.m14 + a.m32 * b.m24 + a.m33 * b.m34 + a.m34 * b.m44;

            Fix64 resultM41 = a.m41 * b.m11 + a.m42 * b.m21 + a.m43 * b.m31 + a.m44 * b.m41;
            Fix64 resultM42 = a.m41 * b.m12 + a.m42 * b.m22 + a.m43 * b.m32 + a.m44 * b.m42;
            Fix64 resultM43 = a.m41 * b.m13 + a.m42 * b.m23 + a.m43 * b.m33 + a.m44 * b.m43;
            Fix64 resultM44 = a.m41 * b.m14 + a.m42 * b.m24 + a.m43 * b.m34 + a.m44 * b.m44;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;
            result.m14 = resultM14;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;
            result.m24 = resultM24;

            result.m31 = resultM31;
            result.m32 = resultM32;
            result.m33 = resultM33;
            result.m34 = resultM34;

            result.m41 = resultM41;
            result.m42 = resultM42;
            result.m43 = resultM43;
            result.m44 = resultM44;
        }


        /// <summary>
        /// Multiplies two matrices together.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <returns>Combined transformation.</returns>
        public static FixMatrix4x4 Multiply(FixMatrix4x4 a, FixMatrix4x4 b)
        {
            FixMatrix4x4 result;
            Multiply(ref a, ref b, out result);
            return result;
        }


        /// <summary>
        /// Scales all components of the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to scale.</param>
        /// <param name="scale">Amount to scale.</param>
        /// <param name="result">Scaled matrix.</param>
        public static void Multiply(ref FixMatrix4x4 matrix, Fix64 scale, out FixMatrix4x4 result)
        {
            result.m11 = matrix.m11 * scale;
            result.m12 = matrix.m12 * scale;
            result.m13 = matrix.m13 * scale;
            result.m14 = matrix.m14 * scale;

            result.m21 = matrix.m21 * scale;
            result.m22 = matrix.m22 * scale;
            result.m23 = matrix.m23 * scale;
            result.m24 = matrix.m24 * scale;

            result.m31 = matrix.m31 * scale;
            result.m32 = matrix.m32 * scale;
            result.m33 = matrix.m33 * scale;
            result.m34 = matrix.m34 * scale;

            result.m41 = matrix.m41 * scale;
            result.m42 = matrix.m42 * scale;
            result.m43 = matrix.m43 * scale;
            result.m44 = matrix.m44 * scale;
        }

        /// <summary>
        /// Multiplies two matrices together.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <returns>Combined transformation.</returns>
        public static FixMatrix4x4 operator *(FixMatrix4x4 a, FixMatrix4x4 b)
        {
            FixMatrix4x4 toReturn;
            Multiply(ref a, ref b, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Scales all components of the matrix by the given value.
        /// </summary>
        /// <param name="m">First matrix to multiply.</param>
        /// <param name="f">Scaling value to apply to all components of the matrix.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixMatrix4x4 operator *(FixMatrix4x4 m, Fix64 f)
        {
            FixMatrix4x4 result;
            Multiply(ref m, f, out result);
            return result;
        }

        /// <summary>
        /// Scales all components of the matrix by the given value.
        /// </summary>
        /// <param name="m">First matrix to multiply.</param>
        /// <param name="f">Scaling value to apply to all components of the matrix.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixMatrix4x4 operator *(Fix64 f, FixMatrix4x4 m)
        {
            FixMatrix4x4 result;
            Multiply(ref m, f, out result);
            return result;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void Transform(ref FixVector4 v, ref FixMatrix4x4 matrix, out FixVector4 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            Fix64 vW = v.w;
            result.x = vX * matrix.m11 + vY * matrix.m21 + vZ * matrix.m31 + vW * matrix.m41;
            result.y = vX * matrix.m12 + vY * matrix.m22 + vZ * matrix.m32 + vW * matrix.m42;
            result.z = vX * matrix.m13 + vY * matrix.m23 + vZ * matrix.m33 + vW * matrix.m43;
            result.w = vX * matrix.m14 + vY * matrix.m24 + vZ * matrix.m34 + vW * matrix.m44;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector4 Transform(FixVector4 v, FixMatrix4x4 matrix)
        {
            FixVector4 toReturn;
            Transform(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformTranspose(ref FixVector4 v, ref FixMatrix4x4 matrix, out FixVector4 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            Fix64 vW = v.w;
            result.x = vX * matrix.m11 + vY * matrix.m12 + vZ * matrix.m13 + vW * matrix.m14;
            result.y = vX * matrix.m21 + vY * matrix.m22 + vZ * matrix.m23 + vW * matrix.m24;
            result.z = vX * matrix.m31 + vY * matrix.m32 + vZ * matrix.m33 + vW * matrix.m34;
            result.w = vX * matrix.m41 + vY * matrix.m42 + vZ * matrix.m43 + vW * matrix.m44;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector4 TransformTranspose(FixVector4 v, FixMatrix4x4 matrix)
        {
            FixVector4 toReturn;
            TransformTranspose(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void Transform(ref FixVector3 v, ref FixMatrix4x4 matrix, out FixVector4 result)
        {
            result.x = v.x * matrix.m11 + v.y * matrix.m21 + v.z * matrix.m31 + matrix.m41;
            result.y = v.x * matrix.m12 + v.y * matrix.m22 + v.z * matrix.m32 + matrix.m42;
            result.z = v.x * matrix.m13 + v.y * matrix.m23 + v.z * matrix.m33 + matrix.m43;
            result.w = v.x * matrix.m14 + v.y * matrix.m24 + v.z * matrix.m34 + matrix.m44;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector4 Transform(FixVector3 v, FixMatrix4x4 matrix)
        {
            FixVector4 toReturn;
            Transform(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformTranspose(ref FixVector3 v, ref FixMatrix4x4 matrix, out FixVector4 result)
        {
            result.x = v.x * matrix.m11 + v.y * matrix.m12 + v.z * matrix.m13 + matrix.m14;
            result.y = v.x * matrix.m21 + v.y * matrix.m22 + v.z * matrix.m23 + matrix.m24;
            result.z = v.x * matrix.m31 + v.y * matrix.m32 + v.z * matrix.m33 + matrix.m34;
            result.w = v.x * matrix.m41 + v.y * matrix.m42 + v.z * matrix.m43 + matrix.m44;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector4 TransformTranspose(FixVector3 v, FixMatrix4x4 matrix)
        {
            FixVector4 toReturn;
            TransformTranspose(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void Transform(ref FixVector3 v, ref FixMatrix4x4 matrix, out FixVector3 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            result.x = vX * matrix.m11 + vY * matrix.m21 + vZ * matrix.m31 + matrix.m41;
            result.y = vX * matrix.m12 + vY * matrix.m22 + vZ * matrix.m32 + matrix.m42;
            result.z = vX * matrix.m13 + vY * matrix.m23 + vZ * matrix.m33 + matrix.m43;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformTranspose(ref FixVector3 v, ref FixMatrix4x4 matrix, out FixVector3 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            result.x = vX * matrix.m11 + vY * matrix.m12 + vZ * matrix.m13 + matrix.m14;
            result.y = vX * matrix.m21 + vY * matrix.m22 + vZ * matrix.m23 + matrix.m24;
            result.z = vX * matrix.m31 + vY * matrix.m32 + vZ * matrix.m33 + matrix.m34;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformNormal(ref FixVector3 v, ref FixMatrix4x4 matrix, out FixVector3 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            result.x = vX * matrix.m11 + vY * matrix.m21 + vZ * matrix.m31;
            result.y = vX * matrix.m12 + vY * matrix.m22 + vZ * matrix.m32;
            result.z = vX * matrix.m13 + vY * matrix.m23 + vZ * matrix.m33;
        }

        /// <summary>
        /// Transforms a vector using a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector3 TransformNormal(FixVector3 v, FixMatrix4x4 matrix)
        {
            FixVector3 toReturn;
            TransformNormal(ref v, ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <param name="result">Transformed vector.</param>
        public static void TransformNormalTranspose(ref FixVector3 v, ref FixMatrix4x4 matrix, out FixVector3 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            result.x = vX * matrix.m11 + vY * matrix.m12 + vZ * matrix.m13;
            result.y = vX * matrix.m21 + vY * matrix.m22 + vZ * matrix.m23;
            result.z = vX * matrix.m31 + vY * matrix.m32 + vZ * matrix.m33;
        }

        /// <summary>
        /// Transforms a vector using the transpose of a matrix.
        /// </summary>
        /// <param name="v">Vector to transform.</param>
        /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
        /// <returns>Transformed vector.</returns>
        public static FixVector3 TransformNormalTranspose(FixVector3 v, FixMatrix4x4 matrix)
        {
            FixVector3 toReturn;
            TransformNormalTranspose(ref v, ref matrix, out toReturn);
            return toReturn;
        }


        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        /// <param name="m">Matrix to transpose.</param>
        /// <param name="transposed">Matrix to transpose.</param>
        public static void Transpose(ref FixMatrix4x4 m, out FixMatrix4x4 transposed)
        {
            Fix64 intermediate = m.m12;
            transposed.m12 = m.m21;
            transposed.m21 = intermediate;

            intermediate = m.m13;
            transposed.m13 = m.m31;
            transposed.m31 = intermediate;

            intermediate = m.m14;
            transposed.m14 = m.m41;
            transposed.m41 = intermediate;

            intermediate = m.m23;
            transposed.m23 = m.m32;
            transposed.m32 = intermediate;

            intermediate = m.m24;
            transposed.m24 = m.m42;
            transposed.m42 = intermediate;

            intermediate = m.m34;
            transposed.m34 = m.m43;
            transposed.m43 = intermediate;

            transposed.m11 = m.m11;
            transposed.m22 = m.m22;
            transposed.m33 = m.m33;
            transposed.m44 = m.m44;
        }

        /// <summary>
        /// Inverts the matrix.
        /// </summary>
        /// <param name="m">Matrix to invert.</param>
        /// <param name="inverted">Inverted version of the matrix.</param>
        public static void Invert(ref FixMatrix4x4 m, out FixMatrix4x4 inverted)
        {
            Matrix4x8.Invert(ref m, out inverted);
        }

        /// <summary>
        /// Inverts the matrix.
        /// </summary>
        /// <param name="m">Matrix to invert.</param>
        /// <returns>Inverted version of the matrix.</returns>
        public static FixMatrix4x4 Invert(FixMatrix4x4 m)
        {
            FixMatrix4x4 inverted;
            Invert(ref m, out inverted);
            return inverted;
        }

        /// <summary>
        /// Inverts the matrix using a process that only works for rigid transforms.
        /// </summary>
        /// <param name="m">Matrix to invert.</param>
        /// <param name="inverted">Inverted version of the matrix.</param>
        public static void InvertRigid(ref FixMatrix4x4 m, out FixMatrix4x4 inverted)
        {
            //Invert (transpose) the upper left 3x3 rotation.
            Fix64 intermediate = m.m12;
            inverted.m12 = m.m21;
            inverted.m21 = intermediate;

            intermediate = m.m13;
            inverted.m13 = m.m31;
            inverted.m31 = intermediate;

            intermediate = m.m23;
            inverted.m23 = m.m32;
            inverted.m32 = intermediate;

            inverted.m11 = m.m11;
            inverted.m22 = m.m22;
            inverted.m33 = m.m33;

            //Translation component
            var vX = m.m41;
            var vY = m.m42;
            var vZ = m.m43;
            inverted.m41 = -(vX * inverted.m11 + vY * inverted.m21 + vZ * inverted.m31);
            inverted.m42 = -(vX * inverted.m12 + vY * inverted.m22 + vZ * inverted.m32);
            inverted.m43 = -(vX * inverted.m13 + vY * inverted.m23 + vZ * inverted.m33);

            //Last chunk.
            inverted.m14 = F64.C0;
            inverted.m24 = F64.C0;
            inverted.m34 = F64.C0;
            inverted.m44 = F64.C1;
        }

        /// <summary>
        /// Inverts the matrix using a process that only works for rigid transforms.
        /// </summary>
        /// <param name="m">Matrix to invert.</param>
        /// <returns>Inverted version of the matrix.</returns>
        public static FixMatrix4x4 InvertRigid(FixMatrix4x4 m)
        {
            FixMatrix4x4 inverse;
            InvertRigid(ref m, out inverse);
            return inverse;
        }

        /// <summary>
        /// Gets the 4x4 identity matrix.
        /// </summary>
        public static FixMatrix4x4 Identity
        {
            get
            {
                FixMatrix4x4 toReturn;
                toReturn.m11 = F64.C1;
                toReturn.m12 = F64.C0;
                toReturn.m13 = F64.C0;
                toReturn.m14 = F64.C0;

                toReturn.m21 = F64.C0;
                toReturn.m22 = F64.C1;
                toReturn.m23 = F64.C0;
                toReturn.m24 = F64.C0;

                toReturn.m31 = F64.C0;
                toReturn.m32 = F64.C0;
                toReturn.m33 = F64.C1;
                toReturn.m34 = F64.C0;

                toReturn.m41 = F64.C0;
                toReturn.m42 = F64.C0;
                toReturn.m43 = F64.C0;
                toReturn.m44 = F64.C1;
                return toReturn;
            }
        }

        /// <summary>
        /// Creates a right handed orthographic projection.
        /// </summary>
        /// <param name="left">Leftmost coordinate of the projected area.</param>
        /// <param name="right">Rightmost coordinate of the projected area.</param>
        /// <param name="bottom">Bottom coordinate of the projected area.</param>
        /// <param name="top">Top coordinate of the projected area.</param>
        /// <param name="zNear">Near plane of the projection.</param>
        /// <param name="zFar">Far plane of the projection.</param>
        /// <param name="projection">The resulting orthographic projection matrix.</param>
        public static void CreateOrthographicRH(Fix64 left, Fix64 right, Fix64 bottom, Fix64 top, Fix64 zNear, Fix64 zFar, out FixMatrix4x4 projection)
        {
            Fix64 width = right - left;
            Fix64 height = top - bottom;
            Fix64 depth = zFar - zNear;
            projection.m11 = F64.C2 / width;
            projection.m12 = F64.C0;
            projection.m13 = F64.C0;
            projection.m14 = F64.C0;

            projection.m21 = F64.C0;
            projection.m22 = F64.C2 / height;
            projection.m23 = F64.C0;
            projection.m24 = F64.C0;

            projection.m31 = F64.C0;
            projection.m32 = F64.C0;
            projection.m33 = -1 / depth;
            projection.m34 = F64.C0;

            projection.m41 = (left + right) / -width;
            projection.m42 = (top + bottom) / -height;
            projection.m43 = zNear / -depth;
            projection.m44 = F64.C1;

        }

        /// <summary>
        /// Creates a right-handed perspective matrix.
        /// </summary>
        /// <param name="fieldOfView">Field of view of the perspective in radians.</param>
        /// <param name="aspectRatio">Width of the viewport over the height of the viewport.</param>
        /// <param name="nearClip">Near clip plane of the perspective.</param>
        /// <param name="farClip">Far clip plane of the perspective.</param>
        /// <param name="perspective">Resulting perspective matrix.</param>
        public static void CreatePerspectiveFieldOfViewRH(Fix64 fieldOfView, Fix64 aspectRatio, Fix64 nearClip, Fix64 farClip, out FixMatrix4x4 perspective)
        {
            Fix64 h = F64.C1 / Fix64.Tan(fieldOfView / F64.C2);
            Fix64 w = h / aspectRatio;
            perspective.m11 = w;
            perspective.m12 = F64.C0;
            perspective.m13 = F64.C0;
            perspective.m14 = F64.C0;

            perspective.m21 = F64.C0;
            perspective.m22 = h;
            perspective.m23 = F64.C0;
            perspective.m24 = F64.C0;

            perspective.m31 = F64.C0;
            perspective.m32 = F64.C0;
            perspective.m33 = farClip / (nearClip - farClip);
            perspective.m34 = -1;

            perspective.m41 = F64.C0;
            perspective.m42 = F64.C0;
            perspective.m44 = F64.C0;
            perspective.m43 = nearClip * perspective.m33;

        }

        /// <summary>
        /// Creates a right-handed perspective matrix.
        /// </summary>
        /// <param name="fieldOfView">Field of view of the perspective in radians.</param>
        /// <param name="aspectRatio">Width of the viewport over the height of the viewport.</param>
        /// <param name="nearClip">Near clip plane of the perspective.</param>
        /// <param name="farClip">Far clip plane of the perspective.</param>
        /// <returns>Resulting perspective matrix.</returns>
        public static FixMatrix4x4 CreatePerspectiveFieldOfViewRH(Fix64 fieldOfView, Fix64 aspectRatio, Fix64 nearClip, Fix64 farClip)
        {
            FixMatrix4x4 perspective;
            CreatePerspectiveFieldOfViewRH(fieldOfView, aspectRatio, nearClip, farClip, out perspective);
            return perspective;
        }

        /// <summary>
        /// Creates a view matrix pointing from a position to a target with the given up vector.
        /// </summary>
        /// <param name="position">Position of the camera.</param>
        /// <param name="target">Target of the camera.</param>
        /// <param name="upVector">Up vector of the camera.</param>
        /// <param name="viewMatrix">Look at matrix.</param>
        public static void CreateLookAtRH(ref FixVector3 position, ref FixVector3 target, ref FixVector3 upVector, out FixMatrix4x4 viewMatrix)
        {
            FixVector3 forward;
            FixVector3.Subtract(ref target, ref position, out forward);
            CreateViewRH(ref position, ref forward, ref upVector, out viewMatrix);
        }

        /// <summary>
        /// Creates a view matrix pointing from a position to a target with the given up vector.
        /// </summary>
        /// <param name="position">Position of the camera.</param>
        /// <param name="target">Target of the camera.</param>
        /// <param name="upVector">Up vector of the camera.</param>
        /// <returns>Look at matrix.</returns>
        public static FixMatrix4x4 CreateLookAtRH(FixVector3 position, FixVector3 target, FixVector3 upVector)
        {
            FixMatrix4x4 lookAt;
            FixVector3 forward;
            FixVector3.Subtract(ref target, ref position, out forward);
            CreateViewRH(ref position, ref forward, ref upVector, out lookAt);
            return lookAt;
        }


        /// <summary>
        /// Creates a view matrix pointing in a direction with a given up vector.
        /// </summary>
        /// <param name="position">Position of the camera.</param>
        /// <param name="forward">Forward direction of the camera.</param>
        /// <param name="upVector">Up vector of the camera.</param>
        /// <param name="viewMatrix">Look at matrix.</param>
        public static void CreateViewRH(ref FixVector3 position, ref FixVector3 forward, ref FixVector3 upVector, out FixMatrix4x4 viewMatrix)
        {
            FixVector3 z;
            Fix64 length = forward.Length();
            FixVector3.Divide(ref forward, -length, out z);
            FixVector3 x;
            FixVector3.Cross(ref upVector, ref z, out x);
            x.Normalize();
            FixVector3 y;
            FixVector3.Cross(ref z, ref x, out y);

            viewMatrix.m11 = x.x;
            viewMatrix.m12 = y.x;
            viewMatrix.m13 = z.x;
            viewMatrix.m14 = F64.C0;
            viewMatrix.m21 = x.y;
            viewMatrix.m22 = y.y;
            viewMatrix.m23 = z.y;
            viewMatrix.m24 = F64.C0;
            viewMatrix.m31 = x.z;
            viewMatrix.m32 = y.z;
            viewMatrix.m33 = z.z;
            viewMatrix.m34 = F64.C0;
            FixVector3.Dot(ref x, ref position, out viewMatrix.m41);
            FixVector3.Dot(ref y, ref position, out viewMatrix.m42);
            FixVector3.Dot(ref z, ref position, out viewMatrix.m43);
            viewMatrix.m41 = -viewMatrix.m41;
            viewMatrix.m42 = -viewMatrix.m42;
            viewMatrix.m43 = -viewMatrix.m43;
            viewMatrix.m44 = F64.C1;

        }

        /// <summary>
        /// Creates a view matrix pointing looking in a direction with a given up vector.
        /// </summary>
        /// <param name="position">Position of the camera.</param>
        /// <param name="forward">Forward direction of the camera.</param>
        /// <param name="upVector">Up vector of the camera.</param>
        /// <returns>Look at matrix.</returns>
        public static FixMatrix4x4 CreateViewRH(FixVector3 position, FixVector3 forward, FixVector3 upVector)
        {
            FixMatrix4x4 lookat;
            CreateViewRH(ref position, ref forward, ref upVector, out lookat);
            return lookat;
        }



        /// <summary>
        /// Creates a world matrix pointing from a position to a target with the given up vector.
        /// </summary>
        /// <param name="position">Position of the transform.</param>
        /// <param name="forward">Forward direction of the transformation.</param>
        /// <param name="upVector">Up vector which is crossed against the forward vector to compute the transform's basis.</param>
        /// <param name="worldMatrix">World matrix.</param>
        public static void CreateWorldRH(ref FixVector3 position, ref FixVector3 forward, ref FixVector3 upVector, out FixMatrix4x4 worldMatrix)
        {
            FixVector3 z;
            Fix64 length = forward.Length();
            FixVector3.Divide(ref forward, -length, out z);
            FixVector3 x;
            FixVector3.Cross(ref upVector, ref z, out x);
            x.Normalize();
            FixVector3 y;
            FixVector3.Cross(ref z, ref x, out y);

            worldMatrix.m11 = x.x;
            worldMatrix.m12 = x.y;
            worldMatrix.m13 = x.z;
            worldMatrix.m14 = F64.C0;
            worldMatrix.m21 = y.x;
            worldMatrix.m22 = y.y;
            worldMatrix.m23 = y.z;
            worldMatrix.m24 = F64.C0;
            worldMatrix.m31 = z.x;
            worldMatrix.m32 = z.y;
            worldMatrix.m33 = z.z;
            worldMatrix.m34 = F64.C0;

            worldMatrix.m41 = position.x;
            worldMatrix.m42 = position.y;
            worldMatrix.m43 = position.z;
            worldMatrix.m44 = F64.C1;

        }


        /// <summary>
        /// Creates a world matrix pointing from a position to a target with the given up vector.
        /// </summary>
        /// <param name="position">Position of the transform.</param>
        /// <param name="forward">Forward direction of the transformation.</param>
        /// <param name="upVector">Up vector which is crossed against the forward vector to compute the transform's basis.</param>
        /// <returns>World matrix.</returns>
        public static FixMatrix4x4 CreateWorldRH(FixVector3 position, FixVector3 forward, FixVector3 upVector)
        {
            FixMatrix4x4 lookat;
            CreateWorldRH(ref position, ref forward, ref upVector, out lookat);
            return lookat;
        }



        /// <summary>
        /// Creates a matrix representing a translation.
        /// </summary>
        /// <param name="translation">Translation to be represented by the matrix.</param>
        /// <param name="translationMatrix">Matrix representing the given translation.</param>
        public static void CreateTranslation(ref FixVector3 translation, out FixMatrix4x4 translationMatrix)
        {
            translationMatrix = new FixMatrix4x4
            {
                m11 = F64.C1,
                m22 = F64.C1,
                m33 = F64.C1,
                m44 = F64.C1,
                m41 = translation.x,
                m42 = translation.y,
                m43 = translation.z
            };
        }

        /// <summary>
        /// Creates a matrix representing a translation.
        /// </summary>
        /// <param name="translation">Translation to be represented by the matrix.</param>
        /// <returns>Matrix representing the given translation.</returns>
        public static FixMatrix4x4 CreateTranslation(FixVector3 translation)
        {
            FixMatrix4x4 translationMatrix;
            CreateTranslation(ref translation, out translationMatrix);
            return translationMatrix;
        }

        /// <summary>
        /// Creates a matrix representing the given axis aligned scale.
        /// </summary>
        /// <param name="scale">Scale to be represented by the matrix.</param>
        /// <param name="scaleMatrix">Matrix representing the given scale.</param>
        public static void CreateScale(ref FixVector3 scale, out FixMatrix4x4 scaleMatrix)
        {
            scaleMatrix = new FixMatrix4x4
            {
                m11 = scale.x,
                m22 = scale.y,
                m33 = scale.z,
                m44 = F64.C1
            };
        }

        /// <summary>
        /// Creates a matrix representing the given axis aligned scale.
        /// </summary>
        /// <param name="scale">Scale to be represented by the matrix.</param>
        /// <returns>Matrix representing the given scale.</returns>
        public static FixMatrix4x4 CreateScale(FixVector3 scale)
        {
            FixMatrix4x4 scaleMatrix;
            CreateScale(ref scale, out scaleMatrix);
            return scaleMatrix;
        }

        /// <summary>
        /// Creates a matrix representing the given axis aligned scale.
        /// </summary>
        /// <param name="x">Scale along the x axis.</param>
        /// <param name="y">Scale along the y axis.</param>
        /// <param name="z">Scale along the z axis.</param>
        /// <param name="scaleMatrix">Matrix representing the given scale.</param>
        public static void CreateScale(Fix64 x, Fix64 y, Fix64 z, out FixMatrix4x4 scaleMatrix)
        {
            scaleMatrix = new FixMatrix4x4
            {
                m11 = x,
                m22 = y,
                m33 = z,
                m44 = F64.C1
            };
        }

        /// <summary>
        /// Creates a matrix representing the given axis aligned scale.
        /// </summary>
        /// <param name="x">Scale along the x axis.</param>
        /// <param name="y">Scale along the y axis.</param>
        /// <param name="z">Scale along the z axis.</param>
        /// <returns>Matrix representing the given scale.</returns>
        public static FixMatrix4x4 CreateScale(Fix64 x, Fix64 y, Fix64 z)
        {
            FixMatrix4x4 scaleMatrix;
            CreateScale(x, y, z, out scaleMatrix);
            return scaleMatrix;
        }

        /// <summary>
        /// Creates a string representation of the matrix.
        /// </summary>
        /// <returns>A string representation of the matrix.</returns>
        public override string ToString()
        {
            return "{" + m11 + ", " + m12 + ", " + m13 + ", " + m14 + "} " +
                   "{" + m21 + ", " + m22 + ", " + m23 + ", " + m24 + "} " +
                   "{" + m31 + ", " + m32 + ", " + m33 + ", " + m34 + "} " +
                   "{" + m41 + ", " + m42 + ", " + m43 + ", " + m44 + "}";
        }
    }
}
