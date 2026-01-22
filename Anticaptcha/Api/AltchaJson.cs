using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    ///  Вариант решения Altcha капчи с использованием JSON с challenge URL виджета капчи
    /// </summary>
    public class AltchaJson : AltchaAbstract
    {
        /// <summary>
        /// <para>Вариант 2</para>
        /// <para>Challenge JSON полученный с challenge URL виджета капчи</para>
        /// <example><code>
        /// {
        ///     "algorithm":"SHA-256",
        ///     "challenge":"1a40f7ba3393f9513016879de41c7221f14e563856de2f647233a00accf9c28b",
        ///     "salt":"0887f273d79df143355b9e5f",
        ///     "signature":"1de2bbf282420aef6ca0a84c38c85e2b1e40023d28bef72278d735555a8f47fb"
        /// }
        /// </code></example>
        /// </summary>
        [JsonProperty("challengeJSON")]
        public string ChallengeJson { get; protected set; }
    }
}