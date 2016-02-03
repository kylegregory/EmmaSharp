using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class MembersAdd
    {
        [JsonProperty("import_id")]
        public int ImportId { get; set; }
    }
}
