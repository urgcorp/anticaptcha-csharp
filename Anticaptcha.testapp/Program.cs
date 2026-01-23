using Anticaptcha;
using Anticaptcha.Api;
using Anticaptcha.Client;
using Anticaptcha.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

DotNetEnv.Env.TraversePath().Load();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables("AC_")
    .Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.AddLogging(builder =>
{
    builder.AddConfiguration(configuration.GetSection("Logging"));
    builder.AddConsole();
});

serviceCollection.AddSingleton(new AnticaptchaApiConfiguration()
{
    ClientKey = configuration["Anticaptcha:ClientKey"] ?? throw new ApplicationException("Anticaptcha token required"),
    SoftId = int.Parse(configuration["Anticaptcha:SoftId"] ?? "0"),
    DefaultProxy = null
});
serviceCollection.AddSingleton<IAnticaptchaApi, AnticaptchaApi>();

var serviceProvider = serviceCollection.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();
var services = scope.ServiceProvider;
var logger = services.GetRequiredService<ILogger<Program>>();
var api = services.GetRequiredService<IAnticaptchaApi>();

var balance = await api.GetBalanceAsync();
logger.LogInformation("Balance: $ {balance}", balance.BalanceUSD);

var imgCaptcha = new ImageToText()
{
    ImageBodyBase64 = ImageHelper.ImageFileToBase64String("CaptchaImages/example.jpg")
                      ?? throw new ApplicationException("Captcha example image not found"),
    Case = true
};

var captcha = await api.CreateTaskHandleAsync(imgCaptcha);
if (await captcha.TryWaitAsync())
{
    logger.LogInformation("Test captcha solved: {captchaSolution}", captcha.Response!.Solution.Text);
}
else
{
    logger.LogError(captcha.Exception, "Failed to solve captcha");
}