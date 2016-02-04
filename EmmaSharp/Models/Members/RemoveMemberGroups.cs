using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    /// <summary>
    /// Remove multiple members from groups.
    /// </summary>
    public class RemoveMemberGroups
    {
        /// <summary>
        /// Member ids to remove from the given groups.
        /// </summary>
        [JsonProperty("member_ids")]
        public List<int> MemberIds { get; set; }

        /// <summary>
        /// Group ids from which to remove the given members.
        /// </summary>
        [JsonProperty("group_ids")]
        public List<int> GroupIds { get; set; }
    }
}
