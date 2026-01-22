using System;

namespace Anticaptcha.Common
{
    public class ProxyConfig
    {
        /// <summary>
        /// Proxy type
        /// </summary>
        public ProxyType ProxyType { get; set; }

        /// <summary>
        /// <para>IPv4/IPv6 proxy address</para>
        /// <para>Local network hosts are not allowed</para>
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Proxy port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Login if authorization is required (Basic)
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Proxy password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// <para>User-Agent of browser to emulate.</para>
        /// <para>Required for some captcha's.</para>
        /// <para>You should use modern browser useragent or captcha like 'Google' will ask you to update browser</para>
        /// </summary>
        public string UserAgent { get; set; }

        public ProxyConfig(ProxyType proxyType, string address, int port)
        {
            ProxyType = proxyType;
            Address = address;
            Port = port;
        }

        /// <summary>
        /// Validate proxy configuration
        /// </summary>
        /// <returns>Configuration is valid</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool Validate()
        {
            if (Port <= 0 || Port > 65535)
                throw new ArgumentOutOfRangeException(nameof(Port), Port, "Port must be a positive number <= 65535.");
            if (!Uri.TryCreate(Address, UriKind.Absolute, out var uri))
                throw new ArgumentException("Address must be a valid URI", nameof(Address));
            if (uri.Scheme != Uri.UriSchemeHttps &&
                uri.Scheme != Uri.UriSchemeHttp &&
                !uri.Scheme.StartsWith("socks"))
            {
                throw new ArgumentException("Invalid proxy Address.", nameof(Address));
            }

            return true;
        }
    }
}