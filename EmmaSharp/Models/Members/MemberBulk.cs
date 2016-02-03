using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmmaSharp.Models
{
    /// <summary>
    /// Used to add new members or update existing members in bulk.
    /// </summary>
    public class MemberBulk
    {
        /// <summary>
        /// Email address of member to add or update
        /// </summary>
        [JsonProperty("email")]
        public string MemberEmail { get; set; }

        /// <summary>
        /// Names and values of user-defined fields to update
        /// </summary>
        [JsonProperty("fields")]
        public Dictionary<string, string> Fields { get; set; }
    }
}
