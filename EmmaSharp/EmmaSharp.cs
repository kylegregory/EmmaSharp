using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using System;
using System.Diagnostics;
using System.Net;

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
        /// <param name="start">If more than 500 results, use these parameters to start/end pages.</param>
        /// <param name="end">If more than 500 results, use these parameters to start/end pages.</param>
        /// <returns>Response data from the API call.</returns>
        private T Execute<T>(RestRequest request, int start = -1, int end = -1) where T : new()
        {
            // Explicitly set requests to TLS 1.1 or higher per Emma Documentation
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);

            client.Authenticator = new HttpBasicAuthenticator(_publicKey, _secretKey);
            request.AddParameter("accountId", _accountId, ParameterType.UrlSegment); // used on every request

            if (start >= 0 && end >= 0) {
                request.AddQueryParameter("start", start.ToString());
                request.AddQueryParameter("end", end.ToString());
            }

            request.RequestFormat = DataFormat.Json;

            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());
            request.JsonSerializer = new EmmaJsonSerializer(serializer);

            IRestResponse<T> execute = client.Execute<T>(request);
            Trace.WriteLine(request.JsonSerializer.Serialize(request));
            checkResponse(execute);
            
            T response = JsonConvert.DeserializeObject<T>(execute.Content);
            return response;
        }

        private void checkResponse(IRestResponse response)
        {
            int code = (int)response.StatusCode;
            if (code >= 400)
            {
                throw new EmmaException(response);
            }
        }
    }
}