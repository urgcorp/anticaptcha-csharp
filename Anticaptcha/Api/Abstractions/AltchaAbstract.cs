using Newtonsoft.Json;

namespace Anticaptcha.Api.Abstractions
{
    /// <summary>
    /// <para>Попробуйте решить без прокси прежде чем переходить на задачи с решением с помощью прокси.</para>
    /// </summary>
    public class AltchaSolution
    {
        /// <summary>
        /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
        /// <example>eyJhbGdvcml0aG0iOiJTSEEtMjU2IiwiY2hhbGxlbmdlIjoiZWFiOTE3NjRkM2Y5ZDBjMGU4ZmR.......</example>
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public abstract class AltchaAbstract : ApiTaskRequestAbstract<AltchaSolution>
    {
        public override string Type => "AltchaTaskProxyless";

        public override string ProxyType => "AltchaTask";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }
    }
}