using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    public class ResponseBase
    {
        [JsonProperty("sent")]
        public int? Sent { get; set; }

        [JsonProperty("delivered")]
        public int? Delivered { get; set; }

        [JsonProperty("bounced")]
        public int? Bounced { get; set; }

        [JsonProperty("opened")]
        public int? Opened { get; set; }

        [JsonProperty("clicked")]
        public int? Clicked { get; set; }

        [JsonProperty("clicked_unique")]
        public int? ClickedUnique { get; set; }

        [JsonProperty("forwarded")]
        public int? Forwarded { get; set; }

        [JsonProperty("shared")]
        public int? Shared { get; set; }

        [JsonProperty("share_clicked")]
        public int? ShareClicked { get; set; }

        [JsonProperty("webview_shared")]
        public int? WebviewShared { get; set; }

        [JsonProperty("webview_share_clicked")]
        public int? WebviewShareClicked { get; set; }

        [JsonProperty("signed_up")]
        public int? SignedUp { get; set; }

        [JsonProperty("opted_out")]
        public int? OptedOut { get; set; }

        [JsonProperty("count_purchased")]
        public int? CountPurchased { get; set; }

        [JsonProperty("sum_purchased")]
        public decimal? SumPurchased { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("in_progress")]
        public int? InProgress { get; set; }

        [JsonProperty("recipient_count")]
        public int? RecipientCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("purchase_metrics")]
        //public List<T> PurchaseMetrics { get; set; }
    }

    public class ResponseSummary : ResponseBase
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("mailings")]
        public int? Mailings { get; set; }

    }
}
