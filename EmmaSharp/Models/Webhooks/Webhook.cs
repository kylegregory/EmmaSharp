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

        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }
}
