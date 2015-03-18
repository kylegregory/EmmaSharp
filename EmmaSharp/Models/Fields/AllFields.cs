using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Fields
{
    public class AllFields : PaginationBase
    {
        [DeserializeAs(Name = "fields")]
        public List<Field> Fields { get; set; }
    }
}
