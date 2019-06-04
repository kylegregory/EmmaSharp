using System;
using EmmaSharp.Extensions;
using Newtonsoft.Json;

namespace EmmaSharp.Models.Webhooks
{
    public class WebhookPostMemberSignup
    {
        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("resource_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResourceUrl { get; set; }

        [JsonProperty("data")]
        public WebhookPostDataMemberSignup Data { get; set; }
    }

    public class WebhookPostDataMemberSignup
    {
        [JsonProperty("signup_form_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SignupFormId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("member_id")]
        public string MemberId { get; set; }

        [JsonProperty("mailing_id", NullValueHandling = NullValueHandling.Ignore)]
        public long MailingId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

    }
}
