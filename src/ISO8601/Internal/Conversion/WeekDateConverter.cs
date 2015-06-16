﻿namespace System.ISO8601.Internal.Conversion
{
    internal static class WeekDateConverter
    {
        internal static CalendarDate ToCalendarDate(WeekDate weekDate, CalendarDatePrecision precision)
        {
            if (weekDate.Precision != WeekDatePrecision.Day)
            {
                throw new ConversionException("The week date must be defined to the day to be converted to a calendar date without information loss.");
            }

            return ToOrdinalDate(weekDate).ToCalendarDate(precision);
        }

        internal static OrdinalDate ToOrdinalDate(WeekDate weekDate)
        {
            if (weekDate.Precision != WeekDatePrecision.Day)
            {
                throw new ConversionException("The week date must be defined to the day to be converted to an ordinal date.");
            }

            var year = weekDate.Year;
            var ordinalDay = DateTimeCalculator.DayOfYear(weekDate);
            var daysInYear = DateTimeCalculator.DaysInYear(year);

            if (ordinalDay < 1)
            {
                ordinalDay += DateTimeCalculator.DaysInYear(year - 1);
            }

            if (ordinalDay > daysInYear)
            {
                ordinalDay -= daysInYear;
            }

            return new OrdinalDate(year, ordinalDay);
        }
    }
}