using RestSharp.Deserializers;
using System.Collections.Generic;

namespace EmmaSharp.Models.Response
{
    public class Response
    {
        [DeserializeAs(Name = "delivered")]
        public int Delivered { get; set; }

        [DeserializeAs(Name = "signed_up")]
        public int SignedUp { get; set; }

        [DeserializeAs(Name = "clicked")]
        public int Clicked { get; set; }

        [DeserializeAs(Name = "forwarded")]
        public int Forwarded { get; set; }

        [DeserializeAs(Name = "clicked_unique")]
        public int ClickedUnique { get; set; }

        [DeserializeAs(Name = "webview_share_clicked")]
        public int WebviewShareClicked { get; set; }

        [DeserializeAs(Name = "subject")]
        public string Subject { get; set; }

        [DeserializeAs(Name = "opened")]
        public int Opened { get; set; }

        [DeserializeAs(Name = "opted_out")]
        public int OptedOut { get; set; }

        [DeserializeAs(Name = "share_clicked")]
        public int ShareClicked { get; set; }

        [DeserializeAs(Name = "shred")]
        public int Shared { get; set; }

        [DeserializeAs(Name = "webview_shared")]
        public int WebviewShared { get; set; }

        [DeserializeAs(Name = "in_progress")]
        public int InProgress { get; set; }

        [DeserializeAs(Name = "bounced")]
        public int Bounced { get; set; }

        [DeserializeAs(Name = "recipient_count")]
        public int RecipientCount { get; set; }

        [DeserializeAs(Name = "sent")]
        public int Sent { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "count_purchased")]
        public int CountPurchased { get; set; }

        [DeserializeAs(Name = "sum_purchased")]
        public int SumPurchased { get; set; }

        //[DeserializeAs(Name = "purchase_metrics")]
        //public List<T> PurchaseMetrics { get; set; }
    }
}
