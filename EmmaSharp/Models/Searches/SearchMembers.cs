using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Searches
{
    public class SearchMembers
    {
        [JsonProperty("members")]
        public List<Member> Members { get; set; }
    }
}
