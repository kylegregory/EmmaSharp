using RestSharp;
using System.Collections.Generic;
using EmmaSharp.Models.Mailings;
using EmmaSharp.Models;

namespace EmmaSharp
{
    public partial class EmmaApi
    {
        #region Mailings

        /// <summary>
        /// Get information about current mailings.
        /// </summary>
        /// <param name="archived">Boolen. Optional flag to include archived mailings in the list.</param>
        /// <param name="mailingType">Accepts a List with one or more of the following mailing types: ‘m’ (standard), ‘t’ (test), ‘r’ (trigger), ‘s’ (split). Defaults to ‘m,t’, standard and test mailings, when none are specified.</param>
        /// <param name="mailingStatus">Accepts a List with one or more of the following mailing statuses: ‘p’ (pending), ‘a’ (paused), ‘s’ (sending), ‘x’ (canceled), ‘c’ (complete), ‘f’ (failed). Defaults to ‘p,a,s,x,c,f’, all statuses, when none are specified.</param>
        /// <param name="isScheduled">Boolen. Mailings that have a scheduled timestamp.</param>
        /// <param name="withHtmlBody">Boolen. Include the html_body content.</param>
        /// <param name="withPlaintext">Boolen. Include the plaintext content.</param>
        /// <returns>An array of mailings.</returns>
        /// <exception cref="HttpResponseException">Http400 if invalid mailing types or statuses are specified.</exception>
        public AllMailings ListMailings(bool archived = false, List<MailingType> mailingType = null, List<MailingStatus> mailingStatus = null, bool isScheduled = false, bool withHtmlBody = false, bool withPlaintext = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/mailings";

            if (archived)
                request.AddParameter("include_archived", archived);

            if (mailingType != null)
                request.AddParameter("mailing_types", mailingType);

            if (mailingStatus != null)
                request.AddParameter("mailing_statuses", mailingStatus);

            if (isScheduled)
                request.AddParameter("is_scheduled", isScheduled);

            if (withHtmlBody)
                request.AddParameter("with_html_body", withHtmlBody);

            if (withPlaintext)
                request.AddParameter("with_plaintext", withPlaintext);

			return Execute<AllMailings>(request);
        }

		/// <summary>
		/// Get detailed information for one mailing.
		/// </summary>
		/// <returns>The mailing.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <exception cref="HttpResponseException">Http404 if no mailing is found.</exception>
		public Mailing GetMailing(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<Mailing>(request);
		}
        
		/// <summary>
		/// Get the list of members to whom the given mailing was sent. This does not include groups or searches.
		/// </summary>
		/// <returns>An array of members including status and member fields.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <exception cref="HttpResponseException">Http404 if no mailing is found.</exception>
		public MailingMembers GetMailingMembers(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/members";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<MailingMembers>(request);
		}

		/// <summary>
		/// Gets the personalized message content as sent to a specific member as part of the specified mailing.
		/// </summary>
		/// <returns>Message content from a mailing, personalized for a member. The response will contain all parts of the mailing content by default, or just the type of content specified by type..</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="memberId">Member identifier.</param>
		/// <param name="type">Accepts: ‘all’, ‘html’, ‘plaintext’, ‘subject’. Defaults to ‘all’, if not provided.</param>
		/// <exception cref="HttpResponseException">Http404 if no mailing is found.</exception>
		public List<PersonalizationType> GetMailingMembersPersonalization(string mailingId, string memberId, PersonalizationType type = null)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/messages/{memberId}";
			request.AddUrlSegment("mailingId", mailingId);
			request.AddUrlSegment("memberId", memberId);

			if (type != null)
				request.AddParameter("type", type);

			return Execute<List<PersonalizationType>>(request);
		}

		/// <summary>
		/// Get the groups to which a particular mailing was sent.
		/// </summary>
		/// <returns>An array of groups.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <exception cref="HttpResponseException">Http404 if no mailing is found.</exception>
		public MailingGroups GetMailingGroups(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/groups";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<MailingGroups>(request);
		}

		/// <summary>
		/// Get all searches associated with a sent mailing.
		/// </summary>
		/// <returns>An array of searches.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <exception cref="HttpResponseException">Http404 if no mailing is found.</exception>
		public MailingSearches GetMailingSearches(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/searches";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<MailingSearches>(request);
		}

		/// <summary>
		/// Update status of a current mailing.
		/// </summary>
		/// <returns>Returns the mailing’s new status.</returns> 
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="status">The status can be one of canceled, paused or ready. This method can be used to control the progress of a mailing by pausing, canceling or resuming it. Once a mailing is canceled it can’t be resumed, and will not show in the normal mailing_list output.</param>
		public MailingSearches UpdateMailingStatus(string mailingId, MailingStatus status)
		{
			var request = new RestRequest(Method.PUT);
			request.Resource = "/{accountId}/mailings/{mailingId}";
			request.AddUrlSegment("mailingId", mailingId);

			if (status == MailingStatus.Paused || status == MailingStatus.Canceled || status == MailingStatus.Sending)
				request.AddBody("mailing_statuses", status.ToString());

			return Execute<MailingSearches>(request);
		}

		/// <summary>
		/// Sets archived timestamp for a mailing so it is no longer included in mailing_list.
		/// </summary>
		/// <returns>True if the mailing is successfully archived.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		public bool ArchiveMailing(string mailingId)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "/{accountId}/mailings/{mailingId}";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<bool>(request);
		}

		/// <summary>
		/// Cancels a mailing that has a current status of pending or paused. All other statuses will result in a 404.
		/// </summary>
		/// <returns>True if mailing marked as cancelled.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		public bool CancelMailing(string mailingId)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "/{accountId}/mailings/cancel/{mailingId}";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<bool>(request);
		}

		/// <summary>
		/// Forward a previous message to additional recipients. If these recipients are not already in the audience, they will be added with a status of FORWARDED.
		/// </summary>
		/// <returns>A reference to the new mailing.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="memberId">Member identifier.</param>
		/// <param name="recipientEmails">An array of email addresses to which to forward the specified message.</param>
		/// <param name="note">A note to include in the forward. This note will be HTML encoded and is limited to 500 characters.</param>
		/// <exception cref="HttpResponseException">Http404 if no message is found.</exception>
		public Mailing ForwardMailing(string mailingId, string memberId, List<string> recipientEmails, string note)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/forwards/{mailingId}/{memberId}";
			request.AddUrlSegment("mailingId", mailingId);
			request.AddUrlSegment("mailingId", memberId);
			request.AddBody("recipient_emails", string.Join(",", recipientEmails));
			request.AddBody("note", note);

			return Execute<Mailing>(request);
		}

		/// <summary>
		/// Send a prior mailing to additional recipients. A new mailing will be created that inherits its content from the original.
		/// </summary>
		/// <returns>TA reference to the new mailing.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="headsUpEmails"> A list of email addresses that heads up notification emails will be sent to.</param>
		/// <param name="recipientEmails">An array of email addresses to which the new mailing should be sent.</param>
		/// <param name="recipientGroups">An array of member groups to which the new mailing should be sent.</param>
		/// <param name="recipientSearches">A list of searches that this mailing should be sent to.</param>
		/// <param name="sender">The message sender. If this is not supplied, the sender of the original mailing will be used.</param>
		/// <exception cref="HttpResponseException">Http404 if no message is found.</exception>
		public Mailing ResendMailing(string mailingId, List<string> headsUpEmails, List<string> recipientEmails, List<string> recipientGroups, List<string> recipientSearches, string sender = null)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/mailings/{mailingId}";
			request.AddUrlSegment("mailingId", mailingId);
			request.AddBody("heads_up_emails", string.Join(",", headsUpEmails));
			request.AddBody("recipient_emails", string.Join(",", recipientEmails));
			request.AddBody("recipient_groups", string.Join(",", recipientGroups));
			request.AddBody("recipient_searches", string.Join(",", recipientSearches));
			if (!string.IsNullOrWhiteSpace(sender))
				request.AddBody("sender", sender);

			return Execute<Mailing>(request);
		}

		/// <summary>
		/// Get heads up email address(es) related to a mailing.
		/// </summary>
		/// <returns>An array of heads up email addresses.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		public List<string> GetHeadsUpEmailsForMailing(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/headsup";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<List<string>>(request);
		}

		/// <summary>
		/// Validate that a mailing has valid personalization-tag syntax. Checks tag syntax in three params:
		/// </summary>
		/// <returns><c>true</c>, if personalization syntax was vaildated, <c>false</c> otherwise.</returns>
		/// <param name="htmlBody">The html contents of the mailing</param>
		/// <param name="plaintext">The plaintext contents of the mailing. Unlike in create_mailing, this param is not required.</param>
		/// <param name="subject">The subject of the mailing.</param>
		/// <exception cref="HttpResponseException">Http400 if any tags are invalid. The response body will have information about the invalid tags.</exception>
		public bool VaildatePersonalizationSyntax(string htmlBody, string plaintext, string subject)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/mailings/validate";
			request.AddBody("html_body", htmlBody);
			request.AddBody("plaintext", plaintext);
			request.AddBody("subject", subject);

			return Execute<bool>(request);
		}

		/// <summary>
		/// Declare the winner of a split test manually. In the event that the test duration has not elapsed, the current stats for each test will be frozen and the content defined in the user declared winner will sent to the remaining members for the mailing. Please note, any messages that are pending for each of the test variations will receive the content assigned to them when the test was initially constructed.
		/// </summary>
		/// <returns><c>true</c>, if winner was declared, <c>false</c> otherwise.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="winnerId">Winner identifier.</param>
		/// <exception cref="HttpResponseException">Http403 if the winner cannot be manually declared.</exception>
		public bool DeclareWinner(string mailingId, string winnerId)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/mailings/{mailingId}/winner/{winnerId}";
			request.AddUrlSegment("mailingId", mailingId);
			request.AddUrlSegment("winnerId", winnerId);

			return Execute<bool>(request);
		}
        #endregion
    }
}
