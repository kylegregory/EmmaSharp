using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models.Searches
{
    public class Search
    {
        [JsonProperty("search_id")]
        public long? SearchId { get; set; }

        [JsonProperty("optout_count")]
        public int? OptoutCount { get; set; }

        [JsonProperty("error_count")]
        public int? ErrorCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("criteria")]
        public string Criteria { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("last_run_at")]
        public DateTime? LastRunAt { get; set; }

        [JsonProperty("active_count")]
        public int? ActiveCount { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }
    }
}
