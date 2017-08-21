using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Mailings
{
    /// <summary>
    /// Send a prior mailing to additional recipients. A new mailing will be created that inherits its content from the original.
    /// </summary>
    public class ResendMailing
    {
        /// <summary>
        /// An array of email addresses to which the new mailing should be sent.
        /// </summary>
        [JsonProperty("recipient_emails")]
        public List<string> RecipientEmails { get; set; }

        /// <summary>
        /// A list of email addresses that heads up notification emails will be sent to.
        /// </summary>
        [JsonProperty("heads_up_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> HeadsUpEmails { get; set; }

        /// <summary>
        /// An array of member groups to which the new mailing should be sent.
        /// </summary>
        [JsonProperty("recipient_groups", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RecipientGroups { get; set; }

        /// <summary>
        /// A list of searches that this mailing should be sent to.
        /// </summary>
        [JsonProperty("recipient_searches", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RecipientSearches { get; set; }

        /// <summary>
        /// The message sender. If this is not supplied, the sender of the original mailing will be used.
        /// </summary>
        [JsonProperty("sender", NullValueHandling = NullValueHandling.Ignore)]
        public string Sender { get; set; }
    }
}
