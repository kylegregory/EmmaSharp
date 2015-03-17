using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Searches
{
    class SearchMembers
    {
        [JsonProperty("members")]
        public IList<Member> Members { get; set; }
    }
}
