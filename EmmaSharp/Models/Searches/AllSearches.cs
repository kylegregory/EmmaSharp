using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Searches
{
    public class AllSearches
    {
        [DeserializeAs(Name = "searches")]
        public IList<Search> Searches { get; set; }
    }
}
