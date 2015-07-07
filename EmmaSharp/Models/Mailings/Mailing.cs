using EmmaSharp.Models.Generics;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Searches;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp.Models.Mailings
{
    public class Mailing
    {
        [DeserializeAs(Name = "recipient_groups")]
        public List<Group> RecipientGroups { get; set; }

        [DeserializeAs(Name = "heads_up_emails")]
        public List<Email> HeadsUpEmails { get; set; }

        [DeserializeAs(Name = "send_started")]
        public DateTime? SendStarted { get; set; }

        [DeserializeAs(Name = "signup_form_id")]
        public int SignupFormId { get; set; }

        [DeserializeAs(Name = "links")]
        public List<Link> Links { get; set; }

        [DeserializeAs(Name = "mailing_id")]
        public int MailingId { get; set; }

        [DeserializeAs(Name = "plaintext")]
        public string Plaintext { get; set; }

        [DeserializeAs(Name = "recipient_count")]
        public int RecipientCount { get; set; }

        [DeserializeAs(Name = "public_webview_url")]
        public string PublicWebviewUrl { get; set; }

        [DeserializeAs(Name = "mailing_type")]
        public MailingType MailingType { get; set; }

        [DeserializeAs(Name = "parent_mailing_id")]
        public int? ParentMailingId { get; set; }

        [DeserializeAs(Name = "recipient_searches")]
        public List<Search> RecipientSearches { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "recipient_members")]
        public List<Member> RecipientMembers { get; set; }

        [DeserializeAs(Name = "mailing_status")]
        public MailingStatus MailingStatus { get; set; }

        [DeserializeAs(Name = "sender")]
        public string Sender { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "send_finished")]
        public bool? SendFinished { get; set; }

        [DeserializeAs(Name = "send_at")]
        public DateTime? SendAt { get; set; }

        [DeserializeAs(Name = "subject")]
        public string Subject { get; set; }

        [DeserializeAs(Name = "archived_ts")]
        public DateTime? ArchivedTimestamp { get; set; }

        [DeserializeAs(Name = "html_body")]
        public string HtmlBody { get; set; }
    }
}
