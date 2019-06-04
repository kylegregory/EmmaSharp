using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MailingType
    {
        [EnumMember(Value = "m")]
        Standard,
        [EnumMember(Value = "t")]
        Test,
        [EnumMember(Value = "r")]
        Trigger,
        [EnumMember(Value = "s")]
        Split,
        [EnumMember(Value = "c")]
        ContentSplit,
        Unknown
    }
}
