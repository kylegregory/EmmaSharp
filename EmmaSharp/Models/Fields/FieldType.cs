using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
    public sealed class FieldType {
        private readonly string name;

        public static readonly FieldType text = new FieldType("text");
        public static readonly FieldType textArray = new FieldType("text[]");
        public static readonly FieldType numeric = new FieldType("numeric");
        public static readonly FieldType boolean = new FieldType("boolean");
        public static readonly FieldType date = new FieldType("date");
        public static readonly FieldType timestamp = new FieldType("timestamp");

        private FieldType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
