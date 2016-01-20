using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmmaSharp.Models.Members
{
    public class AddMemberRequest
    {
        public string MemberEmail { get; set; }
        public Dictionary<string, string> Fields { get; set; }
        public List<int> GroupIds { get; set; }
        public bool FieldTriggers { get; set; }

        public static AddMemberRequest From(string MemberEmail, Dictionary<string, string> Fields, List<int> GroupIds, bool FieldTriggers)
        {
            return new AddMemberRequest()
            {
                MemberEmail = MemberEmail,
                Fields = Fields,
                GroupIds = GroupIds,
                FieldTriggers = FieldTriggers
            };
        }
    }
}
