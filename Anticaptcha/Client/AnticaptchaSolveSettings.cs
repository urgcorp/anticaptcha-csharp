using System;

namespace Anticaptcha.Client
{
    public class AnticaptchaSolveSettings
    {
        public int MaxSolveTimeSeconds { get; set; } = 300;

        /// <summary>
        /// Задержка ответа перед первым запросом результата
        /// </summary>
        public int InitialDelayMs { get; set; } = 3000;

        /// <summary>
        /// Не будет задерживать первый запрос результата если разница между созданием задачи и запросом меньше 
        /// </summary>
        public int InitialDelayThresholdMs { get; set; } = 10;

        public int PollingTimeoutMs { get; set; }
    }
}