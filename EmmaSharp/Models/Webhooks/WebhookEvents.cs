using RestSharp.Deserializers;

namespace EmmaSharp.Models.Webhooks
{
    public class WebhookEvents
    {
        [DeserializeAs(Name = "event_name")]
        public string EventName { get; set; }

        [DeserializeAs(Name = "webhook_event")]
        public int WebhookEvent { get; set; }

        [DeserializeAs(Name = "description")]
        public string Description { get; set; }
    }
}
