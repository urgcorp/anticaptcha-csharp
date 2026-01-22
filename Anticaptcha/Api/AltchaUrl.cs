using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    ///  Вариант решения Altcha капчи с использованием Challange URL
    /// </summary>
    public class AltchaUrl : AltchaAbstract
    {
        /// <summary>
        /// <para>Challenge URL из altcha-widget</para>
        /// <example>
        /// <code>&lt;altcha-widget challengeurl="/this/one"&gt;&lt;/altcha-widget&gt;</code>
        /// </example>
        /// </summary>
        [JsonProperty("challengeURL")]
        public string ChallengeUrl { get; protected set; }
    }
}