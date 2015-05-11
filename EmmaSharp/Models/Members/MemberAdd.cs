using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class MemberAdd
    {
        [DeserializeAs(Name = "status")]
        public MemberStatus Status { get; set; }

        [DeserializeAs(Name = "member_id")]
        public int MemberId { get; set; }

        [DeserializeAs(Name = "added")]
        public bool Added { get; set; }
    }
}
