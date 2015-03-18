using RestSharp.Deserializers;

namespace EmmaSharp.Models.Response
{
    public class ResponseSummary
    {
        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "month")]
        public int Month { get; set; }

        [DeserializeAs(Name = "year")]
        public int Year { get; set; }

        [DeserializeAs(Name = "mailings")]
        public int Mailings { get; set; }

        [DeserializeAs(Name = "sent")]
        public int Sent { get; set; }

        [DeserializeAs(Name = "delivered")]
        public int Delivered { get; set; }

        [DeserializeAs(Name = "bounced")]
        public int Bounced { get; set; }

        [DeserializeAs(Name = "opened")]
        public int Opened { get; set; }

        [DeserializeAs(Name = "clicked_unique")]
        public int ClickedUnique { get; set; }

        [DeserializeAs(Name = "clicked")]
        public int Clicked { get; set; }

        [DeserializeAs(Name = "forwarded")]
        public int Forwarded { get; set; }

        [DeserializeAs(Name = "shared")]
        public int Shared { get; set; }

        [DeserializeAs(Name = "share_clicked")]
        public int ShareClicked { get; set; }

        [DeserializeAs(Name = "webview_shared")]
        public int WebviewShared { get; set; }

        [DeserializeAs(Name = "webview_share_clicked")]
        public int WebviewShareClicked { get; set; }

        [DeserializeAs(Name = "opted_out")]
        public int OptedOut { get; set; }

        [DeserializeAs(Name = "signed_up")]
        public int SignedUp { get; set; }

        [DeserializeAs(Name = "count_purchased")]
        public int CountPurchased { get; set; }

        [DeserializeAs(Name = "sum_purchased")]
        public int SumPurchased { get; set; }
    }
}
