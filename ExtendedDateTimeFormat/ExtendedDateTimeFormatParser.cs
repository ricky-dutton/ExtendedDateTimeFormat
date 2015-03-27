using System.ExtendedDateTimeFormat.Internal.Parsers;
using System.Linq;

namespace System.ExtendedDateTimeFormat
{
    public static class ExtendedDateTimeFormatParser
    {
        public static IExtendedDateTimeIndependentType ParseAll(string extendedDateTimeFormattedString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeFormattedString))
            {
                return null;
            }

            if (extendedDateTimeFormattedString.Contains('/'))
            {
                return ExtendedDateTimeIntervalParser.Parse(extendedDateTimeFormattedString);
            }

            if (extendedDateTimeFormattedString[0] == '{')
            {
                return (IExtendedDateTimeIndependentType)ExtendedDateTimeCollectionParser.Parse(extendedDateTimeFormattedString);
            }
            else if (extendedDateTimeFormattedString[0] == '[')
            {
                return (IExtendedDateTimeIndependentType)ExtendedDateTimePossibilityCollectionParser.Parse(extendedDateTimeFormattedString);
            }
            else if (extendedDateTimeFormattedString.Contains('u') || extendedDateTimeFormattedString.Contains('x'))
            {
                return (IExtendedDateTimeIndependentType)IncompleteExtendedDateTimeParser.Parse(extendedDateTimeFormattedString);
            }
            else
            {
                return (IExtendedDateTimeIndependentType)ExtendedDateTimeParser.Parse(extendedDateTimeFormattedString);
            }
        }

        public static ExtendedDateTimeInterval ParseInterval(string extendedDateTimeIntervalString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeIntervalString))
            {
                return null;
            }

            return ExtendedDateTimeIntervalParser.Parse(extendedDateTimeIntervalString);
        }

        public static ExtendedDateTimeCollection ParseCollection(string extendedDateTimeCollectionString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeCollectionString))
            {
                return null;
            }

            return ExtendedDateTimeCollectionParser.Parse(extendedDateTimeCollectionString);
        }

        public static ExtendedDateTimePossibilityCollection ParsePossibilityCollection(string extendedDateTimePossibilityCollectionString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimePossibilityCollectionString))
            {
                return null;
            }

            return ExtendedDateTimePossibilityCollectionParser.Parse(extendedDateTimePossibilityCollectionString);
        }

        public static IncompleteExtendedDateTime ParseincompleteExtendedDateTime(string incompleteExtendedDateTimeString)
        {
            if (string.IsNullOrWhiteSpace(incompleteExtendedDateTimeString))
            {
                return null;
            }

            return IncompleteExtendedDateTimeParser.Parse(incompleteExtendedDateTimeString);
        }

        public static ExtendedDateTime ParseExtendedDateTime(string extendedDateTimeString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeString))
            {
                return null;
            }

            return ExtendedDateTimeParser.Parse(extendedDateTimeString);
        }
    }
}