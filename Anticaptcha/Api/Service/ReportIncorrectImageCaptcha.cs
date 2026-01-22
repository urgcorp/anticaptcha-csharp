using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Newtonsoft.Json;

namespace Anticaptcha.Api.Service
{
    /// <summary>
    /// <para>Жалобы на капчи-изображения.</para>
    /// <para>Жалоба будет проверена 3-мя модераторами, двое из них должны ее подтвердить. Только после этого вы получаете полный возврат.
    /// Если ваши жалобы подтверждаются менее чем в 50% случаев, то ваши последующие отчеты будут проигнорированы.Отчеты должны быть присланы в течение 60 секунд после завершения задачи.</para>
    /// <para>Жалобы принимаются только на капчи на английском языке.</para>
    /// </summary>
    public class ReportIncorrectImageCaptcha : ApiRequestAbstract<ReportCaptchaResponse>
    {
        public override string Method => "reportIncorrectImageCaptcha";

        /// <summary>
        /// Идентификатор, который был получен в методе 'createTask'
        /// </summary>
        [JsonProperty("taskId")]
        public long taskId { get; set; }
    }
}