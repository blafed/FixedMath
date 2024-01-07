namespace FixedMath
{
    public struct FixVector2
    {
        public Fix64 x;
        public Fix64 y;

        public override bool Equals(object obj)
        {
            if (obj is FixVector2)
            {
                return this == (FixVector2)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }

        public static readonly FixVector2 zero = new FixVector2(Fix64.Zero, Fix64.Zero);
        public static readonly FixVector2 one = new FixVector2(Fix64.One, Fix64.One);
        public static readonly FixVector2 up = new FixVector2(Fix64.Zero, Fix64.One);
        public static readonly FixVector2 down = new FixVector2(Fix64.Zero, -Fix64.One);
        public static readonly FixVector2 left = new FixVector2(-Fix64.One, Fix64.Zero);
        public static readonly FixVector2 right = new FixVector2(Fix64.One, Fix64.Zero);


        public Fix64 magnitude
        {
            get
            {
                return FixMath.Sqrt(x * x + y * y);
            }
        }

        public Fix64 sqrMagnitude
        {
            get
            {
                return x * x + y * y;
            }
        }

        public FixVector2 normalized
        {
            get
            {
                Fix64 magnitude = this.magnitude;
                if (magnitude > Fix64.Zero)
                {
                    return this / magnitude;
                }
                return FixVector2.zero;
            }
        }



        public FixVector2(Fix64 x, Fix64 y)
        {
            this.x = x;
            this.y = y;
        }

        public static FixVector2 operator +(FixVector2 a, FixVector2 b)
        {
            return new FixVector2(a.x + b.x, a.y + b.y);
        }

        public static FixVector2 operator -(FixVector2 a, FixVector2 b)
        {
            return new FixVector2(a.x - b.x, a.y - b.y);
        }

        public static FixVector2 operator *(FixVector2 a, Fix64 b)
        {
            return new FixVector2(a.x * b, a.y * b);
        }

        public static FixVector2 operator *(Fix64 b, FixVector2 a)
        {
            return new FixVector2(a.x * b, a.y * b);
        }

        public static FixVector2 operator /(FixVector2 a, Fix64 b)
        {
            return new FixVector2(a.x / b, a.y / b);
        }

        public static FixVector2 operator /(Fix64 b, FixVector2 a)
        {
            return new FixVector2(a.x / b, a.y / b);
        }

        public static FixVector2 operator -(FixVector2 a)
        {
            return new FixVector2(-a.x, -a.y);
        }

        public static bool operator ==(FixVector2 a, FixVector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(FixVector2 a, FixVector2 b)
        {
            return a.x != b.x || a.y != b.y;
        }

        public static Fix64 Dot(FixVector2 a, FixVector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static Fix64 Cross(FixVector2 a, FixVector2 b)
        {
            return a.x * b.y - a.y * b.x;
        }

        public static FixVector2 Cross(Fix64 a, FixVector2 b)
        {
            return new FixVector2(a * b.y, -a * b.x);
        }

        public static FixVector2 Cross(FixVector2 a, Fix64 b)
        {
            return new FixVector2(-b * a.y, b * a.x);
        }

        public static FixVector2 Min(FixVector2 a, FixVector2 b)
        {
            return new FixVector2(FixMath.Min(a.x, b.x), FixMath.Min(a.y, b.y));
        }

        public static FixVector2 Max(FixVector2 a, FixVector2 b)
        {
            return new FixVector2(FixMath.Max(a.x, b.x), FixMath.Max(a.y, b.y));
        }

        public static FixVector2 Clamp(FixVector2 a, FixVector2 min, FixVector2 max)
        {
            return new FixVector2(FixMath.Clamp(a.x, min.x, max.x), FixMath.Clamp(a.y, min.y, max.y));
        }

        public static FixVector2 Clamp01(FixVector2 a)
        {
            return new FixVector2(FixMath.Clamp01(a.x), FixMath.Clamp01(a.y));
        }

        public static FixVector2 Lerp(FixVector2 a, FixVector2 b, Fix64 t)
        {
            return new FixVector2(FixMath.Lerp(a.x, b.x, t), FixMath.Lerp(a.y, b.y, t));
        }

        public static FixVector2 LerpUnclamped(FixVector2 a, FixVector2 b, Fix64 t)
        {
            return new FixVector2(FixMath.LerpUnclamped(a.x, b.x, t), FixMath.LerpUnclamped(a.y, b.y, t));
        }

        public static FixVector2 MoveTowards(FixVector2 current, FixVector2 target, Fix64 maxDistanceDelta)
        {
            FixVector2 a = target - current;
            Fix64 magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == Fix64.Zero)
            {
                return target;
            }
            return current + a / magnitude * maxDistanceDelta;
        }

        public static FixVector2 Reflect(FixVector2 inDirection, FixVector2 inNormal)
        {
            return -FixVector2.Dot(inNormal, inDirection) * inNormal * Fix64.Two + inDirection;
        }

        public static FixVector2 Perpendicular(FixVector2 inDirection)
        {
            return new FixVector2(-inDirection.y, inDirection.x);
        }

        public static FixVector2 Scale(FixVector2 a, FixVector2 b)
        {
            return new FixVector2(a.x * b.x, a.y * b.y);
        }

        public static Fix64 Angle(FixVector2 from, FixVector2 to)
        {
            return Fix64.Acos(FixVector2.Dot(from.normalized, to.normalized)) * FixMath.Rad2Deg;
        }

        public static Fix64 Distance(FixVector2 a, FixVector2 b)
        {
            return (a - b).magnitude;
        }

        public static Fix64 SqrDistance(FixVector2 a, FixVector2 b)
        {
            return (a - b).sqrMagnitude;
        }

        public static FixVector2 FromAngle(Fix64 angle)
        {
            return new FixVector2(FixMath.Cos(angle * FixMath.Deg2Rad), FixMath.Sin(angle * FixMath.Deg2Rad));
        }

        public static FixVector2 FromAngle(Fix64 angle, Fix64 magnitude)
        {
            return new FixVector2(FixMath.Cos(angle * FixMath.Deg2Rad), FixMath.Sin(angle * FixMath.Deg2Rad)) * magnitude;
        }






    }
}