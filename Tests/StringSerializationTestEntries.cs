﻿using System;
using System.Collections.Generic;
using System.ExtendedDateTimeFormat;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class StringSerializationTestEntries
    {
        public static StringSerializationTestEntry[] DateEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTime(2001, 2, 3), "2001-02-03"),
            new StringSerializationTestEntry(new ExtendedDateTime(2008, 12), "2008-12"),
            new StringSerializationTestEntry(new ExtendedDateTime(2008), "2008"),
            new StringSerializationTestEntry(new ExtendedDateTime(-999), "-0999"),
            new StringSerializationTestEntry(new ExtendedDateTime(0), "0000")
        };

        public static StringSerializationTestEntry[] DateAndTimeEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTime(2001, 2, 3, 9, 30, 1, TimeZoneInfo.Local.BaseUtcOffset), "2001-02-03T09:30:01-08"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 1, 1, 10, 10, 10, TimeSpan.Zero), "2004-01-01T10:10:10Z"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 1, 1, 10, 10, 10, TimeSpan.FromHours(5)), "2004-01-01T10:10:10+05")
        };

        public static StringSerializationTestEntry[] IntervalEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1964), new ExtendedDateTime(2008)), "1964/2008"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 6), new ExtendedDateTime(2006, 8)), "2004-06/2006-08"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 2, 1), new ExtendedDateTime(2005, 2, 8)), "2004-02-01/2005-02-08"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 2, 1), new ExtendedDateTime(2005, 2)), "2004-02-01/2005-02"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 2, 1), new ExtendedDateTime(2005)), "2004-02-01/2005"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2005), new ExtendedDateTime(2006, 2)), "2005/2006-02")
        };

        public static readonly IEnumerable<StringSerializationTestEntry> L0Entries = DateEntries
            .Concat(DateAndTimeEntries)
            .Concat(IntervalEntries);

        public static StringSerializationTestEntry[] UncertainOrApproximateEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTime(1984, ExtendedDateTimeFlags.Uncertain), "1984?"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain), "2004-06?"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain), "2004-06-11?"),
            new StringSerializationTestEntry(new ExtendedDateTime(1984, ExtendedDateTimeFlags.Approximate), "1984~"),
            new StringSerializationTestEntry(new ExtendedDateTime(1984, ExtendedDateTimeFlags.Uncertain | ExtendedDateTimeFlags.Approximate), "1984?~")
        };

        public static StringSerializationTestEntry[] UnspecifiedEntries = 
        {
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("199u"), "199u"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("19uu"), "19uu"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("1999", "uu"), "1999-uu"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("1999", "01", "uu"), "1999-01-uu"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("1999", "uu", "uu"), "1999-uu-uu")
        };

        public static StringSerializationTestEntry[] L1ExtendedIntervalEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(ExtendedDateTime.Unknown, new ExtendedDateTime(2006)), "unknown/2006"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 6, 1), ExtendedDateTime.Unknown), "2004-06-01/unknown"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 1, 1), ExtendedDateTime.Open), "2004-01-01/open"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984, ExtendedDateTimeFlags.Approximate), new ExtendedDateTime(2004, 6)), "1984~/2004-06"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984), new ExtendedDateTime(2004, 6, ExtendedDateTimeFlags.Approximate, ExtendedDateTimeFlags.Approximate)), "1984/2004-06~"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984, ExtendedDateTimeFlags.Approximate), new ExtendedDateTime(2004, ExtendedDateTimeFlags.Approximate)), "1984~/2004~"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984, ExtendedDateTimeFlags.Uncertain), new ExtendedDateTime(2004, ExtendedDateTimeFlags.Uncertain | ExtendedDateTimeFlags.Approximate)), "1984?/2004?~"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984, 6, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain), new ExtendedDateTime(2004, 8, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain)), "1984-06?/2004-08?"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984, 6, 2, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain), new ExtendedDateTime(2004, 8, 8, ExtendedDateTimeFlags.Approximate, ExtendedDateTimeFlags.Approximate, ExtendedDateTimeFlags.Approximate)), "1984-06-02?/2004-08-08~"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(1984, 6, 2, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain, ExtendedDateTimeFlags.Uncertain), ExtendedDateTime.Unknown), "1984-06-02?/unknown")
        };
            
        public static StringSerializationTestEntry[] YearExceedingFourDigitsEntries = 
        {
            new StringSerializationTestEntry(ExtendedDateTime.FromLongYear(170000002), "y170000002"),
            new StringSerializationTestEntry(ExtendedDateTime.FromLongYear(-170000002), "y-170000002")
        };

        public static StringSerializationTestEntry[] SeasonEntries = 
        {
            new StringSerializationTestEntry(ExtendedDateTime.FromSeason(2001, Season.Spring), "2001-21"),
            new StringSerializationTestEntry(ExtendedDateTime.FromSeason(2001, Season.Summer), "2001-22"),
            new StringSerializationTestEntry(ExtendedDateTime.FromSeason(2001, Season.Autumn), "2001-23"),
            new StringSerializationTestEntry(ExtendedDateTime.FromSeason(2001, Season.Winter), "2001-24")
        };

        public static readonly IEnumerable<StringSerializationTestEntry> L1ExtensionEntries = UncertainOrApproximateEntries
            .Concat(UnspecifiedEntries)
            .Concat(L1ExtendedIntervalEntries)
            .Concat(YearExceedingFourDigitsEntries)
            .Concat(SeasonEntries);

        public static StringSerializationTestEntry[] PartialUncertainOrApproximateEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, yearFlags: ExtendedDateTimeFlags.Uncertain), "2004?-06-11"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, yearFlags: ExtendedDateTimeFlags.Approximate, monthFlags: ExtendedDateTimeFlags.Approximate), "2004-06~-11"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, monthFlags: ExtendedDateTimeFlags.Uncertain), "2004-(06)?-11"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, dayFlags: ExtendedDateTimeFlags.Approximate), "2004-06-(11)~"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, monthFlags: ExtendedDateTimeFlags.Approximate | ExtendedDateTimeFlags.Uncertain), "2004-(06)?~"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, monthFlags: ExtendedDateTimeFlags.Uncertain, dayFlags: ExtendedDateTimeFlags.Uncertain), "(2004)-06-11?"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 11, yearFlags: ExtendedDateTimeFlags.Uncertain, dayFlags: ExtendedDateTimeFlags.Approximate), "2004?-06-(11)~"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, yearFlags: ExtendedDateTimeFlags.Uncertain, monthFlags: ExtendedDateTimeFlags.Uncertain | ExtendedDateTimeFlags.Approximate), "2004?-(06)?~"),
            new StringSerializationTestEntry(new ExtendedDateTime(2004, 6, 4, yearFlags: ExtendedDateTimeFlags.Uncertain, monthFlags: ExtendedDateTimeFlags.Approximate, dayFlags: ExtendedDateTimeFlags.Approximate), "(2004)?-06-04~"),
            new StringSerializationTestEntry(new ExtendedDateTime(2011, 6, 4, monthFlags: ExtendedDateTimeFlags.Approximate, dayFlags: ExtendedDateTimeFlags.Approximate), "(2011)-06-04~"),
            new StringSerializationTestEntry(ExtendedDateTime.FromSeason(2011, Season.Autumn, yearFlags: ExtendedDateTimeFlags.Approximate, seasonFlags: ExtendedDateTimeFlags.Approximate), "2011-23~")
        };

        public static StringSerializationTestEntry[] PartialUnspecifiedEntries = 
        {
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("156u", "12", "25"), "156u-12-25"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("15uu", "12", "25"), "15uu-12-25"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("15uu", "12", "uu"), "15uu-12-uu"),
            new StringSerializationTestEntry(new UnspecifiedExtendedDateTime("1560", "uu", "25"), "1560-uu-25")
        };

        public static StringSerializationTestEntry[] OneOfASetEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTimePossibilityCollection { new ExtendedDateTime(1667), new ExtendedDateTime(1668), new ExtendedDateTimeRange(new ExtendedDateTime(1670), new ExtendedDateTime(1672)) }, "[1667,1668,1670..1672]"),
            new StringSerializationTestEntry(new ExtendedDateTimePossibilityCollection { new ExtendedDateTimeRange(null, new ExtendedDateTime(1760, 12, 3)) }, "[..1760-12-03]"),
            new StringSerializationTestEntry(new ExtendedDateTimePossibilityCollection { new ExtendedDateTimeRange(new ExtendedDateTime(1760, 12), null) }, "[1760-12..]"),
            new StringSerializationTestEntry(new ExtendedDateTimePossibilityCollection { new ExtendedDateTime(1760, 1), new ExtendedDateTime(1760, 2), new ExtendedDateTimeRange(new ExtendedDateTime(1760, 12), null) }, "[1760-01,1760-02,1760-12..]"),
            new StringSerializationTestEntry(new ExtendedDateTimePossibilityCollection { new ExtendedDateTime(1667), new ExtendedDateTime(1760, 12) }, "[1667,1760-12]")
        };

        public static StringSerializationTestEntry[] MultipleDateEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTimeCollection { new ExtendedDateTime(1667), new ExtendedDateTime(1668), new ExtendedDateTimeRange(new ExtendedDateTime(1670), new ExtendedDateTime(1672)) }, "{1667,1668,1670..1672}"),
            new StringSerializationTestEntry(new ExtendedDateTimeCollection { new ExtendedDateTime(1960), new ExtendedDateTime(1961, 12) }, "{1960,1961-12}"),
        };

        public static StringSerializationTestEntry[] L2ExtendedIntervalEntries = 
        {
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new ExtendedDateTime(2004, 6, 1, dayFlags: ExtendedDateTimeFlags.Approximate), new ExtendedDateTime(2004, 6, 20, dayFlags: ExtendedDateTimeFlags.Approximate)), "2004-06-(01)~/2004-06-(20)~"),
            new StringSerializationTestEntry(new ExtendedDateTimeInterval(new UnspecifiedExtendedDateTime("2004", "06", "uu"), new ExtendedDateTime(2004, 7, 3)), "2004-06-uu/2004-07-03")
        };

        public static StringSerializationTestEntry[] ExponentialFormOfYearsExceedingFourDigitsEntries = 
        {
            new StringSerializationTestEntry(ExtendedDateTime.FromScientificNotation(17, 7), "y17e7"),
            new StringSerializationTestEntry(ExtendedDateTime.FromScientificNotation(-17, 7), "y-17e7"),
            new StringSerializationTestEntry(ExtendedDateTime.FromScientificNotation(17101, 4, 3), "y17101e4p3")
        };

        public static readonly IEnumerable<StringSerializationTestEntry> L2ExtensionEntries = PartialUncertainOrApproximateEntries
            .Concat(PartialUnspecifiedEntries)
            .Concat(OneOfASetEntries)
            .Concat(MultipleDateEntries)
            .Concat(L2ExtendedIntervalEntries)
            .Concat(ExponentialFormOfYearsExceedingFourDigitsEntries);

        public static readonly IEnumerable<StringSerializationTestEntry> SpecificationStrings = L0Entries
            .Concat(L1ExtensionEntries)
            .Concat(L2ExtensionEntries);
    }
}
