using System;

namespace FixedMath
{
    public enum RotationOrder
    {
        XYZ,
        XZY,
        YXZ,
        YZX,
        ZXY,
        ZYX
    }
    public struct FixQuaternion
    {
        public Fix64 x;
        public Fix64 y;
        public Fix64 z;
        public Fix64 w;

        public FixQuaternion normalized
        {
            get
            {
                Fix64 num = Fix64.One / Fix64.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
                return new FixQuaternion(this.x * num, this.y * num, this.z * num, this.w * num);
            }
        }

        public FixVector3 eulerAngles
        {
            get
            {
                Fix64 num10 = this.x * this.x;
                Fix64 num9 = this.x * this.y;
                Fix64 num8 = this.x * this.z;
                Fix64 num7 = this.x * this.w;
                Fix64 num6 = this.y * this.y;
                Fix64 num5 = this.y * this.z;
                Fix64 num4 = this.y * this.w;
                Fix64 num3 = this.z * this.z;
                Fix64 num2 = this.z * this.w;
                Fix64 num = this.w * this.w;
                Fix64 x = FixMath.Asin(FixMath.Clamp((Fix64)(2M * ((num4 - num8) * num10 - (num7 + num9) * num6)), (Fix64)(-1M), (Fix64)1M)) * FixMath.Rad2Deg;
                Fix64 y = FixMath.Atan2(FixMath.Clamp((Fix64)(2M * ((num7 - num9) * num6 + (num4 + num8) * num10)), (Fix64)(-1M), (Fix64)1M), FixMath.Clamp((Fix64)(-2M * ((num7 + num9) * num5 - (num4 - num8) * num3)), (Fix64)(-1M), (Fix64)1M)) * FixMath.Rad2Deg;
                Fix64 z = FixMath.Atan2(FixMath.Clamp((Fix64)(2M * ((num7 - num8) * num3 + (num9 + num4) * num5)), (Fix64)(-1M), (Fix64)1M), FixMath.Clamp((Fix64)(-2M * ((num7 + num8) * num6 - (num9 - num4) * num10)), (Fix64)(-1M), (Fix64)1M)) * FixMath.Rad2Deg;
                return new FixVector3(x, y, z);
            }
        }

        public FixQuaternion(Fix64 x, Fix64 y, Fix64 z, Fix64 w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        public static FixQuaternion identity
        {
            get
            {
                return new FixQuaternion(Fix64.Zero, Fix64.Zero, Fix64.Zero, Fix64.One);
            }
        }

        public static FixQuaternion Euler(Fix64 x, Fix64 y, Fix64 z)
        {
            Fix64 halfX = x * FixMath.Deg2Rad * (Fix64)0.5M;
            Fix64 halfY = y * FixMath.Deg2Rad * (Fix64)0.5M;
            Fix64 halfZ = z * FixMath.Deg2Rad * (Fix64)0.5M;

            Fix64 sinX = FixMath.Sin(halfX);
            Fix64 cosX = FixMath.Cos(halfX);
            Fix64 sinY = FixMath.Sin(halfY);
            Fix64 cosY = FixMath.Cos(halfY);
            Fix64 sinZ = FixMath.Sin(halfZ);
            Fix64 cosZ = FixMath.Cos(halfZ);

            return new FixQuaternion(
                cosY * sinX * cosZ + sinY * cosX * sinZ,
                sinY * cosX * cosZ - cosY * sinX * sinZ,
                cosY * cosX * sinZ - sinY * sinX * cosZ,
                cosY * cosX * cosZ + sinY * sinX * sinZ
            );
        }

        public static FixQuaternion Euler(FixVector3 euler)
        {
            return Euler(euler.x, euler.y, euler.z);
        }

        public static FixQuaternion AngleAxis(Fix64 angle, FixVector3 axis)
        {
            Fix64 halfAngle = angle * (Fix64)0.5M;
            Fix64 sin = FixMath.Sin(halfAngle);
            Fix64 cos = FixMath.Cos(halfAngle);
            return new FixQuaternion(
                axis.x * sin,
                axis.y * sin,
                axis.z * sin,
                cos
            );
        }

        public static FixQuaternion operator *(FixQuaternion a, FixQuaternion b)
        {
            return new FixQuaternion(
                a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
                a.w * b.y + a.y * b.w + a.z * b.x - a.x * b.z,
                a.w * b.z + a.z * b.w + a.x * b.y - a.y * b.x,
                a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z
            );
        }

        public static FixVector3 operator *(FixQuaternion rotation, FixVector3 point)
        {
            Fix64 num = rotation.x * (Fix64)2M;
            Fix64 num2 = rotation.y * (Fix64)2M;
            Fix64 num3 = rotation.z * (Fix64)2M;
            Fix64 num4 = rotation.x * num;
            Fix64 num5 = rotation.y * num2;
            Fix64 num6 = rotation.z * num3;
            Fix64 num7 = rotation.x * num2;
            Fix64 num8 = rotation.x * num3;
            Fix64 num9 = rotation.y * num3;
            Fix64 num10 = rotation.w * num;
            Fix64 num11 = rotation.w * num2;
            Fix64 num12 = rotation.w * num3;
            FixVector3 result;
            result.x = (Fix64)((Fix64)((Fix64)1M - (Fix64)2M * (Fix64)(num5 + num6)) * point.x + (Fix64)(num7 - num12) * point.y + (Fix64)(num8 + num11) * point.z);
            result.y = (Fix64)((Fix64)(num7 + num12) * point.x + (Fix64)((Fix64)1M - (Fix64)2M * (Fix64)(num4 + num6)) * point.y + (Fix64)(num9 - num10) * point.z);
            result.z = (Fix64)((Fix64)(num8 - num11) * point.x + (Fix64)(num9 + num10) * point.y + (Fix64)((Fix64)1M - (Fix64)2M * (Fix64)(num4 + num5)) * point.z);
            return result;
        }

        public static FixQuaternion LookRotation(FixVector3 forward, FixVector3 upwards)
        {
            FixVector3 vector = forward.normalized;
            FixVector3 vector2 = FixVector3.Cross(upwards, vector).normalized;
            FixVector3 vector3 = FixVector3.Cross(vector, vector2);
            Fix64 m00 = vector2.x;
            Fix64 m01 = vector2.y;
            Fix64 m02 = vector2.z;
            Fix64 m10 = vector3.x;
            Fix64 m11 = vector3.y;
            Fix64 m12 = vector3.z;
            Fix64 m20 = vector.x;
            Fix64 m21 = vector.y;
            Fix64 m22 = vector.z;

            Fix64 num8 = (m00 + m11) + m22;
            FixQuaternion fixQuaternion = new FixQuaternion();
            if (num8 > Fix64.Zero)
            {
                Fix64 num = Fix64.Sqrt(num8 + Fix64.One);
                fixQuaternion.w = num * (Fix64)0.5M;
                num = (Fix64)0.5M / num;
                fixQuaternion.x = (m12 - m21) * num;
                fixQuaternion.y = (m20 - m02) * num;
                fixQuaternion.z = (m01 - m10) * num;
                return fixQuaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                Fix64 num7 = Fix64.Sqrt(((Fix64.One + m00) - m11) - m22);
                Fix64 num4 = (Fix64)0.5M / num7;
                fixQuaternion.x = (Fix64)0.5M * num7;
                fixQuaternion.y = (m01 + m10) * num4;
                fixQuaternion.z = (m02 + m20) * num4;
                fixQuaternion.w = (m12 - m21) * num4;
                return fixQuaternion;
            }
            if (m11 > m22)
            {
                Fix64 num6 = Fix64.Sqrt(((Fix64.One + m11) - m00) - m22);
                Fix64 num3 = (Fix64)0.5M / num6;
                fixQuaternion.x = (m10 + m01) * num3;
                fixQuaternion.y = (Fix64)0.5M * num6;
                fixQuaternion.z = (m21 + m12) * num3;
                fixQuaternion.w = (m20 - m02) * num3;
                return fixQuaternion;

            }

            Fix64 num5 = Fix64.Sqrt(((Fix64.One + m22) - m00) - m11);
            Fix64 num2 = (Fix64)0.5M / num5;
            fixQuaternion.x = (m20 + m02) * num2;
            fixQuaternion.y = (m21 + m12) * num2;
            fixQuaternion.z = (Fix64)0.5M * num5;
            fixQuaternion.w = (m01 - m10) * num2;
            return fixQuaternion;

        }

        public static FixQuaternion Slerp(FixQuaternion a, FixQuaternion b, Fix64 t)
        {
            Fix64 num2;
            Fix64 num3;
            FixQuaternion fixQuaternion = new FixQuaternion();
            Fix64 num = t;
            Fix64 num4 = (((a.x * b.x) + (a.y * b.y)) + (a.z * b.z)) + (a.w * b.w);
            bool flag = false;
            if (num4 < Fix64.Zero)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > (Fix64)0.999999M)
            {
                num3 = (Fix64.One - num);
                num2 = flag ? (-num) : num;
            }
            else
            {
                Fix64 num5 = Fix64.Acos(num4);
                Fix64 num6 = Fix64.One / Fix64.Sin(num5);
                num3 = Fix64.Sin(((Fix64.One - num) * num5)) * num6;
                num2 = flag ? (-(Fix64.Sin((num * num5)) * num6)) : (Fix64.Sin((num * num5)) * num6);
            }
            fixQuaternion.x = (num3 * a.x) + (num2 * b.x);
            fixQuaternion.y = (num3 * a.y) + (num2 * b.y);
            fixQuaternion.z = (num3 * a.z) + (num2 * b.z);
            fixQuaternion.w = (num3 * a.w) + (num2 * b.w);
            return fixQuaternion;
        }

        public static FixQuaternion Lerp(FixQuaternion a, FixQuaternion b, Fix64 t)
        {
            if (t > Fix64.One)
            {
                t = Fix64.One;
            }
            else if (t < Fix64.Zero)
            {
                t = Fix64.Zero;
            }
            return new FixQuaternion(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t,
                a.w + (b.w - a.w) * t
            );
        }

        public static FixQuaternion FromToRotation(FixVector3 fromDirection, FixVector3 toDirection)
        {
            FixVector3 cross = FixVector3.Cross(fromDirection, toDirection);
            Fix64 dot = FixVector3.Dot(fromDirection, toDirection);
            FixQuaternion result = new FixQuaternion(cross.x, cross.y, cross.z, dot + FixVector3.Dot(fromDirection, toDirection));
            return result.normalized;
        }

        public static FixQuaternion RotateTowards(FixQuaternion from, FixQuaternion to, Fix64 maxDegreesDelta)
        {
            Fix64 num = FixQuaternion.Angle(from, to);
            if (num == Fix64.Zero)
            {
                return to;
            }
            Fix64 t = FixMath.Min(Fix64.One, maxDegreesDelta / num);
            return FixQuaternion.SlerpUnclamped(from, to, t);
        }

        public static FixQuaternion SlerpUnclamped(FixQuaternion a, FixQuaternion b, Fix64 t)
        {
            Fix64 num2;
            Fix64 num3;
            FixQuaternion fixQuaternion = new FixQuaternion();
            Fix64 num = t;
            Fix64 num4 = (((a.x * b.x) + (a.y * b.y)) + (a.z * b.z)) + (a.w * b.w);
            bool flag = false;
            if (num4 < Fix64.Zero)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > (Fix64)0.999999M)
            {
                num3 = (Fix64.One - num);
                num2 = flag ? (-num) : num;
            }
            else
            {
                Fix64 num5 = Fix64.Acos(num4);
                Fix64 num6 = Fix64.One / Fix64.Sin(num5);
                num3 = Fix64.Sin(((Fix64.One - num) * num5)) * num6;
                num2 = flag ? (-(Fix64.Sin((num * num5)) * num6)) : (Fix64.Sin((num * num5)) * num6);
            }
            fixQuaternion.x = (num3 * a.x) + (num2 * b.x);
            fixQuaternion.y = (num3 * a.y) + (num2 * b.y);
            fixQuaternion.z = (num3 * a.z) + (num2 * b.z);
            fixQuaternion.w = (num3 * a.w) + (num2 * b.w);
            return fixQuaternion;
        }



        public static Fix64 Angle(FixQuaternion a, FixQuaternion b)
        {
            Fix64 f = FixQuaternion.Dot(a, b);
            return Fix64.Acos(FixMath.Min(Fix64.Abs(f), Fix64.One)) * (Fix64)2M * FixMath.Rad2Deg;
        }

        public static Fix64 Dot(FixQuaternion a, FixQuaternion b)
        {
            return (((a.x * b.x) + (a.y * b.y)) + (a.z * b.z)) + (a.w * b.w);
        }

        public static FixQuaternion Inverse(FixQuaternion rotation)
        {
            Fix64 num2 = (((rotation.x * rotation.x) + (rotation.y * rotation.y)) + (rotation.z * rotation.z)) + (rotation.w * rotation.w);
            Fix64 num = Fix64.One / num2;
            return new FixQuaternion(
                -rotation.x * num,
                -rotation.y * num,
                -rotation.z * num,
                rotation.w * num
            );
        }

        public static FixQuaternion Conjugate(FixQuaternion rotation)
        {
            return new FixQuaternion(
                -rotation.x,
                -rotation.y,
                -rotation.z,
                rotation.w
            );
        }

        public static FixQuaternion Euler(Fix64 x, Fix64 y, Fix64 z, RotationOrder order)
        {
            switch (order)
            {
                case RotationOrder.XYZ:
                    return Euler(x, y, z);
                case RotationOrder.XZY:
                    return Euler(x, z, y);
                case RotationOrder.YXZ:
                    return Euler(y, x, z);
                case RotationOrder.YZX:
                    return Euler(y, z, x);
                case RotationOrder.ZXY:
                    return Euler(z, x, y);
                case RotationOrder.ZYX:
                    return Euler(z, y, x);
                default:
                    throw new NotImplementedException();
            }
        }

        public static FixQuaternion Euler(FixVector3 euler, RotationOrder order)
        {
            return Euler(euler.x, euler.y, euler.z, order);
        }




    }


}