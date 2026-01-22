namespace Anticaptcha.Exceptions
{
    public class ProxyException : AnticaptchaException
    {
        public ProxyException(int code, string message) : base(code, message)
        { }
    }
}