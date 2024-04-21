// -----------------------------------------------------------------------
// <copyright file="LongExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.LongExt
{
    using System.Globalization;

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
