using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingGroups
    {
        [DeserializeAs(Name = "groups")]
        public IList<Group> Groups { get; set; }
    }
}
