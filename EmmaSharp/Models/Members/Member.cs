using EmmaSharp.Extensions;
using EmmaSharp.Models.Fields;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class Member
    {
        [JsonProperty("status")]
        public MemberStatus Status { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("confirmed_opt_in")]
        public DateTime? ConfirmedOptIn { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; }

        [JsonProperty("member_id")]
        public long? MemberId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("last_modified_at")]
        public DateTime? LastModifiedAt { get; set; }

        // Updated to ..Short for Groups Methods.
        [JsonProperty("member_status_id")]
        public MemberStatusShort MemberStatusId { get; set; }

        [JsonProperty("plaintext_preferred")]
        public bool PlaintextPreferred { get; set; }

        [JsonProperty("email_error")]
        public string EmailError { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("member_since")]
        public DateTime MemberSince { get; set; }

        [JsonProperty("bounce_count")]
        public int? BounceCount { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
