using Newtonsoft.Json;

namespace EmmaSharp.Models.Mailings
{
    public class MailingPersonalization
    {
        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
