using Newtonsoft.Json;

namespace EmmaSharp.Models.Webhooks
{
    public class WebhookEvents
    {
        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("webhook_event")]
        public int WebhookEvent { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
