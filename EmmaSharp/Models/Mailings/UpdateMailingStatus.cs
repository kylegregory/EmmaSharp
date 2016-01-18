using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UpdateMailingStatus
    {
        [EnumMember(Value = "canceled")]
        Canceled,
        [EnumMember(Value = "paused")]
        Paused,
        [EnumMember(Value = "ready")]
        Ready
    }
}