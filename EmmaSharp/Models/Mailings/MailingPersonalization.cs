using RestSharp.Deserializers;

namespace EmmaSharp.Models.Mailings
{
    public class MailingPersonalization
    {
        [DeserializeAs(Name = "paintext")]
        public string Plaintext { get; set; }

        [DeserializeAs(Name = "subject")]
        public string Subject { get; set; }

        [DeserializeAs(Name = "html_body")]
        public string HtmlBody { get; set; }
    }
}
