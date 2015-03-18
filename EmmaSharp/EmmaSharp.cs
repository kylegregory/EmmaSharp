using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp
{
  public partial class EmmaApi
  {
    const string BaseUrl = "https://api.e2ma.net";

    readonly string _publicKey;
    readonly string _secretKey;
    readonly string _accountId;

    public Emma(string publicKey, string secretKey, string accountId) {
      _publicKey = publicKey;
      _secretKey = secretKey;
      _accountId = accountId;
    }

    public T Execute<T>(RestRequest request) where T : new()
    {
      var client = new RestClient();
      client.BaseUrl = BaseUrl;
      client.Authenticator = new HttpBasicAuthenticator(_publicKey, _secretKey);
      request.AddParameter("accountId", _accountId, ParameterType.UrlSegment); // used on every request
      var response = client.Execute<T>(request);

      if (response.ErrorException != null)
      {
        const string message = "Error retrieving response. Check inner details for more info.";
        var emmaException = new ApplicationException(message, response.ErrorException);
        throw emmaException;
      }
      return response.Data;
    }
  }
}
