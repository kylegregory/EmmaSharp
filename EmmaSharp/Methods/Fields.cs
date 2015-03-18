using EmmaSharp.Models;
using EmmaSharp.Models.Fields;
using RestSharp;

namespace EmmaSharp
{
    public partial class EmmaApi
    {
        public AllFields ListFields(bool? deleted)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/fields";

            if (deleted != null) request.AddParameter("deleted", deleted, ParameterType.UrlSegment);

            return Execute<AllFields>(request);
        }

        public Field GetField(string fieldId, bool? deleted)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            if (deleted != null)
                request.AddParameter("deleted", deleted, ParameterType.UrlSegment);

            return Execute<Field>(request);
        }

        public Field CreateField(string shortcutName, string displayName, string fieldType, WidgetType widgetType, int columnOrder)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/fields";
            request.AddParameter("shortcut_name", shortcutName);
            request.AddParameter("display_name", displayName);
            request.AddParameter("field_type", fieldType);
            request.AddParameter("widget_type", widgetType);
            request.AddParameter("column_order", columnOrder);

            return Execute<Field>(request);
        }

        public bool DeleteField(string fieldId)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            return Execute<bool>(request);
        }

        public bool ClearField(string fieldId)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/{accountId}/fields/{fieldId}/clear";
            request.AddUrlSegment("fieldId", fieldId);

            return Execute<bool>(request);
        }

        public bool UpdateField(string fieldId)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = "/{accountId}/fields/{fieldId}";
            request.AddUrlSegment("fieldId", fieldId);

            return Execute<bool>(request);
        }
    }
}
