using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Members
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MemberStatus
    {
        [EnumMember(Value = "a")]
        Active,
        [EnumMember(Value = "o")]
        Optout,
        [EnumMember(Value = "e")]
        Error,
        [EnumMember(Value = "f")]
        Forwarded
    }
}
