using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    /// <summary>
    /// Copy all account members of one or more statuses into a group.
    /// </summary>
    public class CopyStatus
    {
        /// <summary>
        /// ‘a’ (active), ‘o’ (optout), and/or ‘e’ (error).
        /// </summary>
        [JsonProperty("member_status_id")]
        public List<MemberStatusShort> MemberStatusId { get; set; }
    }
}
