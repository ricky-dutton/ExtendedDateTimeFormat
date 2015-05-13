﻿namespace System.ExtendedDateTimeFormat.Internal.Converters
{
    public static class WeekDateConverter
    {
        public static CalendarDate ToCalendarDate(WeekDate weekDate, CalendarDatePrecision precision)
        {
            if (weekDate.Precision != WeekDatePrecision.Day)
            {
                throw new ConversionException("The week date must be defined to the day to be converted to a calendar date without information loss.");
            }

            return ToOrdinalDate(weekDate).ToCalendarDate(precision);
        }

        public static OrdinalDate ToOrdinalDate(WeekDate weekDate)
        {
            if (weekDate.Precision != WeekDatePrecision.Day)
            {
                throw new ConversionException("The week date must be defined to the day to be converted to an ordinal date.");
            }

            var year = weekDate.Year;
            var ordinalDay = DateCalculator.DayOfYear(weekDate);
            var daysInYear = DateCalculator.DaysInYear(year);

            if (ordinalDay < 1)
            {
                ordinalDay += DateCalculator.DaysInYear(year - 1);
            }

            if (ordinalDay > daysInYear)
            {
                ordinalDay -= daysInYear;
            }

            return new OrdinalDate(year, ordinalDay);
        }
    }
}