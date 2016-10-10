using EmmaSharp.Extensions;
using Newtonsoft.Json;

namespace EmmaSharp.Models.Searches
{
    public class CreateSearch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("criteria")]
        [JsonConverter(typeof(PlainJsonStringConverter))]
        public string Criteria { get; set; }
    }
}
