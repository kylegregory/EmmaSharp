using EmmaSharp.Models.SignupForms;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// With this endpoint, you can list all of your signup forms.
    /// </summary>
    public partial class EmmaApi
    {
        #region SignupForms

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
