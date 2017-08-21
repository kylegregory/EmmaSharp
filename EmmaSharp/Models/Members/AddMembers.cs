using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmmaSharp.Models
{
    /// <summary>
    /// Parameters to add a batch members to an audience. 
    /// </summary>
    public class AddMembers
    {
        /// <summary>
        /// Email address of member to add or update
        /// </summary>
        [JsonProperty("members")]
        public List<MemberBulk> Members { get; set; }

        /// <summary>
        /// Names and values of user-defined fields to update
        /// </summary>
        [JsonProperty("source_filename")]
        public string SourceFileName { get; set; }

        /// <summary>
        /// Optional. Add imported members to this list of groups.
        /// </summary>
        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> GroupIds { get; set; }

        /// <summary>
        /// Optional. Fires related field change autoresponders when set to true.
        /// </summary>
        [JsonProperty("automate_field_changes", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutomateFieldChanges { get; set; }

        /// <summary>
        /// Optional. Only add new members, ignore existing members.
        /// </summary>        
        [JsonProperty("add_only", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AddOnly { get; set; }

        public AddMembers()
        {
            Members = new List<MemberBulk>();
            GroupIds = new List<int>();
        }
    }
}
