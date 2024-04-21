// -----------------------------------------------------------------------
// <copyright file="StringSplitUtils.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.StringExt
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public readonly struct StringSegment
    {
        public readonly string rawString;
        public readonly int startIndex;
        public readonly int length;

        internal StringSegment(string rawString, int startIndex, int length)
        {
            this.rawString = rawString;
            this.startIndex = startIndex;
            this.length = length;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.rawString))
            {
                return string.Empty;
            }

            return this.rawString.Substring(this.startIndex, this.length);
        }
    }

    internal static class StringSplitUtils
    {
        public readonly struct StringSplit : IEnumerable<StringSegment>
        {
            internal readonly string rawString;
            internal readonly char cSeparator;
            internal readonly char[] cSeparators;
            internal readonly string sSeparator;
            internal readonly string[] sSeparators;
            internal readonly int count;
            internal readonly StringSplitOptions options;
            internal readonly SplitBy splitBy;

            internal StringSplit(string rawString, char separator, int count, StringSplitOptions options)
            {
                this.rawString = rawString;
                this.cSeparator = separator;
                this.cSeparators = default;
                this.sSeparator = default;
                this.sSeparators = default;
                this.splitBy = SplitBy.Char;
                this.count = count;
                this.rawString = rawString;
                this.options = options;
            }

            internal StringSplit(string rawString, char[] separator, int count, StringSplitOptions options)
            {
                this.rawString = rawString;
                this.cSeparator = default;
                this.cSeparators = separator;
                this.sSeparator = default;
                this.sSeparators = default;
                this.splitBy = SplitBy.Chars;
                this.count = count;
                this.rawString = rawString;
                this.options = options;
            }

            internal StringSplit(string rawString, string separator, int count, StringSplitOptions options)
            {
                this.rawString = rawString;
                this.cSeparator = default;
                this.cSeparators = default;
                this.sSeparator = separator;
                this.sSeparators = default;
                this.splitBy = SplitBy.String;
                this.count = count;
                this.rawString = rawString;
                this.options = options;
            }

            internal StringSplit(string rawString, string[] separator, int count, StringSplitOptions options)
            {
                this.rawString = rawString;
                this.cSeparator = default;
                this.cSeparators = default;
                this.sSeparator = default;
                this.sSeparators = separator;
                this.splitBy = SplitBy.String;
                this.count = count;
                this.rawString = rawString;
                this.options = options;
            }

            internal enum SplitBy
            {
                Char,
                Chars,
                String,
                Strings,
            }

            public IEnumerator<StringSegment> GetEnumerator()
            {
                return new StringSegmentEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public struct StringSegmentEnumerator : IEnumerator<StringSegment>
            {
                private StringSplit stringSplit;
                private StringSegment processing;

                internal StringSegmentEnumerator(StringSplit stringSplit)
                {
                    this.stringSplit = stringSplit;
                    this.processing = new StringSegment(stringSplit.rawString, 0, stringSplit.rawString.Length);
                    this.Current = default;
                }

                public bool MoveNext()
                {
                    string rawString = this.stringSplit.rawString;
                    if (this.processing.startIndex == rawString.Length)
                    {
                        return false;
                    }

                    int index = -1;
                    int sepLength = 1;
                    switch (this.stringSplit.splitBy)
                    {
                        case SplitBy.Char:
                            index = rawString.IndexOf(this.stringSplit.cSeparator, this.processing.startIndex);
                            break;
                        case SplitBy.Chars:
                            index = rawString.IndexOfAny(this.stringSplit.cSeparators, this.processing.startIndex);
                            break;
                        case SplitBy.String:
                            sepLength = this.stringSplit.sSeparator.Length;
                            index = rawString.IndexOf(this.stringSplit.sSeparator, this.processing.startIndex, StringComparison.Ordinal);
                            break;
                        case SplitBy.Strings:
                            for (int i = 0, count = this.stringSplit.sSeparators.Length; i < count; ++i)
                            {
                                string s = this.stringSplit.sSeparators[i];
                                sepLength = s.Length;
                                index = rawString.IndexOf(s, this.processing.startIndex, StringComparison.Ordinal);
                                if (index >= 0)
                                {
                                    break;
                                }
                            }

                            break;
                    }

                    if (index == -1)
                    {
                        this.Current = this.processing;
                        this.processing = new StringSegment(rawString, rawString.Length, 0);
                    }
                    else
                    {
                        this.Current = new StringSegment(rawString, this.processing.startIndex, index - this.processing.startIndex);
                        int newStart = index + sepLength;
                        this.processing = new StringSegment(rawString, newStart, rawString.Length - newStart);
                    }

                    return true;
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }

                public void Dispose()
                {
                }

                public StringSegment Current { get; private set; }

                object IEnumerator.Current => this.Current;
            }
        }

        internal static IEnumerable<StringSegment> Split(string source, char separator, int count = int.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (options < StringSplitOptions.None || options > StringSplitOptions.RemoveEmptyEntries)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            return new StringSplit(source, separator, count, options);
        }

        internal static IEnumerable<StringSegment> Split(string source, char[] separator, int count = int.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (options < StringSplitOptions.None || options > StringSplitOptions.RemoveEmptyEntries)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            return new StringSplit(source, separator, count, options);
        }

        internal static IEnumerable<StringSegment> Split(string source, string separator, int count = int.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (options < StringSplitOptions.None || options > StringSplitOptions.RemoveEmptyEntries)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            return new StringSplit(source, separator, count, options);
        }

        internal static IEnumerable<StringSegment> Split(string source, string[] separator, int count = int.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (options < StringSplitOptions.None || options > StringSplitOptions.RemoveEmptyEntries)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            return new StringSplit(source, separator, count, options);
        }
    }
}
