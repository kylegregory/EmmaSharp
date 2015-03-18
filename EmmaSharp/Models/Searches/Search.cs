using RestSharp.Deserializers;
using System;

namespace EmmaSharp.Models.Searches
{
    public class Search
    {
        [DeserializeAs(Name = "search_id")]
        public int SearchId { get; set; }

        [DeserializeAs(Name = "optout_count")]
        public int OptoutCount { get; set; }

        [DeserializeAs(Name = "error_count")]
        public int ErrorCount { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "criteria")]
        public string Criteria { get; set; }

        [DeserializeAs(Name = "deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [DeserializeAs(Name = "purged_at")]
        public DateTime? PurgedAt { get; set; }

        [DeserializeAs(Name = "last_run_at")]
        public DateTime? LastRunAt { get; set; }

        [DeserializeAs(Name = "active_count")]
        public int ActiveCount { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }
    }
}
