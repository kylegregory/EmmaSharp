using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class AllImports
    {
        [DeserializeAs(Name = "imports")]
        public List<Import> Imports { get; set; }
    }
}
