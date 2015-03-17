using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models
{
    class Field
    {
        [JsonProperty("shortcut_name")]
        public string ShortcutName { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("field_id")]
        public int FieldId { get; set; }

        [JsonProperty("widget_type")]
        public string WidgetType { get; set; }

        [JsonProperty("short_display_name")]
        public string ShortDisplayName { get; set; }

        [JsonProperty("shortcut_name")]
        public int ColumnOrder { get; set; }

        [JsonProperty("shortcut_name")]
        public DateTime DeletedAt { get; set; }

        [JsonProperty("shortcut_name")]
        public string Options { get; set; }
    }
}
