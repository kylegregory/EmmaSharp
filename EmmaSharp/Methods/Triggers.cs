﻿using EmmaSharp.Models.Mailings;
using EmmaSharp.Models.Triggers;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace EmmaSharp
{
    public partial class EmmaApi
    {
        #region Triggers

        /// <summary>
        /// Get a count of all triggers in an account.
        /// </summary>
        /// <returns>A list of Triggers in the account.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
        public int GetTriggersCount()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers";
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get a basic listing of all triggers in an account.
        /// </summary>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>A list of Triggers in the account.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
        public List<Trigger> GetTriggers(int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers";

            return Execute<List<Trigger>>(request, start, end);
        }

        /// <summary>
        /// Look up a trigger by trigger id.
        /// </summary>
        /// <param name="triggerId">The ID of the Trigger to return.</param>
        /// <returns>A trigger.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
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
        /// <param name="triggerId">The ID of the Trigger to update.</param>
        /// <param name="name">The updated name of the trigger.</param>
        /// <returns>The id of the updated trigger.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
        public int UpdateTrigger(string triggerId, string name)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/triggers/{triggerId}";
            request.AddUrlSegment("triggerId", triggerId);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            request.AddBody(new { name = name });

            return Execute<int>(request);
        }

        /// <summary>
        /// Delete a trigger.
        /// </summary>
        /// <param name="triggerId">ID of the trigger to be deleted.</param>
        /// <returns>True if the trigger is deleted.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
        public bool DeleteTrigger(string triggerId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/triggers/{triggerId}";
            request.AddUrlSegment("triggerId", triggerId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Get a count of mailings sent by a trigger.
        /// </summary>
        /// <param name="triggerId">The trigger ID of the returned mailings.</param>
        /// <returns>An array of mailings.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
        public int GetMailingsByTriggerCount(string triggerId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers/{triggerId}/mailings";
            request.AddUrlSegment("triggerId", triggerId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get mailings sent by a trigger.
        /// </summary>
        /// <param name="triggerId">The trigger ID of the returned mailings.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of mailings.</returns>
        [Obsolete("Trigger endpoints have been deprecated, and will be removed in future releases.")]
        public List<MailingTrigger> GetMailingsByTrigger(string triggerId, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/triggers/{triggerId}/mailings";
            request.AddUrlSegment("triggerId", triggerId);

            return Execute<List<MailingTrigger>>(request, start, end);
        }

        #endregion
    }
}
