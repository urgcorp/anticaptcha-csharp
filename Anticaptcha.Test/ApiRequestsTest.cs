using Anticaptcha.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Test;

public class ApiRequestsTest
{
    public readonly JsonSerializer Serializer = new JsonSerializer()
    {
        NullValueHandling = NullValueHandling.Ignore
    };

    [Fact]
    public void ApiRequest_Serialize()
    {
        var wsUrl = "https://example.com";
        var req = new RecaptchaV3()
        {
            WebsiteUrl = wsUrl,
            WebsiteKey = "XXXXX",
            MinScore = 0.3
        };
        var jObj = JObject.FromObject(req, Serializer);
        jObj = new JObject()
        {
            { "clientKey", "xxxx" },
            { "task", jObj },
            { "softId", 0 }
        };

        var json = jObj.ToString();
        var jObjTask = jObj["task"];
        Assert.NotNull(jObjTask);
        var jUrl = jObjTask["websiteURL"];
        Assert.NotNull(jUrl);
        Assert.Equal(wsUrl, jUrl.Value<string>());
    }
}