using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Капча Turnstile от Cloudflare – это очередная попытка заменить рекапчу.</para>
    /// <para>Поддерживает все ее подтипы автоматически: manual, non-interactive и invisible</para>
    /// <para>Не нужно предоставлять кастомный User-Agent браузера, так как это может помешать решить капчу.</para>
    /// </summary>
    public class Turnstile : ApiTaskRequestAbstract<Turnstile.TurnstileSolution>
    {
        public class TurnstileSolution
        {
            /// <summary>
            /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
            /// <example>0.vtJqmZnvobaUzK2i2PyKaSqHELYtBZfRoPwMvLMdA81WL_9G0vCO3y2VQVIeVplG0mxYF7uX.......</example>
            /// </summary>
            [JsonProperty("token")]
            public string Token { get; set; }

            /// <summary>
            /// <para>User-Agent браузера работника.</para>
            /// <para>Используйте его, когда отправляете форму с токеном.</para>
            /// <example>Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:102.0) Gecko/20100101 Firefox/102.0</example>
            /// </summary>
            [JsonProperty("userAgent")]
            public string UserAgent { get; set; }
        }

        public override string Type => "TurnstileTaskProxyless";

        public override string ProxyType => "TurnstileTask";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.</para>
        /// <para>Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Ключ Turnstile
        /// </summary>
        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Опциональное значение параметра "action".
        /// </summary>
        [JsonProperty("action")]
        public string? Action { get; set; }

        /// <summary>
        /// <para>Опциональный токен "cData" для Cloudflare.</para>
        /// <para>https://anti-captcha.com/ru/apidoc/articles/how-to-bypass-cloudflare</para>
        /// </summary>
        [JsonProperty("cData")]
        public string? CData { get; set; }

        /// <summary>
        /// <para>Опциональный токен "chlPageData" для Cloudflare</para>
        /// </summary>
        [JsonProperty("chlPageData")]
        public string? CHLPageData { get; set; }
    }
}