using Newtonsoft.Json;

namespace EmmaSharp.Models.Webhooks
{
    public class Webhook
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("webhook_id")]
        public int? WebhookId { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("name")]
        public string Event { get; set; }
    }
}
