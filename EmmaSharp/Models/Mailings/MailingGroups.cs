using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    class MailingGroups
    {
        [JsonProperty("groups")]
        public IList<Group> Groups { get; set; }
    }
}
