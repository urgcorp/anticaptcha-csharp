using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Anticaptcha.Api.Service;
using Anticaptcha.Api.Service.Results;
using Anticaptcha.Common;
using Anticaptcha.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anticaptcha.Client
{
    public class AnticaptchaApi : IAnticaptchaApi
    {
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        protected readonly ILogger? _logger;
        protected readonly AnticaptchaApiConfiguration _config;

        private readonly HttpClient _httpClient;

        /// <summary>
        /// So that call warnings log only once
        /// </summary>
        private readonly HashSet<string> _proxyMethodsWarnings = new HashSet<string>();

        public AnticaptchaApi(AnticaptchaApiConfiguration config, ILogger<AnticaptchaApi>? logger = null)
        {
            _logger = logger;
            _config = config;

            _httpClient = new HttpClient();
        }

        public async Task<ApiResponse> PostCallAsync<TResult>(ApiRequestAbstract<TResult> request, ProxyConfig? proxyConfig,
                CancellationToken cancellationToken = default)
            where TResult : ApiResponse
        {
            var uri = new Uri(Path.Combine(_config.Host, request.Method));
            var postData = GetPostData(request, proxyConfig, out var isTask);

            var jsonData = postData.ToString(Formatting.Indented);
            using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            if (isTask)
                return await ReadResponse<CreateTaskResponse>(response).ConfigureAwait(false);
            return await ReadResponse<TResult>(response).ConfigureAwait(false);
        }

        protected JObject GetPostData<TResult>(ApiRequestAbstract<TResult> request, ProxyConfig? proxyConfig, out bool isTask)
            where TResult : ApiResponse
        {
            isTask = false;

            var data = JObject.FromObject(request, JsonSerializer);
            if (request is IApiTaskRequest taskRequest)
            {
                isTask = true;

                data["type"] = taskRequest.Type;
                data = new JObject()
                {
                    { "task", data }
                };
                if (_config.SoftId > 0) // SoftId used only for creating tasks (I suppose)
                    data["softId"] = _config.SoftId;

                if (proxyConfig != null)
                {
                    if (taskRequest.IsProxySupported)
                    {
                        data["task"]!["type"] = taskRequest.ProxyType;

                        data["proxyType"] = proxyConfig.ProxyType.ToString("F").ToLower();
                        data["proxyAddress"] = proxyConfig.Address;
                        data["proxyPort"] = proxyConfig.Port;
                        if (!string.IsNullOrEmpty(proxyConfig.Login))
                            data["proxyLogin"] = proxyConfig.Login;
                        if (!string.IsNullOrEmpty(proxyConfig.Password))
                            data["proxyPassword"] = proxyConfig.Password;
                        if (!string.IsNullOrEmpty(proxyConfig.UserAgent))
                            data["userAgent"] = proxyConfig.UserAgent;
                    }
                    else if (_proxyMethodsWarnings.Add(request.Method))
                    {
                        _logger?.LogWarning("Method {apiMethodName} was called with proxy but does not support proxy calls", request.Method);
                    }
                }
                if (!string.IsNullOrEmpty(_config.CallbackUrl))
                    data["callbackUrl"] = _config.CallbackUrl;
            }
            data["clientKey"] = _config.ClientKey;

            return data;
        }

        protected async Task<TResult> ReadResponse<TResult>(HttpResponseMessage response)
            where TResult : ApiResponse
        {
            await using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var reader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(reader);

            var res = JsonSerializer.Deserialize<TResult>(jsonReader);
            if (res == null)
                throw new InvalidDataException($"Anticaptcha returned empty response or invalid JSON for the type {typeof(TResult).Name}.");

            if (res.ErrorId.HasValue && res.ErrorId.Value > 0)
                HandleAnticaptchaError(res);

            return res;
        }

        public async Task<CreateTaskResponse> CreateTaskAsync<TSolution>(ApiTaskRequestAbstract<TSolution> request, CancellationToken cancellationToken = default)
            where TSolution : class
        {
            var res = await PostCallAsync(request, _config.DefaultProxy, cancellationToken).ConfigureAwait(false);
            return (CreateTaskResponse)res;
        }

        public async Task<TaskResponse<TSolution>> GetTaskResultAsync<TSolution>(long taskId, CancellationToken cancellationToken = default)
            where TSolution : class
        {
            var request = new GetTaskResult<TSolution>(taskId);
            var res = await PostCallAsync(request, null, cancellationToken).ConfigureAwait(false);
            return (TaskResponse<TSolution>)res;
        }

        public async Task<ACTask<TSolution>> CreateTaskHandleAsync<TSolution>(ApiTaskRequestAbstract<TSolution> request, CancellationToken cancellationToken = default) where TSolution : class
        {
            try
            {
                var taskResponse = await CreateTaskAsync(request, cancellationToken).ConfigureAwait(false);
                var acTask = new ACTask<TSolution>(this, _config.SolveSettings, taskResponse.TaskId);
                return acTask;
            }
            catch (Exception ex)
            {
                return ACTask<TSolution>.CreateFailedTask(ex);
            }
        }

        public async Task<GetBalanceResponse> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetBalance();
            var res = await PostCallAsync(request, null, cancellationToken).ConfigureAwait(false);
            return (GetBalanceResponse)res;
        }

        #region Helpers
        private void HandleAnticaptchaError(ApiResponse response)
        {
            switch (response.ErrorId!.Value)
            {
                case (int)AnticaptchaErrorCode.KEY_DOES_NOT_EXIST:
                    throw AuthenticationException.InvalidAuthorizationKey(response.ErrorDescription ?? AnticaptchaErrorCode.KEY_DOES_NOT_EXIST.ToString("F"));
                case (int)AnticaptchaErrorCode.ACCOUNT_SUSPENDED:
                    throw AuthenticationException.AccountSuspended(response.ErrorDescription ?? AnticaptchaErrorCode.ACCOUNT_SUSPENDED.ToString("F"));
                case (int)AnticaptchaErrorCode.NO_SLOT_AVALIABLE:
                    throw new NoSlotAvaliableException(response.ErrorDescription ?? AnticaptchaErrorCode.NO_SLOT_AVALIABLE.ToString("F"));
                case (int)AnticaptchaErrorCode.ZERO_BALANCE:
                    throw new ZeroBalanceException(response.ErrorDescription ?? AnticaptchaErrorCode.ZERO_BALANCE.ToString("F"));
                default:
                    if (!Enum.IsDefined(typeof(AnticaptchaErrorCode), response.ErrorId!.Value))
                        _logger?.LogError("Unknown error {errorCode} occured:\n\t{errorDescription}", response.ErrorCode, response.ErrorDescription);
                    throw new AnticaptchaException(response.ErrorId.Value, response.ErrorDescription ?? "Unknown error");
            }
        }
        #endregion
    }
}