using System;

namespace ObjRenderer.Extensions
{
    public static class FloatExtensions
    {
        public const float Epsilon = 0.0001f;

        public static bool EqualsEpsilon(this float a, float b)
        {
            return Math.Abs(a - b) < Epsilon;
        }

    }
}