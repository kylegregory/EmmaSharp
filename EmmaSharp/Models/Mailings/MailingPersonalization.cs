using Newtonsoft.Json;

namespace EmmaSharp.Models.Mailings
{
    /// <summary>
    /// Validate that a mailing has valid personalization-tag syntax.
    /// </summary>
    public class MailingPersonalization
    {
        /// <summary>
        /// The html contents of the mailing.
        /// </summary>
        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }

        /// <summary>
        /// The plaintext contents of the mailing. Unlike in create_mailing, this param is not required.
        /// </summary>
        [JsonProperty("plaintext", NullValueHandling = NullValueHandling.Ignore)]
        public string Plaintext { get; set; }

        /// <summary>
        /// The subject of the mailing.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}
