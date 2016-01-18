using EmmaSharp.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        Split
    }
}
