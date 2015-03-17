using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models.Searches
{
    class Search
    {
        [JsonProperty("search_id")]
        public int SearchId { get; set; }

        [JsonProperty("optout_count")]
        public int OptoutCount { get; set; }

        [JsonProperty("error_count")]
        public int ErrorCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("criteria")]
        public string Criteria { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("last_run_at")]
        public DateTime? LastRunAt { get; set; }

        [JsonProperty("active_count")]
        public int ActiveCount { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }
    }
}
