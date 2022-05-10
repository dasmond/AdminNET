
using Furion;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using UAParser;
using ServiceCore.Shared;
using Serilog;  
using Dapr.Shared;

namespace ServiceCore.Shared
{
    /// <summary>
    /// 请求操作拦截
    /// </summary>
    public class RequestActionFilter : IAsyncActionFilter
    {
        private readonly IEventPublisher _eventPublisher;

        public RequestActionFilter(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sw = new Stopwatch();
            sw.Start();
            var actionContext = await next();
            sw.Stop();

            var httpContext = context.HttpContext;
            var httpRequest = httpContext.Request;

            var isRequestSucceed = actionContext.Exception == null; // 判断是否请求成功（没有异常就是成功）
            var headers = httpRequest.Headers;
            var clientInfo = headers.ContainsKey("User-Agent") ? Parser.GetDefault().Parse(headers["User-Agent"]) : null;
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var ip = httpContext.GetRemoteIpAddressToIPv4();
            //使用req日志
            Log.Information("Add:OpLog", new AddOpLogEvent
                 (
                      isRequestSucceed,
                       ip,
                      httpRequest.GetRequestUrlAddress(),
                     clientInfo?.UA.Family + clientInfo?.UA.Major,
                      clientInfo?.OS.Family + clientInfo?.OS.Major,
                      httpRequest.Path,
                      context.Controller.ToString(),
                      actionDescriptor?.ActionName,
                       httpRequest.Method,
                      context.ActionArguments.Count < 1 ? string.Empty : JSON.Serialize(context.ActionArguments),
                      actionContext.Result?.GetType() == typeof(JsonResult) ? JSON.Serialize(actionContext.Result) : string.Empty,
                      sw.ElapsedMilliseconds,
                      httpContext.User?.FindFirstValue(ClaimConst.UserName),
                      httpContext.User?.FindFirstValue(ClaimConst.RealName)
                 ));
        }
    }
}