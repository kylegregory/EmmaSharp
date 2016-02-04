using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    /// <summary>
    /// Add or Remove a single member to one or more groups.
    /// </summary>
    public class MemberGroups
    {
        /// <summary>
        /// Group ids to which to add or remove this member.
        /// </summary>
        [JsonProperty("group_ids")]
        public List<int> GroupIds { get; set; }
    }
}
