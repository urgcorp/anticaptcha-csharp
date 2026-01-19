Вычищеный форк `anticaptcha-csharp`, который может формировать NuGet пакет

# Examples
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
## GeeTest V4
Website key ("gt") and "challenge" for testing you can get here: https://auth.geetest.com/api/init_captcha?time=1561554686474  
You need to get a new "challenge" each time
```csharp
var api = new GeeTestV4Proxyless()
{
    ClientKey = ClientKey,
    WebsiteUrl = new Uri("http://www.supremenewyork.com"),
    WebsiteKey = "b6e21f90a91a3c2d4a31fe84e10d0442"
};

api.initParameters.Add("riskType", "slide");

if (!api.CreateTask())
    Console.WriteLine($"API v2 send failed. {api.ErrorMessage}");
else if (!api.WaitForResult())
    Console.WriteLine($"Could not solve the captcha.");
```