using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Subscriptions
{
    public class SubscriptionImportBulk
    {
        [JsonProperty("import_id")]
        public long ImportId { get; set; }
    }
}
