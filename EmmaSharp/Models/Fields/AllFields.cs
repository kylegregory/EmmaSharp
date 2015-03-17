using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Fields
{
    class AllFields : PaginationBase
    {
        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }
    }
}
