using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    /// <summary>
    /// Update a single member’s information.
    /// </summary>
    public class UpdateMember
    {
        /// <summary>
        /// A new email address for the member.
        /// </summary>
        [JsonProperty("member_email", NullValueHandling = NullValueHandling.Ignore)]
        public string MemberEmail { get; set; }

        /// <summary>
        /// A new status for the member. Accepts one of ‘a’ (active), ‘e’ (error), ‘o’ (opt-out).
        /// </summary>
        [JsonProperty("status_to", NullValueHandling = NullValueHandling.Ignore)]
        public MemberStatusShort StatusTo { get; set; }

        /// <summary>
        /// An array of fields with associated values for this member
        /// </summary>
        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Fields { get; set; }

        /// <summary>
        /// Optional. Fires related field change autoresponders when set to true.
        /// </summary>
        [JsonProperty("field_triggers", NullValueHandling = NullValueHandling.Ignore)]
        public bool FieldTriggers { get; set; }
    }
}
