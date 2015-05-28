using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmmaSharp.Models.Response;
using EmmaSharp.Extensions;

namespace EmmaSharp
{
    public class Responses : EmmaApi
    {
        #region Response

        /// <summary>
        /// Response Endpoints
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public Responses(string publicKey, string secretKey, string accountId)
            : base(publicKey, secretKey, accountId)
        {
        }

        /// <summary>
        /// Get the response summary for an account.
        /// </summary>
        /// <param name="includeArchived">Accepts 1. All other values are False. Optional flag to include archived mailings in the list.</param>
        /// <param name="range">Optional. A DateRange object to build the range parameter.</param>
        /// <returns>A list of objects with each object representing one month.</returns>
        /// <exception cref="HttpResponseException"></exception>
        public Response GetResponseSummary(bool includeArchived = false, DateRange range = null)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response";

            if (includeArchived)
                request.AddParameter("include_archived", "1");

            if (range != null)
                request.AddParameter("range", range.BuildRangeString());

            return Execute<Response>(request);
        }

        #endregion
    }
}
