using RestSharp.Deserializers;
using System;

namespace EmmaSharp.Models
{
    public class Field
    {
        [DeserializeAs(Name = "shortcut_name")]
        public string ShortcutName { get; set; }

        [DeserializeAs(Name = "display_name")]
        public string DisplayName { get; set; }

        [DeserializeAs(Name = "account_id")]
        public int AccountId { get; set; }

        [DeserializeAs(Name = "field_type")]
        public FieldType FieldType { get; set; }

        [DeserializeAs(Name = "required")]
        public bool Required { get; set; }

        [DeserializeAs(Name = "field_id")]
        public int FieldId { get; set; }

        [DeserializeAs(Name = "widget_type")]
        public WidgetType WidgetType { get; set; }

        [DeserializeAs(Name = "short_display_name")]
        public string ShortDisplayName { get; set; }

        [DeserializeAs(Name = "shortcut_name")]
        public int ColumnOrder { get; set; }

        [DeserializeAs(Name = "shortcut_name")]
        public DateTime DeletedAt { get; set; }

        [DeserializeAs(Name = "shortcut_name")]
        public string Options { get; set; }
    }
}
