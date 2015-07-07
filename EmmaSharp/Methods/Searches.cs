using EmmaSharp.Models.Searches;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// These endpoints allow you to create, edit, and delete searches. You can also retrieve the members matching any search created in your account.
    /// </summary>
    public partial class EmmaApi
    {
        #region Searches

        /// <summary>
        /// Retrieve a list of saved searches.
        /// </summary>
        /// <param name="deleted">Accepts True or 1. Optional flag to include deleted searches.</param>
        /// <returns>An array of searches.</returns>
        /// <remarks></remarks>
        public List<Search> GetSearches(bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response";

            if (deleted)
                request.AddParameter("deleted", "true");

            return Execute<List<Search>>(request);
        }

        /// <summary>
        /// Get the details for a saved search.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="deleted">>Accepts True or 1. Optional flag to include deleted searches.</param>
        /// <returns>A search.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
        public Search GetSearchDetails(string searchId, bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{searchId}";
            request.AddUrlSegment("searchId", searchId);

            if (deleted)
                request.AddParameter("deleted", "true");

            return Execute<Search>(request);
        }

        public void CreateSavedSearch() { }
        public void UpdateSavedSearch() { }

        /// <summary>
        /// Delete a saved search. The member records referred to by the search are not affected.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <returns>True if the search is deleted.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
        public bool DeleteSavedSearch(string searchId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/response/{searchId}";
            request.AddUrlSegment("searchId", searchId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Get the members matching the search.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <returns>An array of members.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
        public SearchMembers GetMembersMatchingSearch(string searchId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{searchId}/members";

            return Execute<SearchMembers> (request);
        }

        #endregion
    }
}
