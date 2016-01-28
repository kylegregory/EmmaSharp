using EmmaSharp.Models.Members;
using EmmaSharp.Models.Searches;
using RestSharp;
using RestSharp.Serializers;
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
        /// Get a count of the number of saved searches.
        /// </summary>
        /// <param name="deleted">Accepts True or 1. Optional flag to include deleted searches.</param>
        /// <returns>An array of searches.</returns>
        /// <remarks></remarks>
        public List<Search> GetSearchesCount(bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/searches";
            request.AddParameter("count", "true");

            if (deleted)
                request.AddParameter("deleted", "true");

            return Execute<List<Search>>(request);
        }

        /// <summary>
        /// Retrieve a list of saved searches.
        /// </summary>
        /// <param name="deleted">Accepts True or 1. Optional flag to include deleted searches.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of searches.</returns>
        /// <remarks></remarks>
        public List<Search> GetSearches(bool deleted = false, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/searches";

            if (deleted)
                request.AddParameter("deleted", "true");

            return Execute<List<Search>>(request, start, end);
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
            request.Resource = "/{accountId}/searches/{searchId}";
            request.AddUrlSegment("searchId", searchId);

            if (deleted)
                request.AddParameter("deleted", "true");

            return Execute<Search>(request);
        }

        /// <summary>
        /// Create a saved search.
        /// </summary>
        /// <param name="search">A name used to describe this search and a combination of search conditions, as described in the documentation.</param>
        /// <returns>The ID of the new search.</returns>
        /// <remarks>Http400 if the search is invalid.</remarks>
        public int CreateSavedSearch(CreateSearch search) 
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/searches";
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(search);

            return Execute<int>(request);        
        }

        /// <summary>
        /// Update a saved search. No parameters are required, but either the name or criteria parameter must be present for an update to occur.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="search">A name used to describe this search and/or a combination of search conditions, as described in the documentation.</param>
        /// <returns>True if the update was successful</returns>
        /// <remarks>Http404 if the search does not exist. Http400 if the search criteria is invalid.</remarks>
        public bool UpdateSavedSearch(string searchId, CreateSearch search) 
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/searches/{searchId}";
            request.AddUrlSegment("searchId", searchId);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();

            request.AddBody(search);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Delete a saved search. The member records referred to by the search are not affected.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <returns>True if the search is deleted.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
        public bool DeleteSavedSearch(string searchId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/searches/{searchId}";
            request.AddUrlSegment("searchId", searchId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Get a count of the number of members matching the search.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <returns>An array of members.</returns>
        public int GetMembersMatchingSearchCount(string searchId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/searches/{searchId}/members";
            request.AddUrlSegment("searchId", searchId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the members matching the search.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of members.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
        public List<Member> GetMembersMatchingSearch(string searchId, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/searches/{searchId}/members";
            request.AddUrlSegment("searchId", searchId);

            return Execute<List<Member>>(request, start, end);
        }

        #endregion
    }
}
