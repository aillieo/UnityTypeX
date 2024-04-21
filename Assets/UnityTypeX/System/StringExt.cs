// -----------------------------------------------------------------------
// <copyright file="StringExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.StringExt
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public static class StringExt
    {
        public static string Repeat(this char chatToRepeat, int repeat)
        {
            return new string(chatToRepeat, repeat);
        }

        [ThreadStatic]
        private static StringBuilder builder;

        public static string Repeat(this string stringToRepeat, int repeat)
        {
            if (builder == null)
            {
                builder = new StringBuilder();
            }

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

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, int.MaxValue, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, count, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, char[] separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, int.MaxValue, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, char[] separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, count, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, string separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, int.MaxValue, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, string separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, count, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, string[] separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, int.MaxValue, options);
        }

        public static IEnumerable<StringSegment> SplitNonAlloc(this string source, string[] separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return StringSplitUtils.Split(source, separator, count, options);
        }
    }
}
