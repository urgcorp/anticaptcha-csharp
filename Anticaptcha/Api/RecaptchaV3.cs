using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Этот тип задач решает Google Recaptcha V3.</para>
    /// <para>Задача будет выполнена используя прокси сервера AntiCaptcha или IP адреса работников.</para>
    /// <para>Обратите внимание, что есть разница между невидимой рекапчей V2 и рекапчей V3.
    /// Они выглядят одинаково и их легко спутать.
    /// Есть быстрый способ определить правильный тип – попробуйте решить их через наше API, как V2-invisible и V3.
    /// В одной из попыток вы получите ошибку, в другой нет.</para>
    /// </summary>
    public class RecaptchaV3 : ApiTaskRequestAbstract<RecaptchaV3.RecaptchaV3Solution>
    {
        public class RecaptchaV3Solution
        {
            /// <summary>
            /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
            /// <example>3AHJ_VuvYIBNBW5yyv0zRYJ75VkOKvhKj9_xGBJKnQimF72rfoq3Iy-DyGHMwLAo6a3</example>
            /// </summary>
            [JsonProperty("gRecaptchaResponse")]
            public string GCaptchaResponse { get; set; }
        }

        public override string Type => "RecaptchaV3TaskProxyless";

        public override string ProxyType => "RecaptchaV3Task";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// <para>Ключ рекапчи.</para>
        /// <para>https://anti-captcha.com/ru/apidoc/articles/how-to-find-the-sitekey</para>
        /// </summary>
        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// <para>Фильтрует работников с требуемым score.</para>
        /// <para>Значение может быть 0.3, 0.7, 0.9</para>
        /// </summary>
        [JsonProperty("minScore")]
        public double MinScore { get; set; } = 0.3d;

        /// <summary>
        /// <para>Значения "action" рекапчи.</para>
        /// <para>Владелец страницы задает действие пользователя на странице через этот параметр.</para>
        /// <example>
        /// <code>grecaptcha.execute('site_key', {action:'login_test'})</code>
        /// </example>
        /// </summary>
        [JsonProperty("pageAction")]
        public string? PageAction { get; set; }

        /// <summary>
        /// <para>Установите этот флаг в "true", если вы хотите решить эту рекапчу как Enterprise.</para>
        /// <para>Значение по-умолчанию равно "false" и рекапча будет решена через обычное API.
        /// Может быть определено по вызову javascript, как в примере</para>
        /// <example><code>grecaptcha.enterprise.execute('site_key', {..})</code></example>
        /// </summary>
        [JsonProperty("isEnterprise")]
        public bool? IsEnterprise { get; set; }

        /// <summary>
        /// <para>Используйте этот параметр, чтобы прислать доменное имя, с которого мы должны загружать скрипты рекапчи.</para>
        /// <para>Может иметь только одно из этих двух значений: "www.google.com" или "www.recaptcha.net".</para>
        /// <para>Не используйте этот параметр, если не понимаете зачем он нужен.</para>
        /// </summary>
        [JsonProperty("apiDomain")]
        public string? ApiDomain { get; set; }
    }
}