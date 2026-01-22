using System.Diagnostics;
using Anticaptcha.Api.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api.Abstractions
{
    /// <summary>
    /// Базовый тип для всех методов API
    /// </summary>
    [DebuggerDisplay("{Method}")]
    public abstract class ApiRequestAbstract<TResult> where TResult : ApiResponse
    {
        /// <summary>
        /// Метод API
        /// </summary>
        [JsonIgnore]
        public abstract string Method { get; }
    }
}