using RestSharp.Deserializers;

namespace EmmaSharp.Models
{
    public sealed class WidgetType {
        private readonly string name;

        public static readonly WidgetType text = new WidgetType("text");
        public static readonly WidgetType longInt = new WidgetType("long");
        public static readonly WidgetType checkbox = new WidgetType("checkbox");
        public static readonly WidgetType selectMultiple = new WidgetType("select multiple");
        public static readonly WidgetType checkMultiple = new WidgetType("check_multiple"); //Seems like the underscore here is correct
        public static readonly WidgetType radio = new WidgetType("radio");
        public static readonly WidgetType date = new WidgetType("date");
        public static readonly WidgetType selectOne = new WidgetType("select one");
        public static readonly WidgetType number = new WidgetType("number");

        private WidgetType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }    
    }
}
