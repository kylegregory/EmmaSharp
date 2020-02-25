﻿using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Members
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MemberStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "opt-out")]
        Optout,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "forwarded")]
        Forwarded,
        Unknown
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MemberStatusShort
    {
        [EnumMember(Value = "a")]
        Active,
        [EnumMember(Value = "o")]
        Optout,
        [EnumMember(Value = "e")]
        Error,
        [EnumMember(Value = "f")]
        Forwarded,
        Unknown
    }

    public class MemberStatusShortList 
    {
        [JsonProperty("member_status_id")]
        public List<MemberStatusShort> MemberStatusId { get; set; }
    }
}
