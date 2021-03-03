using System;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.TypeExt
{
    public static class IEnumerableExt
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }

        private static class HashSetForUniqueTest<T>
        {
            [ThreadStatic]
            public static readonly HashSet<T> hashSet = new HashSet<T>();
        }

        public static bool IsUnique<T>(this IEnumerable<T> source)
        {
            HashSet<T> hashSet = HashSetForUniqueTest<T>.hashSet;
            bool unique = source.All(t => hashSet.Add(t));
            hashSet.Clear();
            return unique;
        }
    }
}
