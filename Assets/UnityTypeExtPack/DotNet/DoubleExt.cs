using System.Globalization;

namespace AillieoUtils.TypeExt
{
    public static class DoubleExt
    {
        public static double SafeParse(string str, double defaultValue)
        {
            if (double.TryParse(
                str,
                NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture,
                out double value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
