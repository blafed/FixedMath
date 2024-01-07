using System.IO;
using System;
namespace FixedMath.Generation
{
    using static Fix64Constants;
    using static Fix64;
    class Fix64Generator
    {

        public static void GenerateSinLut()
        {
            using (var writer = new StreamWriter("Lut/Fix64SinLut.cs"))
            {
                writer.Write(
@"namespace FixedMath.Lut 
{
    static partial class Fix64Lut 
    {
        public static readonly long[] SinLut = new[] 
        {");
                int lineCounter = 0;
                for (int i = 0; i < LUT_SIZE; ++i)
                {
                    var angle = i * Math.PI * 0.5 / (LUT_SIZE - 1);
                    if (lineCounter++ % 8 == 0)
                    {
                        writer.WriteLine();
                        writer.Write("            ");
                    }
                    var sin = Math.Sin(angle);
                    var rawValue = ((Fix64)sin).m_rawValue;
                    writer.Write(string.Format("0x{0:X}L, ", rawValue));
                }
                writer.Write(
@"
        };
    }
}");
            }
        }

        public static void GenerateTanLut()
        {
            using (var writer = new StreamWriter("Lut/Fix64TanLut.cs"))
            {
                writer.Write(
@"namespace FixedMath.Lut 
{
    static partial struct Fix64Lut 
    {
        public static readonly long[] TanLut = new[] 
        {");
                int lineCounter = 0;
                for (int i = 0; i < LUT_SIZE; ++i)
                {
                    var angle = i * Math.PI * 0.5 / (LUT_SIZE - 1);
                    if (lineCounter++ % 8 == 0)
                    {
                        writer.WriteLine();
                        writer.Write("            ");
                    }
                    var tan = Math.Tan(angle);
                    if (tan > (double)MaxValue || tan < 0.0)
                    {
                        tan = (double)MaxValue;
                    }
                    var rawValue = (((decimal)tan > (decimal)MaxValue || tan < 0.0) ? MaxValue : (Fix64)tan).m_rawValue;
                    writer.Write(string.Format("0x{0:X}L, ", rawValue));
                }
                writer.Write(
@"
        };
    }
}");
            }
        }
    }
}