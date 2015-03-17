using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    class AllImports
    {
        [JsonProperty("imports")]
        public IList<Import> Imports { get; set; }
    }
}
