using EmmaSharp.Models.Generics;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Searches;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class Mailing
    {
        [JsonProperty("recipient_groups")]
        public List<Group> RecipientGroups { get; set; }

        [JsonProperty("heads_up_emails")]
        public List<Email> HeadsUpEmails { get; set; }

        [JsonProperty("send_started")]
        public DateTime? SendStarted { get; set; }

        [JsonProperty("signup_form_id")]
        public int SignupFormId { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [JsonProperty("mailing_id")]
        public int MailingId { get; set; }

        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("recipient_count")]
        public int RecipientCount { get; set; }

        [JsonProperty("public_webview_url")]
        public string PublicWebviewUrl { get; set; }

        [JsonProperty("mailing_type")]
        public MailingType MailingType { get; set; }

        [JsonProperty("parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [JsonProperty("recipient_searches")]
        public List<Search> RecipientSearches { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("recipient_members")]
        public List<Member> RecipientMembers { get; set; }

        [JsonProperty("mailing_status")]
        public MailingStatus MailingStatus { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("send_finished")]
        public bool? SendFinished { get; set; }

        [JsonProperty("send_at")]
        public DateTime? SendAt { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("archived_ts")]
        public DateTime? ArchivedTimestamp { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
