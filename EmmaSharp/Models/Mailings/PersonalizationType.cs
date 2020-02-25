using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PersonalizationType
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "html")]
        Html,
        [EnumMember(Value = "plaintext")]
        PlainText,
        [EnumMember(Value = "subject")]
        Subject,
        Unknown
    }
}
