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
    }
}
