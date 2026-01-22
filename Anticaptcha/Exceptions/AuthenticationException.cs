namespace Anticaptcha.Exceptions
{
    public class AuthenticationException : AnticaptchaException
    {
        public AuthenticationException(int code, string message) : base(code, message)
        { }

        public static AuthenticationException InvalidAuthorizationKey(string message)
            => new AuthenticationException((int)AnticaptchaErrorCode.KEY_DOES_NOT_EXIST, message);

        public static AuthenticationException AccountSuspended(string message)
            => new AuthenticationException((int)AnticaptchaErrorCode.ACCOUNT_SUSPENDED, message);
    }
}