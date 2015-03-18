using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    public class AllGroups
    {
        [DeserializeAs(Name = "groups")]
        public IList<Group> Groups { get; set; }
    }
}
