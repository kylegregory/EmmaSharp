using EmmaSharp.Models.Automation;
using RestSharp;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace EmmaSharp
{
    public partial class EmmaApi
    {
        #region Automation

        /// <summary>
        /// Gets a list of this account’s automation workflows.
        /// </summary>
        /// <returns>A list of automation workflows in the given account.</returns>
        public List<Workflow> GetWorkflows()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/automation/workflows";

            return Execute<List<Workflow>>(request);
        }

        /// <summary>
        /// Gets detailed information about a single workflow.
        /// </summary>
        /// <param name="workflowId">The ID of the Workflow to return.</param>
        /// <returns>A single workflow if one exists</returns>
        public Workflow GetWorkflowById(string workflowId)
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/automation/workflows/{workflowId}";
            request.AddUrlSegment("workflowId", workflowId);

            return Execute<Workflow>(request);
        }

        /// <summary>
        /// Gets the counts of workflows for this account by workflow state.
        /// </summary>
        /// <returns>Returns counts for the workflow by state ("active", "inactive" and "draft").</returns>
        public WorkflowCount GetWorkflowCounts()
        {
            var request = new RestRequest();
            request.Resource = "/{accountId}/automation/counts";

            return Execute<WorkflowCount>(request);
        }

        #endregion
    }
}
