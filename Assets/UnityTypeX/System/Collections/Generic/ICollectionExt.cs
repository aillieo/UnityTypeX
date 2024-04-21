// -----------------------------------------------------------------------
// <copyright file="ICollectionExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.ICollectionExt
{
    using System;
    using System.Collections.Generic;

    public static class ICollectionExt
    {
        public static bool GetOrDefault<T>(this ICollection<T> collection, T item)
        {
            if (!collection.Contains(item))
            {
                collection.Add(item);
                return true;
            }

            return false;
        }

        private static class ItemsToRemove<T>
        {
            [ThreadStatic]
            public static List<T> toRemove;
        }

        public static int RemoveAll<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (ItemsToRemove<T>.toRemove == null)
            {
                ItemsToRemove<T>.toRemove = new List<T>();
            }

            List<T> toRemove = ItemsToRemove<T>.toRemove;
            toRemove.Clear();
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    toRemove.Add(item);
                }
            }

            int removeCount = toRemove.Count;
            for (int i = 0; i < removeCount; ++i)
            {
                collection.Remove(toRemove[i]);
            }

            toRemove.Clear();
            return removeCount;
        }
    }
}
