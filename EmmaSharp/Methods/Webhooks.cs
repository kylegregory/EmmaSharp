using EmmaSharp.Models.Webhooks;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp
{
    public partial class EmmaApi
    {
        #region Webhooks

        /// <summary>
        /// Get a basic listing of all webhooks associated with an account.
        /// </summary>
        /// <returns>A list of webhooks that belong to the given account.</returns>
        public List<Webhook> GetWebhooks()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/webhooks";

            return Execute<List<Webhook>>(request);
        }

        /// <summary>
        /// Get information for a specific webhook belonging to a specific account.
        /// </summary>
        /// <param name="webhookId">The ID of the Webhook to return.</param>
        /// <returns>Details for a single webhook</returns>
        public Webhook GetWebhookById(string webhookId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/webhooks/{webhookId}";
            request.AddUrlSegment("webhookId", webhookId);

            return Execute<Webhook>(request);
        }

        /// <summary>
        /// Get a listing of all event types that are available for webhooks.
        /// </summary>
        /// <returns>A list of event types and descriptions</returns>
        public List<WebhookEvents> GetWebhookEvents()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/webhooks/events";

            return Execute<List<WebhookEvents>>(request);
        }

        /// <summary>
        /// Create an new webhook.
        /// </summary>
        /// <param name="webhook">The webhook to be created.</param>
        /// <returns>The ID of the newly created webhook.</returns>
        public int CreateWebhook(Webhook webhook)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/webhooks";
            request.AddBody(webhook);

            return Execute<int>(request);
        }

        /// <summary>
        /// Update an existing webhook
        /// </summary>
        /// <param name="webhookId">The ID of the Webhook to update.</param>
        /// <param name="webhook">The webhook parameters to be updated.</param>
        /// <returns>The id of the updated webhook, or False if the update failed.</returns>
        public int UpdateWebhook(string webhookId, Webhook webhook)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/webhooks/{webhookId}";
            request.AddUrlSegment("webhookId", webhookId);
            request.AddBody(webhook);

            return Execute<int>(request);
        }

        /// <summary>
        /// Deletes an existing webhook.
        /// </summary>
        /// <param name="webhookId">The ID of the Webhook to delete.</param>
        /// <returns>True if the webhook deleted successfully.</returns>
        public bool DeleteWebhookById(string webhookId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/webhooks/{webhookId}";
            request.AddUrlSegment("webhookId", webhookId);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Delete all webhooks registered for an account.
        /// </summary>
        /// <returns>True if the webhook deleted successfully.</returns>
        public bool DeleteWebhook()
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/webhooks";

            return Execute<bool>(request);
        }

        #endregion
    }
}
