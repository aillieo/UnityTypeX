using System;
using System.Collections.Generic;

namespace AillieoUtils.TypeExt
{

    public static class IListExt
    {

        private static readonly Random rand = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n-- > 1)
            {
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T GetRandom<T>(this IList<T> list)
        {
            int n = list.Count;
            if (n == 0)
            {
                throw new Exception("list is empty");
            }

            return list[rand.Next(n + 1)];
        }

        public static void RemoveAtSwapBack<T>(this IList<T> list, int index)
        {
            int count = list.Count;
            list[index] = list[count - 1];
            list.RemoveAt(count - 1);
        }

        public static bool RemoveSwapBack<T>(this IList<T> list, T item)
        {
            int index = list.IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            RemoveAtSwapBack(list, index);
            return true;
        }
    }
}
