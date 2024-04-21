// -----------------------------------------------------------------------
// <copyright file="DateTimeExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.DateTimeExt
{
    using System;

    public static class DateTimeExt
    {
        private static readonly DateTime reference = new DateTime(1970, 1, 1).ToLocalTime();

        public static long ToTimeStamp(this DateTime dateTime)
        {
            return (long)(dateTime - reference).TotalSeconds;
        }

        public static long ToTimeStampMilliseconds(this DateTime dateTime)
        {
            return (long)(dateTime - reference).TotalMilliseconds;
        }

        public static DateTime FromTimeStamp(long timeStamp)
        {
            return reference.AddSeconds(timeStamp).ToLocalTime();
        }

        public static DateTime FromTimeStampMilliseconds(long timeStampMilliseconds)
        {
            return reference.AddMilliseconds(timeStampMilliseconds).ToLocalTime();
        }
    }
}
