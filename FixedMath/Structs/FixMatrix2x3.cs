namespace FixedMath
{
    /// <summary>
    /// 2 row, 3 column matrix.
    /// </summary>
    public struct FixMatrix2x3
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
        /// Value at row 1, column 2 of the matrix.
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
        /// Constructs a new 2 row, 2 column matrix.
        /// </summary>
        /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
        /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
        /// <param name="m13">Value at row 1, column 3 of the matrix.</param>
        /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
        /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
        /// <param name="m23">Value at row 2, column 3 of the matrix.</param>
        public FixMatrix2x3(Fix64 m11, Fix64 m12, Fix64 m13, Fix64 m21, Fix64 m22, Fix64 m23)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
        }

        /// <summary>
        /// Adds the two matrices together on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to add.</param>
        /// <param name="b">Second matrix to add.</param>
        /// <param name="result">Sum of the two matrices.</param>
        public static void Add(ref FixMatrix2x3 a, ref FixMatrix2x3 b, out FixMatrix2x3 result)
        {
            Fix64 m11 = a.m11 + b.m11;
            Fix64 m12 = a.m12 + b.m12;
            Fix64 m13 = a.m13 + b.m13;

            Fix64 m21 = a.m21 + b.m21;
            Fix64 m22 = a.m22 + b.m22;
            Fix64 m23 = a.m23 + b.m23;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;
        }


        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref FixMatrix2x3 a, ref FixMatrix3x3 b, out FixMatrix2x3 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32;
            Fix64 resultM13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32;
            Fix64 resultM23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;
        }

        /// <summary>
        /// Multiplies the two matrices.
        /// </summary>
        /// <param name="a">First matrix to multiply.</param>
        /// <param name="b">Second matrix to multiply.</param>
        /// <param name="result">Product of the multiplication.</param>
        public static void Multiply(ref FixMatrix2x3 a, ref FixMatrix4x4 b, out FixMatrix2x3 result)
        {
            Fix64 resultM11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31;
            Fix64 resultM12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32;
            Fix64 resultM13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33;

            Fix64 resultM21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31;
            Fix64 resultM22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32;
            Fix64 resultM23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33;

            result.m11 = resultM11;
            result.m12 = resultM12;
            result.m13 = resultM13;

            result.m21 = resultM21;
            result.m22 = resultM22;
            result.m23 = resultM23;
        }

        /// <summary>
        /// Negates every element in the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to negate.</param>
        /// <param name="result">Negated matrix.</param>
        public static void Negate(ref FixMatrix2x3 matrix, out FixMatrix2x3 result)
        {
            Fix64 m11 = -matrix.m11;
            Fix64 m12 = -matrix.m12;
            Fix64 m13 = -matrix.m13;

            Fix64 m21 = -matrix.m21;
            Fix64 m22 = -matrix.m22;
            Fix64 m23 = -matrix.m23;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;
        }

        /// <summary>
        /// Subtracts the two matrices from each other on a per-element basis.
        /// </summary>
        /// <param name="a">First matrix to subtract.</param>
        /// <param name="b">Second matrix to subtract.</param>
        /// <param name="result">Difference of the two matrices.</param>
        public static void Subtract(ref FixMatrix2x3 a, ref FixMatrix2x3 b, out FixMatrix2x3 result)
        {
            Fix64 m11 = a.m11 - b.m11;
            Fix64 m12 = a.m12 - b.m12;
            Fix64 m13 = a.m13 - b.m13;

            Fix64 m21 = a.m21 - b.m21;
            Fix64 m22 = a.m22 - b.m22;
            Fix64 m23 = a.m23 - b.m23;

            result.m11 = m11;
            result.m12 = m12;
            result.m13 = m13;

            result.m21 = m21;
            result.m22 = m22;
            result.m23 = m23;
        }


        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.  Considered to be a row vector for purposes of multiplication.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Row vector product of the transformation.</param>
        public static void Transform(ref FixVector2 v, ref FixMatrix2x3 matrix, out FixVector3 result)
        {
#if !WINDOWS
            result = new FixVector3();
#endif
            result.x = v.x * matrix.m11 + v.y * matrix.m21;
            result.y = v.x * matrix.m12 + v.y * matrix.m22;
            result.z = v.x * matrix.m13 + v.y * matrix.m23;
        }

        /// <summary>
        /// Transforms the vector by the matrix.
        /// </summary>
        /// <param name="v">Vector2 to transform.  Considered to be a column vector for purposes of multiplication.</param>
        /// <param name="matrix">Matrix to use as the transformation.</param>
        /// <param name="result">Column vector product of the transformation.</param>
        public static void Transform(ref FixVector3 v, ref FixMatrix2x3 matrix, out FixVector2 result)
        {
#if !WINDOWS
            result = new FixVector2();
#endif
            result.x = matrix.m11 * v.x + matrix.m12 * v.y + matrix.m13 * v.z;
            result.y = matrix.m21 * v.x + matrix.m22 * v.y + matrix.m23 * v.z;
        }


        /// <summary>
        /// Computes the transposed matrix of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to transpose.</param>
        /// <param name="result">Transposed matrix.</param>
        public static void Transpose(ref FixMatrix2x3 matrix, out FixMatrix3x2 result)
        {
            result.m11 = matrix.m11;
            result.m12 = matrix.m21;

            result.m21 = matrix.m12;
            result.m22 = matrix.m22;

            result.m31 = matrix.m13;
            result.m32 = matrix.m23;
        }


        /// <summary>
        /// Creates a string representation of the matrix.
        /// </summary>
        /// <returns>A string representation of the matrix.</returns>
        public override string ToString()
        {
            return "{" + m11 + ", " + m12 + ", " + m13 + "} " +
                   "{" + m21 + ", " + m22 + ", " + m23 + "}";
        }
    }
}