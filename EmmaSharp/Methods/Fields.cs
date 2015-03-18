using Syste;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace EmmaSharp
{
	public partial class EmmaApi
	{
    public AllFields ListFields (bool? deleted) {
      var request = new RestRequest();
			request.Resource = "/{accountId}/fields";

      if (deleted != null)
        request.AddParameter("deleted", deleted, ParameterType.UrlSegment);

			return Execute<AllFields>(request);
    };

    public Field GetField (int fieldId, bool? deleted) {
      var request = new RestRequest();
			request.Resource = "/{accountId}/fields/{fieldId}";
      request.AddUrlSegment("fieldId", fieldId);

      if (deleted != null)
        request.AddParameter("deleted", deleted, ParameterType.UrlSegment);

			return Execute<Field>(request);
    };

    public Field CreateField (string shortcutName, string displayName, string fieldType, WidgetType widgetType, int columnOrder) {
      var request = new RestRequest(Method.POST);
			request.Resource = "/{accountId}/fields";
      request.AddParameter("shortcut_name", from);
      request.AddParameter("display_name", to);
      request.AddParameter("field_type", to);
      request.AddParameter("widget_type", to);
      request.AddParameter("column_order", to);

			return Execute<Field>(request);
    }

    public bool DeleteField (int fieldId) {
      var request = new RestRequest(Method.DELETE);
      request.Resource = "/{accountId}/fields/{fieldId}";
      request.AddUrlSegment("fieldId", fieldId);

      return Execute<bool>(request);
    };

    public bool ClearField (int fieldId) {
      var request = new RestRequest(Method.POST);
      request.Resource = "/{accountId}/fields/{fieldId}/clear";
      request.AddUrlSegment("fieldId", fieldId);

      return Execute<bool>(request);
    };

    public bool UpdateField (int fieldId) {
      var request = new RestRequest(Method.PUT);
      request.Resource = "/{accountId}/fields/{fieldId}";
      request.AddUrlSegment("fieldId", fieldId);

      return Execute<bool>(request);
    };
  }
}
