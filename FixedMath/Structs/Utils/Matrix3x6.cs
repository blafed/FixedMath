using System;
using System.Runtime.CompilerServices;
namespace FixedMath
{
    internal struct Matrix3x6
    {
        public Fix64 M11;
        public Fix64 M12;
        public Fix64 M13;
        public Fix64 M14;
        public Fix64 M15;
        public Fix64 M16;
        public Fix64 M21;
        public Fix64 M22;
        public Fix64 M23;
        public Fix64 M24;
        public Fix64 M25;
        public Fix64 M26;
        public Fix64 M31;
        public Fix64 M32;
        public Fix64 M33;
        public Fix64 M34;
        public Fix64 M35;
        public Fix64 M36;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Set(ref Matrix3x6 contents, int row, int column, Fix64 value)
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: contents.M11 = value; return;
                        case 1: contents.M12 = value; return;
                        case 2: contents.M13 = value; return;
                        case 3: contents.M14 = value; return;
                        case 4: contents.M15 = value; return;
                        case 5: contents.M16 = value; return;
                        default: throw new IndexOutOfRangeException();
                    }
                case 1:
                    switch (column)
                    {
                        case 0: contents.M21 = value; return;
                        case 1: contents.M22 = value; return;
                        case 2: contents.M23 = value; return;
                        case 3: contents.M24 = value; return;
                        case 4: contents.M25 = value; return;
                        case 5: contents.M26 = value; return;
                        default: throw new IndexOutOfRangeException();
                    }
                case 2:
                    switch (column)
                    {
                        case 0: contents.M31 = value; return;
                        case 1: contents.M32 = value; return;
                        case 2: contents.M33 = value; return;
                        case 3: contents.M34 = value; return;
                        case 4: contents.M35 = value; return;
                        case 5: contents.M36 = value; return;
                        default: throw new IndexOutOfRangeException();
                    }
                default: throw new IndexOutOfRangeException();
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Fix64 Get(in Matrix3x6 contents, int row, int column)
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0: return contents.M11;
                        case 1: return contents.M12;
                        case 2: return contents.M13;
                        case 3: return contents.M14;
                        case 4: return contents.M15;
                        case 5: return contents.M16;
                        default: throw new IndexOutOfRangeException();
                    }
                case 1:
                    switch (column)
                    {
                        case 0: return contents.M21;
                        case 1: return contents.M22;
                        case 2: return contents.M23;
                        case 3: return contents.M24;
                        case 4: return contents.M25;
                        case 5: return contents.M26;
                        default: throw new IndexOutOfRangeException();
                    }
                case 2:
                    switch (column)
                    {
                        case 0: return contents.M31;
                        case 1: return contents.M32;
                        case 2: return contents.M33;
                        case 3: return contents.M34;
                        case 4: return contents.M35;
                        case 5: return contents.M36;
                        default: throw new IndexOutOfRangeException();
                    }
                default: throw new IndexOutOfRangeException();
            }
        }
        [ThreadStatic] private static Fix64[,] Matrix;

        public static bool Gauss(ref Matrix3x6 M, int m, int n)
        {
            // Perform Gauss-Jordan elimination
            for (int k = 0; k < m; k++)
            {
                // Fix64 maxValue = Fix64.Abs(M[k, k]);
                Fix64 maxValue = Fix64.Abs(Get(in M, k, k));
                int iMax = k;
                for (int i = k + 1; i < m; i++)
                {
                    // Fix64 value = Fix64.Abs(M[i, k]);
                    Fix64 value = Fix64.Abs(Get(in M, i, k));
                    if (value >= maxValue)
                    {
                        maxValue = value;
                        iMax = i;
                    }
                }
                if (maxValue == F64.C0)
                    return false;
                // Swap rows k, iMax
                if (k != iMax)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // Fix64 temp = M[k, j];
                        Fix64 temp = Get(in M, k, j);
                        // M[k, j] = M[iMax, j];
                        Set(ref M, k, j, Get(in M, iMax, j));
                        // M[iMax, j] = temp;
                        Set(ref M, iMax, j, temp);
                    }
                }

                // Divide row by pivot
                // Fix64 pivotInverse = F64.C1 / M[k, k];
                Fix64 pivotInverse = F64.C1 / Get(in M, k, k);

                // M[k, k] = F64.C1;
                Set(ref M, k, k, F64.C1);
                for (int j = k + 1; j < n; j++)
                {
                    // M[k, j] *= pivotInverse;
                    Set(ref M, k, j, Get(in M, k, j) * pivotInverse);
                }

                // Subtract row k from other rows
                for (int i = 0; i < m; i++)
                {
                    if (i == k)
                        continue;
                    // Fix64 f = M[i, k];
                    Fix64 f = Get(in M, i, k);
                    for (int j = k + 1; j < n; j++)
                    {
                        // M[i, j] = M[i, j] - M[k, j] * f;
                        Set(ref M, i, j, Get(in M, i, j) - Get(in M, k, j) * f);
                    }
                    // M[i, k] = F64.C0;
                    Set(ref M, i, k, F64.C0);
                }
            }
            return true;
        }

        public static bool Invert(ref FixMatrix3x3 m, out FixMatrix3x3 r)
        {
            Matrix3x6 M;

            // Initialize temporary matrix
            // M[0, 0] = m.M11;
            M.M11 = m.M11;
            // M[0, 1] = m.M12;
            M.M12 = m.M12;
            // M[0, 2] = m.M13;
            M.M13 = m.M13;
            // M[1, 0] = m.M21;
            M.M21 = m.M21;
            // M[1, 1] = m.M22;
            M.M22 = m.M22;
            // M[1, 2] = m.M23;
            M.M23 = m.M23;
            // M[2, 0] = m.M31;
            M.M31 = m.M31;
            // M[2, 1] = m.M32;
            M.M32 = m.M32;
            // M[2, 2] = m.M33;
            M.M33 = m.M33;

            // M[0, 3] = Fix64.One;
            M.M14 = Fix64.One;
            // M[0, 4] = Fix64.Zero;
            M.M15 = Fix64.Zero;
            // M[0, 5] = Fix64.Zero;
            M.M16 = Fix64.Zero;
            // M[1, 3] = Fix64.Zero;
            M.M24 = Fix64.Zero;
            // M[1, 4] = Fix64.One;
            M.M25 = Fix64.One;
            // M[1, 5] = Fix64.Zero;
            M.M26 = Fix64.Zero;
            // M[2, 3] = Fix64.Zero;
            M.M34 = Fix64.Zero;
            // M[2, 4] = Fix64.Zero;
            M.M35 = Fix64.Zero;
            // M[2, 5] = Fix64.One;
            M.M36 = Fix64.One;

            if (!Gauss(ref M, 3, 6))
            {
                r = new FixMatrix3x3();
                return false;
            }
            r = new FixMatrix3x3(
                // m11...m13
                // M[0, 3],
                M.M14,
                // M[0, 4],
                M.M15,
                // M[0, 5],
                M.M16,

                // m21...m23
                // M[1, 3],
                M.M24,
                // M[1, 4],
                M.M25,
                // M[1, 5],
                M.M26,

                // m31...m33
                // M[2, 3],
                M.M34,
                // M[2, 4],
                M.M35,
                // M[2, 5]
                M.M36
                );
            return true;
        }


    }
}