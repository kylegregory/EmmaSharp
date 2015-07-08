using Newtonsoft.Json;

namespace EmmaSharp.Models
{
    public class PaginationBase
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }

        [JsonProperty("count")]
        public bool Count { get; set; }
    }
}
