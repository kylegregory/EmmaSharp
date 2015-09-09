using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Extensions
{
    public class EmmaDateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Deal with this, ugh: "@D:2014-11-26T11:40:55"
            writer.WriteValue("@D:" + ((DateTime)value).ToString("s"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            else
            {
                string date = reader.Value.ToString().Replace("@D:", "");
                return DateTime.Parse(date);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
