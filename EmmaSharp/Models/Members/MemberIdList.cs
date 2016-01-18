using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    public class MemberIdList
    {
        [JsonProperty("member_ids")]
        public List<string> MemberIds { get; set; }
    }
}
