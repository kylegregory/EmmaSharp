using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
	public sealed class PersonalizationType {
        private readonly string name;

		public static readonly PersonalizationType All = new PersonalizationType("all");
		public static readonly PersonalizationType Html = new PersonalizationType("html");
		public static readonly PersonalizationType PlainText = new PersonalizationType("plaintext");
		public static readonly PersonalizationType Subject = new PersonalizationType("subject");

		private PersonalizationType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
