using EmmaSharp.Models;
using EmmaSharp.Models.Fields;
using RestSharp;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// These endpoints let you create, edit, update and delete all of the custom fields in your account. Of particular interest is the <see cref="ClearField(string)"/> method which lets you clear out all the data in a single field for all members in your account. This makes it easy to re-initialize a dataset if you’re looking to correct an import error or syncing issue.
    /// </summary>
    public partial class EmmaApi
    {
        #region Fields

        /// <summary>
		/// Gets number of fields for paging.
		/// </summary>
		/// <param name="deleted">Accepts True. Optional flag to include deleted fields</param>
		/// <returns>An array of fields.</returns>
		public int ListFieldsCount(bool deleted = false)
		{
			var request = new RestRequest();
			request.Resource = "/{accountId}/fields";
			request.AddParameter("count", "true");

			if (deleted) 
				request.AddParameter("deleted", deleted);

            return Execute<int>(request);
		}

		/// <summary>
        /// Gets a list of this account's defined fields. Be sure to get a count of fields before accessing this method, so you're aware of paging requirements.
		/// </summary>
        /// <param name="deleted">Accepts True. Optional flag to include deleted fields</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of fields.</returns>
		public List<Field> ListFields(bool deleted = false, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/fields";

            if (deleted) 
                request.AddParameter("deleted", deleted);

            return Execute<List<Field>>(request, start, end);
        }

        /// <summary>
        /// Gets the detailed information about a particular field.
        /// </summary>
        /// <param name="fieldId">The Field Id of the field to retrieve.</param>
        /// <param name="deleted">Accepts True. Optionally show a field even if it has been deleted.</param>
        /// <returns>A field.</returns>
        /// <remarks>Http404 if the field does not exist.</remarks>
        public Field GetField(string fieldId, bool deleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            if (deleted)
                request.AddParameter("deleted", deleted);

            return Execute<Field>(request);
        }

        /// <summary>
        /// Create a new field. There must not already be a field with this name.
        /// </summary>
        /// <param name="field">The Field to be created.</param>
        /// <returns>A reference (Field ID as int) to the new field.</returns>
        public int CreateField(CreateField field)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/fields";

            request.AddBody(field);

            return Execute<int>(request);
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
        /// <returns>A reference (Field ID as int) to the updated field.</returns>
        public int UpdateField(string fieldId, UpdateField field)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            request.AddBody(field);

            return Execute<int>(request);
        }

        #endregion
    }
}
