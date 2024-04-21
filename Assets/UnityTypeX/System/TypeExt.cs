// -----------------------------------------------------------------------
// <copyright file="TypeExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.TypeExt
{
    using System;

    public static class TypeExt
    {
        public static bool IsAssignableTo(this Type thisType, Type targetType)
        {
            if (targetType == null)
            {
                return false;
            }

            return targetType.IsAssignableFrom(thisType);
        }
    }
}
