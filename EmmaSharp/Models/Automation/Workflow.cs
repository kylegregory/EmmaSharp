using EmmaSharp.Extensions;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace EmmaSharp.Models.Automation
{
    public class Workflow
    {
        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public WorkflowStatus Status { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonConverter(typeof(EmmaDateConverter))]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public enum WorkflowStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "inactive")]
        Inactive,
        [EnumMember(Value = "draft")]
        Draft,
        Unknown
    }

    public class WorkflowCount
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("draft")]
        public int Draft { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("inactive")]
        public int Inactive { get; set; }
    }
}

