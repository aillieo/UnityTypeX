using System.Collections.Generic;

namespace AillieoUtils.TypeExt
{
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
    }
}
