using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Этот тип задачи решает Google Recaptcha V2.</para>
    /// <para>Задача будет выполнена используя прокси сервера Anticaptcha или адреса IP работников.</para>
    /// <para>В данный момент рекапча не защищена от ситуаций, когда рекапча решена с одного IP-адреса,
    /// а форма с g-response отправлена с другого IP.
    /// Google API не предоставляет – IP-адрес человека, решившего их рекапчу.</para>
    /// </summary>
    public class RecaptchaV2 : ApiTaskRequestAbstract<RecaptchaV2.RecaptchaV2Solution>
    {
        public class RecaptchaV2Solution
        {
            /// <summary>
            /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
            /// <example>3AHJ_VuvYIBNBW5yyv0zRYJ75VkOKvhKj9_xGBJKnQimF72rfoq3Iy-DyGHMwLAo6a3</example>
            /// </summary>
            [JsonProperty("gRecaptchaResponse")]
            public string GCaptchaResponse { get; set; }

            /// <summary>
            /// <para>Опциональный массив cookies, который был использован для решения рекапчи.</para>
            /// <para>Применимо только к доменам google.com и под-доменам.</para>
            /// </summary>
            [JsonProperty("cookies")]
            public string? Cookies { get; set; }
        }

        public override string Type => "RecaptchaV2TaskProxyless";

        public override string ProxyType => "RecaptchaV2Task";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Наши работники не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
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
        /// <para>Значение параметра 'data-s'.</para>
        /// <para>Применимо только к рекапче на страницах Google.</para>
        /// </summary>
        [JsonProperty("recaptchaDataSValue")]
        public string? DataSValue { get; set; }

        /// <summary>
        /// <para>Укажите, если рекапча невидимая.</para>
        /// <para>Это отобразит правильный виджет рекапчи у наших работников.</para>
        /// </summary>
        [JsonProperty("isInvisible")]
        public bool? IsInvisible { get; set; }
    }
}