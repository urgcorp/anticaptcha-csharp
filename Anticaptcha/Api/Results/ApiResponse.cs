using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api.Results
{
    /// <summary>
    /// Базовый ответ от Anticaptcha
    /// </summary>
    public class ApiResponse
    {
        [JsonProperty("errorId")]
        public int? ErrorId { get; set; }

        [JsonProperty("errorCode")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Короткое описание ошибки
        /// </summary>
        [JsonProperty("errorDescription")]
        public string? ErrorDescription { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> UndefinedData { get; } = null!;
    }
}