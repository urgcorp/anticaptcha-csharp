using System.Diagnostics;
using Anticaptcha.Api.Results;
using Newtonsoft.Json;

namespace Anticaptcha.Api.Abstractions
{
    /// <summary>
    /// Базовый тип для методов создания задач решения капчи 
    /// </summary>
    [DebuggerDisplay("{Type}")]
    public abstract class ApiTaskRequestAbstract<TSolution> : ApiRequestAbstract<TaskResponse<TSolution>>, IApiTaskRequest
        where TSolution : class
    {
        public override string Method => "createTask";

        /// <summary>
        /// Тип капчи для <see cref="Method"/> = "createTask"
        /// </summary>
        [JsonIgnore]
        public abstract string Type { get; }

        /// <summary>
        /// Тип капчи для прокси
        /// </summary>
        [JsonIgnore]
        public virtual string? ProxyType => null;

        /// <summary>
        /// Поддерживается ли прокси этим методом
        /// </summary>
        [JsonIgnore]
        public bool IsProxySupported => ProxyType != null;
    }
}