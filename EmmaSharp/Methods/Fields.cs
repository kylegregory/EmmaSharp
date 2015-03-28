using EmmaSharp.Models;
using EmmaSharp.Models.Fields;
using RestSharp;

namespace EmmaSharp
{
    public class Fields : EmmaApi
    {
        /// <summary>
        /// Fields Endpoints
        /// </summary>
        /// <param name="publicKey">The account's public key.</param>
        /// <param name="secretKey">The account's private key.</param>
        /// <param name="accountId">The account id.</param>
        public Fields(string publicKey, string secretKey, string accountId)
            : base(publicKey, secretKey, accountId)
        {
        }

		/// <summary>
		/// Gets number of fields for paging.
		/// </summary>
		/// <param name="deleted">Accepts True. Optional flag to include deleted fields</param>
		/// <returns>An array of fields.</returns>
		public int GetFieldCount(bool? deleted)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/fields";
			request.AddParameter("count", "true");

			if (!deleted ?? false) 
				request.AddParameter("deleted", deleted);

			return Execute<int>(request);
		}

		/// <summary>
        /// Gets a list of this account's defined fields. Be sure to get a count of fields before accessing this method, so you're aware of paging requirements.
		/// </summary>
		/// <param name="start">Start paging record at.</param>
		/// <param name="end">End paging record at.</param>
        /// <param name="deleted">Accepts True. Optional flag to include deleted fields</param>
        /// <returns>An array of fields.</returns>
		public AllFields ListFields(bool? deleted, int? start, int? end)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/fields";

			if (!start.HasValue)
				start = 0;
			request.AddParameter("start", start);

			if (!end.HasValue || end - start > 500)
				end = 500;
			request.AddParameter("end", end);

            if (!deleted ?? false) 
                request.AddParameter("deleted", deleted);

            return Execute<AllFields>(request);
        }

        /// <summary>
        /// Gets the detailed information about a particular field.
        /// </summary>
        /// <param name="fieldId">The Field Id of the field to retrieve.</param>
        /// <param name="deleted">Accepts True. Optionally show a field even if it has been deleted.</param>
        /// <returns>A field.</returns>
        /// <exception cref="HttpResponseException">Http404 if the field does not exist.</exception>
        public Field GetField(string fieldId, bool? deleted)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            if (!deleted ?? false)
                request.AddParameter("deleted", deleted);

            return Execute<Field>(request);
        }

        /// <summary>
        /// Create a new field field. There must not already be a field with this name.
        /// </summary>
        /// <param name="field">The Field to be created.</param>
        /// <returns>A reference to the new field.</returns>
        public Field CreateField(Field field)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/fields";
            request.AddBody(field);

            return Execute<Field>(request);
        }

        /// <summary>
        /// Deletes a field.
        /// </summary>
        /// <param name="fieldId">The Field Id of the field to delete.</param>
        /// <returns>True if the field is deleted, False otherwise.</returns>
        public bool DeleteField(string fieldId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Clear the member data for the specified field.
        /// </summary>
        /// <param name="fieldId">The Field Id of the field to clear.</param>
        /// <returns>True if all of the member field data is deleted</returns>
        public bool ClearField(string fieldId)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/fields/{fieldId}/clear";
            request.AddUrlSegment("fieldId", fieldId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Updates an existing field.
        /// </summary>
        /// <param name="fieldId">The Field Id of the field to update.</param>
        /// <param name="field">The Field to be updated.</param>
        /// <returns>A reference to the updated field.</returns>
        public bool UpdateField(string fieldId, Field field)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);
            request.AddBody(field);

            return Execute<bool>(request);
        }
    }
}
