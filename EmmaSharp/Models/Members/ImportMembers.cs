using Newtonsoft.Json;

namespace EmmaSharp.Models.Members
{
    public class ImportMembers
    {
        [JsonProperty("member_id")]
        public long? MemberId { get; set; }

        [JsonProperty("change_type")]
        public ImportChangeType ChangeType { get; set; }

        [JsonProperty("member_status_id")]
        public MemberStatusShort MemberStatusId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
