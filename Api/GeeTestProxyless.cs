﻿using System;
using Newtonsoft.Json.Linq;
using Anticaptcha.ApiResponse;

namespace Anticaptcha.Api
{
    public class GeeTestProxyless : AnticaptchaBase, IAnticaptchaTaskProtocol
    {
        public Uri WebsiteUrl { protected get; set; }
        public string WebsiteKey { protected get; set; }
        public string WebsiteChallenge { protected get; set; }
        public string GeetestApiServerSubdomain { protected get; set; }

        public override JObject GetPostData()
        {
            var postData = new JObject
            {
                {"type", "GeeTestTaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"gt", WebsiteKey},
                {"challenge", WebsiteChallenge},
            };

            if (!string.IsNullOrEmpty(GeetestApiServerSubdomain))
            {
                postData["geetestApiServerSubdomain"] = GeetestApiServerSubdomain;
            }

            return postData;
        }

        public TaskResultResponse.SolutionData GetTaskSolution()
        {
            return TaskInfo.Solution;
        }
    }
}