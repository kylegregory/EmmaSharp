using Newtonsoft.Json;
using RestSharp;
using System;

namespace EmmaSharp
{
    /// <summary>
    /// Base Class for APIs
    /// </summary>
	public partial class EmmaApi
    {
        private const string BaseUrl = "https://api.e2ma.net";

        readonly string _publicKey;
        readonly string _secretKey;
        readonly string _accountId;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmmaApi"/> class.
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public EmmaApi(string publicKey, string secretKey, string accountId)
        {
            _publicKey = publicKey;
            _secretKey = secretKey;
            _accountId = accountId;
        }

        /// <summary>
        /// Execute the Call to the Emma API. All methods return this base method.
        /// </summary>
        /// <typeparam name="T">The model or type to bind the return response.</typeparam>
        /// <param name="request">The RestRequest request.</param>
        /// <returns>Response data from the API call.</returns>
        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_publicKey, _secretKey);
            request.AddParameter("accountId", _accountId, ParameterType.UrlSegment); // used on every request
            var execute = client.Execute(request);
            T response = JsonConvert.DeserializeObject<T>(execute.Content);

            if (execute.ErrorException != null)
            {
                const string message = "Error retrieving response. Check inner details for more info.";
                var emmaException = new ApplicationException(message, execute.ErrorException);
                throw emmaException;
            }
            return response;
        }
    }
}
