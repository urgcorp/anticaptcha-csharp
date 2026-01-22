using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Service.Results;

namespace Anticaptcha.Api.Service
{
    /// <summary>
    /// <para>Запрос баланса учетной записи по ключу доступа.</para>
    /// <para>Пожалуйста, не запрашивайте баланс чаще, чем раз в 30 секунд, и используйте кэш в памяти или на диске.</para>
    /// </summary>
    public class GetBalance : ApiRequestAbstract<GetBalanceResponse>
    {
        public override string Method => "getBalance";
    }
}