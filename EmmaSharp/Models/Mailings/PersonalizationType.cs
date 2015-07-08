using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        Subject
    }
}
