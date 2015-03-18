using EmmaSharp.Models.Generics;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    public class ResponseLinks
    {
        [DeserializeAs(Name = "links")]
        public IList<Link> Links { get; set; }
    }
}
