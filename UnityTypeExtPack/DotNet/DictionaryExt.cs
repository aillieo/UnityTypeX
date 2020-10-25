using System;
using System.Collections.Generic;

namespace AillieoUtils.TypeExt
{

    public static class DictionaryExt
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
    }
}
