using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    class AllGroups
    {
        [JsonProperty("groups")]
        public IList<Group> Groups { get; set; }
    }
}
