namespace Anticaptcha.Api.Abstractions
{
    public interface IApiTaskRequest
    {
        string Type { get; }

        string? ProxyType { get; }

        bool IsProxySupported { get; }
    }
}