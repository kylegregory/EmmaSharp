using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    class MailingMembers
    {
        [JsonProperty("members")]
        public IList<Member> Members { get; set; }
    }
}
