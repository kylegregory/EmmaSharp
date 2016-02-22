using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Extensions
{
    /// <summary>
    /// Emma has custom DateTime strings. So here's where we convert them into something C# can handle.
    /// </summary>
    public class EmmaDateConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object. Writes a DateTime value that Emma expects.
        /// </summary>
        /// <param name="writer">Instance of the JsonWriter class.</param>
        /// <param name="value">The value of the Date to be serialized.</param>
        /// <param name="serializer">Instance of the JsonSearlizer class.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Deal with this, ugh: "@D:2014-11-26T11:40:55"
            writer.WriteValue("@D:" + ((DateTime)value).ToString("s"));
        }

        /// <summary>
        /// Reads the JSON representation of the object. In this case a DateTime that C# can parse.
        /// </summary>
        /// <param name="reader">Instance of the JsonREader class.</param>
        /// <param name="objectType">The type of object to read.</param>
        /// <param name="existingValue">The existing object value.</param>
        /// <param name="serializer">Instance of the JsonSearlizer class.</param>
        /// <returns>The object value.</returns>
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

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
