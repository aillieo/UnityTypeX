using System.Globalization;

namespace AillieoUtils.TypeExt
{
    public static class LongExt
    {
        public static long SafeParse(string str, long defaultValue)
        {
            if (long.TryParse(
                str,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out long value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
