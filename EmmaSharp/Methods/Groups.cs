using EmmaSharp.Models;
using EmmaSharp.Models.Groups;
using EmmaSharp.Models.Members;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// With these endpoints, you can manage all aspects of the groups in your account. In addition to various CRUD methods, you can also use these endpoints to manage the members of your groups. You’ll want to use these methods if you’re managing group membership for more than one member at a time. For dealing with single members, there are better methods in the members endpoints.
    /// </summary>
    public class Groups : EmmaApi
    {
        #region Groups

        /// <summary>
        /// Groups Endpoints
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public Groups(string publicKey, string secretKey, string accountId)
            : base(publicKey, secretKey, accountId)
        {
        }

		/// <summary>
		/// Get number of all active member groups for a single account.
		/// </summary>
		/// <returns>An int of groups.</returns>
		public int GetGroupCount()
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/groups";
			request.AddParameter("count", "true");

			return Execute<int>(request);
		}

        /// <summary>
		/// Get a basic listing of all active member groups for a single account. Be sure to get a count of groups before accessing this method, so you're aware of paging requirements.
		/// </summary>
		/// <param name="groupType">Accepts a comma-separated string with one or more GroupTypes. Defaults to Group.</param>
		/// <param name="start">Start paging record at.</param>
		/// <param name="end">End paging record at.</param>
        /// <returns>An array of groups.</returns>
		public List<Group> ListGroups(GroupType groupType, int? start, int? end)
        {
            var request = new RestRequest();
			request.Resource = "/{accountId}/groups";

			if (!start.HasValue)
				start = 0;
			request.AddParameter("start", start);

			if (!end.HasValue || end - start > 500)
				end = 500;
			request.AddParameter("end", end);

            if (groupType != null) 
                request.AddParameter("group_types", groupType);

            return Execute<List<Group>>(request);
        }

        /// <summary>
        /// Create one or more new member groups.
        /// </summary>
        /// <param name="groups">A Group to be created. Each object must contain a group_name parameter.</param>
        /// <returns>An array of the new group ids and group names.</returns>
        public List<Group> CreateFields(List<Group> groups)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/groups";
            request.AddBody(groups);

            return Execute<List<Group>>(request);
        }

        /// <summary>
        /// Get the detailed information for a single member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <returns>A group.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public Group GetGroup(string memberGroupId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/groups/{memberGroupId}";
            request.AddUrlSegment("memberIdGroup", memberGroupId);

            return Execute<Group>(request);
        }

        /// <summary>
        /// Update information for a single member group.
        /// </summary>
        /// <param name="group">The Group to be updated.</param>
        /// <param name="memberGroupId">The Member Group Id to be updated.</param>
        /// <returns>True if the update was successful</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public Group UpdateGroup(Group group, string memberGroupId)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{memberIdGroup}";
            request.AddUrlSegment("memberIdGroup", memberGroupId);
            request.AddBody(group.ActiveCount);

            return Execute<Group>(request);
        }

        /// <summary>
        /// Delete a single member group.
        /// </summary>
        /// <param name="memberIdGroup">The Member Group Id to be deleted.</param>
        /// <returns>True if the group is deleted.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool DeleteGroup(string memberIdGroup)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/groups/{memberIdGroup}";
            request.AddUrlSegment("memberIdGroup", memberIdGroup);

            return Execute<bool>(request);
        }
        #endregion

        #region GroupMembers

        /// <summary>
        /// Get the members in a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="deleted">Include deleted members. Optional, defaults to false.</param>
        /// <returns>An array of members.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public GroupMembers ListGroupMembers(string memberGroupId, bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberIdGroup", memberGroupId);

            if (deleted != false)
                request.AddParameter("deleted", deleted);

            return Execute<GroupMembers>(request);
        }

        /// <summary>
        /// Add a list of members to a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="memberIds">An array of member ids.</param>
        /// <returns>An array of references to the members added to the group. If a member already exists in the group or is not a valid member, that reference will not be returned.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public List<string> AddMembersToGroup(string memberGroupId, List<string> memberIds)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberIdGroup", memberGroupId);
            request.AddBody(memberIds);

            return Execute<List<string>>(request);
        }

        /// <summary>
        /// Remove members from a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="memberIds">An array of member ids.</param>
        /// <returns>An array of references to the removed members.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public List<string> RemoveMembersFromGroup(string memberGroupId, List<string> memberIds) 
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members/remove";
            request.AddUrlSegment("memberIdGroup", memberGroupId);
            request.AddBody(memberIds);

            return Execute<List<string>>(request);
        }

        /// <summary>
        /// Remove all members from a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="status">A Member Status string. Optional. This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns the number of members removed from the group.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public int DeleteAllMembersFromGroup(string memberGroupId, MemberStatus status)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberIdGroup", memberGroupId);

            if (status != null)
                request.AddParameter("member_status_id", status);

            return Execute<int>(request);
        }

        /// <summary>
        /// Remove all members from all active member groups as a background job. The member_status_id parameter must be set.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="status">A Member Status string. Optional. This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns true.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool DeleteAllMembersFromAllGroups(string memberGroupId, MemberStatus status)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members/remove";
            request.AddUrlSegment("memberIdGroup", memberGroupId);

            if (status != null)
                request.AddParameter("member_status_id", status);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Copy all the users of one group into another group
        /// </summary>
        /// <param name="fromGroupId">The Member Group ID to be copied from.</param>
        /// <param name="toGroupId">The Member Group ID to be copied to.</param>
        /// <param name="status">A Member Status string. Optional. This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns true.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool CopyUsersFromGroup(string fromGroupId, string toGroupId, MemberStatus status)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/groups/{fromGroupId}/{toGroupId}/members/copy";
            request.AddUrlSegment("memberIdGroup", fromGroupId);
            request.AddUrlSegment("memberIdGroup", toGroupId);

            if (status != null)
                request.AddParameter("member_status_id", status);

            return Execute<bool>(request);
        }
        #endregion

    }
}
