using RestSharp;
using System.Collections.Generic;
using EmmaSharp.Models;
using EmmaSharp.Models.Members;
using EmmaSharp.Models.Fields;

namespace EmmaSharp
{
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
			request.AddParameter ("count", "true");

			if(!deleted ?? false)
				request.AddParameter("deleted", deleted.ToString());

			return Execute<int>(request);
		}

		/// <summary>
		/// Get a basic listing of all members in an account.
		/// </summary>
		/// <returns>A list of members in the given account.</returns>
		/// <param name="deleted">Accepts True. Optional flag to include deleted members.</param>
		public AllMembers ListMembers(bool? deleted, int? start, int? end)
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

			return Execute<AllMembers>(request);
		}

		/// <summary>
		/// Get detailed information on a particular member, including all custom fields.
		/// </summary>
		/// <returns>A single member if one exists.</returns>
		/// <param name="memberId">Member identifier.</param>
		/// <param name="deleted">Accepts True. Optional flag to include deleted members.</param>
		/// <exception cref="HttpResponseException">Http404 if no member is found.</exception>
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
		/// <exception cref="HttpResponseException">Http404 if no member is found.</exception>
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
		/// <exception cref="HttpResponseException">Http404 if no member is found.</exception>
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
        /// <param name="email">Member email address for optout.</param>
        /// <returns>True if member status change was successful or member was already opted out.</returns>
        /// <exception cref=" HttpResponseException">Http404 if no member is found.</exception>
        public bool UpdateMemberToOptoutByEmail(string memberEmail)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}members/email/optout/{memberEmail}";
            request.AddUrlSegment("email", memberEmail);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Add new members or update existing members in bulk. If you are doing actions for a single member please see the <see cref=""/> call .
        /// </summary>
        /// <param name="members">An array of members to update. A member is a dictionary of member emails and field values to import. The only required field is “email”. All other fields are treated as the name of a member field.</param>
        /// <param name="sourceFilename">An arbitrary string to associate with this import. This should generally be set to the filename that the user uploaded.</param>
        /// <param name="addOnly">Optional. Only add new members, ignore existing members.</param>
        /// <param name="groupIds">Optional. Add imported members to this list of groups.</param>
        /// <returns>An import id.</returns>
        /// <exception cref="HttpResponseException"></exception>
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
        /// <param name="memberemail">Email address of member to add or update</param>
        /// <param name="fields">Names and values of user-defined fields to update</param>
        /// <param name="groupIds">Optional. Add imported members to this list of groups.</param>
        /// <param name="field_triggers">Optional. Fires related field change autoresponders when set to true.</param>
        /// <returns>The member_id of the new or updated member, whether the member was added or an existing member was updated, and the status of the member. The status will be reported as ‘a’ (active), ‘e’ (error), or ‘o’ (optout).</returns>
        /// <exception cref="HttpResponseException"></exception>
        public MemberAdd AddOrUpdateSingleMember(string memberEmail, AllFields fields, MemberGroups groupIds, bool field_triggers)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/members/add";
            request.AddParameter("email", memberEmail);
            request.AddParameter("fields", fields.Fields);

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
        /// <exception cref="HttpResponseException"></exception>
        public MemberSignup MemberSignup(string memberEmail, MemberGroups groupIds, AllFields fields, int signupFormId, string optInSubject, string optInMessage, bool fieldTriggers)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/members/signup";
            request.AddParameter("email", memberEmail);
            request.AddParameter("group_ids", groupIds.Groups);

            if (fields.Fields.Count != 0)
                request.AddParameter("fields", fields.Fields);

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

		#endregion
	}
}

