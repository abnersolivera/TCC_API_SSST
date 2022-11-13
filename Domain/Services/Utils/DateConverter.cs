using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAPIs.Converters
{
    public class DateConverter : JsonConverter<DateTime>
    {

        private string FormatDate = "dd/MM/yyyyTHH:mm:ssZ";

        //public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => DateTime.ParseExact(reader.GetString()!, FormatDate, CultureInfo.InvariantCulture);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //if (reader.TryGetDateTime(out var date))
            var a = reader;
            if (reader.ValueSpan.IsEmpty)
            {
                DateTime? Date = null;
                return Date.GetValueOrDefault();
            }
            return DateTime.ParseExact(reader.GetString()!, FormatDate, CultureInfo.InvariantCulture);



        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(FormatDate));
    }
}
