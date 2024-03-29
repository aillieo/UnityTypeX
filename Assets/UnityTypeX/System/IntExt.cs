using System.Globalization;

namespace AillieoUtils.TypeX.IntExt
{
    public static class IntExt
    {
        public static int SafeParse(string str, int defaultValue)
        {
            if (int.TryParse(
                str,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
