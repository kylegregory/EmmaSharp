using RestSharp;
using System.Collections.Generic;
using EmmaSharp.Models;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Mailings;

namespace EmmaSharp
{
    /// <summary>
    /// In addition to the various CRUD endpoints here related to members, you can also change the status of members, including opting them out.
    ///
    /// You’ll notice that there are calls related to individual members, but we also provide quite a few calls to deal with bulk updates of members. Please try to use these whenever possible as opposed to looping through a list of members and calling the individual member calls.
    ///
    ///Where this is especially important is when adding new members. To do a bulk import, you’ll POST to the /#account_id/members endpoint. In return, you’ll receive an import ID. You can use this ID to check the status and results of your import. Imports are generally pretty fast, but the time to completion can vary with greater system usage.
    /// </summary>
	public class Members : EmmaApi
	{
		#region Members

        /// <summary>
        /// Members Endpoints
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public Members(string publicKey, string secretKey, string accountId)
            : base(publicKey, secretKey, accountId)
        {
        }

		/// <summary>
		/// Get a count of all members in an account.
		/// </summary>
		/// <returns>A list of members in the given account.</returns>
		/// <param name="deleted">Accepts True. Optional flag to include deleted members.</param>
		public int GetMemberCount(bool? deleted)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/members";
			request.AddParameter("count", "true");

			if(!deleted ?? false)
				request.AddParameter("deleted", deleted.ToString());

			return Execute<int>(request);
		}

		/// <summary>
		/// Get a basic listing of all members in an account.
		/// </summary>
		/// <returns>A list of members in the given account.</returns>
		/// <param name="deleted">Accepts True. Optional flag to include deleted members.</param>
        /// <param name="start">Pagination: start page. Defaults to first page (e.g. 0).</param>
        /// <param name="end">Pagination: end page. Defaults to first page (e.g. 500).</param>
		public List<Member> ListMembers(bool? deleted, int? start, int? end)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/members";

			if (!start.HasValue)
				start = 0;
			request.AddParameter("start", start);

			if (!end.HasValue || end - start > 500)
				end = 500;
			request.AddParameter("end", end);

			if(!deleted ?? false)
				request.AddParameter("deleted", deleted.ToString());

            return Execute<List<Member>>(request);
		}

		/// <summary>
		/// Get detailed information on a particular member, including all custom fields.
		/// </summary>
		/// <returns>A single member if one exists.</returns>
		/// <param name="memberId">Member identifier.</param>
		/// <param name="deleted">Accepts True. Optional flag to include deleted members.</param>
		/// <remarks>Http404 if no member is found.</remarks>
		public Member GetMemeber(string memberId, bool deleted = false)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/members/{memberId}";
			request.AddUrlSegment("memberId", memberId);

			if(deleted)
				request.AddParameter("deleted", deleted.ToString());

			return Execute<Member>(request);
		}

		/// <summary>
		/// Get detailed information on a particular member, including all custom fields, by email address instead of ID.
		/// </summary>
		/// <returns>A single member if one exists.</returns>
		/// <param name="memberEmail">Member email.</param>
		/// <param name="deleted">Accepts True. Optional flag to include deleted members.</param>
		/// <remarks>Http404 if no member is found.</remarks>
		public Member GetMemberByEmail(string memberEmail, bool deleted = false)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/members/email/{memberEmail}";
			request.AddUrlSegment("memberEmail", memberEmail);

			if(deleted)
				request.AddParameter("deleted", deleted.ToString());

			return Execute<Member>(request);
		}

		/// <summary>
		/// If a member has been opted out, returns the details of their optout, specifically date and mailing_id.
		/// </summary>
		/// <returns>Member opt out date and mailing if member is opted out.</returns>
		/// <remarks>Http404 if no member is found.</remarks>
		/// <param name="memberId">Member identifier.</param>
		public MemberOptout GetMemberOptout(string memberId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/members/{memberId}/optout";
			request.AddUrlSegment("memberId", memberId);

			return Execute<MemberOptout>(request);
		}

        /// <summary>
        /// Update a member’s status to optout keyed on email address instead of an ID.
        /// </summary>
        /// <param name="memberEmail">Member email address for optout.</param>
        /// <returns>True if member status change was successful or member was already opted out.</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public bool UpdateMemberToOptoutByEmail(string memberEmail)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}members/email/optout/{memberEmail}";
            request.AddUrlSegment("email", memberEmail);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Add new members or update existing members in bulk. If you are doing actions for a single member please see the <see cref="AddOrUpdateSingleMember"/> call .
        /// </summary>
        /// <param name="members">An array of members to update. A member is a dictionary of member emails and field values to import. The only required field is “email”. All other fields are treated as the name of a member field.</param>
        /// <param name="sourceFilename">An arbitrary string to associate with this import. This should generally be set to the filename that the user uploaded.</param>
        /// <param name="addOnly">Optional. Only add new members, ignore existing members.</param>
        /// <param name="groupIds">Optional. Add imported members to this list of groups.</param>
        /// <returns>An import id.</returns>
        /// <remarks></remarks>
        public int AddNewMemebers(Members members, string sourceFilename, bool addOnly, MemberGroups groupIds)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/members";
            request.AddParameter("members", members);
            request.AddParameter("source_filename", sourceFilename);

            if (addOnly)
                request.AddParameter("add_only", addOnly.ToString());

            if (groupIds.Groups.Count != 0)
                request.AddParameter("group_ids", groupIds.Groups);

            return Execute<int>(request);
        }

        /// <summary>
        /// Adds or updates a single audience member. If you are performing actions on bulk members please use the /members call above.
        /// </summary>
        /// <param name="memberEmail">Email address of member to add or update</param>
        /// <param name="fields">Names and values of user-defined fields to update</param>
        /// <param name="groupIds">Optional. Add imported members to this list of groups.</param>
        /// <param name="field_triggers">Optional. Fires related field change autoresponders when set to true.</param>
        /// <returns>The member_id of the new or updated member, whether the member was added or an existing member was updated, and the status of the member. The status will be reported as ‘a’ (active), ‘e’ (error), or ‘o’ (optout).</returns>
        /// <remarks></remarks>
        public MemberAdd AddOrUpdateSingleMember(string memberEmail, List<Field> fields, MemberGroups groupIds, bool field_triggers)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/members/add";
            request.AddParameter("email", memberEmail);
            request.AddParameter("fields", fields);

            if (groupIds.Groups.Count != 0)
                request.AddParameter("group_ids", groupIds);

            if (field_triggers)
                request.AddParameter("field_triggers", field_triggers);

            return Execute<MemberAdd>(request);
        }

        /// <summary>
        /// Takes the necessary actions to signup a member and enlist them in the provided group ids. You can send the same member multiple times and pass in new group ids to signup. This process triggers the opt-out workflow, and will send a mailing to the member on new group enlistments. If no new group ids are provided for an existing member, the endpoint will respond back with their status and member_id, performing no additional actions.
        /// </summary>
        /// <param name="memberEmail">Email address of the member to sign-up.</param>
        /// <param name="groupIds">An array of group ids to associate sign-up with.</param>
        /// <param name="fields">Optional. Names and values of user-defined fields to update.</param>
        /// <param name="signupFormId">Optional. Indicate that this member used a particular signup form. This is important if you have custom mailings for a particular signup form and so that signup-based triggers will be fired.</param>
        /// <param name="optInSubject">Optional. Override the confirmation message subject with your own copy.</param>
        /// <param name="optInMessage">Optional. Override the confirmation message body with your own copy. Must include the following tags: [rsvp_name], [rsvp_email], [opt_in_url], [opt_out_url].</param>
        /// <param name="fieldTriggers">Optional. Fires related field change autoresponders when set to true.</param>
        /// <returns>The member_id of the member, and their status. The status will be reported as ‘a’ (active), ‘e’ (error), or ‘o’ (optout).</returns>
        /// <remarks></remarks>
        public MemberSignup MemberSignup(string memberEmail, MemberGroups groupIds, List<Field> fields, int signupFormId, string optInSubject, string optInMessage, bool fieldTriggers)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/members/signup";
            request.AddParameter("email", memberEmail);
            request.AddParameter("group_ids", groupIds.Groups);

            if (fields.Count != 0)
                request.AddParameter("fields", fields);

            if (signupFormId != 0)
                request.AddParameter("signup_form_id", signupFormId);

            if (!string.IsNullOrWhiteSpace(optInSubject))
                request.AddParameter("opt_in_subject", optInSubject);

            if (!string.IsNullOrWhiteSpace(optInMessage))
                request.AddParameter("opt_in_message", optInMessage);

            if (fieldTriggers)
                request.AddParameter("field_triggers", fieldTriggers);

            return Execute<MemberSignup>(request);
        }

        /// <summary>
        /// Delete an array of members. The members will be marked as deleted and cannot be retrieved.
        /// </summary>
        /// <param name="memberIds">An array of member ids to delete.</param>
        /// <returns>True if all members are successfully deleted, otherwise False.</returns>
        /// <remarks></remarks>
        public bool DeleteMembers(List<string> memberIds)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/delete";
            request.AddParameter("member_ids", memberIds);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Change the status for an array of members. The members will have their member_status_id update
        /// </summary>
        /// <param name="memberIds">The array of member ids to change.</param>
        /// <param name="statusTo">The new status for the given members. Accepts one of ‘a’ (active), ‘e’ (error), ‘o’ (optout).</param>
        /// <returns>True if the members are successfully updated, otherwise False.</returns>
        /// <remarks></remarks>
        public bool ChangeMemberStatus(List<string> memberIds, MemberStatus statusTo)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/status";
            request.AddParameter("member_ids", memberIds);
            request.AddParameter("status_to", statusTo);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Update a single member’s information. Update the information for an existing member (even if they are marked as deleted). Note that this method allows the email address to be updated (which cannot be done with a POST, since in that case the email address is used to identify the member).
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="memberEmail">A new email address for the member.</param>
        /// <param name="statusTo"> A new status for the member. Accepts one of ‘a’ (active), ‘e’ (error), ‘o’ (opt-out).</param>
        /// <param name="fields">An array of fields with associated values for this member.</param>
        /// <param name="fieldTriggers">Optional. Fires related field change autoresponders when set to true.</param>
        /// <returns>True if the member was updated successfully</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public bool UpdateSingleMemberInformation(string memberId, string memberEmail, MemberStatus statusTo, List<Field> fields, bool fieldTriggers)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/{memberId}";
            request.AddUrlSegment("memberId", memberId);
            request.AddParameter("email", memberEmail);
            request.AddParameter("status_to", statusTo);
            request.AddParameter("fields", fields);

            if (fieldTriggers)
                request.AddParameter("field_triggers", fieldTriggers);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Delete the specified member. The member, along with any associated response and history information, will be completely removed from the database.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <returns>True if the member is deleted.</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public bool DeleteMember(string memberId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/members/{memberId}";
            request.AddUrlSegment("memberId", memberId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Get the groups to which a member belongs.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <returns>An array of groups.</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public MemberGroups GetMemberGroups(string memberId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/members/{memberId}/groups";
            request.AddUrlSegment("memberId", memberId);

            return Execute<MemberGroups>(request);
        }

        /// <summary>
        /// Add a single member to one or more groups.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="groupIds">Group ids to which to add this member.</param>
        /// <returns>An array of ids of the affected groups.</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public List<string> AddMemberToGroups(string memberId, List<string> groupIds)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/{memberId}/groups";
            request.AddUrlSegment("memberId", memberId);
            request.AddParameter("group_ids", groupIds);

            return Execute<List<string>>(request);
        }

        /// <summary>
        /// Remove a single member from one or more groups.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="groupIds">Group ids from which to remove this member</param>
        /// <returns>An array of references to the affected groups.</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public List<string> RemoveMemberFromGroups(string memberId, List<string> groupIds)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/{memberId}/groups/remove";
            request.AddUrlSegment("memberId", memberId);
            request.AddParameter("group_ids", groupIds);

            return Execute<List<string>>(request);
        }

        /// <summary>
        /// Delete all members.
        /// </summary>
        /// <param name="memberStatusId">This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns true.</returns>
        /// <remarks></remarks>
        public bool DeleteAllMembers(MemberStatus memberStatusId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/members";
            request.AddParameter("member_status_id", memberStatusId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Remove the specified member from all groups.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <returns>True if the member is removed from all groups.</returns>
        /// <remarks>Http404 if no member is found.</remarks>
        public bool RemoveMemberFromGroups(string memberId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/members/{memberId}/groups";
            request.AddUrlSegment("memberId", memberId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Remove multiple members from groups.
        /// </summary>
        /// <param name="memberIds">Member ids to remove from the given groups.</param>
        /// <param name="groupIds">Group ids from which to remove the given members</param>
        /// <returns>True if the members are deleted, otherwise False.</returns>
        /// <remarks>Http404 if any of the members or groups do not exist</remarks>
        public bool RemoveMembersFromGroups(List<string> memberIds, List<string> groupIds)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/groups/remove";
            request.AddParameter("member_ids", memberIds);
            request.AddParameter("group_ids", groupIds);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Get the entire mailing history for a member.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <returns>Message history details for the specified member.</returns>
        /// <remarks></remarks>
        public MailingHistory GetMemberMailingHistory(string memberId) 
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/members/{memberId}/mailings";
            request.AddUrlSegment("memberId", memberId);

            return Execute<MailingHistory>(request);
        }

        /// <summary>
        /// Get a list of members affected by this import.
        /// </summary>
        /// <param name="importId">Import identifier.</param>
        /// <returns>A list of members in the given account and import.</returns>
        /// <remarks></remarks>
        public ImportMembers GetMembersAffectedByImport(string importId) 
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/members/imports/{importId}/members";
            request.AddUrlSegment("importId", importId);

            return Execute<ImportMembers>(request);
        }

        /// <summary>
        /// Get information and statistics about this import.
        /// </summary>
        /// <param name="importId">Import identifier.</param>
        /// <returns>Import details for the given import_id.</returns>
        /// <remarks></remarks>
        public Import GetImportInformation(string importId) 
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/members/imports/{importId}";
            request.AddUrlSegment("importId", importId);

            return Execute<Import>(request);
        }

        /// <summary>
        /// Get information about all imports for this account.
        /// </summary>
        /// <returns>An array of import details.</returns>
        /// <remarks></remarks>
        public List<Import> GetAllImportInformation() 
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/members/imports";

            return Execute<List<Import>>(request);
        }

        /// <summary>
        /// Update an import record to be marked as ‘deleted’.
        /// </summary>
        /// <returns>True if the import is marked as deleted.</returns>
        /// <remarks>Http404 if the import record does not exist.</remarks>
        public bool UpdateImportRecordAsDeleted()
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/members/imports/delete";

            return Execute<bool>(request);
        }

        /// <summary>
        /// Copy all account members of one or more statuses into a group.
        /// </summary>
        /// <param name="groupId">Group identifier.</param>
        /// <param name="memberStatusId"> ‘a’ (active), ‘o’ (optout), and/or ‘e’ (error).</param>
        /// <returns>True</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool CopyMembersIntoStatusGroup(string groupId, List<string> memberStatusId)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/{groupId}/copy";
            request.AddUrlSegment("groupId", groupId);
            request.AddParameter("member_status_id", memberStatusId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Update the status for a group of members, based on their current status. Valid statuses id are (‘a’,’e’, ‘f’, ‘o’) active, error, forwarded, optout.
        /// </summary>
        /// <param name="statusFrom">The current status of the members.</param>
        /// <param name="statusTo">The updated status of the members.</param>
        /// <param name="groupId">Optional. Limit the update to members of the specified group</param>
        /// <returns>True</returns>
        /// <remarks>Http400 if the specified status is invalid</remarks>
        public bool UpdateStatusOfGroupMembersBasedOnCurrentStatus(MemberStatus statusFrom, MemberStatus statusTo, string groupId)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/members/status/{statusFrom}/to/{statusTo}";
            request.AddUrlSegment("statusFrom", statusFrom.ToString());
            request.AddUrlSegment("statusTo", statusTo.ToString());
            request.AddParameter("group_id", groupId);

            return Execute<bool>(request);
        }

		#endregion
	}
}

