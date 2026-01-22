using Newtonsoft.Json;

namespace Anticaptcha.Api.Abstractions
{
    public class AmazonSolution
    {
        /// <summary>
        /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
        /// <example>fe4c2ff3-6ed6-40fa-95c9-4c738a7dad49:FgoAe0ZLBmYBAAAA:LK0S/m1nGbfjDk/9i6tMmiUWGecMfyjvuAx9lY6ZhaBUmjrILEqW00UAsEliykPjwebdzn9J3...</example>
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public abstract class AmazonAbstract : ApiTaskRequestAbstract<AmazonSolution>
    {
        public override string Type => "AmazonTaskProxyless";

        public override string ProxyType => "AmazonTask";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("websiteKey")] // Netwonsof.JsonPropertyAttribute наследуется
        public abstract string WebsiteKey { get; set; }
    }
}