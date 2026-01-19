using Newtonsoft.Json.Linq;
using Anticaptcha.Helper;

namespace Anticaptcha.Api
{
    public class HCaptcha : HCaptchaProxyless
    {
        public ProxyTypeOption? ProxyType { protected get; set; }
        public string ProxyAddress { protected get; set; }
        public int? ProxyPort { protected get; set; }
        public string ProxyLogin { protected get; set; }
        public string ProxyPassword { protected get; set; }
        public string Cookies { protected get; set; }

        public override JObject GetPostData()
        {
            if (!ProxyHelper.IsValidProxy(ProxyType, ProxyPort, ProxyAddress))
            {
                DebugHelper.Out("Proxy data is incorrect!", DebugHelper.Type.Error);
                return null;
            }

            var postData = base.GetPostData();
            postData["type"] = "HCaptchaTask";

            postData.Add("proxyType", ProxyType.ToString().ToLower());
            postData.Add("proxyAddress", ProxyAddress);
            postData.Add("proxyPort", ProxyPort);
            postData.Add("proxyLogin", ProxyLogin);
            postData.Add("proxyPassword", ProxyPassword);
            postData.Add("cookies", Cookies);

            return postData;
        }
    }
}