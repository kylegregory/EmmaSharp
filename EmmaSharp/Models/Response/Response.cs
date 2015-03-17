using Newtonsoft.Json;

namespace EmmaSharp.Models.Response
{
    class Response
    {
        [JsonProperty("delivered")]
        public int Delivered { get; set; }

        [JsonProperty("signed_up")]
        public int SignedUp { get; set; }

        [JsonProperty("clicked")]
        public int Clicked { get; set; }

        [JsonProperty("forwarded")]
        public int Forwarded { get; set; }

        [JsonProperty("clicked_unique")]
        public int ClickedUnique { get; set; }

        [JsonProperty("webview_share_clicked")]
        public int WebviewShareClicked { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("opened")]
        public int Opened { get; set; }

        [JsonProperty("opted_out")]
        public int OptedOut { get; set; }

        [JsonProperty("share_clicked")]
        public int ShareClicked { get; set; }

        [JsonProperty("shred")]
        public int Shared { get; set; }

        [JsonProperty("webview_shared")]
        public int WebviewShared { get; set; }

        [JsonProperty("in_progress")]
        public int InProgress { get; set; }

        [JsonProperty("bounced")]
        public int Bounced { get; set; }

        [JsonProperty("recipient_count")]
        public int RecipientCount { get; set; }

        [JsonProperty("sent")]
        public int Sent { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count_purchased")]
        public int CountPurchased { get; set; }

        [JsonProperty("sum_purchased")]
        public int SumPurchased { get; set; }
    }
}
