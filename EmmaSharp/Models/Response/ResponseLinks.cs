using EmmaSharp.Models.Generics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    public class ResponseLinks
    {
        [JsonProperty("links")]
        public List<Link> Links { get; set; }
    }
}
