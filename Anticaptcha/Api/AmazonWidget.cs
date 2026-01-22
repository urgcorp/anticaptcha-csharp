using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Автономный виджет капчи, который запускается действием пользователя.</para>
    /// <para>Используйте этот тип задач, чтобы получить токен Amazon WAF Captcha.</para>
    /// <para></para>
    /// </summary>
    public class AmazonWidget : AmazonAbstract
    {
        /// <summary>
        /// <para>Возьмите этот ключ из функции <c>Awswafcaptcha.rendercaptcha</c>.</para>
        /// <example><code>
        /// AwsWafCaptcha.renderCaptcha = function(obj, params) { console.log('CAPTCHA API KEY:', params.apiKey); }
        /// </code></example>
        /// </summary>
        public override string WebsiteKey { get; set; }

        /// <summary>
        /// Держите это равным <c>widget</c>, так API будет знать, что показывать нашим работникам.
        /// </summary>
        [JsonProperty("wafType")]
        public string WafType { get; protected set; } = "widget";

        /// <summary>
        /// <para>Полный URL <c>jsapi.js</c></para>
        /// <para>Чтобы получить URL <c>jsapi.js</c> просто найдите его на вкладке «Сеть» в консоли разработчиков.</para>
        /// <example>https://164cb210e333.edge.captcha-sdk.awswaf.com/164cb210e333/jsapi.js</example>
        /// </summary>
        [JsonProperty("jsapiScript")]
        public string JSApiScript { get; set; }
    }
}