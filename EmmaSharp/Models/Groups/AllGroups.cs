using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Groups
{
    public class AllGroups
    {
        [DeserializeAs(Name = "groups")]
        public List<Group> Groups { get; set; }
    }
}
