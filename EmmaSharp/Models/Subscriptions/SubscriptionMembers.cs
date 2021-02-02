using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Subscriptions
{
    public class SubscriptionMembers
    {
        public List<Individual> MemberIds { get; set; }
    }
    public class Individual
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; }
    }
}
