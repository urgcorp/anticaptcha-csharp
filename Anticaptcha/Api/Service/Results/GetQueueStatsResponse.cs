using Newtonsoft.Json;

namespace Anticaptcha.Api.Service.Results
{
    public class GetQueueStatsResponse
    {
        /// <summary>
        /// Количество работников на линии, ожидающих новую задачу
        /// </summary>
        [JsonProperty("waiting")]
        public int Waiting { get; set; }

        /// <summary>
        /// Загрузка очереди в процентах
        /// </summary>
        [JsonProperty("load")]
        public double Load { get; set; }

        /// <summary>
        /// Средняя стоимость решения задачи в USD
        /// </summary>
        [JsonProperty("bid")]
        public double BidUSD { get; set; }

        /// <summary>
        /// Средняя скорость решения задачи в секундах
        /// </summary>
        [JsonProperty("speed")]
        public double SpeedSeconds { get; set; }

        /// <summary>
        /// Общее количество работников
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}