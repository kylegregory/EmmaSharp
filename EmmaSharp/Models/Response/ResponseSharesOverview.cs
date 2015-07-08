using Newtonsoft.Json;

namespace EmmaSharp.Models.Response
{
    public class ResponseSharesOverview
    {
        [JsonProperty("share_count")]
        public int ShareCount { get; set; }

        [JsonProperty("share_clicks")]
        public int ShareClicks { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }
    }
}
