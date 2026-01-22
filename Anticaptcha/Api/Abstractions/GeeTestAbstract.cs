using Newtonsoft.Json;

namespace Anticaptcha.Api.Abstractions
{
    /// <summary>
    /// <para>Этот тип задач решает капчу GeeTest в браузере работников AntiCaptcha.</para>
    /// </summary>
    public abstract class GeeTestAbstract<TSolution> : ApiTaskRequestAbstract<TSolution>
        where TSolution : class
    {
        public override string Type => "GeeTestTaskProxyless";

        public override string ProxyType => "GeeTestTask";

        protected abstract int? _version { get; set; }

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Публичный ключ домена, редко обновляется.
        /// </summary>
        [JsonProperty("gt")]
        public string GT { get; set; }

        /// <summary>
        /// <para>Меняющийся ключ.</para>
        /// <para>Убедитесь, что получаете каждый раз новый ключ для каждой капчи, иначе вы будете платить за каждую капчу с ошибкой.</para>
        /// <para>Требуется для версии 3. Не требуется для версии 4</para>
        /// </summary>
        [JsonProperty("challenge")]
        public string? Challenge { get; set; }

        /// <summary>
        /// <para>Опциональный поддомен API.</para>
        /// <para>Может потребоваться для некоторых имплементаций.</para>
        /// </summary>
        [JsonProperty("geetestApiServerSubdomain")]
        public string? ApiServerSubdomain { get; set; }

        /// <summary>
        /// <para>Номер версии.</para>
        /// <para>Default - 3</para>
        /// </summary>
        [JsonProperty("version")]
        public int? Version => _version;
    }
}