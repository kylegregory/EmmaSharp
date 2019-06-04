using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MailingStatus
    {
        [EnumMember(Value = "p")]
        Pending,
        [EnumMember(Value = "a")]
        Paused,
        [EnumMember(Value = "s")]
        Sending,
        [EnumMember(Value = "x")]
        Canceled,
        [EnumMember(Value = "c")]
        Complete,
        [EnumMember(Value = "f")]
        Failed,
        Unknown
    }
}
