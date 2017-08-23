using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    public class SignupMember
    {
        /// <summary>
        /// Email address of the member to sign-up.
        /// </summary>
        [JsonProperty("email")]
        public string MemberEmail { get; set; }

        /// <summary>
        /// An array of group ids to associate sign-up with.
        /// </summary>
        [JsonProperty("group_ids")]
        public List<int> GroupIds { get; set; }

        /// <summary>
        /// Optional. Names and values of user-defined fields to update.
        /// </summary>
        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Fields { get; set; }

        /// <summary>
        /// Optional. Indicate that this member used a particular signup form. This is important if you have custom mailings for a particular signup form and so that signup-based triggers will be fired.
        /// </summary>
        [JsonProperty("signup_form_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? SignupFormId { get; set; }

        /// <summary>
        /// Optional. Override the confirmation message subject with your own copy.
        /// </summary>
        [JsonProperty("opt_in_subject", NullValueHandling = NullValueHandling.Ignore)]
        public string OptInSubject { get; set; }

        /// <summary>
        /// Optional. Override the confirmation message body with your own copy. Must include the following tags: [rsvp_name], [rsvp_email], [opt_in_url], [opt_out_url].
        /// </summary>
        [JsonProperty("opt_in_message", NullValueHandling = NullValueHandling.Ignore)]
        public string OptInMessage { get; set; }

        /// <summary>
        /// Optional. Fires related field change autoresponders when set to true.
        /// </summary>
        [JsonProperty("field_triggers", NullValueHandling = NullValueHandling.Ignore)]
        public bool FieldTriggers { get; set; }

        /// <summary>
        /// Optional. Sends the default plaintext confirmation email when set to true. NOTE: Confirmation email will be sent by default if this parameter is left out.
        /// </summary>
        [JsonProperty("opt_in_confirmation", NullValueHandling = NullValueHandling.Ignore)]
        public bool OptInConfirmation { get; set; }
    }
}
