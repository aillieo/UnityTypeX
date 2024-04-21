// -----------------------------------------------------------------------
// <copyright file="IntExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.IntExt
{
    using System.Globalization;

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
