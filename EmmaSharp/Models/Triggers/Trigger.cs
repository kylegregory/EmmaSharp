using EmmaSharp.Extensions;
using EmmaSharp.Models.Groups;
using EmmaSharp.Models.Mailings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Triggers
{
    public class Trigger
    {
        [JsonProperty("parent_mailing")]
        public MailingTrigger ParentMailing { get; set; }

        [JsonProperty("surveys")]
        public string Surveys { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        // Need more info from Emma
        [JsonProperty("links")]
        public string Links { get; set; }

        [JsonProperty("field_id")]
        public long? FieldId { get; set; }

        // Need more info from Emma
        [JsonProperty("signup_integrations")]
        public string SignupIntegrations { get; set; }

        // Need more info from Emma
        [JsonProperty("push_offest_units")]
        public string PushOffsetUnits { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("start_timestamp")]
        public DateTime? StartTimestamp { get; set; }

        [JsonProperty("trigger_id")]
        public long? TriggerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // Need more info from Emma
        [JsonProperty("signups")]
        public int?[] Signups { get; set; }

        // Need more info from Emma
        [JsonProperty("push_offset")]
        public string PushOffset { get; set; }

        // Need more info from Emma
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("parent_mailing_id")]
        public long? ParentMailingId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("is_disabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }
    }
}
