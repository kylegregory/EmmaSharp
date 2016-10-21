using EmmaSharp.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    public class BaseGroup
    {
        
    }
    public class Group : BaseGroup
    {
        [JsonProperty("active_count")]
        public int? ActiveCount { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("error_count")]
        public int? ErrorCount { get; set; }

        [JsonProperty("optout_count")]
        public int? OptoutCount { get; set; }

        [JsonProperty("group_type")]
        public GroupType GroupType { get; set; }

        [JsonProperty("member_group_id")]
        public int? MemberGroupId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }

    public class CreateGroups
    {
        [JsonProperty("groups")]
        public List<GroupName> Groups { get; set; }
    }

    public class GroupName
    {
        [JsonProperty("group_name")]
        public string Name { get; set; }
    }

    public class UpdateGroup : GroupName
    {

    }
}
