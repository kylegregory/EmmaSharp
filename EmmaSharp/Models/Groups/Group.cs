using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace EmmaSharp.Models
{
    public class Group
    {
        [JsonProperty("active_count")]
        public int ActiveCount { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("error_count")]
        public int ErrorCount { get; set; }

        [JsonProperty("optout_count")]
        public int OptoutCount { get; set; }

        [JsonProperty("group_type")]
        public GroupType GroupType { get; set; }

        [JsonProperty("member_group_id")]
        public int MemberGroupId { get; set; }

        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }
}
