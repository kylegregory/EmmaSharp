using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Members
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportChangeType
    {
        [EnumMember(Value = "a")]
        Add,
        [EnumMember(Value = "u")]
        Update
    }
}
