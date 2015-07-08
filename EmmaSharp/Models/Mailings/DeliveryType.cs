using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Mailings
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeliveryTypeShort
    {
        [EnumMember(Value = "d")]
        Delivered,
        [EnumMember(Value = "h")]
        Hard,
        [EnumMember(Value = "s")]
        Soft
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeliveryType
    {
        [EnumMember(Value = "delivered")]
        Delivered,
        [EnumMember(Value = "hard")]
        Hard,
        [EnumMember(Value = "short")]
        Soft
    }
}
