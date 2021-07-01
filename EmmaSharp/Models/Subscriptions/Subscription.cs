using EmmaSharp.Extensions;
using EmmaSharp.Models.Groups;
using EmmaSharp.Models.Mailings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Subscriptions
{      

    public class Subscription
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("import_status")]
        public string ImportStatus { get; set; }

        [JsonProperty("member_count")]
        public int? MemberCount { get; set; }

        [JsonProperty("modified_at")]
        public string ModifiedAt { get; set; }

        [JsonProperty("optout_count")]
        public int? OptoutCount { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("subscription_id")]
        public long? SubscriptionId { get; set; }

        [JsonProperty("subscription_name")]
        public string SubscriptionName { get; set; }

        [JsonProperty("subscription_order")]
        public int? SubscriptionOrder { get; set; }
    }
    public class Settings
    {
        [JsonProperty("show_on_default_preference_form")]
        public bool ShowOnDefaultPreferenceForm { get; set; }
    }

}
