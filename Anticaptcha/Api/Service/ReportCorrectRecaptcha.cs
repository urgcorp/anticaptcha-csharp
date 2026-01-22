using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Newtonsoft.Json;

namespace Anticaptcha.Api.Service
{
    /// <summary>
    /// <para>Используйте этот метод вместе с <see cref="ReportIncorrectRecaptcha"/> для ваших задач Recaptcha V3 и Recaptcha V2 Enterprise</para>
    /// <para>Отчеты должны быть присланы в течение 60 секунд после завершения задачи. Разрешается присылать только одну жалобу на каждую задачу.</para>
    /// </summary>
    public class ReportCorrectRecaptcha : ApiRequestAbstract<ReportCaptchaResponse>
    {
        public override string Method => "reportCorrectRecaptcha";

        /// <summary>
        /// Идентификатор, который был получен в методе <see cref="CreateTask"/>
        /// </summary>
        [JsonProperty("taskId")]
        public long TaskId { get; set; }
    }
}