using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Friendly Captcha это еще один клон reCaptcha.</para>
    /// <para>Попробуйте решить без прокси прежде чем переходить на задачи с решением с помощью прокси.</para>
    /// </summary>
    public class FriendlyCaptcha : ApiTaskRequestAbstract<FriendlyCaptcha.FriendlyCaptchaSolution>
    {
        public class FriendlyCaptchaSolution
        {
            /// <summary>
            /// <para>Строка токена, которая требуется для отправки формы на целевом сайте.</para>
            /// <example>sPwOkl_n2Rh5Ah_OXyGMaSI_VGo0UiU3-6W8na0jz6CdLoFe0gEXQtAs_q1B_CObNrZIJTqZXR8IKWFpTwl.......</example>
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

        public override string Type => "FriendlyCaptchaTaskProxyless";

        public override string ProxyType => "FriendlyCaptchaTask";

        /// <summary>
        /// <para>Адрес целевой страницы.</para>
        /// <para>Может находиться в любом месте сайта, в том числе в закрытом для подписчиков разделе.
        /// Работники AntiCaptcha не посещают сайт, а вместо этого эмулируют посещение страницы.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// <para>Ключ Friendly Captcha.</para>
        /// <example>FCMDESUD3M34857N</example>
        /// </summary>
        [JsonProperty("websiteKey")]
        public string WebsiteKey { get; set; }
    }
}