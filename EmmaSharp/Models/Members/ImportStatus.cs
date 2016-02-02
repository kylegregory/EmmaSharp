using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Members
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportStatus
    {
        [EnumMember(Value = "o")]
        Okay,
        [EnumMember(Value = "e")]
        Error
    }
}
