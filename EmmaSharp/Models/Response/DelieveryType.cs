using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Response
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DelieveryType
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "delivered")]
        Delivered,
        [EnumMember(Value = "bounced")]
        Bounced,
        [EnumMember(Value = "hard")]
        Hard,
        [EnumMember(Value = "soft")]
        Soft
    }
}
