using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Anticaptcha.Exceptions;
using Anticaptcha.Api.Results;

namespace Anticaptcha.Client
{
    /// <summary>
    /// Anticaptcha processing task
    /// </summary>
    public class ACTask<TSolution> where TSolution : class
    {
        private readonly IAnticaptchaApi _client;
        private readonly AnticaptchaSolveSettings _config;

        /// <summary>
        /// Captcha solving task ID
        /// </summary>
        public readonly long TaskId;

        /// <summary>
        /// Time of task creation
        /// </summary>
        public readonly DateTime CreatedAt;

        private DateTime? _completeAt;

        /// <summary>
        /// Time of task completion
        /// </summary>
        public DateTime? CompletedAt
        {
            get => Response?.EndTime ?? _completeAt;
            set => _completeAt = value;
        }
    
        /// <summary>
        /// Solution result
        /// </summary>
        public TaskResponse<TSolution>? Response { get; private set; }

        /// <summary>
        /// Process exception
        /// </summary>
        public Exception? Exception { get; private set; }

        /// <summary>
        /// Task is completed (result or error)
        /// </summary>
        public bool IsCompleted => CompletedAt != null;

        public ACTask(IAnticaptchaApi client, AnticaptchaSolveSettings config, long taskId)
        {
            _client = client;
            _config = config;

            TaskId = taskId;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Wait for task result
        /// </summary>
        /// <param name="maxWaitMs">Limit wait time</param>
        /// <param name="reqDelay">Delay first api call <see cref="AnticaptchaApi.GetTaskResultAsync"/> request</param>
        /// <returns></returns>
        /// <exception cref="AnticaptchaException">API Exception</exception>
        /// <exception cref="Exception">Unhandled exception</exception>
        /// <exception cref="InvalidDataException">Unknown API status</exception>
        /// <exception cref="TimeoutException">Timeout</exception>
        /// <returns>API solve captcha response</returns>
        public async Task<TaskResponse<TSolution>> WaitAsync(int? maxWaitMs = null, int? reqDelay = null,
            CancellationToken cancellationToken = default)
        {
            if (IsCompleted)
            {
                if (Response != null && Response.Status.Equals("ready", StringComparison.OrdinalIgnoreCase))
                    return Response;

                if (Exception != null)
                    throw Exception;
            }

            using var timeoutCts = new CancellationTokenSource(maxWaitMs ?? _config.MaxSolveTimeSeconds * 1000);
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            var token = linkedCts.Token;
            var requestDelayMs = (reqDelay ?? _config.InitialDelayMs) - (int)(DateTime.UtcNow - CreatedAt).TotalMilliseconds;
            try
            {
                if (requestDelayMs > _config.InitialDelayThresholdMs)
                    await Task.Delay(requestDelayMs, token).ConfigureAwait(false);

                while (!IsCompleted)
                {
                    token.ThrowIfCancellationRequested();

                    try
                    {
                        Response = await _client.GetTaskResultAsync<TSolution>(TaskId, token).ConfigureAwait(false);
                        switch (Response.Status.ToLower())
                        {
                            case "processing":
                                break;
                            case "ready":
                                CompletedAt = DateTime.UtcNow;
                                return Response;
                            default:
                                throw new InvalidDataException($"Unknown API status: {Response?.Status ?? "null"}");
                        }
                    }
                    catch (ObjectDisposedException ex)
                    {
                        CompletedAt = DateTime.UtcNow;
                        Exception = ex;
                        throw;
                    }
                    catch (Exception ex) when (!(ex is OperationCanceledException))
                    {
                        CompletedAt = DateTime.UtcNow;
                        Exception = ex;
                        throw; // Пробрасываем ошибку API наверх
                    }

                    // Если токен отменен, Delay выбросит исключение и мы уйдем в финальный catch
                    await Task.Delay(_config.PollingTimeoutMs, token).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException) when (timeoutCts.IsCancellationRequested)
            {
                throw new TimeoutException();
            }

            // На случай выхода из цикла без return (хотя при IsCompleted это не случится)
            return Response ?? throw new Exception("Task failed without result");
        }

        /// <summary>
        /// Wait for task to receive result
        /// </summary>
        /// <param name="maxWaitMs">Limit wait time</param>
        /// <param name="reqDelay">Delay first api call <see cref="AnticaptchaApi.GetTaskResultAsync"/> request</param>
        /// <returns>Task solved without exceptions</returns>
        public async Task<bool> TryWaitAsync(int? maxWaitMs = null, int? reqDelay = null, 
            CancellationToken cancellationToken = default)
        {
            try 
            {
                await WaitAsync(maxWaitMs, reqDelay, cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ACTask<TSolution> CreateFailedTask(Exception ex)
        {
            var res = new ACTask<TSolution>(null!, null!, 0)
            {
                Exception = ex
            };
            res.CompletedAt = DateTime.UtcNow; // Ensure CreatedAt < CompletedAt
            return res;
        }
    }
}