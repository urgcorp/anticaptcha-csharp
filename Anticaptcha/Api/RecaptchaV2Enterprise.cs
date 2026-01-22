using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Этот тип задач создан для решения Google Recaptcha Enterprise V2 с IP-адреса работника.</para>
    /// <para>Похож на <see cref="RecaptchaV2"/>, но задачи решаются с использованием Enterprise API и назначаются работникам с лучшим score Recaptcha V3</para>
    /// </summary>
    public class RecaptchaV2Enterprise : ApiTaskRequestAbstract<RecaptchaV2.RecaptchaV2Solution>
    {
        public override string Type => "RecaptchaV2EnterpriseTaskProxyless";

        public override string ProxyType => "RecaptchaV2EnterpriseTask";

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
        /// <para>Дополнительные параметры, которые могут быть переданы в метод "grecaptcha.enterprise.render" вместе с sitekey.</para>
        /// <para>В примере вы можете заметить параметр "s", который не задокументирован, но очевидно требуется.
        /// Отправьте его в API, чтобы мы могли корректно отобразить виджет рекапчи с этим параметром.</para>
        /// <example><code>
        /// grecaptcha.enterprise.render("some-div-id", {
        ///     sitekey: "6Lc_aCMTAAAAABx7u2N0D1XnVbI_v6ZdbM6rYf16",
        ///     theme: "dark",
        ///     s: "2JvUXHNTnZl1Jb6WEvbDyBMzrMTR7oQ78QRhBcG07rk9bpaAaE0LRq1ZeP5NYa0N...ugQA"
        /// });
        /// </code></example>
        /// </summary>
        [JsonProperty("enterprisePayload")]
        public string? Payload { get; set; }

        /// <summary>
        /// <para>Используйте этот параметр, чтобы прислать доменное имя, с которого мы должны загружать скрипты рекапчи.</para>
        /// <para>Может иметь только одно из этих двух значений: "www.google.com" или "www.recaptcha.net".</para>
        /// <para>Не используйте этот параметр, если не понимаете зачем он нужен.</para>
        /// </summary>
        [JsonProperty("apiDomain")]
        public string? ApiDomain { get; set; }
    }
}