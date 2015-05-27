using EmmaSharp.Extensions;
using EmmaSharp.Models.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="includeArchived"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Response GetResponseSummary(bool includeArchived = false, DateRange range = null)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response";

            if (includeArchived)
                request.AddParameter("include_archived", "true");

            if (range != null)
                request.AddParameter("range", range);

            return Execute<Response>(request);
        }

        #endregion
    }
}
