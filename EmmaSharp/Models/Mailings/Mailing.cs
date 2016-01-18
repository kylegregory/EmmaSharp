using EmmaSharp.Extensions;
using EmmaSharp.Models.Generics;
using EmmaSharp.Models.Groups;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Searches;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class MailingBase
    {
        [JsonProperty("mailing_type")]
        public MailingType MailingType { get; set; }

        [JsonProperty("mailing_id")]
        public int? MailingId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("send_started")]
        public DateTime? SendStarted { get; set; }

        [JsonProperty("signup_form_id")]
        public int? SignupFormId { get; set; }

        [JsonProperty("recipient_count")]
        public int? RecipientCount { get; set; }

        [JsonProperty("parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("mailing_status")]
        public MailingStatus MailingStatus { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("send_finished")]
        public DateTime? SendFinished { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("send_at")]
        public DateTime? SendAt { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("archived_ts")]
        public DateTime? ArchivedTimestamp { get; set; }
    }

    public class MailingDetails : MailingBase
    {

        [JsonProperty("cancel_by_user_id")]
        public int? CancelByUserId { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("cancel_ts")]
        public DateTime? CancelTimestamp { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("failure_ts")]
        public DateTime? FailureTimestamp { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("start_or_finished")]
        public DateTime? StartedOrFinished { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("created_ts")]
        public DateTime? CreatedTimestamp { get; set; }

        [JsonProperty("plaintext_only")]
        public bool PlaintextOnly { get; set; }

        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }

        [JsonProperty("datacenter")]
        public string Datacenter { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("purged_at")]
        public DateTime? PurgedAt { get; set; }
    }

    public class Mailing : MailingBase
    {
        [JsonProperty("recipient_groups")]
        public List<Group> RecipientGroups { get; set; }

        [JsonProperty("heads_up_emails")]
        public List<Email> HeadsUpEmails { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [JsonProperty("public_webview_url")]
        public string PublicWebviewUrl { get; set; }

        [JsonProperty("recipient_searches")]
        public List<Search> RecipientSearches { get; set; }

        [JsonProperty("recipient_members")]
        public List<Member> RecipientMembers { get; set; }

        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }

    public class MailingInfo : MailingDetails
    {
        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class UpdateMailing : MailingInfo
    {
        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }

    public class MailingTrigger : MailingDetails
    {
        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
