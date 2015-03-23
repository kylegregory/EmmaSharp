using RestSharp;
using System.Collections.Generic;
using EmmaSharp.Models;
using EmmaSharp.Models.Members;

namespace EmmaSharp
{
	public partial class EmmaApi
	{
		#region Members

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
		public MemberOptout GetMemberOptout (string memberId)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/members/{memberId}/optout";
			request.AddUrlSegment("memberId", memberId);

			return Execute<MemberOptout>(request);
		}

		public 

		#endregion
	}
}

