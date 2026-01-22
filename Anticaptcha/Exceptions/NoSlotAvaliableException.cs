namespace Anticaptcha.Exceptions
{
    public class NoSlotAvaliableException : AnticaptchaException
    {
        public NoSlotAvaliableException(string message) : base((int)AnticaptchaErrorCode.NO_SLOT_AVALIABLE, message)
        {
        }
    }
}