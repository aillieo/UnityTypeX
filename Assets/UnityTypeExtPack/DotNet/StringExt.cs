using System;
using System.Text;

namespace AillieoUtils.TypeExt
{
    public static class StringExt
    {
        public static string Repeat(this char chatToRepeat, int repeat)
        {
            return new string(chatToRepeat, repeat);
        }

        [ThreadStatic]
        private static StringBuilder builder = new StringBuilder();
        public static string Repeat(this string stringToRepeat, int repeat)
        {
            builder.Clear();
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }

            return builder.ToString();
        }

        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(source))
            {
                return false;
            }
            return source.IndexOf(value, comparisonType) >= 0;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
