using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WidgetType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "long")]
        LongInt,
        [EnumMember(Value = "checkbox")]
        Checkbox,
        [EnumMember(Value = "select multiple")]
        SelectMultiple,
        [EnumMember(Value = "check_multiple")]
        CheckMultiple,
        [EnumMember(Value = "radio")]
        Radio,
        [EnumMember(Value = "date")]
        Date,
        [EnumMember(Value = "select one")]
        SelectOne,
        [EnumMember(Value = "number")]
        Number
    }
}
