using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class MemberGroups
    {
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}
