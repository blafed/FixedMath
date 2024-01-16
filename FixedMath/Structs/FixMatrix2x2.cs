/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/Matrix2x2.cs
*/
namespace FixedMath
{
    /// <summary>
    /// 2 row, 2 column matrix.
    /// </summary>
    public struct FixMatrix2x2
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
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public Fix64 m21;

        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public Fix64 M22;


        /// <summary>
        /// Constructs a new 2 row, 2 column matrix.
        /// </summary>
        /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
        /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
        /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
        public FixMatrix2x2(Fix64 m11, Fix64 m12, Fix64 m21, Fix64 m22)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m21 = m21;
            M22 = m22;
        }

        /// <summary>
        /// Gets the 2x2 identity matrix.
        /// </summary>
        public static FixMatrix2x2 Identity
        {
            get { return new FixMatrix2x2(F64.C1, F64.C0, F64.C0, F64.C1); }
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(in FixMatrix2x2 a, in FixMatrix2x2 b, out FixMatrix2x2 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.M22 + b.M22;

            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(in FixMatrix4x4 a, in FixMatrix2x2 b, out FixMatrix2x2 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.M22;

            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(in FixMatrix2x2 a, in FixMatrix4x4 b, out FixMatrix2x2 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.M22 + b.m22;

            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(in FixMatrix4x4 a, in FixMatrix4x4 b, out FixMatrix2x2 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.m22;

            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Constructs a uniform scaling matrix.
        /// </summary>
        /// <param name="scale">Value to use in the diagonal.</param>
        /// <param name="matrix">Scaling matrix.</param>
        public static void CreateScale(Fix64 scale, out FixMatrix2x2 matrix)
        {
            matrix.m11 = scale;
            matrix.M22 = scale;

            matrix.m12 = F64.C0;
            matrix.m21 = F64.C0;
        }


        /// <summary>
        /// Inverts the given matix.
        /// </summary>
        /// <param name="matrix">Matrix to be inverted.</param>
        /// <param name="result">Inverted matrix.</param>
        public static void Invert(in FixMatrix2x2 matrix, out FixMatrix2x2 result)
        {
            Fix64 determinantInverse = F64.C1 / (matrix.m11 * matrix.M22 - matrix.m12 * matrix.m21);
            Fix64 m11 = matrix.M22 * determinantInverse;
            Fix64 m12 = -matrix.m12 * determinantInverse;

            Fix64 m21 = -matrix.m21 * determinantInverse;
            Fix64 m22 = matrix.m11 * determinantInverse;

            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(in FixMatrix2x2 a, in FixMatrix2x2 b, out FixMatrix2x2 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.M22;

            Fix64 resultM21 = a.m21 * b.m11 + a.M22 * b.m21;
            Fix64 resultM22 = a.m21 * b.m12 + a.M22 * b.M22;

            result.m11 = resultM11;
            result.m12 = resultM12;

            result.m21 = resultM21;
            result.M22 = resultM22;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(in FixMatrix2x2 a, in FixMatrix4x4 b, out FixMatrix2x2 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22;

            Fix64 resultM21 = a.m21 * b.m11 + a.M22 * b.m21;
            Fix64 resultM22 = a.m21 * b.m12 + a.M22 * b.m22;

            result.m11 = resultM11;
            result.m12 = resultM12;

            result.m21 = resultM21;
            result.M22 = resultM22;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(in FixMatrix4x4 a, in FixMatrix2x2 b, out FixMatrix2x2 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.M22;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.M22;

            result.m11 = resultM11;
            result.m12 = resultM12;

            result.m21 = resultM21;
            result.M22 = resultM22;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(in FixMatrix2x3 a, in FixMatrix3x2 b, out FixMatrix2x2 result)
        {
            result.m11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31;
            result.m12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32;

            result.m21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31;
            result.M22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(in FixMatrix2x2 matrix, out FixMatrix2x2 result)
        {
            Fix64 m11 = -matrix.m11;
            Fix64 m12 = -matrix.m12;

            Fix64 m21 = -matrix.m21;
            Fix64 m22 = -matrix.M22;


            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to subtract.</param>
        /// <param name="b">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(in FixMatrix2x2 a, in FixMatrix2x2 b, out FixMatrix2x2 result)
        {
            Fix64 m11 = a.m11 - b.m11;
            Fix64 m12 = a.m12 - b.m12;

            Fix64 m21 = a.m21 - b.m21;
            Fix64 m22 = a.M22 - b.M22;

            result.m11 = m11;
            result.m12 = m12;

            result.m21 = m21;
            result.M22 = m22;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Product of the transformation.</param>
        public static void Transform(in FixVector2 v, in FixMatrix2x2 matrix, out FixVector2 result)
        {
            Fix64 vX = v.x;
            Fix64 vY = v.y;
#if !WINDOWS
            result = new FixVector2();
#endif
            result.x = vX * matrix.m11 + vY * matrix.m21;
            result.y = vX * matrix.m12 + vY * matrix.M22;
        }

        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <param name="result">Transposed matrix.</param>
        public static void Transpose(in FixMatrix2x2 matrix, out FixMatrix2x2 result)
        {
            Fix64 m21 = matrix.m12;

            result.m11 = matrix.m11;
            result.m12 = matrix.m21;

            result.m21 = m21;
            result.M22 = matrix.M22;
        }

        /// <summary>
        /// Transposes the matrix in-place.
        /// </summary>
        public void Transpose()
        {
            Fix64 m21 = this.m21;
            this.m21 = m12;
            m12 = m21;
        }

        /// <summary>
        /// Creates a string representation of the matrix.
        /// </summary>
        /// <returns>A string representation of the matrix.</returns>
        public override string ToString()
        {
            return "{" + m11 + ", " + m12 + "} " +
                   "{" + m21 + ", " + M22 + "}";
        }

        /// <summary>
        /// Calculates the determinant of the matrix.
        /// </summary>
        /// <returns>The matrix's determinant.</returns>
        public Fix64 Determinant()
        {
            return m11 * M22 - m12 * m21;
        }
    }
}