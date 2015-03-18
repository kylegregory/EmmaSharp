using RestSharp.Deserializers;

namespace EmmaSharp.Models.Members
{
    public class ImportMembers
    {
        [DeserializeAs(Name = "member_id")]
        public int MemberId { get; set; }

        [DeserializeAs(Name = "change_type")]
        public string ChangeType { get; set; }

        [DeserializeAs(Name = "member_status_id")]
        public string MemberStatusId { get; set; }

        [DeserializeAs(Name = "email")]
        public string Email { get; set; }
    }
}
