using EmmaSharp.Extensions;
using EmmaSharp.Models.Generics;
using EmmaSharp.Models.Mailings;
using EmmaSharp.Models.Response;
using RestSharp;
using System.Collections.Generic;

namespace EmmaSharp
{
    /// <summary>
    /// We know that you want to do some fancy pivot tables with your response data, so we’ve provided quite a few endpoints here to give you access to that response data. You can get overview numbers for all of your mailings and also drill down into finding out the actual members who opened a particular mailing.
    /// </summary>
    public partial class EmmaApi
    {
        #region Responses

        /// <summary>
        /// Get the response summary for an account. This method will return a month-based time series of data including sends, opens, clicks, mailings, forwards, and opt-outs. Test mailings and forwards are not included in the data returned.
        /// </summary>
        /// <param name="includeArchived">Accepts 1. All other values are False. Optional flag to include archived mailings in the list.</param>
        /// <param name="range">Optional. A DateRange object to build the range parameter.</param>
        /// <returns>A list of objects with each object representing one month.</returns>
        /// <remarks></remarks>
        public List<ResponseSummary> GetResponseSummary(bool includeArchived = false, DateRange range = null)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response";

            if (includeArchived)
                request.AddParameter("include_archived", "1");

            if (range != null)
                request.AddParameter("range", range.BuildRangeString());

            return Execute<List<ResponseSummary>>(request);
        }

        /// <summary>
        /// Get the response summary for a particular mailing. This method will return the counts of each type of response activity for a particular mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>A single mailing object.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public Response GetMailingResponse(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<Response>(request);
        }

        /// <summary>
        /// Get the count of the list of messages that have been sent to an MTA (Message Transfer Agent) for delivery.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public int GetMailingSendsCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/sends";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the list of messages that have been sent to an MTA (Message Transfer Agent) for delivery.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>Get the list of messages that have been sent to an MTA for delivery.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseGeneric> GetMailingSends(string mailingId, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/sends";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseGeneric>>(request, start, end);
        }

        /// <summary>
        /// Get the count of the list of messages that are in the queue, possibly sent, but not yet delivered.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>Get the list of messages that are in-progress.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public int GetMailingInProgressCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/in_progress";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the list of messages that are in the queue, possibly sent, but not yet delivered.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>Get the list of messages that are in-progress.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseGeneric> GetMailingInProgress(string mailingId, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/in_progress";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseGeneric>>(request, start, end);
        }

        /// <summary>
        /// Get the count of the list of messages that have finished delivery. This will include those that were successfully delivered, as well as those that failed due to hard or soft bounces.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="result">Optional. Accepted options: ‘all’, ‘delivered’, ‘bounced’, ‘hard’, ‘soft’. Defaults to ‘all’, if not provided.</param>
        /// <returns>An array of message responses that have finished delivery.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public int GetMailingDelieveriesCount(string mailingId, DeliveryType result = DeliveryType.All)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/deliveries";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            request.AddParameter("result", result.ToEnumString<DeliveryType>());

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the list of messages that have finished delivery. This will include those that were successfully delivered, as well as those that failed due to hard or soft bounces.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="result">Optional. Accepted options: ‘all’, ‘delivered’, ‘bounced’, ‘hard’, ‘soft’. Defaults to ‘all’, if not provided.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of message responses that have finished delivery.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseDeliveries> GetMailingDelieveries(string mailingId, DeliveryType result = DeliveryType.All, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/deliveries";
            request.AddUrlSegment("mailingId", mailingId);

            request.AddParameter("result", result.ToEnumString<DeliveryType>());

            return Execute<List<ResponseDeliveries>>(request, start, end);
        }

        /// <summary>
        /// Get the list of opened messages for this campaign.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>Get the list of messages that opened.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public int GetMailingOpensCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/opens";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the count of the list of opened messages for this campaign.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>Get the list of messages that opened.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseGeneric> GetMailingOpens(string mailingId, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/opens";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseGeneric>>(request, start, end);
        }

        /// <summary>
        /// Get the list of links for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of link objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<Link> GetMailingLinks(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/links";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<Link>>(request);
        }

        /// <summary>
        /// Get the count of the list of clicks for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of link objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public int GetMailingClicksCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/clicks";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the list of clicks for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="memberId">Optional. Limits results to a single member.</param>
        /// <param name="linkId">Optional. Limits results to a single link.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of link objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseClicks> GetMailingClicks(string mailingId, string memberId = null, string linkId = null, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/clicks";
            request.AddUrlSegment("mailingId", mailingId);

            if (!string.IsNullOrWhiteSpace(memberId))
                request.AddParameter("member_id", memberId);

            if (!string.IsNullOrWhiteSpace(linkId))
                request.AddParameter("link_id", linkId);

            return Execute<List<ResponseClicks>>(request, start, end);
        }

        /// <summary>
        /// Get the list of forwards for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of forwards objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseForwards> GetMailingForwards(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/forwards";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseForwards>>(request);
        }

        /// <summary>
        /// Get the count of the list of optouts for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of optouts objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public int GetMailingOptoutsCount(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/optouts";
            request.AddUrlSegment("mailingId", mailingId);
            request.AddParameter("count", "true");

            return Execute<int>(request);
        }

        /// <summary>
        /// Get the list of optouts for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of optouts objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseGeneric> GetMailingOptouts(string mailingId, int start = -1, int end = -1)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/optouts";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseGeneric>>(request, start, end);
        }

        /// <summary>
        /// Get the list of signups for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of signups objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseSignups> GetMailingSignups(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/signups";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseSignups>>(request);
        }

        /// <summary>
        /// Get the list of shares for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of signups objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseShares> GetMailingShares(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/shares";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseShares>>(request);
        }

        /// <summary>
        /// Get the list of customer shares for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of customer shares objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseCustomerShare> GetMailingCustomerShares(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/customer_shares";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseCustomerShare>>(request);
        }

        /// <summary>
        /// Get the list of customer share clicks for this mailing.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of customer share click objects for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public List<ResponseCustomerShareClicks> GetMailingCustomerShareClicks(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/customer_share_clicks";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseCustomerShareClicks>>(request);
        }

        /// <summary>
        /// Get the customer share associated with the share id.
        /// </summary>
        /// <param name="shareId">Share Identifier</param>
        /// <returns>A customer share for the mailing.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid mailing type - ‘m’ for standard mailings, ‘t’ for test mailings and ‘r’ for trigger mailings.</remarks>
        public ResponseCustomerShare GetMailingCustomerShare(string shareId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{shareId}/customer_share";
            request.AddUrlSegment("shareId", shareId);

            return Execute<ResponseCustomerShare>(request);
        }

        /// <summary>
        /// Get overview of shares pertaining to this mailing_id.
        /// </summary>
        /// <param name="mailingId">Mailing Identifier</param>
        /// <returns>An array of share summary objects for the mailing, by network.</returns>
        /// <remarks>Http404 if the mailing does not exist. Http404 if the mailing is not valid.</remarks>
        public List<ResponseSharesOverview> GetMailingSharesOverview(string mailingId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/response/{mailingId}/shares/overview";
            request.AddUrlSegment("mailingId", mailingId);

            return Execute<List<ResponseSharesOverview>>(request);
        }

        #endregion
    }
}
