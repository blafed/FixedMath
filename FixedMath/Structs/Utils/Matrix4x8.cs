/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/Matrix4x8.cs
*/
using System;
using System.Runtime.CompilerServices;

namespace FixedMath
{
    internal struct Matrix4x8
    {
        public Matrix3x6 M3x6;

        // Additional fields
        public Fix64 M41;
        public Fix64 M42;
        public Fix64 M43;
        public Fix64 M44;
        public Fix64 M45;
        public Fix64 M46;
        public Fix64 M47;
        public Fix64 M48;

        public Fix64 M17;
        public Fix64 M18;
        public Fix64 M27;
        public Fix64 M28;
        public Fix64 M37;
        public Fix64 M38;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Fix64 Get(ref Matrix4x8 matrix, int row, int column)
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: return matrix.M3x6.M11;
                        case 1: return matrix.M3x6.M12;
                        case 2: return matrix.M3x6.M13;
                        case 3: return matrix.M3x6.M14;
                        case 4: return matrix.M3x6.M15;
                        case 5: return matrix.M3x6.M16;
                        case 6: return matrix.M17;
                        case 7: return matrix.M18;
                        default: throw new IndexOutOfRangeException();
                    }
                case 1:
                    switch (column)
                    {
                        case 0: return matrix.M3x6.M21;
                        case 1: return matrix.M3x6.M22;
                        case 2: return matrix.M3x6.M23;
                        case 3: return matrix.M3x6.M24;
                        case 4: return matrix.M3x6.M25;
                        case 5: return matrix.M3x6.M26;
                        case 6: return matrix.M27;
                        case 7: return matrix.M28;
                        default: throw new IndexOutOfRangeException();
                    }
                case 2:
                    switch (column)
                    {
                        case 0: return matrix.M3x6.M31;
                        case 1: return matrix.M3x6.M32;
                        case 2: return matrix.M3x6.M33;
                        case 3: return matrix.M3x6.M34;
                        case 4: return matrix.M3x6.M35;
                        case 5: return matrix.M3x6.M36;
                        case 6: return matrix.M37;
                        case 7: return matrix.M38;
                        default: throw new IndexOutOfRangeException();
                    }
                case 3:
                    switch (column)
                    {
                        case 0: return matrix.M41;
                        case 1: return matrix.M42;
                        case 2: return matrix.M43;
                        case 3: return matrix.M44;
                        case 4: return matrix.M45;
                        case 5: return matrix.M46;
                        case 6: return matrix.M47;
                        case 7: return matrix.M48;
                        default: throw new IndexOutOfRangeException();
                    }
                default: throw new IndexOutOfRangeException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set(ref Matrix4x8 matrix, int row, int column, Fix64 value)
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: matrix.M3x6.M11 = value; break;
                        case 1: matrix.M3x6.M12 = value; break;
                        case 2: matrix.M3x6.M13 = value; break;
                        case 3: matrix.M3x6.M14 = value; break;
                        case 4: matrix.M3x6.M15 = value; break;
                        case 5: matrix.M3x6.M16 = value; break;
                        case 6: matrix.M17 = value; break;
                        case 7: matrix.M18 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                    break;
                case 1:
                    switch (column)
                    {
                        case 0: matrix.M3x6.M21 = value; break;
                        case 1: matrix.M3x6.M22 = value; break;
                        case 2: matrix.M3x6.M23 = value; break;
                        case 3: matrix.M3x6.M24 = value; break;
                        case 4: matrix.M3x6.M25 = value; break;
                        case 5: matrix.M3x6.M26 = value; break;
                        case 6: matrix.M27 = value; break;
                        case 7: matrix.M28 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                    break;
                case 2:
                    switch (column)
                    {
                        case 0: matrix.M3x6.M31 = value; break;
                        case 1: matrix.M3x6.M32 = value; break;
                        case 2: matrix.M3x6.M33 = value; break;
                        case 3: matrix.M3x6.M34 = value; break;
                        case 4: matrix.M3x6.M35 = value; break;
                        case 5: matrix.M3x6.M36 = value; break;
                        case 6: matrix.M37 = value; break;
                        case 7: matrix.M38 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                    break;
                case 3:
                    switch (column)
                    {
                        case 0: matrix.M41 = value; break;
                        case 1: matrix.M42 = value; break;
                        case 2: matrix.M43 = value; break;
                        case 3: matrix.M44 = value; break;
                        case 4: matrix.M45 = value; break;
                        case 5: matrix.M46 = value; break;
                        case 6: matrix.M47 = value; break;
                        case 7: matrix.M48 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                    break;
                default: throw new IndexOutOfRangeException();
            }
        }

        public static bool Invert(in FixMatrix4x4 m, out FixMatrix4x4 r)
        {
            Matrix4x8 M;

            // M[0, 0] = m.M11;
            M.M3x6.M11 = m.m11;
            // M[0, 1] = m.M12;
            M.M3x6.M12 = m.m12;
            // M[0, 2] = m.M13;
            M.M3x6.M13 = m.m13;
            // M[0, 3] = m.M14;
            M.M3x6.M14 = m.m14;
            // M[1, 0] = m.M21;
            M.M3x6.M21 = m.m21;
            // M[1, 1] = m.M22;
            M.M3x6.M22 = m.m22;
            // M[1, 2] = m.M23;
            M.M3x6.M23 = m.m23;
            // M[1, 3] = m.M24;
            M.M3x6.M24 = m.m24;
            // M[2, 0] = m.M31;
            M.M3x6.M31 = m.m31;
            // M[2, 1] = m.M32;
            M.M3x6.M32 = m.m32;
            // M[2, 2] = m.M33;
            M.M3x6.M33 = m.m33;
            // M[2, 3] = m.M34;
            M.M3x6.M34 = m.m34;
            // M[3, 0] = m.M41;
            M.M41 = m.m41;
            // M[3, 1] = m.M42;
            M.M42 = m.m42;
            // M[3, 2] = m.M43;
            M.M43 = m.m43;
            // M[3, 3] = m.M44;
            M.M44 = m.m44;

            // M[0, 4] = Fix64.One;
            M.M3x6.M15 = Fix64.One;
            // M[0, 5] = Fix64.Zero;
            M.M3x6.M16 = Fix64.Zero;
            // M[0, 6] = Fix64.Zero;
            M.M17 = Fix64.Zero;
            // M[0, 7] = Fix64.Zero;
            M.M18 = Fix64.Zero;
            // M[1, 4] = Fix64.Zero;
            M.M3x6.M25 = Fix64.Zero;
            // M[1, 5] = Fix64.One;
            M.M3x6.M26 = Fix64.One;
            // M[1, 6] = Fix64.Zero;
            M.M27 = Fix64.Zero;
            // M[1, 7] = Fix64.Zero;
            M.M28 = Fix64.Zero;
            // M[2, 4] = Fix64.Zero;
            M.M3x6.M35 = Fix64.Zero;
            // M[2, 5] = Fix64.Zero;
            M.M3x6.M36 = Fix64.Zero;
            // M[2, 6] = Fix64.One;
            M.M37 = Fix64.One;
            // M[2, 7] = Fix64.Zero;
            M.M38 = Fix64.Zero;
            // M[3, 4] = Fix64.Zero;
            M.M44 = Fix64.Zero;
            // M[3, 5] = Fix64.Zero;
            M.M46 = Fix64.Zero;
            // M[3, 6] = Fix64.Zero;
            M.M47 = Fix64.Zero;
            // M[3, 7] = Fix64.One;
            M.M48 = Fix64.One;


            if (!Matrix3x6.Gauss(ref M.M3x6, 4, 8))
            {
                r = new FixMatrix4x4();
                return false;
            }
            r = new FixMatrix4x4(
                // m11...m14
                // M[0, 4],
                M.M3x6.M15,
                // M[0, 5],
                M.M3x6.M16,
                // M[0, 6],
                M.M17,
                // M[0, 7],
                M.M18,

                // m21...m24				
                // M[1, 4],
                M.M3x6.M25,
                // M[1, 5],
                M.M3x6.M26,
                // M[1, 6],
                M.M27,
                // M[1, 7],
                M.M28,

                // m31...m34
                // M[2, 4],
                M.M3x6.M35,
                // M[2, 5],
                M.M3x6.M36,
                // M[2, 6],
                M.M37,
                // M[2, 7],
                M.M38,

                // m41...m44
                // M[3, 4],
                M.M44,
                // M[3, 5],
                M.M46,
                // M[3, 6],
                M.M47,
                // M[3, 7]
                M.M48
                );
            return true;
        }
    }
}