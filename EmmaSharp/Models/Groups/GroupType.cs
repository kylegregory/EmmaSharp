using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
    public sealed class GroupType {
        private readonly string name;

        public static readonly GroupType group = new GroupType("g");
        public static readonly GroupType test = new GroupType("t");
        public static readonly GroupType hidden = new GroupType("h");
        public static readonly GroupType all = new GroupType("a");

        private GroupType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
