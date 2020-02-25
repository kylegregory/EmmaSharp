using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace EmmaSharp.Models.Fields
{
    public class BaseField
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("field_type")]
        public FieldType FieldType { get; set; }

        [JsonProperty("widget_type")]
        public WidgetType WidgetType { get; set; }

        [JsonProperty("column_order")]
        public int? ColumnOrder { get; set; }
    }
    public class Field : BaseField
    {
        [JsonProperty("shortcut_name")]
        public string ShortcutName { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("field_id")]
        public long? FieldId { get; set; }

        [JsonProperty("short_display_name")]
        public string ShortDisplayName { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("options")]
        public string[] Options { get; set; }
    }

    public class CreateField : BaseField
    {
        [JsonProperty("shortcut_name")]
        public string ShortcutName { get; set; }

        public CreateField()
        {
            ShortcutName = ShortcutName;
            DisplayName = DisplayName;
            FieldType = FieldType.Text;
            WidgetType = WidgetType.Text;
            ColumnOrder = 0;
        }
    }

    public class UpdateField : BaseField
    {
        public UpdateField()
        {
            DisplayName = DisplayName;
            FieldType = FieldType.Text;
            WidgetType = WidgetType.Text;
            ColumnOrder = 0;
        }
    }
}
