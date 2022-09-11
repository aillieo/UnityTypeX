using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AillieoUtils.TypeX.StringExt
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

        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotNullOrWhiteSpace(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static string Join<T>(this string separator, IEnumerable<T> values)
        {
            return string.Join(separator, values);
        }

        public static string Truncate(this string source, int lengthMax, string ellipses = "...")
        {
            if (source.Length <= lengthMax)
            {
                return source;
            }

            int lengthKeep = lengthMax - ellipses.Length;
            return source.Substring(0, lengthKeep) + ellipses;
        }

        public static string TruncateUTF8(this string source, int charsMax, string ellipses = "...")
        {
            StringInfo stringInfo = new StringInfo(source);
            if (stringInfo.LengthInTextElements <= charsMax)
            {
                return source;
            }

            string truncated = stringInfo.SubstringByTextElements(0, charsMax);
            return truncated + ellipses;
        }
    }
}
