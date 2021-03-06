using System.ComponentModel;
using System.EDTF.Internal.Converters;
using System.EDTF.Internal.Parsers;
using System.EDTF.Internal.Serializers;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.EDTF
{
    [Serializable]
    [TypeConverter(typeof(ExtendedDateTimeIntervalConverter))]
    public class ExtendedDateTimeInterval : IExtendedDateTimeIndependentType, ISerializable, IXmlSerializable
    {
        public ExtendedDateTimeInterval(ISingleExtendedDateTimeType start, ISingleExtendedDateTimeType end)
        {
            Start = start;
            End = end;
        }

        internal ExtendedDateTimeInterval()
        {
        }

        public TimeSpan Span()
        {
            return End.Latest() - Start.Earliest();
        }

        protected ExtendedDateTimeInterval(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            Parse((string)info.GetValue("edtiStr", typeof(string)), this);
        }

        public ISingleExtendedDateTimeType End { get; set; }

        public ISingleExtendedDateTimeType Start { get; set; }

        public static ExtendedDateTimeInterval Parse(string extendedDateTimeIntervalString)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeIntervalString))
            {
                return null;
            }

            return ExtendedDateTimeIntervalParser.Parse(extendedDateTimeIntervalString);
        }

        public ExtendedDateTime Earliest()
        {
            return Start.Earliest();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("edtiStr", ToString());
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public ExtendedDateTime Latest()
        {
            return End.Latest();
        }

        public void ReadXml(XmlReader reader)
        {
            Parse(reader.ReadString(), this);
        }

        public override string ToString()
        {
            return ExtendedDateTimeIntervalSerializer.Serialize(this);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(ToString());
        }

        internal static ExtendedDateTimeInterval Parse(string extendedDateTimeIntervalString, ExtendedDateTimeInterval extendedDateTimeInterval = null)
        {
            if (string.IsNullOrWhiteSpace(extendedDateTimeIntervalString))
            {
                return null;
            }

            return ExtendedDateTimeIntervalParser.Parse(extendedDateTimeIntervalString, extendedDateTimeInterval);
        }
    }
}