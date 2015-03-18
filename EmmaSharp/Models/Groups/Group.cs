using RestSharp.Deserializers;
using System;

namespace EmmaSharp.Models
{
    public class Group
    {
        [DeserializeAs(Name = "active_count")]
        public int ActiveCount { get; set; }

        [DeserializeAs(Name = "deleted_at")]
        public DateTime DeletedAt { get; set; }

        [DeserializeAs(Name = "error_count")]
        public int ErrorCount { get; set; }

        [DeserializeAs(Name = "outout_count")]
        public int OptoutCount { get; set; }

        [DeserializeAs(Name = "group_type")]
        public string GroupType { get; set; }

        [DeserializeAs(Name = "member_group_id")]
        public int MemberGroupId { get; set; }

        [DeserializeAs(Name = "purged_at")]
        public DateTime PurgedAt { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "group_name")]
        public string GroupName { get; set; }
    }
}
