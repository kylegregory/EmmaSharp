using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    public class DeleteMembers
    {
        /// <summary>
        /// An array of member ids to delete.
        /// </summary>
        [JsonProperty("member_ids")]
        public List<long> MemberIds { get; set; }
    }
}
