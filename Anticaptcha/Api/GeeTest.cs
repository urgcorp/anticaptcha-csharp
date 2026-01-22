using System.Collections.Generic;
using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    public class GeeTestV3 : GeeTestAbstract<GeeTestV3.GeeTestV3Solution>
    {
        public class GeeTestV3Solution
        {
            /// <summary>
            /// Строка-хэш, требуется для взаимодействия с формой на целевом сайте.
            /// </summary>
            [JsonProperty("challenge")]
            public string Challenge { get; set; }

            /// <summary>
            /// Строка-хэш, тоже требуется.
            /// </summary>
            [JsonProperty("validate")]
            public string Validate { get; set; }

            /// <summary>
            /// Еще одна строка, мы без понятия зачем их 3 штуки.
            /// </summary>
            [JsonProperty("seccode")]
            public string Seccode { get; set; }
        }

        protected override int? _version { get; set; } = 3;
    }

    public class GeeTestV4 : GeeTestAbstract<GeeTestV4.GeeTestV4Solution>
    {
        public class GeeTestV4Solution
        {
            [JsonProperty("captcha_id")]
            public string CaptchaId { get; set; }

            [JsonProperty("lot_number")]
            public string LotNumber { get; set; }

            [JsonProperty("pass_token")]
            public string PassToken { get; set; }

            [JsonProperty("gen_time")]
            public int GenTime { get; set; }

            [JsonProperty("captcha_output")]
            public string Output { get; set; }
        }

        protected override int? _version { get; set; } = 4;

        /// <summary>
        /// <para>Дополнительные параметры инициализации для версии 4</para>
        /// <example>{"riskType": "slide"}</example>
        /// </summary>
        public Dictionary<string, string> InitParameters { get; } = new Dictionary<string, string>();
    }
}