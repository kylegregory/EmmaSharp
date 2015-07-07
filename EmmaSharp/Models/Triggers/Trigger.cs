using EmmaSharp.Models.Groups;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Triggers
{
    public class Trigger
    {
        [DeserializeAs(Name = "parent_mailing")]
        public TriggerParent ParentMailing { get; set; }

        [DeserializeAs(Name = "surveys")]
        public string Surveys { get; set; }

        [DeserializeAs(Name = "event_type")]
        public string EventType { get; set; }

        // Need more info from Emma
        [DeserializeAs(Name = "links")]
        public string Links { get; set; }

        [DeserializeAs(Name = "field_id")]
        public int FieldId { get; set; }

        // Need more info from Emma
        [DeserializeAs(Name = "signup_integrations")]
        public string SignupIntegrations { get; set; }

        // Need more info from Emma
        [DeserializeAs(Name = "push_offest_units")]
        public string PushOffsetUnits { get; set; }

        [DeserializeAs(Name = "start_timestamp")]
        public DateTime? StartTimestamp { get; set; }

        [DeserializeAs(Name = "trigger_id")]
        public int TriggerId { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        // Need more info from Emma
        [DeserializeAs(Name = "signups")]
        public string Signups { get; set; }

        // Need more info from Emma
        [DeserializeAs(Name = "push_offset")]
        public string PushOffset { get; set; }

        // Need more info from Emma
        [DeserializeAs(Name = "groups")]
        public List<Group> Groups { get; set; }

        [DeserializeAs(Name = "parent_mailing_id")]
        public int ParentMailingId { get; set; }

        [DeserializeAs(Name = "deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [DeserializeAs(Name = "is_disabled")]
        public bool IsDisabled { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }
    }
}
