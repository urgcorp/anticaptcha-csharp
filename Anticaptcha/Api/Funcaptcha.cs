using Newtonsoft.Json;
using Anticaptcha.Api.Abstractions;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Этот тип задач решает пазлы от arkoselabs.com (Funcaptcha) в браузере работника</para>
    /// <para>Задача будет выполнена используя прокси сервера AntiCaptcha или адреса IP работников.</para>
    /// <para>Arkose Labs API предоставляет информацию владельцу сайта об IP-адресе человека, решившего капчу.
    /// И все же стоит сперва попробовать обойти капчу без прокси</para>
    /// </summary>
    public class Funcaptcha : ApiTaskRequestAbstract<Funcaptcha.FuncaptchaSolution>
    {
        public class FuncaptchaSolution
        {
            /// <summary>
            /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
            /// <example>14160cdbe84b28cd5.8020398501|r=us-east-1|metabgclr=%23ffffff|maintxtclr=%231B1B1B|mainbgclr=%23ffffff|guitextcolor=%23747474|metaiconclr=%23757575|meta=7|pk=B7D8911C-5CC8-A9A3-35B0-554ACEE604DA|at=40|ag=101|cdn_url=https%3A%2F%2Ffuncaptcha.com%2Fcdn%2Ffc|lurl=https%3A%2F%2Faudio-us-east-1.arkoselabs.com|surl=https%3A%2F%2Ffuncaptcha.com</example>
            /// </summary>
            [JsonProperty("token")]
            public string Token { get; set; }
        }

        public override string Type => "FunCaptchaTaskProxyless";

        public override string ProxyType => "FunCaptchaTask";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Наши работники не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Публичный ключ Arkose Labs
        /// </summary>
        [JsonProperty("websitePublicKey")]
        public string WebsitePublicKey { get; set; }

        /// <summary>
        /// <para>Кастомный субдомен фанкапчи, с которого загружается JavaScript виджета.</para>
        /// <para>Ищите в браузере в консоли для разработчиков URL</para>
        /// <example>
        /// <para>https://someservice-api.arkoselabs.com/v2/07070707-2000-0000-1111-888888888888/api.js</para>
        /// <para>
        /// Поддомен - "someservice-api.arkoselabs.com"<br/>
        /// Ключ - "07070707-2000-0000-1111-888888888888
        /// </para>
        /// </example>
        /// </summary>
        [JsonProperty("funcaptchaApiJSSubdomain")]
        public string? ApiJsSubdomain { get; set; }

        /// <summary>
        /// <para>Дополнительный параметр, который может потребоваться имплементацией Arkose Labs.</para>
        /// <para>Используйте это свойство, чтобы присылать значение "blob" как объект, конвертированный в строку.</para>
        /// <example><code>
        /// {"blob":"HERE_COMES_THE_blob_VALUE"}
        /// </code></example>
        /// </summary>
        [JsonProperty("data")]
        public string? DataJson { get; set; }
    }
}