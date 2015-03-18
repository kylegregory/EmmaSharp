using EmmaSharp.Models.Members;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Searches
{
    public class SearchMembers
    {
        [DeserializeAs(Name = "members")]
        public IList<Member> Members { get; set; }
    }
}
