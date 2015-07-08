using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    public class ResponseSignups
    {
        [JsonProperty("ref_member_id")]
        public int? ReferingMemberId { get; set; }

        [JsonProperty("mailing_mailing_id")]
        public int? MailingMailingId { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("member_id")]
        public int? MemberId { get; set; }

        [JsonProperty("member_since")]
        public DateTime? MemberSince { get; set; }

        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }

        [JsonProperty("email_user")]
        public string EmailUser { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("member_status_id")]
        public MemberStatus MemberStatusId { get; set; }
    }
}
