using EmmaSharp.Extensions;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;

namespace EmmaSharp.Models.Fields
{
    public class Field
    {
        [JsonProperty("shortcut_name")]
        public string ShortcutName { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("field_type")]
        public FieldType FieldType { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("field_id")]
        public int? FieldId { get; set; }

        [JsonProperty("widget_type")]
        public WidgetType WidgetType { get; set; }

        [JsonProperty("short_display_name")]
        public string ShortDisplayName { get; set; }

        [JsonProperty("column_order")]
        public int? ColumnOrder { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("options")]
        public string[] Options { get; set; }
    }
}
