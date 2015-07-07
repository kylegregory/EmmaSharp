using EmmaSharp.Models.Triggers;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp
{
    public partial class EmmaApi
    {
        #region Triggers

        /// <summary>
        /// Get a basic listing of all triggers in an account.
        /// </summary>
        /// <returns>A list of Triggers in the account.</returns>
        public List<Trigger> GetTriggers()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers";

            return Execute<List<Trigger>>(request);
        }

        /// <summary>
        /// Look up a trigger by trigger id.
        /// </summary>
        /// <param name="triggerId">The ID of the Trigger to return.</param>
        /// <returns>A trigger.</returns>
        public Trigger GetTriggerById(string triggerId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers/{triggerId}";
            request.AddUrlSegment("triggerId", triggerId);

            return Execute<Trigger>(request);
        }

        /// <summary>
        /// Update or edit a trigger.
        /// </summary>
        /// <param name="trigger">Trigger fields to update</param>
        /// <returns>The id of the updated trigger.</returns>
        public int UpdateTrigger(string triggerId, Trigger trigger)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/triggers/{triggerId}";
            request.AddUrlSegment("triggerId", triggerId);
            request.AddBody(trigger);

            return Execute<int>(request);
        }

        /// <summary>
        /// Delete a trigger.
        /// </summary>
        /// <param name="triggerId">ID of the trigger to be deleted.</param>
        /// <returns>True if the trigger is deleted.</returns>
        public int DeleteTrigger(string triggerId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/triggers/{triggerId}";
            request.AddUrlSegment("triggerId", triggerId);

            return Execute<int>(request);
        }

        /// <summary>
        /// Get mailings sent by a trigger.
        /// </summary>
        /// <param name="triggerId">The trigger ID of the returned mailings.</param>
        /// <returns>An array of mailings.</returns>
        public List<TriggerParent> GetMailingsByTrigger(string triggerId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers/{triggerId}/mailings";
            request.AddUrlSegment("triggerId", triggerId);

            return Execute<List<TriggerParent>>(request);
        }

        #endregion
    }
}
