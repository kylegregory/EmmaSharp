using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Webhooks
{
    /// <summary>
    /// Common Properties to all Webhook classes.
    /// </summary>
    public class WebhookBase
    {
        /// <summary>
        /// The name of an event to register this webhook for
        /// </summary>
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public string Event { get; set; }

        /// <summary>
        /// The URL to call when the event happens
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// The method to use when calling the webhook. Can be GET or POST. Defaults to POST.
        /// </summary>
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public WebhookMethod Method { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Webhook : WebhookBase
    {
        /// <summary>
        /// The Id of the webhook
        /// </summary>
        [JsonProperty("webhook_id")]
        public long? WebhookId { get; set; }

        /// <summary>
        /// The ID associated with the webhook account
        /// </summary>
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }
    }
    /// <summary>
    /// Properties associated with creating webhooks
    /// </summary>
    public class CreateWebhook : WebhookBase
    {
        /// <summary>
        /// The public_key to use for authentication. Note: this can also be spelled “user_id” but this is deprecated.
        /// </summary>
        [JsonProperty("public_key", NullValueHandling = NullValueHandling.Ignore)]
        public string PublicKey { get; set; }
    }
    /// <summary>
    /// Properties associated with updating webhooks
    /// </summary>
    public class UpdateWebhook : CreateWebhook
    {
    }
    /// <summary>
    /// Webhook method enumeration
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookMethod
    {
        /// <summary>
        /// Webhook uses HTTP GET
        /// </summary>
        [EnumMember(Value = "GET")]
        Get,
        /// <summary>
        /// Webhook uses HTTP POST
        /// </summary>
        [EnumMember(Value = "POST")]
        Post,
        Unknown
    }
}
