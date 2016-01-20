using EmmaSharp.Extensions;
using EmmaSharp.Models;
using EmmaSharp.Models.Groups;
using EmmaSharp.Models.Members;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// With these endpoints, you can manage all aspects of the groups in your account. In addition to various CRUD methods, you can also use these endpoints to manage the members of your groups. You’ll want to use these methods if you’re managing group membership for more than one member at a time. For dealing with single members, there are better methods in the members endpoints.
    /// </summary>
    public partial class EmmaApi
    {
        #region Groups

        /// <summary>
		/// Get number of all active member groups for a single account.
		/// </summary>
		/// <returns>An int of groups.</returns>
        public int ListGroupCount(List<GroupType> groupType = null)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/groups";
			request.AddParameter("count", "true");

            if (groupType != null)
                request.AddParameter("group_types", string.Join(",", string.Join(",", Array.ConvertAll(groupType.ToArray(), i => i.ToEnumString<GroupType>()))));

			return Execute<int>(request);
		}

        /// <summary>
		/// Get a basic listing of all active member groups for a single account. Be sure to get a count of groups before accessing this method, so you're aware of paging requirements.
		/// </summary>
		/// <param name="groupType">Accepts a comma-separated string with one or more GroupTypes. Defaults to Group.</param>
		/// <param name="start">Start paging record at.</param>
		/// <param name="end">End paging record at.</param>
        /// <returns>An array of groups.</returns>
		public List<Group> ListGroups(List<GroupType> groupType = null, int start = -1, int end = -1)
        {
            var request = new RestRequest();
			request.Resource = "/{accountId}/groups";

            if (groupType != null) 
                request.AddParameter("group_types", string.Join(",", string.Join(",", Array.ConvertAll(groupType.ToArray(), i => i.ToEnumString<GroupType>()))));

            return Execute<List<Group>>(request, start, end);
        }

        /// <summary>
        /// Create one or more new member groups.
        /// </summary>
        /// <param name="groups">A Group to be created. Each object must contain a group_name parameter.</param>
        /// <returns>An array of the new group ids and group names.</returns>
        public List<Group> CreateGroups(CreateGroups groups)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/groups";
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

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
            request.AddUrlSegment("memberGroupId", memberGroupId);

            return Execute<Group>(request);
        }

        /// <summary>
        /// Update information for a single member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be updated.</param>
        /// <param name="group">The Group to be updated.</param>
        /// <returns>True if the update was successful</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool UpdateGroup(string memberGroupId, UpdateGroup group)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{memberIdGroup}";
            request.AddUrlSegment("memberIdGroup", memberGroupId);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(group);

            return Execute<bool>(request);
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
        /// Get the count of members in a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="deleted">Include deleted members. Optional, defaults to false.</param>
        /// <returns>An array of members.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public int ListGroupMembersCount(string memberGroupId, bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberGroupId", memberGroupId);

            if (deleted != false)
                request.AddParameter("deleted", deleted);

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the members in a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="deleted">Include deleted members. Optional, defaults to false.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of members.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public List<Member> ListGroupMembers(string memberGroupId, bool deleted = false, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberGroupId", memberGroupId);

            if (deleted != false)
                request.AddParameter("deleted", deleted);

            return Execute<List<Member>>(request, start, end);
        }

        /// <summary>
        /// Add a list of members to a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="memberIds">An array of member ids.</param>
        /// <returns>An array of references to the members added to the group. If a member already exists in the group or is not a valid member, that reference will not be returned.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public List<int> AddMembersToGroup(string memberGroupId, MemberIdList memberIds)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberGroupId", memberGroupId);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(memberIds);

            return Execute<List<int>>(request);
        }

        /// <summary>
        /// Remove members from a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="memberIds">An array of member ids.</param>
        /// <returns>An array of references to the removed members.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public List<int> RemoveMembersFromGroup(string memberGroupId, MemberIdList memberIds) 
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members/remove";
            request.AddUrlSegment("memberGroupId", memberGroupId);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(memberIds);

            return Execute<List<int>>(request);
        }

        /// <summary>
        /// Remove all members from a single active member group.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="status">A Member Status string. Optional. This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns the number of members removed from the group.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public int DeleteAllMembersFromGroup(string memberGroupId, MemberStatusShort? status = null)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members";
            request.AddUrlSegment("memberGroupId", memberGroupId);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            if (status != null)
                request.AddParameter("member_status_id", status.ToEnumString<MemberStatusShort>());

            return Execute<int>(request);
        }

        /// <summary>
        /// Delete all members in this group with the specified status. Then, remove those members from all active member groups as a background job. The member_status_id parameter must be set.
        /// </summary>
        /// <param name="memberGroupId">The Member Group Id to be retrieved.</param>
        /// <param name="status">A Member Status string. This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns true.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool DeleteAllFromMemberGroupsByStatus(string memberGroupId, MemberStatusShort status)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/groups/{memberGroupId}/members/remove";
            request.AddUrlSegment("memberGroupId", memberGroupId);

            request.AddParameter("member_status_id", status.ToEnumString<MemberStatusShort>());

            return Execute<bool>(request);
        }

        /// <summary>
        /// Copy all the users of one group into another group
        /// </summary>
        /// <param name="fromGroupId">The Member Group ID to be copied from.</param>
        /// <param name="toGroupId">The Member Group ID to be copied to.</param>
        /// <param name="status">An Array of Member Status strings. This is ‘a’ (active), ‘o’ (optout), or ‘e’ (error).</param>
        /// <returns>Returns true.</returns>
        /// <remarks>Http404 if the group does not exist.</remarks>
        public bool CopyUsersFromGroup(string fromGroupId, string toGroupId, MemberStatusShortList status)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/groups/{fromGroupId}/{toGroupId}/members/copy";
            request.AddUrlSegment("fromGroupId", fromGroupId);
            request.AddUrlSegment("toGroupId", toGroupId);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(status);

            return Execute<bool>(request);
        }
        #endregion

    }
}
