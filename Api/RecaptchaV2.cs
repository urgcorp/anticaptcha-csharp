﻿using Newtonsoft.Json.Linq;
using Anticaptcha.Helper;

namespace Anticaptcha.Api
{
    public class RecaptchaV2 : RecaptchaV2Proxyless
    {
        public string Cookies { protected get; set; }
        public string ProxyLogin { protected get; set; }
        public string ProxyPassword { protected get; set; }
        public int? ProxyPort { protected get; set; }
        public ProxyTypeOption? ProxyType { protected get; set; }
        public string UserAgent { protected get; set; }
        public string ProxyAddress { protected get; set; }

        public override JObject GetPostData()
        {
            var postData = base.GetPostData();
            postData["type"] = "RecaptchaV2Task";

            if (ProxyType == null || ProxyPort == null || ProxyPort < 1 || ProxyPort > 65535 ||
                string.IsNullOrEmpty(ProxyAddress))
            {
                DebugHelper.Out("Proxy data is incorrect!", DebugHelper.Type.Error);

                return null;
            }

            postData.Add("proxyType", ProxyType.ToString().ToLower());
            postData.Add("proxyAddress", ProxyAddress);
            postData.Add("proxyPort", ProxyPort);
            postData.Add("proxyLogin", ProxyLogin);
            postData.Add("proxyPassword", ProxyPassword);
            postData.Add("userAgent", UserAgent);
            postData.Add("cookies", Cookies);

            return postData;
        }
    }
}