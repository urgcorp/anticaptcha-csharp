using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api
{
    /// <summary>
    /// Это тип задачи, где ваше приложение указывает URL страницы и индивидуальное задание для нашего работника.
    /// Он выполняет задание пошагово и возвращает полный слепок браузера для использования внутри вашего приложения.
    /// После этого вы можете продолжить браузерную сессию работника.
    /// <example>https://anti-captcha.com/ru/apidoc/articles/how-to-bypass-any-captcha</example>
    /// </summary>
    public class AntiGate : ApiTaskRequestAbstract<JObject>
    {
        public override string Type => "AntiGateTask";

        public override string ProxyType => "AntiGateTask";

        /// <summary>
        /// <para>Адрес целевой страницы куда работник AntiCaptcha.</para>
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// <para>Название шаблона сценария из нашей базы данных.</para>
        /// <para>Вы можете использовать существующий шаблон или создать свой.
        /// Можно поискать существующий шаблон под этой таблицей.</para>
        /// </summary>
        [JsonProperty("templateName")]
        public string TemplateName { get; set; }

        /// <summary>
        /// Объект содержащий переменные шаблона и его значения.
        /// </summary>
        [JsonProperty("variables")]
        public JObject Variables { get; set; }

        /// <summary>
        /// <para>Список доменных имен, где мы должны собрать cookies и значения localStorage.</para>
        /// <para>Его также можно задать статично при редактировании шаблона.</para>
        /// </summary>
        [JsonProperty("domainsOfInterest")]
        public JObject DomainOfInterest { get; set; }
    }
}