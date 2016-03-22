using EmmaSharp.Extensions;
using EmmaSharp.Models;
using EmmaSharp.Models.Groups;
using EmmaSharp.Models.Mailings;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Searches;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// With these endpoints, you can get information about your mailings including their HTML contents. You can retrieve the members to whom the mailing was sent. You can also pause mailings and cancel mailings that are pending or paused.
    /// </summary>
    public partial class EmmaApi
    {
        #region Mailings

        /// <summary>
        /// Get number of current mailings.
        /// </summary>
        /// <param name="archived">Boolean. Optional flag to include archived mailings in the list.</param>
        /// <param name="mailingType">Accepts a List with one or more of the following mailing types: ‘m’ (standard), ‘t’ (test), ‘r’ (trigger), ‘s’ (split). Defaults to ‘m,t’, standard and test mailings, when none are specified.</param>
        /// <param name="mailingStatus">Accepts a List with one or more of the following mailing statuses: ‘p’ (pending), ‘a’ (paused), ‘s’ (sending), ‘x’ (canceled), ‘c’ (complete), ‘f’ (failed). Defaults to ‘p,a,s,x,c,f’, all statuses, when none are specified.</param>
        /// <param name="isScheduled">Boolean. Mailings that have a scheduled timestamp.</param>
        /// <param name="withHtmlBody">Boolean. Include the html_body content.</param>
        /// <param name="withPlaintext">Boolean. Include the plaintext content.</param>
        /// <returns>An number of mailings.</returns>
        /// <remarks>Http400 if invalid mailing types or statuses are specified.</remarks>
        public int ListMailingsCount(bool archived = false, List<MailingType> mailingType = null, List<MailingStatus> mailingStatus = null, bool isScheduled = false, bool withHtmlBody = false, bool withPlaintext = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/mailings";
            request.AddParameter("count", "true");

            if (archived)
                request.AddParameter("include_archived", archived);

            if (mailingType != null)
                request.AddParameter("mailing_types", string.Join(",", Array.ConvertAll(mailingType.ToArray(), i => i.ToEnumString<MailingType>())));

            if (mailingStatus != null)
                request.AddParameter("mailing_statuses", string.Join(",", Array.ConvertAll(mailingStatus.ToArray(), i => i.ToEnumString<MailingStatus>())));

            if (isScheduled)
                request.AddParameter("is_scheduled", isScheduled);

            if (withHtmlBody)
                request.AddParameter("with_html_body", withHtmlBody);

            if (withPlaintext)
                request.AddParameter("with_plaintext", withPlaintext);

            return Execute<int>(request);
        }

        /// <summary>
		/// Get information about current mailings. Be sure to get a count of mailings before accessing this method, so you're aware of paging requirements.
        /// </summary>
        /// <param name="archived">Boolean. Optional flag to include archived mailings in the list.</param>
        /// <param name="mailingType">Accepts a List with one or more of the following mailing types: ‘m’ (standard), ‘t’ (test), ‘r’ (trigger), ‘s’ (split). Defaults to ‘m,t’, standard and test mailings, when none are specified.</param>
        /// <param name="mailingStatus">Accepts a List with one or more of the following mailing statuses: ‘p’ (pending), ‘a’ (paused), ‘s’ (sending), ‘x’ (canceled), ‘c’ (complete), ‘f’ (failed). Defaults to ‘p,a,s,x,c,f’, all statuses, when none are specified.</param>
        /// <param name="isScheduled">Boolean. Mailings that have a scheduled timestamp.</param>
        /// <param name="withHtmlBody">Boolean. Include the html_body content.</param>
        /// <param name="withPlaintext">Boolean. Include the plaintext content.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of mailings.</returns>
        /// <remarks>Http400 if invalid mailing types or statuses are specified.</remarks>
        public List<MailingInfo> ListMailings(bool archived = false, List<MailingType> mailingType = null, List<MailingStatus> mailingStatus = null, bool isScheduled = false, bool withHtmlBody = false, bool withPlaintext = false, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/mailings";

			if (archived)
                request.AddParameter("include_archived", archived);

            if (mailingType != null)
                request.AddParameter("mailing_types", string.Join(",", Array.ConvertAll(mailingType.ToArray(), i => i.ToEnumString<MailingType>())));

            if (mailingStatus != null)
                request.AddParameter("mailing_statuses", string.Join(",", Array.ConvertAll(mailingStatus.ToArray(), i => i.ToEnumString<MailingStatus>())));

            if (isScheduled)
                request.AddParameter("is_scheduled", isScheduled);

            if (withHtmlBody)
                request.AddParameter("with_html_body", withHtmlBody);

            if (withPlaintext)
                request.AddParameter("with_plaintext", withPlaintext);

            return Execute<List<MailingInfo>>(request, start, end);
        }

		/// <summary>
		/// Get detailed information for one mailing.
		/// </summary>
		/// <returns>The mailing.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <remarks>Http404 if no mailing is found.</remarks>
		public Mailing GetMailing(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}";
			request.AddUrlSegment("mailingId", mailingId);

			return Execute<Mailing>(request);
		}

        /// <summary>
        /// Get the count of members to whom the given mailing was sent. This does not include groups or searches.
        /// </summary>
        /// <returns>An array of members including status and member fields.</returns>
        /// <param name="mailingId">Mailing identifier.</param>
        /// <remarks>Http404 if no mailing is found.</remarks>
        public int GetMailingMembersCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/mailings/{mailingId}/members";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }
        
		/// <summary>
		/// Get the list of members to whom the given mailing was sent. This does not include groups or searches.
		/// </summary>
        /// <param name="mailingId">Mailing identifier.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of members including status and member fields.</returns>
		/// <remarks>Http404 if no mailing is found.</remarks>
        public List<Member> GetMailingMembers(string mailingId, int start = -1, int end = -1)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/members";
			request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<Member>>(request, start, end);
		}

		/// <summary>
		/// Gets the personalized message content as sent to a specific member as part of the specified mailing.
		/// </summary>
		/// <returns>Message content from a mailing, personalized for a member. The response will contain all parts of the mailing content by default, or just the type of content specified by type..</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="memberId">Member identifier.</param>
		/// <param name="type">Accepts: ‘all’, ‘html’, ‘plaintext’, ‘subject’. Defaults to ‘all’, if not provided.</param>
		/// <remarks>Http404 if no mailing is found.</remarks>
        public MailingPersonalization GetMailingMembersPersonalization(string mailingId, string memberId, PersonalizationType? type = null)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/messages/{memberId}";
			request.AddUrlSegment("mailingId", mailingId);
			request.AddUrlSegment("memberId", memberId);

			if (type != null)
				request.AddParameter("type", type);

            return Execute<MailingPersonalization>(request);
		}

        /// <summary>
        /// Get the count of groups to which a particular mailing was sent.
        /// </summary>
        /// <returns>An array of groups.</returns>
        /// <param name="mailingId">Mailing identifier.</param>
        /// <remarks>Http404 if no mailing is found.</remarks>
        public int GetMailingGroupsCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/mailings/{mailingId}/groups";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

		/// <summary>
		/// Get the groups to which a particular mailing was sent.
		/// </summary>
        /// <param name="mailingId">Mailing identifier.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of groups.</returns>
		/// <remarks>Http404 if no mailing is found.</remarks>
        public List<Group> GetMailingGroups(string mailingId, int start = -1, int end = -1)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/groups";
			request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<Group>>(request, start, end);
		}

		/// <summary>
		/// Get all searches associated with a sent mailing.
		/// </summary>
		/// <returns>An array of searches.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <remarks>Http404 if no mailing is found.</remarks>
		public List<Search> GetMailingSearches(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/searches";
			request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<Search>>(request);
		}

		/// <summary>
		/// Update status of a current mailing.
		/// </summary>
		/// <returns>Returns the mailing’s new status.</returns> 
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="status">The status can be one of canceled, paused or ready. This method can be used to control the progress of a mailing by pausing, canceling or resuming it. Once a mailing is canceled it can’t be resumed, and will not show in the normal mailing_list output.</param>
        public UpdateMailing UpdateMailingStatus(string mailingId, UpdateMailingStatus status)
		{
			var request = new RestRequest(Method.PUT);
			request.Resource = "/{accountId}/mailings/{mailingId}";
            request.AddUrlSegment("mailingId", mailingId);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(new { status = status.ToEnumString<UpdateMailingStatus>() });

            return Execute<UpdateMailing>(request);
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
		/// <param name="mailing">Class representing the fields to forward and email to additional recipients.</param>
		/// <remarks>Http404 if no message is found.</remarks>
        public MailingIdentifier ForwardMailing(string mailingId, string memberId, ForwardMailing mailing)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/forwards/{mailingId}/{memberId}";
			request.AddUrlSegment("mailingId", mailingId);
            request.AddUrlSegment("memberId", memberId);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            
			request.AddBody(mailing);

            return Execute<MailingIdentifier>(request);
		}

		/// <summary>
		/// Send a prior mailing to additional recipients. A new mailing will be created that inherits its content from the original.
		/// </summary>
		/// <returns>The mailing id of the new mailing.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="mailing">Class representing the available fields when resending a mailing.</param>
		/// <remarks>Http404 if no message is found.</remarks>
        public MailingIdentifier ResendMailing(string mailingId, ResendMailing mailing)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/mailings/{mailingId}";
            request.AddUrlSegment("mailingId", mailingId);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

			request.AddBody(mailing);

            return Execute<MailingIdentifier>(request);
		}

		/// <summary>
		/// Get heads up email address(es) related to a mailing.
		/// </summary>
		/// <returns>An array of heads up email addresses.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
        public List<MailingHeadsUp> GetHeadsUpEmailsForMailing(string mailingId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/mailings/{mailingId}/headsup";
			request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<MailingHeadsUp>>(request);
		}

		/// <summary>
		/// Validate that a mailing has valid personalization-tag syntax. Checks tag syntax in three params:
		/// </summary>
		/// <returns><c>true</c>, if personalization syntax was validated, <c>false</c> otherwise.</returns>
        /// <param name="personalization">HTML body, plaintext body and subject line for personalization testing.</param>
		/// <remarks>Http400 if any tags are invalid. The response body will have information about the invalid tags.</remarks>
		public bool VaildatePersonalizationSyntax(MailingPersonalization personalization)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/mailings/validate";
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(personalization);

			return Execute<bool>(request);
		}

		/// <summary>
		/// Declare the winner of a split test manually. In the event that the test duration has not elapsed, the current stats for each test will be frozen and the content defined in the user declared winner will sent to the remaining members for the mailing. Please note, any messages that are pending for each of the test variations will receive the content assigned to them when the test was initially constructed.
		/// </summary>
		/// <returns><c>true</c>, if winner was declared, <c>false</c> otherwise.</returns>
		/// <param name="mailingId">Mailing identifier.</param>
		/// <param name="winnerId">Winner identifier.</param>
		/// <remarks>Http403 if the winner cannot be manually declared.</remarks>
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
