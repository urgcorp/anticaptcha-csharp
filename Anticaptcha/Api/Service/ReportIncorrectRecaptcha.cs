using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Newtonsoft.Json;

namespace Anticaptcha.Api.Service
{
    /// <summary>
    /// <para>Жалобы принимаются только на рекапчу V2 и V3, включая Enterprise Recaptcha</para>
    /// <para>Отчеты должны быть присланы в течение 60 секунд после завершения задачи.
    /// Если вы пришлете отчет позже, API вернет ошибку ERROR_NO_SUCH_CAPCHA_ID.
    /// Разрешается присылать только одну жалобу на каждую задачу.</para>
    /// </summary>
    public class ReportIncorrectRecaptcha : ApiRequestAbstract<ReportCaptchaResponse>
    {
        public override string Method => "reportIncorrectRecaptcha";

        [JsonProperty("taskId")]
        public long TaskId { get; set; }
    }
}