using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
    public sealed class MailingType {
        private readonly string name;

        public static readonly MailingType Standard = new MailingType("m");
        public static readonly MailingType Test = new MailingType("t");
        public static readonly MailingType Trigger = new MailingType("r");
        public static readonly MailingType Spilt = new MailingType("s");

        private MailingType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
