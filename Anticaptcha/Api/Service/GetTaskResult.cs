using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api.Service
{
    public class GetTaskResult<TSolution> : ApiRequestAbstract<TaskResponse<TSolution>>
        where TSolution : class
    {
        public override string Method => "getTaskResult";

        /// <summary>
        /// Идентификатор, который был получен в методе <see cref="CreateTask"/>
        /// </summary>
        [JsonProperty("taskId")]
        public long TaskId { get; set; }

        public GetTaskResult(long taskId)
        {
            TaskId = taskId;
        }
    }

    public class GetTaskResult : GetTaskResult<JObject>
    {
        public GetTaskResult(long taskId) : base(taskId)
        { }
    }
}