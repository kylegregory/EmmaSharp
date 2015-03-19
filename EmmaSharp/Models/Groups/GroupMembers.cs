using EmmaSharp.Models.Members;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    public class GroupMembers
    {
        [DeserializeAs(Name = "members")]
        public List<Member> Members { get; set; }
    }
}
