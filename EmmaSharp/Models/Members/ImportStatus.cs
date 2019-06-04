using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Members
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportStatus
    {
        [EnumMember(Value = "o")]
        Okay,
        [EnumMember(Value = "e")]
        Error,
        [EnumMember(Value = "q")]
        Queued,
        Unknown
    }
}
