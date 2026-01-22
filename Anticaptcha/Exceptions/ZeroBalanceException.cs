namespace Anticaptcha.Exceptions
{
    public class ZeroBalanceException : AnticaptchaException
    {
        public ZeroBalanceException(string message) : base((int)AnticaptchaErrorCode.ZERO_BALANCE, message)
        { }
    }
}