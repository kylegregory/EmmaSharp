using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    class GroupMembers
    {
        [JsonProperty("members")]
        public IList<Member> Members { get; set; }
    }
}
