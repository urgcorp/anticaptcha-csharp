namespace Anticaptcha.Helper
{
    public static class ProxyHelper
    {
        public static bool IsValidProxy(AnticaptchaBase.ProxyTypeOption? proxyType, int? proxyPort, string ProxyAddress)
        {
            return proxyType != null &&
                   !string.IsNullOrWhiteSpace(ProxyAddress) &&
                   proxyPort != null &&
                   proxyPort > 0 &&
                   proxyPort <= 65535;
        }
    }
}