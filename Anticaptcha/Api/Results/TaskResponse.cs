using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api.Results
{
    /// <summary>
    /// Ответ метода <see cref="IAnticaptchaApi.CreateTaskAsync"/>
    /// </summary>
    /// <typeparam name="TSolution">Класс, который описывает результат решения задачи.</typeparam>
    public class TaskResponse<TSolution> : ApiResponse
        where TSolution : class
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Результат решения задачи. Разный для каждого типа задач
        /// </summary>
        [JsonProperty("solution")]
        public TSolution Solution { get; set; }

        /// <summary>
        /// Стоимость задачи в USD
        /// </summary>
        [JsonProperty("cost")]
        public double CostUSD { get; set; }

        /// <summary>
        /// IP, с которого задача была создана.
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Время создания задачи
        /// </summary>
        [JsonProperty("createTime")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Время завершения задачи
        /// </summary>
        [JsonProperty("endTime")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Количество работников, которые пытались решить вашу задачу.
        /// </summary>
        [JsonProperty("solveCount")]
        public int SolveCount { get; set; }
    }

    public class TaskResponse : TaskResponse<JObject>
    { }
}