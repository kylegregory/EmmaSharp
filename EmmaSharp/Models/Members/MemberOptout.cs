using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models.Members
{
    public class MemberOptout
    {
        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }

		[JsonProperty("mailing_id")]
		public long? MailingId { get; set; }
	}
}
