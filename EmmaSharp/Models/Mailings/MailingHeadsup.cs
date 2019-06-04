using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models.Mailings
{
    /// <summary>
    /// Class representing the return values on a heads up information of a mailing.
    /// </summary>
    public class MailingHeadsUp
    {
        /// <summary>
        /// Timestamp of when the heads up mailing was sent.
        /// </summary>
        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("sent_ts")]
        public DateTime? SentTimestamp { get; set; }

        /// <summary>
        /// Email address the heads up email was sent
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Mailing associated with these heads up mailings.
        /// </summary>
        [JsonProperty("mailing_id")]
        public long MailingId { get; set; }
    }
}
