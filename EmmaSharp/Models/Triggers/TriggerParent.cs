using RestSharp.Deserializers;
using System;

namespace EmmaSharp.Models.Triggers
{
    public class TriggerParent
    {
        [DeserializeAs(Name = "mailing_type")]
        public MailingType MailingType { get; set; }

        [DeserializeAs(Name = "send_started")]
        public DateTime? SendStarted { get; set; }

        [DeserializeAs(Name = "signup_form_id")]
        public int SignupFormId { get; set; }

        [DeserializeAs(Name = "mailing_id")]
        public int MailingId { get; set; }

        [DeserializeAs(Name = "plaintext")]
        public string Plaintext { get; set; }

        [DeserializeAs(Name = "recipient_count")]
        public int RecipientCount { get; set; }

        [DeserializeAs(Name = "cancel_ts")]
        public DateTime? CancelTimestamp { get; set; }

        [DeserializeAs(Name = "created_ts")]
        public DateTime? CreatedTimestamp { get; set; }

        [DeserializeAs(Name = "month")]
        public string Month { get; set; }

        [DeserializeAs(Name = "failure_ts")]
        public DateTime? FailureTimestamp { get; set; }

        [DeserializeAs(Name = "year")]
        public int Year { get; set; }

        [DeserializeAs(Name = "datacenter")]
        public string Datacenter { get; set; }

        [DeserializeAs(Name = "start_or_finished")]
        public DateTime? StartedOrFinished { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "disabled")]
        public bool Disabled { get; set; }

        [DeserializeAs(Name = "mailing_status")]
        public MailingStatus MailingStatus { get; set; }

        [DeserializeAs(Name = "plaintext_only")]
        public bool PlaintextOnly { get; set; }

        [DeserializeAs(Name = "sender")]
        public string Sender { get; set; }

        [DeserializeAs(Name = "parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [DeserializeAs(Name = "failure_message")]
        public string FailureMessage { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "send_finished")]
        public bool? SendFinished { get; set; }

        [DeserializeAs(Name = "cancel_by_user_id")]
        public int CancelByUserId { get; set; }

        [DeserializeAs(Name = "send_at")]
        public DateTime? SendAt { get; set; }

        [DeserializeAs(Name = "reply_to")]
        public string ReplyTo { get; set; }

        [DeserializeAs(Name = "subject")]
        public string Subject { get; set; }

        [DeserializeAs(Name = "purged_at")]
        public DateTime? PurgedAt { get; set; }

        [DeserializeAs(Name = "archived_ts")]
        public DateTime? ArchivedTimestamp { get; set; }

        [DeserializeAs(Name = "html_body")]
        public string HtmlBody { get; set; }
    }
}
