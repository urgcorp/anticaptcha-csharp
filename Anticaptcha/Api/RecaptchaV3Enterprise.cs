using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>RecaptchaV3 Enterprise не имеет отличия от RecaptchaV3.</para>
    /// <para>У этого класс выставлен параметр <see cref="IsEnterprise"/> в true</para>
    /// </summary>
    public class RecaptchaV3Enterprise : RecaptchaV3
    {
        public RecaptchaV3Enterprise()
        {
            base.IsEnterprise = true;
        }

        /// <summary>
        /// <example><code>grecaptcha.enterprise.execute('site_key', {..})</code></example>
        /// </summary>
        [JsonProperty("isEnterprise")]
        public new bool IsEnterprise => base.IsEnterprise.Value;
    }
}