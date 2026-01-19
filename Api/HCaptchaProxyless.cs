using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Anticaptcha.ApiResponse;

namespace Anticaptcha.Api
{
    public class HCaptchaProxyless : AnticaptchaBase, IAnticaptchaTaskProtocol
    {
        public Uri WebsiteUrl { protected get; set; }
        public string WebsiteKey { protected get; set; }
        public string UserAgent { protected get; set; }
        public Dictionary<string, string> EnterprisePayload = new Dictionary<string, string>();

        public override JObject GetPostData()
        {
            var postData = new JObject
            {
                {"type", "HCaptchaTaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"websiteKey", WebsiteKey},
                {"userAgent", UserAgent},
            };
            if (EnterprisePayload.Count > 0)
                postData["enterprisePayload"] = JObject.FromObject(EnterprisePayload);
            
            return postData;
        }

        public TaskResultResponse.SolutionData GetTaskSolution()
        {
            return TaskInfo.Solution;
        }
    }
}