using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    /// <summary>
    /// Change the status for an array of members.
    /// </summary>
    public class ChangeStatus
    {
        /// <summary>
        /// The array of member ids to change.
        /// </summary>
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }

        /// <summary>
        /// The new status for the given members. Accepts one of ‘a’ (active), ‘e’ (error), ‘o’ (optout).
        /// </summary>
        [JsonProperty("status_to")]
        public MemberStatusShort StatusTo { get; set; }
    }
}