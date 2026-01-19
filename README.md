Вычищеный форк `anticaptcha-csharp`, который может формировать NuGet пакет

### SoftId
Allow you to earn 10% commission with app with code from https://anti-captcha.com/clients/tools/devcenter  
All captcha APIs have `SoftId` property
# Examples
## Get AntiCaptcha Credits Balance
```csharp
var credits = api.GetCreditsBalance();

if (credits == null)
    Console.WriteLine($"GetCreditsBalance() failed. {api.ErrorMessage}");
else
    Console.WriteLine($"Credits balance: {balance}");
```
## Recaptcha V2
```csharp
var api = new RecaptchaV2
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://http.myjino.ru/recaptcha/test-get.php"),
    WebsiteKey = "6Lc_aCMTAAAAABx7u2W0WPXnVbI_v6ZdbM6rYf16",
    UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
    // proxy access parameters
    ProxyType = AnticaptchaBase.ProxyTypeOption.Http,
    ProxyAddress = "xx.xx.xx.xx",
    ProxyPort = 8282,
    ProxyLogin = "123",
    ProxyPassword = "456"
};

// Use to set Recaptcha V2-invisible mode.
// Note that V2-invisible and V3 are different captchas!
// api.IsInvisible = true;

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
else
    Console.WriteLine($"Result: {api.GetTaskSolution().GRecaptchaResponse}");
```
## HCaptcha
```csharp
var api = new HCaptchaProxyless
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://democaptcha.com/"),
    WebsiteKey = "51829642-2cda-4b09-896c-594f89d700cc"
    WebsiteKey = "51829642-2cda-4b09-896c-594f89d700cc"
};

// use to set invisible mode
// api.IsInvisible = true;

// Use to set Hcaptcha Enterprise parameters like rqdata, sentry, apiEndpoint, endpoint, reportapi, assethost, imghost
// api.IsEnterprise = true;

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
else
    Console.WriteLine($"Result: {api.GetTaskSolution().GRecaptchaResponse}");
```
## AntiGate
```csharp
var api = new AntiGateTask
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://antigate.com/logintest.php"),
    TemplateName = "Sign-in and wait for control text",
    Variables = new JObject
    {
        {"login_input_css", "#login"},
        {"login_input_value", "the login"},
        {"password_input_css", "#password"},
        {"password_input_value", "the password"},
        {"control_text", "You have been logged successfully"},
    }
};

// api.ProxyAddress = "194.67.219.51";
// api.ProxyPort = 9736;
// api.ProxyLogin = "7Szw7f";
// api.ProxyPassword = "63HX4n";

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
```
## GeeTest
Website key ("gt") and "challenge" for testing you can get here: https://auth.geetest.com/api/init_captcha?time=1561554686474  
You need to get a new "challenge" each time
```csharp
var api = new GeeTest()
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://www.supremenewyork.com"),
    WebsiteKey = "b6e21f90a91a3c2d4a31fe84e10d0442",
    WebsiteChallenge = "169acd4a58f2c99770322dfa5270c221",
    UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
    // proxy access parameters
    ProxyType = AnticaptchaBase.ProxyTypeOption.Http,
    ProxyAddress = "xx.xx.xx.xx",
    ProxyPort = 8282,
    ProxyLogin = "123",
    ProxyPassword = "456"
};

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
else
{
    Console.WriteLine("Result CHALLENGE: " + api.GetTaskSolution().Challenge);
    Console.WriteLine("Result SECCODE: " + api.GetTaskSolution().Seccode);
    Console.WriteLine("Result VALIDATE: " + api.GetTaskSolution().Validate);
}
```
## GeeTest V4
Website key ("gt") and "challenge" for testing you can get here: https://auth.geetest.com/api/init_captcha?time=1561554686474  
You need to get a new "challenge" each time
```csharp
var api = new GeeTestV4()
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://www.supremenewyork.com"),
    WebsiteKey = "b6e21f90a91a3c2d4a31fe84e10d0442",
    UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
    // proxy access parameters
    ProxyType = AnticaptchaBase.ProxyTypeOption.Http,
    ProxyAddress = "xx.xx.xx.xx",
    ProxyPort = 8282,
    ProxyLogin = "123",
    ProxyPassword = "456"
};

api.initParameters.Add("riskType", "slide");

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
else
{
    Console.WriteLine("Result CaptchaId: " + api.GetTaskSolution().CaptchaId);
    Console.WriteLine("Result LotNumber: " + api.GetTaskSolution().LotNumber);
    Console.WriteLine("Result PassToken: " + api.GetTaskSolution().PassToken);
    Console.WriteLine("Result GenTime: " + api.GetTaskSolution().GenTime);
    Console.WriteLine("Result CaptchaOutput: " + api.GetTaskSolution().CaptchaOutput);
}
```
## FunCaptcha
```csharp
var api = new FunCaptcha
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://http.myjino.ru/funcaptcha_test/"),
    WebsitePublicKey = "DE0B0BB7-1EE4-4D70-1853-31B835D4506B",
    ApiJSSubdomain = "something.arkoselabs.com",
    DataBlob = "{\"blob\":\"HERE_COMES_THE_blob_VALUE\"}",
    UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
    // proxy access parameters
    ProxyType = AnticaptchaBase.ProxyTypeOption.Http,
    ProxyAddress = "xx.xx.xx.xx",
    ProxyPort = 8282,
    ProxyLogin = "123",
    ProxyPassword = "456"
};

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
else
    Console.WriteLine($"Result: {api.GetTaskSolution().Token}");
```