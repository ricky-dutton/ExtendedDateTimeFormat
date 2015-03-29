﻿using System.Linq;

namespace System.ExtendedDateTimeFormat.Internal.Parsers
{
    internal static class ExtendedDateTimeIntervalParser
    {
        public static ExtendedDateTimeInterval Parse(string extendedDateTimeIntervalString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeIntervalString))
            {
                return null;
            }

            var intervalPartStrings = extendedDateTimeIntervalString.Split(new char[] { '/' });

            if (intervalPartStrings.Length != 2)
            {
                throw new ParseException("An interval string must contain exactly one forward slash.", extendedDateTimeIntervalString);
            }

            var startString = intervalPartStrings[0];
            var endString = intervalPartStrings[1];
            var extendedDateTimeInterval = new ExtendedDateTimeInterval();

            if (startString[0] == '{')
            {
                throw new ParseException("An interval cannot contain a collection.", startString);
            }

            if (startString == "unknown")
            {
                extendedDateTimeInterval.Start = ExtendedDateTime.Unknown;
            }
            else if (startString == "open")
            {
                extendedDateTimeInterval.Start = ExtendedDateTime.Open;
            }
            else if (startString[0] == '[')
            {
                extendedDateTimeInterval.Start = ExtendedDateTimePossibilityCollectionParser.Parse(startString);
            }
            else if (startString.Contains('u') || startString.Contains('x'))
            {
                extendedDateTimeInterval.Start = PartialExtendedDateTimeParser.Parse(startString);
            }
            else
            {
                extendedDateTimeInterval.Start = ExtendedDateTimeParser.Parse(startString);
            }

            if (endString[0] == '{')
            {
                throw new ParseException("An interval cannot contain a collection.", startString);
            }

            if (endString == "unknown")
            {
                extendedDateTimeInterval.End = ExtendedDateTime.Unknown;
            }
            else if (endString == "open")
            {
                extendedDateTimeInterval.End = ExtendedDateTime.Open;
            }
            else if (endString[0] == '[')
            {
                extendedDateTimeInterval.End = ExtendedDateTimePossibilityCollectionParser.Parse(endString);
            }
            else if (endString.Contains('u') || endString.Contains('x'))
            {
                extendedDateTimeInterval.End = PartialExtendedDateTimeParser.Parse(endString);
            }
            else
            {
                extendedDateTimeInterval.End = ExtendedDateTimeParser.Parse(endString);
            }

            return extendedDateTimeInterval;
        }
    }
}