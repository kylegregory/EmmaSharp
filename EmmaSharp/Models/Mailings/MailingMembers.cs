using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingMembers
    {
        [JsonProperty("members")]
        public List<Member> Members { get; set; }
    }
}
