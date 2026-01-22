using System.Threading;
using System.Threading.Tasks;
using Anticaptcha.Api.Abstractions;
using Anticaptcha.Api.Results;
using Anticaptcha.Api.Service.Results;
using Anticaptcha.Client;

namespace Anticaptcha
{
    public interface IAnticaptchaApi
    {
        /// <summary>
        /// Создает задачу решения капчи
        /// </summary>
        /// <param name="request">Тип задачи</param>
        /// <typeparam name="TSolution">Тип данных ответа, который должна вернуть задача</typeparam>
        /// <returns>Идентификатор созданной задачи</returns>
        Task<CreateTaskResponse> CreateTaskAsync<TSolution>(ApiTaskRequestAbstract<TSolution> request, CancellationToken cancellationToken = default)
            where TSolution : class;

        /// <summary>
        /// Запрос результата задачи, созданной через <see cref="CreateTaskAsync"/>
        /// </summary>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <typeparam name="TSolution">Тип данных ответа, который должна вернуть задача</typeparam>
        /// <returns>Результата задачи</returns>
        Task<TaskResponse<TSolution>> GetTaskResultAsync<TSolution>(long taskId, CancellationToken cancellationToken = default)
            where TSolution : class;

        /// <summary>
        /// Создает задачу решения капчи
        /// </summary>
        /// <param name="request">Тип задачи</param>
        /// <typeparam name="TSolution">Тип данных ответа, который должна вернуть задача</typeparam>
        /// <returns>Объект ожидания результата задачи</returns>
        Task<ACTask<TSolution>> CreateTaskHandleAsync<TSolution>(ApiTaskRequestAbstract<TSolution> request, CancellationToken cancellationToken = default)
            where TSolution : class;

        /// <summary>
        /// <para>Запрос баланса учетной записи.</para>
        /// <para>Не рекомендуется запрашивать чаще чем раз в 30 секунд</para>
        /// </summary>
        /// <returns>Информация о балансе учётной записи</returns>
        Task<GetBalanceResponse> GetBalanceAsync(CancellationToken cancellationToken = default);
    }
}