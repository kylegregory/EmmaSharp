using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class MemberOptout
    {
		[DeserializeAs(Name = "timestamp")]
		public DateTime Timestamp { get; set; }

		[DeserializeAs(Name = "mailing_id")]
		public int MailingId { get; set; }
	}
}
