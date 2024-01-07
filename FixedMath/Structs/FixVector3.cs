namespace FixedMath
{
    public struct FixVector3
    {
        public Fix64 x;
        public Fix64 y;
        public Fix64 z;

        public FixVector3(Fix64 x, Fix64 y, Fix64 z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is FixVector3)
            {
                return this == (FixVector3)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }

        public static readonly FixVector3 zero = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);
        public static readonly FixVector3 one = new FixVector3(Fix64.One, Fix64.One, Fix64.One);
        public static readonly FixVector3 up = new FixVector3(Fix64.Zero, Fix64.One, Fix64.Zero);
        public static readonly FixVector3 down = new FixVector3(Fix64.Zero, -Fix64.One, Fix64.Zero);
        public static readonly FixVector3 left = new FixVector3(-Fix64.One, Fix64.Zero, Fix64.Zero);
        public static readonly FixVector3 right = new FixVector3(Fix64.One, Fix64.Zero, Fix64.Zero);
        public static readonly FixVector3 forward = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.One);
        public static readonly FixVector3 back = new FixVector3(Fix64.Zero, Fix64.Zero, -Fix64.One);


        public Fix64 magnitude
        {
            get
            {
                return FixMath.Sqrt(x * x + y * y + z * z);
            }
        }

        public Fix64 sqrMagnitude
        {
            get
            {
                return x * x + y * y + z * z;
            }
        }

        public FixVector3 normalized
        {
            get
            {
                Fix64 magnitude = this.magnitude;
                if (magnitude > Fix64.Zero)
                {
                    return this / magnitude;
                }
                return FixVector3.zero;
            }
        }

        public static FixVector3 operator +(FixVector3 a, FixVector3 b)
        {
            return new FixVector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static FixVector3 operator -(FixVector3 a, FixVector3 b)
        {
            return new FixVector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static FixVector3 operator -(FixVector3 a)
        {
            return new FixVector3(-a.x, -a.y, -a.z);
        }

        public static FixVector3 operator *(FixVector3 a, Fix64 d)
        {
            return new FixVector3(a.x * d, a.y * d, a.z * d);
        }

        public static FixVector3 operator *(Fix64 d, FixVector3 a)
        {
            return new FixVector3(a.x * d, a.y * d, a.z * d);
        }

        public static FixVector3 operator /(FixVector3 a, Fix64 d)
        {
            return new FixVector3(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(FixVector3 lhs, FixVector3 rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
        }

        public static bool operator !=(FixVector3 lhs, FixVector3 rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z;
        }

        public static Fix64 Dot(FixVector3 lhs, FixVector3 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        public static FixVector3 Cross(FixVector3 lhs, FixVector3 rhs)
        {
            return new FixVector3(
                lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.z * rhs.x - lhs.x * rhs.z,
                lhs.x * rhs.y - lhs.y * rhs.x);
        }

        public static FixVector3 Normalize(FixVector3 value)
        {
            Fix64 magnitude = value.magnitude;
            if (magnitude > Fix64.Zero)
            {
                return value / magnitude;
            }
            return FixVector3.zero;
        }

        public static FixVector3 Lerp(FixVector3 from, FixVector3 to, Fix64 t)
        {
            t = FixMath.Clamp(t, Fix64.Zero, Fix64.One);
            return new FixVector3(
                FixMath.Lerp(from.x, to.x, t),
                FixMath.Lerp(from.y, to.y, t),
                FixMath.Lerp(from.z, to.z, t));
        }

        public static FixVector3 LerpUnclamped(FixVector3 from, FixVector3 to, Fix64 t)
        {
            return new FixVector3(
                FixMath.LerpUnclamped(from.x, to.x, t),
                FixMath.LerpUnclamped(from.y, to.y, t),
                FixMath.LerpUnclamped(from.z, to.z, t));
        }

        public static FixVector3 MoveTowards(FixVector3 current, FixVector3 target, Fix64 maxDistanceDelta)
        {
            FixVector3 a = target - current;
            Fix64 magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == Fix64.Zero)
            {
                return target;
            }
            return current + a / magnitude * maxDistanceDelta;
        }

        public static FixVector3 Min(FixVector3 lhs, FixVector3 rhs)
        {
            return new FixVector3(
                FixMath.Min(lhs.x, rhs.x),
                FixMath.Min(lhs.y, rhs.y),
                FixMath.Min(lhs.z, rhs.z));
        }

        public static FixVector3 Max(FixVector3 lhs, FixVector3 rhs)
        {
            return new FixVector3(
                FixMath.Max(lhs.x, rhs.x),
                FixMath.Max(lhs.y, rhs.y),
                FixMath.Max(lhs.z, rhs.z));
        }

        public static FixVector3 Scale(FixVector3 a, FixVector3 b)
        {
            return new FixVector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Fix64 Distance(FixVector3 a, FixVector3 b)
        {
            FixVector3 vector = new FixVector3(a.x - b.x, a.y - b.y, a.z - b.z);
            return FixMath.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static Fix64 SqrDistance(FixVector3 a, FixVector3 b)
        {
            FixVector3 vector = new FixVector3(a.x - b.x, a.y - b.y, a.z - b.z);
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
        }

        public static FixVector3 Project(FixVector3 vector, FixVector3 onNormal)
        {
            Fix64 num = Dot(onNormal, onNormal);
            if (num < FixMath.Epsilon)
            {
                return FixVector3.zero;
            }
            return onNormal * Dot(vector, onNormal) / num;
        }

        public static FixVector3 ProjectOnPlane(FixVector3 vector, FixVector3 planeNormal)
        {
            return vector - Project(vector, planeNormal);
        }


        public static FixVector3 Reflect(FixVector3 inDirection, FixVector3 inNormal)
        {
            return 2 * Dot(inNormal, inDirection) * inNormal + inDirection;
        }


        // public static FixVector3 RotateTowards(FixVector3 current, FixVector3 target, Fix64 maxRadiansDelta, Fix64 maxMagnitudeDelta)
        // {
        //     FixVector3 result;
        //     RotateTowards(ref current, ref target, maxRadiansDelta, maxMagnitudeDelta, out result);
        //     return result;
        // }

        // public static void RotateTowards(ref FixVector3 current, ref FixVector3 target, Fix64 maxRadiansDelta, Fix64 maxMagnitudeDelta, out FixVector3 result)
        // {
        //     Fix64 magnitude = current.magnitude;
        //     Fix64 magnitude2 = target.magnitude;
        //     if (magnitude > Fix64.Epsilon && magnitude2 > Fix64.Epsilon)
        //     {
        //         FixVector3 fixVector = current / magnitude;
        //         FixVector3 fixVector2 = target / magnitude2;
        //         Fix64 num = Dot(fixVector, fixVector2);
        //         if (num > Fix64.One - Fix64.Epsilon)
        //         {
        //             result = Lerp(current, target, Fix64.One);
        //         }
        //         else if (num < Fix64.Epsilon - Fix64.One)
        //         {
        //             FixVector3 axis = Cross(fixVector, fixVector2);
        //             Fix64 num2 = maxRadiansDelta * Fix64.One;
        //             if (num < Fix64.Zero)
        //             {
        //                 num2 = Fix64.Pi - num2;
        //             }
        //             FixQuaternion fixQuaternion = FixQuaternion.AngleAxis(num2 * Fix64.Rad2Deg, axis);
        //             FixVector3 vector = fixQuaternion * fixVector;
        //             Fix64 num3 = magnitude + (magnitude2 - magnitude) * maxMagnitudeDelta;
        //             result = vector * num3;
        //         }
        //         else
        //         {
        //             Fix64 num4 = FixMath.Acos(num);
        //             Fix64 num5 = maxRadiansDelta * Fix64.One;
        //             if (num4 < num5 && num4 > -num5)
        //             {
        //                 result = Lerp(current, target, Fix64.One);
        //             }
        //             else
        //             {
        //                 FixVector3 axis2 = Cross(fixVector, fixVector2);
        //                 FixQuaternion fixQuaternion2 = FixQuaternion.AngleAxis(FixMath.Min(num5 * Fix64.Rad2Deg, num4) * Fix64.Rad2Deg, axis2);
        //                 FixVector3 vector2 = fixQuaternion2 * fixVector;
        //                 Fix64 num6 = magnitude + (magnitude2 - magnitude) * maxMagnitudeDelta;
        //                 result = vector2 * num6;
        //             }
        //         }
        //         return;
        //     }
        //     result = Lerp(current, target, Fix64.One);
        // }
    }
}