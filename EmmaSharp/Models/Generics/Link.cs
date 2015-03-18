using RestSharp.Deserializers;

namespace EmmaSharp.Models.Generics
{
    public class Link
    {
        [DeserializeAs(Name = "mailing_id")]
        public int MailingId { get; set; }

        [DeserializeAs(Name = "plaintext")]
        public bool Plaintext { get; set; }

        [DeserializeAs(Name = "link_id")]
        public int LinkId { get; set; }

        [DeserializeAs(Name = "Link_name")]
        public string LinkName { get; set; }

        [DeserializeAs(Name = "link_target")]
        public string LinkTarget { get; set; }

        [DeserializeAs(Name = "link_order")]
        public int LinkOrder { get; set; }

        [DeserializeAs(Name = "unique_clicks")]
        public int UniqueClicks { get; set; }

        [DeserializeAs(Name = "total_clicks")]
        public int TotalClicks { get; set; }
    }
}
