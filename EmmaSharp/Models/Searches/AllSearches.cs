using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Searches
{
    class AllSearches
    {
        [JsonProperty("searches")]
        public IList<Search> Searches { get; set; }
    }
}
