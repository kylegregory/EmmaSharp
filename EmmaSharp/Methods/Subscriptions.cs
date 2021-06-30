using EmmaSharp.Models.Subscriptions;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public partial class EmmaApi
    {

        /// <summary>
        /// Get a list of all subscriptions in an account.
        /// </summary>
        /// <returns>A list of subscriptions in an account along with related information, including member count and subscription ID.</returns>
        /// <param name="deletedOnly">true or false. Returns deleted subscriptions only. Optional, defaults to false.</param>
        /// <param name="includeDeleted">true or false. Returns deleted subscriptions along with active. Optional, defaults to false.</param>
        public List<Subscription> GetAccountSubscritpions(bool deletedOnly = false, bool includeDeleted = false)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/subscriptions";

            if (deletedOnly)
                request.AddParameter("deleted_only", deletedOnly);
            if (includeDeleted)
                request.AddParameter("include_deleted", includeDeleted);

            return Execute<List<Subscription>>(request);
        }

        /// <summary>
        /// Get detailed information for a specific subscription.
        /// </summary>
        /// <returns>	Information about a subscription.</returns>
        /// <param name="subscription_id">URL segment for the subscrition ID to query details on</param>
        public Subscription GetAccountSubscription(string subscription_id)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}";
            request.AddUrlSegment("subscriptionId", subscription_id);

            return Execute<Subscription>(request);
        }

        /// <summary>
        /// Get a list of member IDs for members subscribed to a specific subscription.
        /// </summary>
        /// <returns>	A list of member IDs.</returns>
        /// <param name="subscription_id">URL segment for the subscrition ID to query details on</param>
        /// <param name="start">Pagination: start page. Defaults to first page (e.g. 0).</param>
        /// <param name="end">Pagination: end page. Defaults to first page (e.g. 500).</param>
        public List<SubscriptionMembers> GetSubscriptionMembers(string subscription_id, int start = 0, int end = 500)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}/members";
            request.AddUrlSegment("subscriptionId", subscription_id);

            return Execute<List<SubscriptionMembers>>(request, start, end);
        }

        /// <summary>
        /// Get a list of member IDs for members who have opted out of a specific subscription.
        /// </summary>
        /// <returns>	A list of member IDs.</returns>
        /// <param name="subscription_id">URL segment for the subscrition ID to query details on</param>
        /// <param name="start">Pagination: start page. Defaults to first page (e.g. 0).</param>
        /// <param name="end">Pagination: end page. Defaults to first page (e.g. 500).</param>
        public List<SubscriptionMembers> GetOptOutSubscriptionMembers(string subscription_id, int start = 0, int end = 500)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}/optouts";
            request.AddUrlSegment("subscriptionId", subscription_id);

            return Execute<List<SubscriptionMembers>>(request, start, end);
        }

        /// <summary>
        /// Create a subscription
        /// </summary>
        /// <returns> Information about the created subscription, including the subscription ID.</returns>
        /// <param name="subscription">Name and descrption of the new subcription to create</param>
        public Subscription PostNewSubscription(SubscriptionNew subscription)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/subscriptions";

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            request.AddBody(subscription);

            return Execute<Subscription>(request);
        }

        /// <summary>
        /// Bulk subscribe members to a subscription using a list of member IDs
        /// </summary>
        /// <returns>True if successful.</returns>
        /// <param name="memberIds">List of memberIDs</param>
        /// <param name="subscription_id">subscription id</param>
        public bool PostBulkMemberSubscrpitions(SubscriptionBulk memberIds, string subscription_id)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}/members/bulk";

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            request.AddBody(memberIds);

            return Execute<bool>(request);
        }

        /// <summary>
        /// Bulk subscribe members to a subscription using the import ID of all members
        /// </summary>
        /// <returns>True if successful.</returns>
        /// <param name="importId">import ID to bulk subscribe</param>
        /// <param name="subscription_id">subscription id</param>
        public bool PostBulkImportSubscrpitions(SubscriptionImportBulk importId, string subscription_id)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}/members/bulk";

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            request.AddBody(importId);

            return Execute<bool>(request);
        }


        /// <summary>
        /// Edit a subscription's name or description.
        /// </summary>
        /// <returns>Information about the updated subscription.Limited to name and description.</returns>
        /// <param name="subscription">Name and descrpition of the subscription text to update. Visible in the Subscription Center.</param>
        /// <param name="subscription_id ">the id to update</param>
        public Subscription EditSubscrpition(SubscriptionNew subscription, string subscription_id)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}";

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            request.AddBody(subscription);

            return Execute<Subscription>(request);
        }

        /// <summary>
        /// Delete a subscription.
        /// </summary>
        /// <returns>Information about the subscription, including the date and time it was deleted.</returns>
        /// <param name="subscription_id ">the id to update</param>
        public Subscription DeleteSubscription(string subscription_id)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/subscriptions/{subscriptionId}";

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();           

            return Execute<Subscription>(request);
        }
    }
}
