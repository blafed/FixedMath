namespace FixedMath
{
    public partial struct Fix64
    {
        public static readonly Fix64 Deg2Rad = (Fix64)0.0174532924M;
        public static readonly Fix64 Rad2Deg = (Fix64)57.29578M;
        public static readonly Fix64 Epsilon = (Fix64)0.00001M;



        public static Fix64 Min(Fix64 a, Fix64 b)
        {
            if (a < b)
            {
                return a;
            }
            return b;
        }

        public static Fix64 Max(Fix64 a, Fix64 b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }

        public static Fix64 Clamp(Fix64 a, Fix64 min, Fix64 max)
        {
            if (a < min)
            {
                return min;
            }
            if (a > max)
            {
                return max;
            }
            return a;
        }

        public static Fix64 Clamp01(Fix64 a)
        {
            if (a > Fix64.One)
            {
                return Fix64.One;
            }
            if (a < Fix64.Zero)
            {
                return Fix64.Zero;
            }
            return a;
        }

        public static Fix64 Lerp(Fix64 a, Fix64 b, Fix64 t)
        {
            t = Clamp01(t);
            return a + (b - a) * t;
        }

        public static Fix64 LerpUnclamped(Fix64 a, Fix64 b, Fix64 t)
        {
            return a + (b - a) * t;
        }


        public static Fix64 MoveTowards(in Fix64 current, in Fix64 target, in Fix64 maxDelta)
        {
            if (Abs(target - current) <= maxDelta)
            {
                return target;
            }
            return current + Sign(target - current) * maxDelta;
        }

        public static Fix64 MoveTowardsUnclamped(Fix64 current, Fix64 target, Fix64 maxDelta)
        {
            return current + Sign(target - current) * maxDelta;
        }

        public static Fix64 SmoothStep(Fix64 from, Fix64 to, Fix64 t)
        {
            t = Clamp01(t);
            t = -Fix64.Cos(t * Fix64.Pi) * Fix64.Half + Fix64.Half;
            return from + (to - from) * t;
        }

        public static Fix64 Repeat(Fix64 t, Fix64 length)
        {
            return Clamp(t - Floor(t / length) * length, Fix64.Zero, length);
        }

        public static Fix64 DeltaAngle(Fix64 current, Fix64 target)
        {
            var num = Repeat(target - current, 2 * Fix64.Pi);
            if (num > Fix64.Pi)
            {
                num -= 2 * Fix64.Pi;
            }
            return num;
        }

        public static Fix64 MoveTowardsAngle(Fix64 current, Fix64 target, Fix64 maxDelta)
        {
            target = current + DeltaAngle(current, target);
            return MoveTowards(current, target, maxDelta);
        }



        public static Fix64 Asin(Fix64 a)
        {
            return (Fix64.Pi / 2) - Acos(a);
        }

    }
}