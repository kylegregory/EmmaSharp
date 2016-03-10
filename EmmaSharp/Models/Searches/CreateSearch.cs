using EmmaSharp.Extensions;
using Newtonsoft.Json;

namespace EmmaSharp.Models.Searches
{
    public class CreateSearch
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(PlainJsonStringConverter))]
        [JsonProperty("criteria")]
        public string Criteria { get; set; }
    }
}
