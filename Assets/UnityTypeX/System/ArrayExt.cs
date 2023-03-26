using System;

namespace AillieoUtils.TypeX.ArrayExt
{
    public static class ArrayExt
    {
        public static void Clear<T>(this Array array)
        {
            if (array.Length == 0)
            {
                return;
            }

            Array.Clear(array, 0, array.Length);
        }

        public static void Clear<T>(this T[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            Array.Clear(array, 0, array.Length);
        }

        public static int Append<T>(ref T[] array, T item)
        {
            int length = array.Length;
            Array.Resize(ref array, length + 1);
            array[length] = item;
            return length + 1;
        }
    }
}
