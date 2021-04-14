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

        public static byte To255Byte(this float value)
        {
            return (byte)MathF.Round((255 * Math.Clamp(value, 0, 1)));
        }
    }
}