using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Members
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImportChangeType
    {
        [EnumMember(Value = "a")]
        Added,
        [EnumMember(Value = "c")]
        Confirmed,
        [EnumMember(Value = "d")]
        Deleted,
        [EnumMember(Value = "n")]
        Undeleted,
        [EnumMember(Value = "u")]
        Updated,
        [EnumMember(Value = "r")]
        UpdateRejected,
        [EnumMember(Value = "s")]
        SignedUp,
        [EnumMember(Value = "t")]
        StatusShifted,
        Unknown
    }
}
