using Newtonsoft.Json.Linq;
using Anticaptcha.ApiResponse;

namespace Anticaptcha
{
    public interface IAnticaptchaTaskProtocol
    {
        JObject GetPostData();
        TaskResultResponse.SolutionData GetTaskSolution();
    }
}