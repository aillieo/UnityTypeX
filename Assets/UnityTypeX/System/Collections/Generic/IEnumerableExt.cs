// -----------------------------------------------------------------------
// <copyright file="IEnumerableExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.IEnumerableExt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExt
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int index = 0;
            foreach (T element in source)
            {
                action(element, index);
                ++index;
            }
        }

        private static class HashSetForUniqueTest<T>
        {
            [ThreadStatic]
            public static HashSet<T> hashSet;
        }

        public static bool IsUnique<T>(this IEnumerable<T> source)
        {
            if (HashSetForUniqueTest<T>.hashSet == null)
            {
                HashSetForUniqueTest<T>.hashSet = new HashSet<T>();
            }

            HashSet<T> hashSet = HashSetForUniqueTest<T>.hashSet;
            bool unique = source.All(t => hashSet.Add(t));
            hashSet.Clear();
            return unique;
        }

        public static IEnumerable<T> ReverseFast<T>(this IEnumerable<T> source)
        {
            if (source is IList<T> list && list.Count > 0)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    yield return list[i];
                }
            }
            else if (source is LinkedList<T> linked && linked.Count > 0)
            {
                LinkedListNode<T> node = linked.Last;
                while (node != null)
                {
                    yield return node.Value;
                    node = node.Previous;
                }
            }
            else
            {
                foreach (T item in source.Reverse())
                {
                    yield return item;
                }
            }
        }

        public static T MinFor<T>(this IEnumerable<T> source, Func<T, float> func)
        {
            T min = default;
            float minValue = float.PositiveInfinity;
            foreach (var item in source)
            {
                float newValue = func(item);
                if (newValue < minValue)
                {
                    minValue = newValue;
                    min = item;
                }
            }

            return min;
        }

        public static T MaxFor<T>(this IEnumerable<T> source, Func<T, float> func)
        {
            T max = default;
            float maxValue = float.NegativeInfinity;
            foreach (var item in source)
            {
                float newValue = func(item);
                if (newValue > maxValue)
                {
                    maxValue = newValue;
                    max = item;
                }
            }

            return max;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static bool ContainsAny<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (source.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (!source.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ToStringEx<T>(this IEnumerable<T> source)
        {
            return string.Join(",", source);
        }
    }
}
