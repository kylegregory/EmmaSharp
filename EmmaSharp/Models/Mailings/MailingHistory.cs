using EmmaSharp.Models.Members;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingHistory
    {
        [JsonProperty("mailing_type")]
        public MailingType MailingType { get; set; }

        [JsonProperty("clicked")]
        public DateTime? Clicked { get; set; }

        [JsonProperty("opened")]
        public DateTime? Opened { get; set; }

        [JsonProperty("mailing_id")]
        public int MailingId { get; set; }

        [JsonProperty("delivery_ts")]
        public DateTime? DelieveryTimestamp { get; set; }

        [JsonProperty("delivery_type")]
        public DeliveryTypeShort DelieveryType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("forwarded")]
        public DateTime? Forwarded { get; set; }

        [JsonProperty("parent_mailing_id")]
        public int ParentMailingId { get; set; }

        [JsonProperty("shared")]
        public DateTime? Shared { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }
    }
}
