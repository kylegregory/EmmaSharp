using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    class AllMembers
    {
        [JsonProperty("members")]
        public IList<Member> Members { get; set; }
    }
}
