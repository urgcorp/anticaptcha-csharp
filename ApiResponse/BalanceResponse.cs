using Anticaptcha.Helper;

namespace Anticaptcha.ApiResponse
{
    public class BalanceResponse
    {
        public int? ErrorId { get; private set; }
        public string ErrorCode { get; private set; }
        public string ErrorDescription { get; private set; }
        public double? Balance { get; private set; }

        public double? CaptchaCredits { get; private set; }

        public BalanceResponse(dynamic json)
        {
            ErrorId = JsonHelper.ExtractInt(json, "errorId");

            if (ErrorId != null)
            {
                if (ErrorId.Equals(0))
                {
                    Balance = JsonHelper.ExtractDouble(json, "balance");
                    CaptchaCredits = JsonHelper.ExtractDouble(json, "captchaCredits");
                }
                else
                {
                    ErrorCode = JsonHelper.ExtractStr(json, "errorCode");
                    ErrorDescription = JsonHelper.ExtractStr(json, "errorDescription") ?? "(no error description)";
                }
            }
            else
                DebugHelper.Out("Unknown error", DebugHelper.Type.Error);
        }
    }
}