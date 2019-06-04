using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Mailings
{
    /// <summary>
    /// Class including just the Mailing Identifier.
    /// </summary>
    public class MailingIdentifier
    {
        /// <summary>
        /// Mailing Identifier.
        /// </summary>
        [JsonProperty("mailing_id")]
        public long MailingId { get; set; }
    }
}
