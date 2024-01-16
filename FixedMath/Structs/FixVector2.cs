/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/Vector2.cs
*/
using System;

namespace FixedMath
{
    /// <summary>
    /// Provides XNA-like 2D vector math.
    /// </summary>
    public struct FixVector2 : IEquatable<FixVector2>
    {
        /// <summary>
        /// X component of the vector.
        /// </summary>
        public Fix64 x;
        /// <summary>
        /// Y component of the vector.
        /// </summary>
        public Fix64 y;


        public Fix64 magitude => Fix64.Sqrt(x * x + y * y);
        public Fix64 sqrMagnitude => x * x + y * y;
        public FixVector2 normalized => Normalize(this);

        /// <summary>
        /// Constructs a new two dimensional vector.
        /// </summary>
        /// <param name="x">X component of the vector.</param>
        /// <param name="y">Y component of the vector.</param>
        public FixVector2(Fix64 x, Fix64 y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Computes the squared length of the vector.
        /// </summary>
        /// <returns>Squared length of the vector.</returns>
        public Fix64 LengthSquared()
        {
            return x * x + y * y;
        }

        /// <summary>
        /// Computes the length of the vector.
        /// </summary>
        /// <returns>Length of the vector.</returns>
        public Fix64 Length()
        {
            return Fix64.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Gets a string representation of the vector.
        /// </summary>
        /// <returns>String representing the vector.</returns>
        public override string ToString()
        {
            return "{" + x + ", " + y + "}";
        }

        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="a">First vector to add.</param>
        /// <param name="b">Second vector to add.</param>
        /// <param name="sum">Sum of the two vectors.</param>
        public static void Add(in FixVector2 a, in FixVector2 b, out FixVector2 sum)
        {
            sum.x = a.x + b.x;
            sum.y = a.y + b.y;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="a">Vector to subtract from.</param>
        /// <param name="b">Vector to subtract from the first vector.</param>
        /// <param name="difference">Result of the subtraction.</param>
        public static void Subtract(in FixVector2 a, in FixVector2 b, out FixVector2 difference)
        {
            difference.x = a.x - b.x;
            difference.y = a.y - b.y;
        }

        /// <summary>
        /// Scales a vector.
        /// </summary>
        /// <param name="v">Vector to scale.</param>
        /// <param name="scale">Amount to scale.</param>
        /// <param name="result">Scaled vector.</param>
        public static void Multiply(in FixVector2 v, Fix64 scale, out FixVector2 result)
        {
            result.x = v.x * scale;
            result.y = v.y * scale;
        }

        /// <summary>
        /// Multiplies two vectors on a per-component basis.
        /// </summary>
        /// <param name="a">First vector to multiply.</param>
        /// <param name="b">Second vector to multiply.</param>
        /// <param name="result">Result of the componentwise multiplication.</param>
        public static void Multiply(in FixVector2 a, in FixVector2 b, out FixVector2 result)
        {
            result.x = a.x * b.x;
            result.y = a.y * b.y;
        }

        /// <summary>
        /// Divides a vector's components by some amount.
        /// </summary>
        /// <param name="v">Vector to divide.</param>
        /// <param name="divisor">Value to divide the vector's components.</param>
        /// <param name="result">Result of the division.</param>
        public static void Divide(in FixVector2 v, Fix64 divisor, out FixVector2 result)
        {
            Fix64 inverse = F64.C1 / divisor;
            result.x = v.x * inverse;
            result.y = v.y * inverse;
        }

        /// <summary>
        /// Computes the dot product of the two vectors.
        /// </summary>
        /// <param name="a">First vector of the dot product.</param>
        /// <param name="b">Second vector of the dot product.</param>
        /// <param name="dot">Dot product of the two vectors.</param>
        public static void Dot(in FixVector2 a, in FixVector2 b, out Fix64 dot)
        {
            dot = a.x * b.x + a.y * b.y;
        }

        /// <summary>
        /// Computes the dot product of the two vectors.
        /// </summary>
        /// <param name="a">First vector of the dot product.</param>
        /// <param name="b">Second vector of the dot product.</param>
        /// <returns>Dot product of the two vectors.</returns>
        public static Fix64 Dot(FixVector2 a, FixVector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        /// <summary>
        /// Gets the zero vector.
        /// </summary>
        public static FixVector2 Zero
        {
            get
            {
                return new FixVector2();
            }
        }

        /// <summary>
        /// Gets a vector pointing along the X axis.
        /// </summary>
        public static FixVector2 UnitX
        {
            get { return new FixVector2 { x = F64.C1 }; }
        }

        /// <summary>
        /// Gets a vector pointing along the Y axis.
        /// </summary>
        public static FixVector2 UnitY
        {
            get { return new FixVector2 { y = F64.C1 }; }
        }


        /// <summary>
        /// Normalizes the vector.
        /// </summary>
        /// <param name="v">Vector to normalize.</param>
        /// <returns>Normalized copy of the vector.</returns>
        public static FixVector2 Normalize(FixVector2 v)
        {
            FixVector2 toReturn;
            FixVector2.Normalize(in v, out toReturn);
            return toReturn;
        }

        /// <summary>
        /// Normalizes the vector.
        /// </summary>
        /// <param name="v">Vector to normalize.</param>
        /// <param name="result">Normalized vector.</param>
        public static void Normalize(in FixVector2 v, out FixVector2 result)
        {
            Fix64 inverse = F64.C1 / Fix64.Sqrt(v.x * v.x + v.y * v.y);
            result.x = v.x * inverse;
            result.y = v.y * inverse;
        }

        /// <summary>
        /// Negates the vector.
        /// </summary>
        /// <param name="v">Vector to negate.</param>
        /// <param name="negated">Negated version of the vector.</param>
        public static void Negate(in FixVector2 v, out FixVector2 negated)
        {
            negated.x = -v.x;
            negated.y = -v.y;
        }

        /// <summary>
        /// Computes the absolute value of the input vector.
        /// </summary>
        /// <param name="v">Vector to take the absolute value of.</param>
        /// <param name="result">Vector with nonnegative elements.</param>
        public static void Abs(in FixVector2 v, out FixVector2 result)
        {
            if (v.x < F64.C0)
                result.x = -v.x;
            else
                result.x = v.x;
            if (v.y < F64.C0)
                result.y = -v.y;
            else
                result.y = v.y;
        }

        /// <summary>
        /// Computes the absolute value of the input vector.
        /// </summary>
        /// <param name="v">Vector to take the absolute value of.</param>
        /// <returns>Vector with nonnegative elements.</returns>
        public static FixVector2 Abs(FixVector2 v)
        {
            FixVector2 result;
            Abs(in v, out result);
            return result;
        }

        /// <summary>
        /// Creates a vector from the lesser values in each vector.
        /// </summary>
        /// <param name="a">First input vector to compare values from.</param>
        /// <param name="b">Second input vector to compare values from.</param>
        /// <param name="min">Vector containing the lesser values of each vector.</param>
        public static void Min(in FixVector2 a, in FixVector2 b, out FixVector2 min)
        {
            min.x = a.x < b.x ? a.x : b.x;
            min.y = a.y < b.y ? a.y : b.y;
        }

        /// <summary>
        /// Creates a vector from the lesser values in each vector.
        /// </summary>
        /// <param name="a">First input vector to compare values from.</param>
        /// <param name="b">Second input vector to compare values from.</param>
        /// <returns>Vector containing the lesser values of each vector.</returns>
        public static FixVector2 Min(FixVector2 a, FixVector2 b)
        {
            FixVector2 result;
            Min(in a, in b, out result);
            return result;
        }


        /// <summary>
        /// Creates a vector from the greater values in each vector.
        /// </summary>
        /// <param name="a">First input vector to compare values from.</param>
        /// <param name="b">Second input vector to compare values from.</param>
        /// <param name="max">Vector containing the greater values of each vector.</param>
        public static void Max(in FixVector2 a, in FixVector2 b, out FixVector2 max)
        {
            max.x = a.x > b.x ? a.x : b.x;
            max.y = a.y > b.y ? a.y : b.y;
        }

        /// <summary>
        /// Creates a vector from the greater values in each vector.
        /// </summary>
        /// <param name="a">First input vector to compare values from.</param>
        /// <param name="b">Second input vector to compare values from.</param>
        /// <returns>Vector containing the greater values of each vector.</returns>
        public static FixVector2 Max(FixVector2 a, FixVector2 b)
        {
            FixVector2 result;
            Max(in a, in b, out result);
            return result;
        }

        /// <summary>
        /// Normalizes the vector.
        /// </summary>
        public void Normalize()
        {
            Fix64 inverse = F64.C1 / Fix64.Sqrt(x * x + y * y);
            x *= inverse;
            y *= inverse;
        }

        /// <summary>
        /// Scales a vector.
        /// </summary>
        /// <param name="v">Vector to scale.</param>
        /// <param name="f">Amount to scale.</param>
        /// <returns>Scaled vector.</returns>
        public static FixVector2 operator *(FixVector2 v, Fix64 f)
        {
            FixVector2 toReturn;
            toReturn.x = v.x * f;
            toReturn.y = v.y * f;
            return toReturn;
        }
        /// <summary>
        /// Scales a vector.
        /// </summary>
        /// <param name="v">Vector to scale.</param>
        /// <param name="f">Amount to scale.</param>
        /// <returns>Scaled vector.</returns>
        public static FixVector2 operator *(Fix64 f, FixVector2 v)
        {
            FixVector2 toReturn;
            toReturn.x = v.x * f;
            toReturn.y = v.y * f;
            return toReturn;
        }

        /// <summary>
        /// Multiplies two vectors on a per-component basis.
        /// </summary>
        /// <param name="a">First vector to multiply.</param>
        /// <param name="b">Second vector to multiply.</param>
        /// <returns>Result of the componentwise multiplication.</returns>
        public static FixVector2 operator *(FixVector2 a, FixVector2 b)
        {
            FixVector2 result;
            Multiply(in a, in b, out result);
            return result;
        }

        /// <summary>
        /// Divides a vector.
        /// </summary>
        /// <param name="v">Vector to divide.</param>
        /// <param name="f">Amount to divide.</param>
        /// <returns>Divided vector.</returns>
        public static FixVector2 operator /(FixVector2 v, Fix64 f)
        {
            FixVector2 toReturn;
            f = F64.C1 / f;
            toReturn.x = v.x * f;
            toReturn.y = v.y * f;
            return toReturn;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="a">Vector to be subtracted from.</param>
        /// <param name="b">Vector to subtract from the first vector.</param>
        /// <returns>Resulting difference.</returns>
        public static FixVector2 operator -(FixVector2 a, FixVector2 b)
        {
            FixVector2 v;
            v.x = a.x - b.x;
            v.y = a.y - b.y;
            return v;
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">First vector to add.</param>
        /// <param name="b">Second vector to add.</param>
        /// <returns>Sum of the addition.</returns>
        public static FixVector2 operator +(FixVector2 a, FixVector2 b)
        {
            FixVector2 v;
            v.x = a.x + b.x;
            v.y = a.y + b.y;
            return v;
        }

        /// <summary>
        /// Negates the vector.
        /// </summary>
        /// <param name="v">Vector to negate.</param>
        /// <returns>Negated vector.</returns>
        public static FixVector2 operator -(FixVector2 v)
        {
            v.x = -v.x;
            v.y = -v.y;
            return v;
        }

        /// <summary>
        /// Tests two vectors for componentwise equivalence.
        /// </summary>
        /// <param name="a">First vector to test for equivalence.</param>
        /// <param name="b">Second vector to test for equivalence.</param>
        /// <returns>Whether the vectors were equivalent.</returns>
        public static bool operator ==(FixVector2 a, FixVector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }
        /// <summary>
        /// Tests two vectors for componentwise inequivalence.
        /// </summary>
        /// <param name="a">First vector to test for inequivalence.</param>
        /// <param name="b">Second vector to test for inequivalence.</param>
        /// <returns>Whether the vectors were inequivalent.</returns>
        public static bool operator !=(FixVector2 a, FixVector2 b)
        {
            return a.x != b.x || a.y != b.y;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(FixVector2 other)
        {
            return x == other.x && y == other.y;
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
            if (obj is FixVector2)
            {
                return Equals((FixVector2)obj);
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
            return x.GetHashCode() + y.GetHashCode();
        }


    }
}
