using Newtonsoft.Json;

namespace EmmaSharp.Models.Members
{
    class ImportMembers
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; }

        [JsonProperty("change_type")]
        public string ChangeType { get; set; }

        [JsonProperty("member_status_id")]
        public string MemberStatusId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
