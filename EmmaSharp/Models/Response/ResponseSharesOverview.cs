using RestSharp.Deserializers;

namespace EmmaSharp.Models.Response
{
    public class ResponseSharesOverview
    {
        [DeserializeAs(Name = "share_count")]
        public int ShareCount { get; set; }

        [DeserializeAs(Name = "share_clicks")]
        public int ShareClicks { get; set; }

        [DeserializeAs(Name = "network")]
        public string Network { get; set; }
    }
}
