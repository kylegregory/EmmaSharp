using EmmaSharp.Models.Searches;
using RestSharp;

namespace EmmaSharp.Methods
{
    public class Searches : EmmaApi
    {
        #region Searches

        /// <summary>
        /// Search Endpoints
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public Searches(string publicKey, string secretKey, string accountId)
            : base(publicKey, secretKey, accountId)
        {
        }

        /// <summary>
        /// Retrieve a list of saved searches.
        /// </summary>
        /// <param name="deleted">Accepts True or 1. Optional flag to include deleted searches.</param>
        /// <returns>An array of searches.</returns>
        /// <exception cref="HttpResponseException"></exception>
        public AllSearches GetSearches(bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response";

            if (deleted)
                request.AddParameter("deleted", "true");

            return Execute<AllSearches>(request);
        }

        /// <summary>
        /// Get the details for a saved search.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="deleted">>Accepts True or 1. Optional flag to include deleted searches.</param>
        /// <returns>A search.</returns>
        /// <exception cref="HttpResponseException">Http404 if the search does not exist.</exception>
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
        /// <exception cref="HttpResponseException">Http404 if the search does not exist.</exception>
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
        /// <exception cref="HttpResponseException">Http404 if the search does not exist.</exception>
        public SearchMembers GetMembersMatchingSearch(string searchId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{searchId}/members";

            return Execute<SearchMembers> (request);
        }

        #endregion
    }
}
