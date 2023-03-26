using System;
using System.Collections.Generic;
using System.Text;

namespace AillieoUtils.TypeX.IDictionaryExt
{

    public static class IDictionaryExt
    {
        public static U GetOrDefault<T, U>(this IDictionary<T, U> dictionary, T key)
        {
            if (dictionary.TryGetValue(key, out U value))
            {
                return value;
            }
            return default;
        }

        public static U GetOrDefault<T, U>(this IDictionary<T, U> dictionary, T key, U defaultValue)
        {
            if (dictionary.TryGetValue(key, out U value))
            {
                return value;
            }
            return defaultValue;
        }

        public static U GetOrAdd<T, U>(this IDictionary<T, U> dictionary, T key, Func<T, U> provider)
        {
            U value = default;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = provider(key);
                dictionary.Add(key, value);
            }

            return value;
        }

        private static class KeysToRemove<T>
        {
            [ThreadStatic]
            public static List<T> toRemove;
        }

        public static int RemoveAll<T, U>(this IDictionary<T, U> dictionary, Func<T, U, bool> predicate)
        {
            if (KeysToRemove<T>.toRemove == null)
            {
                KeysToRemove<T>.toRemove = new List<T>();
            }

            List<T> toRemove = KeysToRemove<T>.toRemove;
            toRemove.Clear();
            foreach (var pair in dictionary)
            {
                if (predicate(pair.Key, pair.Value))
                {
                    toRemove.Add(pair.Key);
                }
            }

            int removeCount = toRemove.Count;
            for (int i = 0; i < removeCount; ++i)
            {
                dictionary.Remove(toRemove[i]);
            }

            toRemove.Clear();
            return removeCount;
        }

        [ThreadStatic]
        private static StringBuilder builderToStringEx;

        public static string ToStringEx<T, U>(this IDictionary<T, U> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return string.Empty;
            }

            if (builderToStringEx == null)
            {
                builderToStringEx = new StringBuilder();
            }

            builderToStringEx.Clear();

            foreach (var pair in dictionary)
            {
                if (builderToStringEx.Length != 0)
                {
                    builderToStringEx.Append(',');
                }

                builderToStringEx.Append($"{pair.Key}={pair.Value}");
            }

            return builderToStringEx.ToString();
        }
    }
}
