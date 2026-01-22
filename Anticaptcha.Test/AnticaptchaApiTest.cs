using Anticaptcha.Api;
using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Anticaptcha.Client;
using Anticaptcha.Common;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Test;

public class AnticaptchaApiTest
{
    public class AnticaptchaTestApi : AnticaptchaApi
    {
        public AnticaptchaTestApi(AnticaptchaApiConfiguration config)
            : base(null!, config)
        { }

        public JObject GetPostDataTest<TResult>(ApiRequestAbstract<TResult> request, ProxyConfig? proxyConfig, out bool isTask)
            where TResult : ApiResponse
        {
            return this.GetPostData(request, proxyConfig, out isTask);
        }
    }

    public AnticaptchaApiConfiguration Config = new AnticaptchaApiConfiguration()
    {
        ClientKey = "X_X_X_X",
        SoftId = 32211,
        CallbackUrl = "https://localhost:32211"
    };

    [Fact]
    public void Api_FormPostData()
    {
        var api = new AnticaptchaTestApi(Config);
        var request = new RecaptchaV3Enterprise()
        {
            WebsiteUrl = "https://example.com",
            WebsiteKey = "random_key"
        };

        var obj = api.GetPostDataTest(request, null, out _);
        var json = obj.ToString();
        Assert.NotNull(obj);
    }
}