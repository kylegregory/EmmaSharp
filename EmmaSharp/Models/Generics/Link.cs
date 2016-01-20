using Newtonsoft.Json;

namespace EmmaSharp.Models.Generics
{
    public class Link
    {
        [JsonProperty("link_order")]
        public int? LinkOrder { get; set; }

        [JsonProperty("Link_name")]
        public string LinkName { get; set; }

        [JsonProperty("unique_clicks")]
        public int? UniqueClicks { get; set; }

        [JsonProperty("plaintext")]
        public bool Plaintext { get; set; }

        [JsonProperty("link_target")]
        public string LinkTarget { get; set; }

        [JsonProperty("total_clicks")]
        public int? TotalClicks { get; set; }

        [JsonProperty("link_id")]
        public int? LinkId { get; set; }
    }
}
