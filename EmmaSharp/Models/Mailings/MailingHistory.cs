using EmmaSharp.Models.Members;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingHistory
    {
        [DeserializeAs(Name = "mailing_type")]
        public MailingType MailingType { get; set; }

        [DeserializeAs(Name = "clicked")]
        public DateTime? Clicked { get; set; }

        [DeserializeAs(Name = "opened")]
        public DateTime? Opened { get; set; }

        [DeserializeAs(Name = "mailing_id")]
        public int MailingId { get; set; }

        [DeserializeAs(Name = "delivery_ts")]
        public DateTime? DelieveryTimestamp { get; set; }

        [DeserializeAs(Name = "delivery_type")]
        public DeliveryTypeShort DelieveryType { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "forwarded")]
        public DateTime? Forwarded { get; set; }

        [DeserializeAs(Name = "parent_mailing_id")]
        public int ParentMailingId { get; set; }

        [DeserializeAs(Name = "shared")]
        public DateTime? Shared { get; set; }

        [DeserializeAs(Name = "subject")]
        public string Subject { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }
    }
}
