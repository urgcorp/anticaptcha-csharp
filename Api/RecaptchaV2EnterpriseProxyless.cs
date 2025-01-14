﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Anticaptcha.ApiResponse;

namespace Anticaptcha.Api
{
    public class RecaptchaV2EnterpriseProxyless : AnticaptchaBase, IAnticaptchaTaskProtocol
    {
        public Uri WebsiteUrl { protected get; set; }
        public string WebsiteKey { protected get; set; }
        public Dictionary<string, string> EnterprisePayload = new Dictionary<string, string>();

        public override JObject GetPostData()
        {
            var jsonObject = new JObject
            {
                {"type", "RecaptchaV2EnterpriseTaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"websiteKey", WebsiteKey}
            };

            if (EnterprisePayload.Count > 0)
            {
                jsonObject["enterprisePayload"] = JObject.FromObject(EnterprisePayload);
            }

            return jsonObject;
        }

        public TaskResultResponse.SolutionData GetTaskSolution()
        {
            return TaskInfo.Solution;
        }
    }
}