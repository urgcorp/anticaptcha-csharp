using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api
{
    public class GeeTest : GeeTestProxyless
    {
        public ProxyTypeOption? ProxyType { protected get; set; }
        public string ProxyAddress { protected get; set; }
        public int? ProxyPort { protected get; set; }
        public string ProxyLogin { protected get; set; }
        public string ProxyPassword { protected get; set; }
        public string UserAgent { protected get; set; }

        public override JObject GetPostData()
        {
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