using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models.Triggers
{
    public class TriggerParent
    {
        [JsonProperty("mailing_type")]
        public MailingType MailingType { get; set; }

        [JsonProperty("send_started")]
        public DateTime? SendStarted { get; set; }

        [JsonProperty("signup_form_id")]
        public int SignupFormId { get; set; }

        [JsonProperty("mailing_id")]
        public int MailingId { get; set; }

        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("recipient_count")]
        public int RecipientCount { get; set; }

        [JsonProperty("cancel_ts")]
        public DateTime? CancelTimestamp { get; set; }

        [JsonProperty("created_ts")]
        public DateTime? CreatedTimestamp { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("failure_ts")]
        public DateTime? FailureTimestamp { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("datacenter")]
        public string Datacenter { get; set; }

        [JsonProperty("start_or_finished")]
        public DateTime? StartedOrFinished { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        [JsonProperty("mailing_status")]
        public MailingStatus MailingStatus { get; set; }

        [JsonProperty("plaintext_only")]
        public bool PlaintextOnly { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("send_finished")]
        public bool? SendFinished { get; set; }

        [JsonProperty("cancel_by_user_id")]
        public int CancelByUserId { get; set; }

        [JsonProperty("send_at")]
        public DateTime? SendAt { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }

        [JsonProperty("archived_ts")]
        public DateTime? ArchivedTimestamp { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
