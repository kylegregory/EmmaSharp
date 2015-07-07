using RestSharp.Deserializers;

namespace EmmaSharp.Models.Webhooks
{
    public class Webhook
    {
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        [DeserializeAs(Name = "webhook_id")]
        public int WebhookId { get; set; }

        [DeserializeAs(Name = "method")]
        public string Method { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "name")]
        public string Event { get; set; }
    }
}
