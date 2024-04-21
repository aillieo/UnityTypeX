// -----------------------------------------------------------------------
// <copyright file="FloatExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.FloatExt
{
    using System.Globalization;

    public static class FloatExt
    {
        public static string ToStringWithDigits(this float value, int digits)
        {
            return value.ToString($"F{digits}", CultureInfo.InvariantCulture);
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
