using Newtonsoft.Json;

namespace Anticaptcha.Api.Service.Results
{
    public class GetBalanceResponse : Api.Results.ApiResponse
    {
        /// <summary>
        /// Сумма баланса в USD
        /// </summary>
        [JsonProperty("balance")]
        public double? BalanceUSD { get; set; }

        /// <summary>
        /// <para>Остаток баланса капча кредитов.</para>
        /// <para>Доступен, только когда куплена и активирована подписка.</para>
        /// </summary>
        [JsonProperty("captchaCredits")]
        public int? CaptchaCredits { get; set; }
    }
}