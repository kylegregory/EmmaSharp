using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Subscriptions
{
    public class SubscriptionBulk
    {
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }

    }

}
