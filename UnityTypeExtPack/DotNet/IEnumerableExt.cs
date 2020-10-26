using System;
using System.Collections.Generic;

public static class IEnumerableExt
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T element in source)
        {
            action(element);
        }
    }
}
