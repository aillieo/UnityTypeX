// -----------------------------------------------------------------------
// <copyright file="ListExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.ListExt
{
    using System;
    using System.Collections.Generic;

    public static class ListExt
    {
        public static void ClearFast<T>(this List<T> list)
        {
            int count = list.Count;
            if (count * 2 < list.Capacity)
            {
                list.RemoveRange(0, count);
            }
            else
            {
                list.Clear();
            }
        }

        public static bool IsSorted<T>(this List<T> list, Comparison<T> comparison)
        {
            for (int i = 0; i < list.Count - 1; ++i)
            {
                if (comparison(list[i], list[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsSorted<T>(this List<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count - 1; ++i)
            {
                if (comparer.Compare(list[i], list[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsSorted<T>(this List<T> list, int index, int count, IComparer<T> comparer)
        {
            for (int i = index; i < index + count - 1; ++i)
            {
                if (comparer.Compare(list[i], list[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
