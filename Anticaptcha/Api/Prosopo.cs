using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para><b>Prosopo</b> это еще один клон reCaptcha.</para>
    /// <para>Попробуйте решить без прокси прежде чем переходить на задачи с решением с помощью прокси.</para>
    /// </summary>
    public class Prosopo : ApiTaskRequestAbstract<Prosopo.ProsopoSolution>
    {
        public class ProsopoSolution
        {
            /// <summary>
            /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
            /// <example>0x00017068747470733a2f2f70726f6e6f646531342e70726f736f706f2e696fc03546785967356a41463.......</example>
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

        public override string Type => "ProsopoTaskProxyless";

        public override string ProxyType => "ProsopoTask";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// <para>Ключ капчи Prosopo</para>
        /// <example>5FxMg5jAF3F8d8PrQezDMZh6ZbZd69kDt6FUVb1KaFpSgS2l</example>
        /// </summary>
        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }
    }
}