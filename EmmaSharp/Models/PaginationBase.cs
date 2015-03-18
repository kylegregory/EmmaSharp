using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
    public class PaginationBase
    {
        [DeserializeAs(Name = "start")]
        public int Start { get; set; }

        [DeserializeAs(Name = "end")]
        public int End { get; set; }

        [DeserializeAs(Name = "count")]
        public bool Count { get; set; }
    }
}
