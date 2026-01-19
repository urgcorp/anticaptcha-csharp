using System;
using Anticaptcha.ApiResponse;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Api
{
    internal class FunCaptchaProxyless : AnticaptchaBase, IAnticaptchaTaskProtocol
    {
        public Uri WebsiteUrl { protected get; set; }
        public string WebsitePublicKey { protected get; set; }
        public string ApiJSSubdomain { protected get; set; }
        public string DataBlob { protected get; set; }

        public override JObject GetPostData()
        {
            return new JObject
            {
                {"type", "FunCaptchaTaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"websitePublicKey", WebsitePublicKey},
                {"funcaptchaApiJSSubdomain", ApiJSSubdomain},
                {"data", DataBlob}
            };
        }

        public TaskResultResponse.SolutionData GetTaskSolution()
        {
            return TaskInfo.Solution;
        }
    }
}