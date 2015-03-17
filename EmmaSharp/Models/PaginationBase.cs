using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models
{
    class PaginationBase
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("count")]
        public bool Count { get; set; }
    }
}
