using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    class ResponseShares
    {
        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("share_clicks")]
        public int ShareClicks { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("member_id")]
        public int MemberId { get; set; }

        [JsonProperty("member_since")]
        public DateTime? MemberSince { get; set; }

        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }

        [JsonProperty("email_user")]
        public string EmailUser { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("member_status_id")]
        public int MemberStatusId { get; set; }
    }
}
