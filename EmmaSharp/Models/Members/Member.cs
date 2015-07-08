using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class Member
    {
        [JsonProperty("status")]
        public MemberStatus Status { get; set; }

        [JsonProperty("confirmed_opt_in")]
        public bool? ConfirmedOptIn { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; }

        [JsonProperty("member_id")]
        public int? MemberId { get; set; }

        [JsonProperty("last_modified_at")]
        public DateTime? LastModifiedAt { get; set; }

        [JsonProperty("member_status_id")]
        public string MemberStatusId { get; set; }

        [JsonProperty("plaintext_preferred")]
        public bool PlaintextPreferred { get; set; }

        [JsonProperty("email_error")]
        public bool? EmailError { get; set; }

        [JsonProperty("member_since")]
        public DateTime MemberSince { get; set; }

        [JsonProperty("bounce_count")]
        public int? BounceCount { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
