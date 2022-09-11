using System.Globalization;

namespace AillieoUtils.TypeX.LongExt
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
