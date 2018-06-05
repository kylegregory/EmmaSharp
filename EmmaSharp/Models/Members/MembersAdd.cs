using Newtonsoft.Json;

namespace EmmaSharp.Models.Members
{
    public class MembersAdd
    {
        [JsonProperty("import_id")]
        public long ImportId { get; set; }
    }
}
