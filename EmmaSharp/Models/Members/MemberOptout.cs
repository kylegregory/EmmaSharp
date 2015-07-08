using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Members
{
    public class MemberOptout
    {
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }

		[JsonProperty("mailing_id")]
		public int MailingId { get; set; }
	}
}
