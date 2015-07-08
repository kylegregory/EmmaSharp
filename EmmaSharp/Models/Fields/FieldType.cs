using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FieldType {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "text[]")]
        TextArray,
        [EnumMember(Value = "numeric")]
        Numeric,
        [EnumMember(Value = "boolean")]
        Boolean,
        [EnumMember(Value = "date")]
        Date,
        [EnumMember(Value = "timestamp")]
        Timestamp
    }
}
