using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class Member
    {
        [DeserializeAs(Name = "status")]
        public string Status { get; set; }

        [DeserializeAs(Name = "confirmed_opt_in")]
        public bool? ConfirmedOptIn { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "fields")]
        public Dictionary<string, string> Fields { get; set; }

        [DeserializeAs(Name = "member_id")]
        public int MemberId { get; set; }

        [DeserializeAs(Name = "last_modified_at")]
        public DateTime? LastModifiedAt { get; set; }

        [DeserializeAs(Name = "member_status_id")]
        public string MemberStatusId { get; set; }

        [DeserializeAs(Name = "plaintext_preferred")]
        public bool PlaintextPreferred { get; set; }

        [DeserializeAs(Name = "email_error")]
        public bool? EmailError { get; set; }

        [DeserializeAs(Name = "member_since")]
        public DateTime MemberSince { get; set; }

        [DeserializeAs(Name = "bounce_count")]
        public int BounceCount { get; set; }

        [DeserializeAs(Name = "deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [DeserializeAs(Name = "email")]
        public string Email { get; set; }
    }
}
