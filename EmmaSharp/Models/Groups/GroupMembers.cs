using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    public class GroupMembers
    {
        [JsonProperty("members")]
        public List<Member> Members { get; set; }
    }
}
