using System.Globalization;

namespace AillieoUtils.TypeExt
{
    public static class FloatExt
    {
        public static string ToStringWithDigits(this float value, int digits)
        {
            return value.ToString($"F{digits}");
        }

        public static float SafeParse(string str, float defaultValue)
        {
            if (float.TryParse(
                str,
                NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture,
                out float value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
