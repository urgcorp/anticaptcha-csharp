using System;

namespace Anticaptcha.Exceptions
{
    public class AnticaptchaException : Exception
    {
        public readonly int RawCode;

        public AnticaptchaErrorCode? ErrorCode;

        public AnticaptchaException(int code, string message) : base(message)
        {
            RawCode = code;
            if (Enum.IsDefined(typeof(AnticaptchaErrorCode), code))
                ErrorCode = (AnticaptchaErrorCode)code;
        }
    }
}