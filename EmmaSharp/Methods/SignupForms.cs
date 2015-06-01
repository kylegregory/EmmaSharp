using EmmaSharp.Models.SignupForms;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp.Methods
{
    public class SignupForms : EmmaApi
    {
        #region SignupForms

        /// <summary>
        /// Signup Forms Endpoints
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public SignupForms(string publicKey, string secretKey, string accountId)
            : base(publicKey, secretKey, accountId)
        {
        }

        /// <summary>
        /// Gets a list of this account’s signup forms.
        /// </summary>
        /// <returns>An array of signup forms.</returns>
        public List<SignupForm> GetSignupForms()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/signup_forms";

            return Execute<List<SignupForm>>(request);
        }

        #endregion
    }
}
