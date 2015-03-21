using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class AllMailings
    {
        [DeserializeAs(Name = "mailings")]
        public List<Mailing> Mailings { get; set; }
    }
}
