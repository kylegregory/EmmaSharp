using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
    public sealed class MailingStatus {
        private readonly string name;

        public static readonly MailingStatus Pending = new MailingStatus("p");
        public static readonly MailingStatus Paused = new MailingStatus("a");
        public static readonly MailingStatus Sending = new MailingStatus("s");
        public static readonly MailingStatus Canceled = new MailingStatus("x");
        public static readonly MailingStatus Complete = new MailingStatus("c");
        public static readonly MailingStatus Failed = new MailingStatus("f");

        private MailingStatus(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
