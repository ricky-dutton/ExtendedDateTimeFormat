﻿namespace System.EDTF
{
    public static class DateTimeExtensions
    {
        public static ExtendedDateTime ToExtendedDateTime(this System.DateTime d)
        {
            return new ExtendedDateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }
    }
}