using Anticaptcha.Api.Results;
using Anticaptcha.Common;

namespace Anticaptcha.Client
{
    public class AnticaptchaApiConfiguration
    {
        public string Host { get; set; } = "https://api.anti-captcha.com";

        /// <summary>
        /// Client API key
        /// </summary>
        public string ClientKey { get; set; }

        /// <summary>
        /// <para>Specify softId to earn 10% commission with your app.</para>
        /// <para>Get your softId at https://anti-captcha.com/clients/tools/devcenter</para>
        /// </summary>
        public int SoftId { get; set; }

        /// <summary>
        /// <para>Опциональный адрес куда мы будем отсылать результат решения капчи или ошибку.</para>
        /// <para>Данные отправляются методом POST. Структура ответа соответствует <see cref="TaskResponse"/></para>
        /// </summary>
        public string? CallbackUrl { get; set; }

        public ProxyConfig? DefaultProxy { get; set; }

        private AnticaptchaSolveSettings _solveSettings = new AnticaptchaSolveSettings();

        public AnticaptchaSolveSettings SolveSettings
        {
            get => _solveSettings;
            set =>  _solveSettings = value ?? new AnticaptchaSolveSettings();
        }
    }
}