using Newtonsoft.Json;

namespace Anticaptcha.Api.Service.Results
{
    public class CreateTaskResponse : Api.Results.ApiResponse
    {
        /// <summary>
        /// Идентификатор задачи, который вы должны использовать в методе <see cref="GetTaskResult"/>
        /// </summary>
        [JsonProperty("taskId")]
        public long TaskId { get; set; }
    }
}