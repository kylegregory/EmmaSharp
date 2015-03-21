using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class AllMembers
    {
        [DeserializeAs(Name = "members")]
        public List<Member> Members { get; set; }
    }
}
