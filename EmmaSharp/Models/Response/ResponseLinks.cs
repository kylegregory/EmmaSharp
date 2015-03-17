using EmmaSharp.Models.Generics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    class ResponseLinks
    {
        [JsonProperty("links")]
        public IList<Link> Links { get; set; }
    }
}
