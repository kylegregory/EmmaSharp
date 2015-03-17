using EmmaSharp.Models.Generics;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Searches;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    class Mailing
    {
        [JsonProperty("recipient_groups")]
        public IList<Group> RecipientGroups { get; set; }

        [JsonProperty("heads_up_emails")]
        public IList<Email> HeadsUpEmails { get; set; }

        [JsonProperty("send_started")]
        public DateTime? SendStarted { get; set; }

        [JsonProperty("signup_form_id")]
        public int SignupFormId { get; set; }

        [JsonProperty("links")]
        public IList<Link> Links { get; set; }

        [JsonProperty("mailing_id")]
        public int MailingId { get; set; }

        [JsonProperty("plaintext")]
        public string Plaintext { get; set; }

        [JsonProperty("recipient_count")]
        public int RecipientCount { get; set; }

        [JsonProperty("public_webview_url")]
        public string PublicWebviewUrl { get; set; }

        [JsonProperty("mailing_type")]
        public string MailingType { get; set; }

        [JsonProperty("parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [JsonProperty("recipient_searches")]
        public IList<Search> RecipientSearches { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("recipient_members")]
        public IList<Member> RecipientMembers { get; set; }

        [JsonProperty("mailing_status")]
        public string MailingStatus { get; set; }

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
        public DateTime? ArchivedTs { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }
    }
}
