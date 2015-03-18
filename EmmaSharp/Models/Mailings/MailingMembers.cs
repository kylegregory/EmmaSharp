using EmmaSharp.Models.Members;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingMembers
    {
        [DeserializeAs(Name = "members")]
        public IList<Member> Members { get; set; }
    }
}
