using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupType
    {
        [EnumMember(Value = "g")]
        Group,
        [EnumMember(Value = "t")]
        Test,
        [EnumMember(Value = "h")]
        Hidden,
        [EnumMember(Value = "all")]
        All,
        Unknown
    }
}
