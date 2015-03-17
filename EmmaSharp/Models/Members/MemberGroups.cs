using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    class MemberGroups
    {
        [JsonProperty("groups")]
        public IList<Group> Groups { get; set; }
    }
}
