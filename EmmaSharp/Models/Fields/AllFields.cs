using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Fields
{
    class AllFields : PaginationBase
    {
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
    }
}
