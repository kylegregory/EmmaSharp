using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingGroups
    {
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}
