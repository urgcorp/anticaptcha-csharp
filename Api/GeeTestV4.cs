using Newtonsoft.Json.Linq;
using Anticaptcha.Helper;

namespace Anticaptcha.Api
{
    public class GeeTestV4 : GeeTestV4Proxyless
    {
        public ProxyTypeOption? ProxyType { protected get; set; }
        public string ProxyAddress { protected get; set; }
        public int? ProxyPort { protected get; set; }
        public string ProxyLogin { protected get; set; }
        public string ProxyPassword { protected get; set; }
        public string UserAgent { protected get; set; }

        public override JObject GetPostData()
        {
            if (!ProxyHelper.IsValidProxy(ProxyType, ProxyPort, ProxyAddress))
            {
                DebugHelper.Out("Proxy data is incorrect!", DebugHelper.Type.Error);
                return null;
            }

            var postData = base.GetPostData();
            postData["proxyType"] = ProxyType.ToString().ToLower();
            postData["proxyAddress"] = ProxyAddress;
            postData["proxyPort"] = ProxyPort;
            postData["proxyLogin"] = ProxyLogin;
            postData["proxyPassword"] = ProxyPassword;
            postData["userAgent"] = UserAgent;

            return postData;
        }
    }
}