using Anticaptcha.Api.Abstractions;
using Newtonsoft.Json;

namespace Anticaptcha.Api
{
    public class ImageToText : ApiTaskRequestAbstract<ImageToText.ImageToTextSolution>
    {
        public class ImageToTextSolution
        {
            /// <summary>
            /// Текст с капчи-изображения
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Адрес, по которому мы будем хранить картинку следующие 24 часа. После этого она удаляется.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        /// <summary>
        /// Требования к вводимой капче
        /// </summary>
        public enum NumericRequirements
        {
            /// <summary>
            /// Нет требований
            /// </summary>
            None = 0,
            /// <summary>
            /// Разрешать только цифры
            /// </summary>
            NumbersOnly = 1,
            /// <summary>
            /// Разрешать только буквы
            /// </summary>
            LettersOnly = 2
        }

        public override string Type => "ImageToTextTask";

        /// <summary>
        /// <para>Тело капчи закодированное в base64</para>
        /// <para>Убедитесь, что присылаете его без знаков переноса строки. Не включайте префиксы 'data:image/png,' или аналоги, только чистый base64!</para>
        /// </summary>
        [JsonProperty("body")]
        public string ImageBodyBase64 { get; set; }

        /// <summary>
        /// <para>false (default) - нет требований</para>
        /// <para>true - требовать от работника ввести, как минимум, один пробел.</para>
        /// <para>Если пробелов не будет, они будут пропускать задачу, поэтому используйте аккуратно.</para>
        /// </summary>
        [JsonProperty("phrase")]
        public bool? Phrase { get; set; }

        /// <summary>
        /// <para>false - нет требований</para>
        /// <para>true (default) - работник увидит специальную пометку, сообщающую о регистрозависимой капче.</para>
        /// </summary>
        [JsonProperty("case")]
        public bool? Case { get; set; }

        /// <summary>
        /// <para>Требования считывания чисел вводимой капчи</para>
        /// <para>Default - <see cref="NumericRequirements.None"/></para>
        /// </summary>
        [JsonProperty("numeric")]
        public NumericRequirements? Numeric { get; set; }

        /// <summary>
        /// <para>false (default) - нет требований</para>
        /// <para>true - работник увидит специальную пометку, сообщающую о необходимость совершить математическое действие с цифрами на капче</para>
        /// </summary>
        [JsonProperty("math")]
        public bool? Math { get; set; }

        /// <summary>
        /// >0 - Определяет минимальную длинну ответа
        /// </summary>
        [JsonProperty("minLength")]
        public int? MinLength { get; set; }

        /// <summary>
        /// >0 - Определяет большую длинну запроса
        /// </summary>
        [JsonProperty("maxLength")]
        public int? MaxLength { get; set; }

        /// <summary>
        /// <para>Дополнительный комментарий для работника навроде "введите буквы красного цвета".</para>
        /// <para>Результат не гарантируется и полностью зависит от работника.</para>
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Опциональный параметр, чтобы позже различать источники картинок в статистике трат.
        /// </summary>
        [JsonProperty("websiteURL")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// <para>Задает язык пула работников. Применимо только к капчам-картинкам.</para>
        /// <para>en (default) - англоязычная очередь</para>
        /// <para>rn - группа стран: Россия, Украина, Беларусь, Казахстан</para>
        /// </summary>
        [JsonProperty("languagePool")]
        public string LanguagePool { get; set; }
    }
}