using EmmaSharp.Models.Groups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Triggers
{
    public class Trigger
    {
        [JsonProperty("parent_mailing")]
        public TriggerParent ParentMailing { get; set; }

        [JsonProperty("surveys")]
        public string Surveys { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        // Need more info from Emma
        [JsonProperty("links")]
        public string Links { get; set; }

        [JsonProperty("field_id")]
        public int? FieldId { get; set; }

        // Need more info from Emma
        [JsonProperty("signup_integrations")]
        public string SignupIntegrations { get; set; }

        // Need more info from Emma
        [JsonProperty("push_offest_units")]
        public string PushOffsetUnits { get; set; }

        [JsonProperty("start_timestamp")]
        public DateTime? StartTimestamp { get; set; }

        [JsonProperty("trigger_id")]
        public int? TriggerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // Need more info from Emma
        [JsonProperty("signups")]
        public string Signups { get; set; }

        // Need more info from Emma
        [JsonProperty("push_offset")]
        public string PushOffset { get; set; }

        // Need more info from Emma
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("is_disabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }
    }
}
