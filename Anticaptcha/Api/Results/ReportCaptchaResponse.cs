using Newtonsoft.Json;

namespace Anticaptcha.Api.Results
{
    public class ReportCaptchaResponse : ApiResponse
    {
        /// <summary>
        /// <para>Результат операции.</para>
        /// <para>Вы получаете либо ошибку, либо status="success", когда жалоба принята.</para>
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}