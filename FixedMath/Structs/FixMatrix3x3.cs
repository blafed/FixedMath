using System;
namespace FixedMath
{
    /// <summary>
    /// 3 row, 3 column matrix.
    /// </summary>
    public struct FixMatrix3x3
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
        /// Constructs a new 3 row, 3 column matrix.
        /// </summary>
        /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
        /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
        /// <param name="m13">Value at row 1, column 3 of the matrix.</param>
        /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
        /// <param name="m23">Value at row 2, column 3 of the matrix.</param>
        /// <param name="m31">Value at row 3, column 1 of the matrix.</param>
        /// <param name="m32">Value at row 3, column 2 of the matrix.</param>
        /// <param name="m33">Value at row 3, column 3 of the matrix.</param>
        public FixMatrix3x3(Fix64 m11, Fix64 m12, Fix64 m13, Fix64 m21, Fix64 m22, Fix64 m23, Fix64 m31, Fix64 m32, Fix64 m33)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
        }

        /// <summary>
        /// Gets the 3x3 identity matrix.
        /// </summary>
        public static FixMatrix3x3 Identity
        {
            get { return new FixMatrix3x3(F64.C1, F64.C0, F64.C0, F64.C0, F64.C1, F64.C0, F64.C0, F64.C0, F64.C1); }
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
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref FixMatrix3x3 a, ref FixMatrix3x3 b, out FixMatrix3x3 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;
            Fix64 m13 = a.m13 + b.m13;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.m22;
            Fix64 m23 = a.m23 + b.m23;

            Fix64 m31 = a.m31 + b.m31;
            Fix64 m32 = a.m32 + b.m32;
            Fix64 m33 = a.m33 + b.m33;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;

            result.m31 = m31;
            result.m32 = m32;
            result.m33 = m33;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref FixMatrix4x4 a, ref FixMatrix3x3 b, out FixMatrix3x3 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;
            Fix64 m13 = a.m13 + b.m13;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.m22;
            Fix64 m23 = a.m23 + b.m23;

            Fix64 m31 = a.m31 + b.m31;
            Fix64 m32 = a.m32 + b.m32;
            Fix64 m33 = a.m33 + b.m33;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;

            result.m31 = m31;
            result.m32 = m32;
            result.m33 = m33;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref FixMatrix3x3 a, ref FixMatrix4x4 b, out FixMatrix3x3 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;
            Fix64 m13 = a.m13 + b.m13;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.m22;
            Fix64 m23 = a.m23 + b.m23;

            Fix64 m31 = a.m31 + b.m31;
            Fix64 m32 = a.m32 + b.m32;
            Fix64 m33 = a.m33 + b.m33;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;

            result.m31 = m31;
            result.m32 = m32;
            result.m33 = m33;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref FixMatrix4x4 a, ref FixMatrix4x4 b, out FixMatrix3x3 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;
            Fix64 m13 = a.m13 + b.m13;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.m22;
            Fix64 m23 = a.m23 + b.m23;

            Fix64 m31 = a.m31 + b.m31;
            Fix64 m32 = a.m32 + b.m32;
            Fix64 m33 = a.m33 + b.m33;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;

            result.m31 = m31;
            result.m32 = m32;
            result.m33 = m33;
        }

        /// <summary>
        /// Creates a skew symmetric matrix M from vector A such that M * B for some other vector B is equivalent to the cross product of A and B.
        /// </summary>
        /// <param name="v">Vector to base the matrix on.</param>
        /// <param name="result">Skew-symmetric matrix result.</param>
        public static void CreateCrossProduct(ref FixVector3 v, out FixMatrix3x3 result)
        {
            result.m11 = F64.C0;
            result.m12 = -v.z;
            result.m13 = v.y;
            result.m21 = v.z;
            result.m22 = F64.C0;
            result.m23 = -v.x;
            result.m31 = -v.y;
            result.m32 = v.x;
            result.m33 = F64.C0;
        }

        /// <summary>
        /// Creates a 3x3 matrix from an XNA 4x4 matrix.
        /// </summary>
        /// <param name="matrix4X4">Matrix to extract a 3x3 matrix from.</param>
        /// <param name="matrix3X3">Upper 3x3 matrix extracted from the XNA matrix.</param>
        public static void CreateFromMatrix(ref FixMatrix4x4 matrix4X4, out FixMatrix3x3 matrix3X3)
        {
            matrix3X3.m11 = matrix4X4.m11;
            matrix3X3.m12 = matrix4X4.m12;
            matrix3X3.m13 = matrix4X4.m13;

            matrix3X3.m21 = matrix4X4.m21;
            matrix3X3.m22 = matrix4X4.m22;
            matrix3X3.m23 = matrix4X4.m23;

            matrix3X3.m31 = matrix4X4.m31;
            matrix3X3.m32 = matrix4X4.m32;
            matrix3X3.m33 = matrix4X4.m33;
        }
        /// <summary>
        /// Creates a 3x3 matrix from an XNA 4x4 matrix.
        /// </summary>
        /// <param name="matrix4X4">Matrix to extract a 3x3 matrix from.</param>
        /// <returns>Upper 3x3 matrix extracted from the XNA matrix.</returns>
        public static FixMatrix3x3 CreateFromMatrix(FixMatrix4x4 matrix4X4)
        {
            FixMatrix3x3 matrix3X3;
            matrix3X3.m11 = matrix4X4.m11;
            matrix3X3.m12 = matrix4X4.m12;
            matrix3X3.m13 = matrix4X4.m13;

            matrix3X3.m21 = matrix4X4.m21;
            matrix3X3.m22 = matrix4X4.m22;
            matrix3X3.m23 = matrix4X4.m23;

            matrix3X3.m31 = matrix4X4.m31;
            matrix3X3.m32 = matrix4X4.m32;
            matrix3X3.m33 = matrix4X4.m33;
            return matrix3X3;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(Fix64 scale, out FixMatrix3x3 matrix)
        {
            matrix = new FixMatrix3x3 { m11 = scale, m22 = scale, m33 = scale };
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <returns>Scaling matrix.</returns>
        public static FixMatrix3x3 CreateScale(Fix64 scale)
        {
            var matrix = new FixMatrix3x3 { m11 = scale, m22 = scale, m33 = scale };
            return matrix;
        }

        /// <summary>
        /// Constructs a non-uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Values defining the axis scales.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(ref FixVector3 scale, out FixMatrix3x3 matrix)
        {
            matrix = new FixMatrix3x3 { m11 = scale.x, m22 = scale.y, m33 = scale.z };
        }

        /// <summary>
        /// Constructs a non-uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Values defining the axis scales.</param>
        /// <returns>Scaling matrix.</returns>
        public static FixMatrix3x3 CreateScale(ref FixVector3 scale)
        {
            var matrix = new FixMatrix3x3 { m11 = scale.x, m22 = scale.y, m33 = scale.z };
            return matrix;
        }


        /// <summary>
        /// Constructs a non-uniform scaling matrix.
        /// </summary>
        /// <param name="x">Scaling along the x axis.</param>
        /// <param name="y">Scaling along the y axis.</param>
        /// <param name="z">Scaling along the z axis.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(Fix64 x, Fix64 y, Fix64 z, out FixMatrix3x3 matrix)
        {
            matrix = new FixMatrix3x3 { m11 = x, m22 = y, m33 = z };
        }

        /// <summary>
        /// Constructs a non-uniform scaling matrix.
        /// </summary>
        /// <param name="x">Scaling along the x axis.</param>
        /// <param name="y">Scaling along the y axis.</param>
        /// <param name="z">Scaling along the z axis.</param>
        /// <returns>Scaling matrix.</returns>
        public static FixMatrix3x3 CreateScale(Fix64 x, Fix64 y, Fix64 z)
        {
            var matrix = new FixMatrix3x3 { m11 = x, m22 = y, m33 = z };
            return matrix;
        }

        /// <summary>
        /// Inverts the given matix.
        /// </summary>
        /// <param name="matrix">Matrix to be inverted.</param>
        /// <param name="result">Inverted matrix.</param>
        /// <returns>false if matrix is singular, true otherwise</returns>
        public static bool Invert(ref FixMatrix3x3 matrix, out FixMatrix3x3 result)
        {
            return Matrix3x6.Invert(ref matrix, out result);
        }

        /// <summary>
        /// Inverts the given matix.
        /// </summary>
        /// <param name="matrix">Matrix to be inverted.</param>
        /// <returns>Inverted matrix.</returns>
        public static FixMatrix3x3 Invert(FixMatrix3x3 matrix)
        {
            FixMatrix3x3 toReturn;
            Invert(ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Inverts the largest nonsingular submatrix in the matrix, excluding 2x2's that involve M13 or M31, and excluding 1x1's that include nondiagonal elements.
        /// </summary>
        /// <param name="matrix">Matrix to be inverted.</param>
        /// <param name="result">Inverted matrix.</param>
        public static void AdaptiveInvert(ref FixMatrix3x3 matrix, out FixMatrix3x3 result)
        {
            // Perform full Gauss-invert and return if successful
            if (Invert(ref matrix, out result))
                return;

            int submatrix;
            Fix64 determinantInverse = F64.C1 / matrix.AdaptiveDeterminant(out submatrix);
            Fix64 m11, m12, m13, m21, m22, m23, m31, m32, m33;
            switch (submatrix)
            {
                case 1: //Upper left matrix, m11, m12, m21, m22.
                    m11 = matrix.m22 * determinantInverse;
                    m12 = -matrix.m12 * determinantInverse;
                    m13 = F64.C0;

                    m21 = -matrix.m21 * determinantInverse;
                    m22 = matrix.m11 * determinantInverse;
                    m23 = F64.C0;

                    m31 = F64.C0;
                    m32 = F64.C0;
                    m33 = F64.C0;
                    break;
                case 2: //Lower right matrix, m22, m23, m32, m33.
                    m11 = F64.C0;
                    m12 = F64.C0;
                    m13 = F64.C0;

                    m21 = F64.C0;
                    m22 = matrix.m33 * determinantInverse;
                    m23 = -matrix.m23 * determinantInverse;

                    m31 = F64.C0;
                    m32 = -matrix.m32 * determinantInverse;
                    m33 = matrix.m22 * determinantInverse;
                    break;
                case 3: //Corners, m11, m31, m13, m33.
                    m11 = matrix.m33 * determinantInverse;
                    m12 = F64.C0;
                    m13 = -matrix.m13 * determinantInverse;

                    m21 = F64.C0;
                    m22 = F64.C0;
                    m23 = F64.C0;

                    m31 = -matrix.m31 * determinantInverse;
                    m32 = F64.C0;
                    m33 = matrix.m11 * determinantInverse;
                    break;
                case 4: //M11
                    m11 = F64.C1 / matrix.m11;
                    m12 = F64.C0;
                    m13 = F64.C0;

                    m21 = F64.C0;
                    m22 = F64.C0;
                    m23 = F64.C0;

                    m31 = F64.C0;
                    m32 = F64.C0;
                    m33 = F64.C0;
                    break;
                case 5: //M22
                    m11 = F64.C0;
                    m12 = F64.C0;
                    m13 = F64.C0;

                    m21 = F64.C0;
                    m22 = F64.C1 / matrix.m22;
                    m23 = F64.C0;

                    m31 = F64.C0;
                    m32 = F64.C0;
                    m33 = F64.C0;
                    break;
                case 6: //M33
                    m11 = F64.C0;
                    m12 = F64.C0;
                    m13 = F64.C0;

                    m21 = F64.C0;
                    m22 = F64.C0;
                    m23 = F64.C0;

                    m31 = F64.C0;
                    m32 = F64.C0;
                    m33 = F64.C1 / matrix.m33;
                    break;
                default: //Completely singular.
                    m11 = F64.C0; m12 = F64.C0; m13 = F64.C0; m21 = F64.C0; m22 = F64.C0; m23 = F64.C0; m31 = F64.C0; m32 = F64.C0; m33 = F64.C0;
                    break;
            }

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;

            result.m31 = m31;
            result.m32 = m32;
            result.m33 = m33;
        }

        /// <summary>
        /// <para>Computes the adjugate transpose of a matrix.</para>
        /// <para>The adjugate transpose A of matrix M is: det(M) * transpose(invert(M))</para>
        /// <para>This is necessary when transforming normals (bivectors) with general linear transformations.</para>
        /// </summary>
        /// <param name="matrix">Matrix to compute the adjugate transpose of.</param>
        /// <param name="result">Adjugate transpose of the input matrix.</param>
        public static void AdjugateTranspose(ref FixMatrix3x3 matrix, out FixMatrix3x3 result)
        {
            //Despite the relative obscurity of the operation, this is a fairly straightforward operation which is actually faster than a true invert (by virtue of cancellation).
            //Conceptually, this is implemented as transpose(det(M) * invert(M)), but that's perfectly acceptable:
            //1) transpose(invert(M)) == invert(transpose(M)), and
            //2) det(M) == det(transpose(M))
            //This organization makes it clearer that the invert's usual division by determinant drops out.

            Fix64 m11 = (matrix.m22 * matrix.m33 - matrix.m23 * matrix.m32);
            Fix64 m12 = (matrix.m13 * matrix.m32 - matrix.m33 * matrix.m12);
            Fix64 m13 = (matrix.m12 * matrix.m23 - matrix.m22 * matrix.m13);

            Fix64 m21 = (matrix.m23 * matrix.m31 - matrix.m21 * matrix.m33);
            Fix64 m22 = (matrix.m11 * matrix.m33 - matrix.m13 * matrix.m31);
            Fix64 m23 = (matrix.m13 * matrix.m21 - matrix.m11 * matrix.m23);

            Fix64 m31 = (matrix.m21 * matrix.m32 - matrix.m22 * matrix.m31);
            Fix64 m32 = (matrix.m12 * matrix.m31 - matrix.m11 * matrix.m32);
            Fix64 m33 = (matrix.m11 * matrix.m22 - matrix.m12 * matrix.m21);

            //Note transposition.
            result.m11 = m11;
            result.m12 = m21;
            result.m13 = m31;

            result.m21 = m12;
            result.m22 = m22;
            result.m23 = m32;

            result.m31 = m13;
            result.m32 = m23;
            result.m33 = m33;
        }

        /// <summary>
        /// <para>Computes the adjugate transpose of a matrix.</para>
        /// <para>The adjugate transpose A of matrix M is: det(M) * transpose(invert(M))</para>
        /// <para>This is necessary when transforming normals (bivectors) with general linear transformations.</para>
        /// </summary>
        /// <param name="matrix">Matrix to compute the adjugate transpose of.</param>
        /// <returns>Adjugate transpose of the input matrix.</returns>
        public static FixMatrix3x3 AdjugateTranspose(FixMatrix3x3 matrix)
        {
            FixMatrix3x3 toReturn;
            AdjugateTranspose(ref matrix, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixMatrix3x3 operator *(FixMatrix3x3 a, FixMatrix3x3 b)
        {
            FixMatrix3x3 result;
            FixMatrix3x3.Multiply(ref a, ref b, out result);
            return result;
        }

        /// <summary>
        /// Scales all components of the matrix by the given value.
        /// </summary>
        /// <param name="m">First matrix to multiply.</param>
        /// <param name="f">Scaling value to apply to all components of the matrix.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixMatrix3x3 operator *(FixMatrix3x3 m, Fix64 f)
        {
            FixMatrix3x3 result;
            Multiply(ref m, f, out result);
            return result;
        }

        /// <summary>
        /// Scales all components of the matrix by the given value.
        /// </summary>
        /// <param name="m">First matrix to multiply.</param>
        /// <param name="f">Scaling value to apply to all components of the matrix.</param>
        /// <returns>Product of the multiplication.</returns>
        public static FixMatrix3x3 operator *(Fix64 f, FixMatrix3x3 m)
        {
            FixMatrix3x3 result;
            Multiply(ref m, f, out result);
            return result;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref FixMatrix3x3 a, ref FixMatrix3x3 b, out FixMatrix3x3 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32;
            Fix64 resultM13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32;
            Fix64 resultM23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33;

            Fix64 resultM31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31;
            Fix64 resultM32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32;
            Fix64 resultM33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;

            result.m31 = resultM31;
            result.m32 = resultM32;
            result.m33 = resultM33;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref FixMatrix3x3 a, ref FixMatrix4x4 b, out FixMatrix3x3 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32;
            Fix64 resultM13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32;
            Fix64 resultM23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33;

            Fix64 resultM31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31;
            Fix64 resultM32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32;
            Fix64 resultM33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;

            result.m31 = resultM31;
            result.m32 = resultM32;
            result.m33 = resultM33;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref FixMatrix4x4 a, ref FixMatrix3x3 b, out FixMatrix3x3 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32;
            Fix64 resultM13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32;
            Fix64 resultM23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33;

            Fix64 resultM31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31;
            Fix64 resultM32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32;
            Fix64 resultM33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;

            result.m31 = resultM31;
            result.m32 = resultM32;
            result.m33 = resultM33;
        }


        /// <summary>
        /// Multiplies a transposed matrix with another matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be multiplied.</param>
        /// <param name="transpose">Matrix to be transposed and multiplied.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void MultiplyTransposed(ref FixMatrix3x3 transpose, ref FixMatrix3x3 matrix, out FixMatrix3x3 result)
        {
            Fix64 resultM11 = transpose.m11 * matrix.m11 + transpose.m21 * matrix.m21 + transpose.m31 * matrix.m31;
            Fix64 resultM12 = transpose.m11 * matrix.m12 + transpose.m21 * matrix.m22 + transpose.m31 * matrix.m32;
            Fix64 resultM13 = transpose.m11 * matrix.m13 + transpose.m21 * matrix.m23 + transpose.m31 * matrix.m33;

            Fix64 resultM21 = transpose.m12 * matrix.m11 + transpose.m22 * matrix.m21 + transpose.m32 * matrix.m31;
            Fix64 resultM22 = transpose.m12 * matrix.m12 + transpose.m22 * matrix.m22 + transpose.m32 * matrix.m32;
            Fix64 resultM23 = transpose.m12 * matrix.m13 + transpose.m22 * matrix.m23 + transpose.m32 * matrix.m33;

            Fix64 resultM31 = transpose.m13 * matrix.m11 + transpose.m23 * matrix.m21 + transpose.m33 * matrix.m31;
            Fix64 resultM32 = transpose.m13 * matrix.m12 + transpose.m23 * matrix.m22 + transpose.m33 * matrix.m32;
            Fix64 resultM33 = transpose.m13 * matrix.m13 + transpose.m23 * matrix.m23 + transpose.m33 * matrix.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;

            result.m31 = resultM31;
            result.m32 = resultM32;
            result.m33 = resultM33;
        }

        /// <summary>
        /// Multiplies a matrix with a transposed matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be multiplied.</param>
        /// <param name="transpose">Matrix to be transposed and multiplied.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void MultiplyByTransposed(ref FixMatrix3x3 matrix, ref FixMatrix3x3 transpose, out FixMatrix3x3 result)
        {
            Fix64 resultM11 = matrix.m11 * transpose.m11 + matrix.m12 * transpose.m12 + matrix.m13 * transpose.m13;
            Fix64 resultM12 = matrix.m11 * transpose.m21 + matrix.m12 * transpose.m22 + matrix.m13 * transpose.m23;
            Fix64 resultM13 = matrix.m11 * transpose.m31 + matrix.m12 * transpose.m32 + matrix.m13 * transpose.m33;

            Fix64 resultM21 = matrix.m21 * transpose.m11 + matrix.m22 * transpose.m12 + matrix.m23 * transpose.m13;
            Fix64 resultM22 = matrix.m21 * transpose.m21 + matrix.m22 * transpose.m22 + matrix.m23 * transpose.m23;
            Fix64 resultM23 = matrix.m21 * transpose.m31 + matrix.m22 * transpose.m32 + matrix.m23 * transpose.m33;

            Fix64 resultM31 = matrix.m31 * transpose.m11 + matrix.m32 * transpose.m12 + matrix.m33 * transpose.m13;
            Fix64 resultM32 = matrix.m31 * transpose.m21 + matrix.m32 * transpose.m22 + matrix.m33 * transpose.m23;
            Fix64 resultM33 = matrix.m31 * transpose.m31 + matrix.m32 * transpose.m32 + matrix.m33 * transpose.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;

            result.m31 = resultM31;
            result.m32 = resultM32;
            result.m33 = resultM33;
        }

        /// <summary>
        /// Scales all components of the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to scale.</param>
        /// <param name="scale">Amount to scale.</param>
        /// <param name="result">Scaled matrix.</param>
        public static void Multiply(ref FixMatrix3x3 matrix, Fix64 scale, out FixMatrix3x3 result)
        {
            result.m11 = matrix.m11 * scale;
            result.m12 = matrix.m12 * scale;
            result.m13 = matrix.m13 * scale;

            result.m21 = matrix.m21 * scale;
            result.m22 = matrix.m22 * scale;
            result.m23 = matrix.m23 * scale;

            result.m31 = matrix.m31 * scale;
            result.m32 = matrix.m32 * scale;
            result.m33 = matrix.m33 * scale;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(ref FixMatrix3x3 matrix, out FixMatrix3x3 result)
        {
            result.m11 = -matrix.m11;
            result.m12 = -matrix.m12;
            result.m13 = -matrix.m13;

            result.m21 = -matrix.m21;
            result.m22 = -matrix.m22;
            result.m23 = -matrix.m23;

            result.m31 = -matrix.m31;
            result.m32 = -matrix.m32;
            result.m33 = -matrix.m33;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to subtract.</param>
        /// <param name="b">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(ref FixMatrix3x3 a, ref FixMatrix3x3 b, out FixMatrix3x3 result)
        {
            Fix64 m11 = a.m11 - b.m11;
            Fix64 m12 = a.m12 - b.m12;
            Fix64 m13 = a.m13 - b.m13;

            Fix64 m21 = a.m21 - b.m21;
            Fix64 m22 = a.m22 - b.m22;
            Fix64 m23 = a.m23 - b.m23;

            Fix64 m31 = a.m31 - b.m31;
            Fix64 m32 = a.m32 - b.m32;
            Fix64 m33 = a.m33 - b.m33;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;

            result.m31 = m31;
            result.m32 = m32;
            result.m33 = m33;
        }

        /// <summary>
        /// Creates a 4x4 matrix from a 3x3 matrix.
        /// </summary>
        /// <param name="a">3x3 matrix.</param>
        /// <param name="b">Created 4x4 matrix.</param>
        public static void ToMatrix4X4(ref FixMatrix3x3 a, out FixMatrix4x4 b)
        {
#if !WINDOWS
            b = new FixMatrix4x4();
#endif
            b.m11 = a.m11;
            b.m12 = a.m12;
            b.m13 = a.m13;

            b.m21 = a.m21;
            b.m22 = a.m22;
            b.m23 = a.m23;

            b.m31 = a.m31;
            b.m32 = a.m32;
            b.m33 = a.m33;

            b.m44 = F64.C1;
            b.m14 = F64.C0;
            b.m24 = F64.C0;
            b.m34 = F64.C0;
            b.m41 = F64.C0;
            b.m42 = F64.C0;
            b.m43 = F64.C0;
        }

        /// <summary>
        /// Creates a 4x4 matrix from a 3x3 matrix.
        /// </summary>
        /// <param name="a">3x3 matrix.</param>
        /// <returns>Created 4x4 matrix.</returns>
        public static FixMatrix4x4 ToMatrix4X4(FixMatrix3x3 a)
        {
#if !WINDOWS
            FixMatrix4x4 b = new FixMatrix4x4();
#else
            Matrix b;
#endif
            b.m11 = a.m11;
            b.m12 = a.m12;
            b.m13 = a.m13;

            b.m21 = a.m21;
            b.m22 = a.m22;
            b.m23 = a.m23;

            b.m31 = a.m31;
            b.m32 = a.m32;
            b.m33 = a.m33;

            b.m44 = F64.C1;
            b.m14 = F64.C0;
            b.m24 = F64.C0;
            b.m34 = F64.C0;
            b.m41 = F64.C0;
            b.m42 = F64.C0;
            b.m43 = F64.C0;
            return b;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Product of the transformation.</param>
        public static void Transform(ref FixVector3 v, ref FixMatrix3x3 matrix, out FixVector3 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
#if !WINDOWS
            result = new FixVector3();
#endif
            result.x = vX * matrix.m11 + vY * matrix.m21 + vZ * matrix.m31;
            result.y = vX * matrix.m12 + vY * matrix.m22 + vZ * matrix.m32;
            result.z = vX * matrix.m13 + vY * matrix.m23 + vZ * matrix.m33;
        }


        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <returns>Product of the transformation.</returns>
        public static FixVector3 Transform(FixVector3 v, FixMatrix3x3 matrix)
        {
            FixVector3 result;
#if !WINDOWS
            result = new FixVector3();
#endif
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;

            result.x = vX * matrix.m11 + vY * matrix.m21 + vZ * matrix.m31;
            result.y = vX * matrix.m12 + vY * matrix.m22 + vZ * matrix.m32;
            result.z = vX * matrix.m13 + vY * matrix.m23 + vZ * matrix.m33;
            return result;
        }

        /// <summary>
        /// Transforms the vector by the matrix's transpose.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation transpose.</param>
        /// <param name="result">Product of the transformation.</param>
        public static void TransformTranspose(ref FixVector3 v, ref FixMatrix3x3 matrix, out FixVector3 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
#if !WINDOWS
            result = new FixVector3();
#endif
            result.x = vX * matrix.m11 + vY * matrix.m12 + vZ * matrix.m13;
            result.y = vX * matrix.m21 + vY * matrix.m22 + vZ * matrix.m23;
            result.z = vX * matrix.m31 + vY * matrix.m32 + vZ * matrix.m33;
        }

        /// <summary>
        /// Transforms the vector by the matrix's transpose.
        /// </summary>
        /// <param name="v">Vector3 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation transpose.</param>
        /// <returns>Product of the transformation.</returns>
        public static FixVector3 TransformTranspose(FixVector3 v, FixMatrix3x3 matrix)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
            Fix64 vZ = v.z;
            FixVector3 result;
#if !WINDOWS
            result = new FixVector3();
#endif
            result.x = vX * matrix.m11 + vY * matrix.m12 + vZ * matrix.m13;
            result.y = vX * matrix.m21 + vY * matrix.m22 + vZ * matrix.m23;
            result.z = vX * matrix.m31 + vY * matrix.m32 + vZ * matrix.m33;
            return result;
        }

        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <param name="result">Transposed matrix.</param>
        public static void Transpose(ref FixMatrix3x3 matrix, out FixMatrix3x3 result)
        {
            Fix64 m21 = matrix.m12;
            Fix64 m31 = matrix.m13;
            Fix64 m12 = matrix.m21;
            Fix64 m32 = matrix.m23;
            Fix64 m13 = matrix.m31;
            Fix64 m23 = matrix.m32;

            result.m11 = matrix.m11;
            result.m12 = m12;
            result.m13 = m13;
            result.m21 = m21;
            result.m22 = matrix.m22;
            result.m23 = m23;
            result.m31 = m31;
            result.m32 = m32;
            result.m33 = matrix.m33;
        }

        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <param name="result">Transposed matrix.</param>
        public static void Transpose(ref FixMatrix4x4 matrix, out FixMatrix3x3 result)
        {
            Fix64 m21 = matrix.m12;
            Fix64 m31 = matrix.m13;
            Fix64 m12 = matrix.m21;
            Fix64 m32 = matrix.m23;
            Fix64 m13 = matrix.m31;
            Fix64 m23 = matrix.m32;

            result.m11 = matrix.m11;
            result.m12 = m12;
            result.m13 = m13;
            result.m21 = m21;
            result.m22 = matrix.m22;
            result.m23 = m23;
            result.m31 = m31;
            result.m32 = m32;
            result.m33 = matrix.m33;
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

            intermediate = m23;
            m23 = m32;
            m32 = intermediate;
        }


        /// <summary>
        /// Creates a string representation of the matrix.
        /// </summary>
        /// <returns>A string representation of the matrix.</returns>
        public override string ToString()
        {
            return "{" + m11 + ", " + m12 + ", " + m13 + "} " +
                   "{" + m21 + ", " + m22 + ", " + m23 + "} " +
                   "{" + m31 + ", " + m32 + ", " + m33 + "}";
        }

        /// <summary>
        /// Calculates the determinant of largest nonsingular submatrix, excluding 2x2's that involve M13 or M31, and excluding all 1x1's that involve nondiagonal elements.
        /// </summary>
        /// <param name="subMatrixCode">Represents the submatrix that was used to compute the determinant.
        /// 0 is the full 3x3.  1 is the upper left 2x2.  2 is the lower right 2x2.  3 is the four corners.
        /// 4 is M11.  5 is M22.  6 is M33.</param>
        /// <returns>The matrix's determinant.</returns>
        internal Fix64 AdaptiveDeterminant(out int subMatrixCode)
        {
            // We do not try the full matrix. This is handled by the AdaptiveInverse.

            // We'll play it fast and loose here and assume the following won't overflow
            //Try m11, m12, m21, m22.
            Fix64 determinant = m11 * m22 - m12 * m21;
            if (determinant != F64.C0)
            {
                subMatrixCode = 1;
                return determinant;
            }
            //Try m22, m23, m32, m33.
            determinant = m22 * m33 - m23 * m32;
            if (determinant != F64.C0)
            {
                subMatrixCode = 2;
                return determinant;
            }
            //Try m11, m13, m31, m33.
            determinant = m11 * m33 - m13 * m12;
            if (determinant != F64.C0)
            {
                subMatrixCode = 3;
                return determinant;
            }
            //Try m11.
            if (m11 != F64.C0)
            {
                subMatrixCode = 4;
                return m11;
            }
            //Try m22.
            if (m22 != F64.C0)
            {
                subMatrixCode = 5;
                return m22;
            }
            //Try m33.
            if (m33 != F64.C0)
            {
                subMatrixCode = 6;
                return m33;
            }
            //It's completely singular!
            subMatrixCode = -1;
            return F64.C0;
        }

        /// <summary>
        /// Creates a 3x3 matrix representing the orientation stored in the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to use to create a matrix.</param>
        /// <param name="result">Matrix representing the quaternion's orientation.</param>
        public static void CreateFromQuaternion(ref FixQuaternion quaternion, out FixMatrix3x3 result)
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

            result.m12 = XY + ZW;
            result.m22 = F64.C1 - XX - ZZ;
            result.m32 = YZ - XW;

            result.m13 = XZ - YW;
            result.m23 = YZ + XW;
            result.m33 = F64.C1 - XX - YY;
        }

        /// <summary>
        /// Creates a 3x3 matrix representing the orientation stored in the quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion to use to create a matrix.</param>
        /// <returns>Matrix representing the quaternion's orientation.</returns>
        public static FixMatrix3x3 CreateFromQuaternion(FixQuaternion quaternion)
        {
            FixMatrix3x3 result;
            CreateFromQuaternion(ref quaternion, out result);
            return result;
        }

        /// <summary>
        /// Computes the outer product of the given vectors.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <param name="result">Outer product result.</param>
        public static void CreateOuterProduct(ref FixVector3 a, ref FixVector3 b, out FixMatrix3x3 result)
        {
            result.m11 = a.x * b.x;
            result.m12 = a.x * b.y;
            result.m13 = a.x * b.z;

            result.m21 = a.y * b.x;
            result.m22 = a.y * b.y;
            result.m23 = a.y * b.z;

            result.m31 = a.z * b.x;
            result.m32 = a.z * b.y;
            result.m33 = a.z * b.z;
        }

        /// <summary>
        /// Creates a matrix representing a rotation of a given angle around a given axis.
        /// </summary>
        /// <param name="axis">Axis around which to rotate.</param>
        /// <param name="angle">Amount to rotate.</param>
        /// <returns>Matrix representing the rotation.</returns>
        public static FixMatrix3x3 CreateFromAxisAngle(FixVector3 axis, Fix64 angle)
        {
            FixMatrix3x3 toReturn;
            CreateFromAxisAngle(ref axis, angle, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Creates a matrix representing a rotation of a given angle around a given axis.
        /// </summary>
        /// <param name="axis">Axis around which to rotate.</param>
        /// <param name="angle">Amount to rotate.</param>
        /// <param name="result">Matrix representing the rotation.</param>
        public static void CreateFromAxisAngle(ref FixVector3 axis, Fix64 angle, out FixMatrix3x3 result)
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

            result.m12 = axis.z * sinAngle + oneMinusCosAngle * xy;
            result.m22 = F64.C1 + oneMinusCosAngle * (yy - F64.C1);
            result.m32 = -axis.x * sinAngle + oneMinusCosAngle * yz;

            result.m13 = -axis.y * sinAngle + oneMinusCosAngle * xz;
            result.m23 = axis.x * sinAngle + oneMinusCosAngle * yz;
            result.m33 = F64.C1 + oneMinusCosAngle * (zz - F64.C1);
        }






    }
}