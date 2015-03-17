using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    class AllMailings
    {
        [JsonProperty("mailings")]
        public IList<Mailing> Mailings { get; set; }
    }
}
