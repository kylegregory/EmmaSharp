using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class MemberSignup
    {
        [JsonProperty("status")]
        public MemberStatus Status { get; set; }

        [JsonProperty("member_id")]
        public int MemberId { get; set; }
    }
}
