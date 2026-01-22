using Anticaptcha.Api.Abstractions;

namespace Anticaptcha.Api
{
    /// <summary>
    /// <para>Страница отфильтровки ботов, которую <b>Amazon</b> показывает автоматически, когда вы посещаете веб-сайт за их фаерволом.</para>
    /// <para>Решается с использованием <c>gokuProps</c>, который вы можете найти параметры <c>window.gokuProps</c> в исходном коде странцы.</para>
    /// <para>Используйте этот тип задач, чтобы получить токен для кукис Amazon WAF,
    /// который вы можете использовать в своем http-запросе в качестве значения <c>cookie</c> с именем <c>amazon-waf-token</c></para>
    /// </summary>
    public class AmazonGoku : AmazonAbstract
    {
        /// <summary>
        /// <para>Значение <c>key</c> от <c>window.gokuProps</c> объекта в исходном коде страницы WAF.</para>
        /// </summary>
        public override string WebsiteKey { get; set; }

        /// <summary>
        /// <para>Значение <c>iv</c> от <c>window.gokuProps</c> объекта в исходном коде страницы WAF.</para>
        /// </summary>
        public string IV { get; set; }

        /// <summary>
        /// <para>Значение <c>context</c> от <c>window.gokuProps</c> объекта в исходном коде страницы WAF.</para>
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// <para>Дополнительный URL, ведущий к <c>captcha.js</c></para>
        /// <example>https://e9b10f157f38.9a96e8b4.us-gov-west-1.captcha.awswaf.com/e9b10f157f38/76cbcde1c834/2a564e323e7b/captcha.js</example>
        /// </summary>
        public string? CaptchaScript { get; set; }

        /// <summary>
        /// <para>Дополнительный URL, приводящий к <c>challenge.js</c></para>
        /// <example>https://e9b10f157f38.9a96e8b4.us-gov-west-1.token.awswaf.com/e9b10f157f38/76cbcde1c834/2a564e323e7b/challenge.js</example>
        /// </summary>
        public string? ChallengeScript { get; set; }
    }
}