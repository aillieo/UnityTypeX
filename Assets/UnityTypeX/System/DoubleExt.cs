// -----------------------------------------------------------------------
// <copyright file="DoubleExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.DoubleExt
{
    using System.Globalization;

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
