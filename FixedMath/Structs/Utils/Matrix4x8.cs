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



    }
}