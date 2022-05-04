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
using ServiceCore.Shared.Const;
using ServiceCore.Shared;
using Serilog; 
using Furion;
using Dapr.Shared;

namespace ServiceCore.Shared.Filter
{
    /// <summary>
    /// 请求操作拦截
    /// </summary>
    public class RequestActionFilter : IAsyncActionFilter
    { 
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpContext = context.HttpContext;
            var httpRequest = httpContext.Request;

            var sw = new Stopwatch();
            sw.Start();
            var actionContext = await next();
            sw.Stop();

            var isRequestSucceed = actionContext.Exception == null; // 判断是否请求成功（没有异常就是成功）
            var headers = httpRequest.Headers;
            var clientInfo = headers.ContainsKey("User-Agent") ? Parser.GetDefault().Parse(headers["User-Agent"]) : null;
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var ip = httpContext.GetRemoteIpAddressToIPv4();

            var data = new AddOpLogEvent
            (
                isRequestSucceed,
                  ip,
                  "", // httpRequest.GetRequestUrlAddress(),
                  clientInfo?.UA.Family + clientInfo?.UA.Major,
                clientInfo?.OS.Family + clientInfo?.OS.Major,
                 httpRequest.Path,
                  context.Controller.ToString(),
                  actionDescriptor?.ActionName,
                  httpRequest.Method,
                 context.ActionArguments.Count < 1 ? string.Empty : JSON.Serialize(context.ActionArguments),
                  actionContext.Result?.GetType() == typeof(JsonResult) ? JSON.Serialize(actionContext.Result) : string.Empty,
                 sw.ElapsedMilliseconds,
                httpContext.User==null?0:long.Parse( httpContext.User.FindFirstValue(ClaimConst.UserId)),
                httpContext.User?.FindFirstValue(ClaimConst.UserName),
                 httpContext.User?.FindFirstValue(ClaimConst.RealName)
            );
            await App.GetService<IEventBus>().PublishAsync(data);
            Log.Information( "Add:OpLog", data);
            
            //await _eventPublisher.PublishAsync(new ChannelEventSource("Add:OpLog",
            //    new
            //    {
            //        Success = isRequestSucceed ? YesNoEnum.Y : YesNoEnum.N,
            //        Ip = ip,
            //        Location = "", // httpRequest.GetRequestUrlAddress(),
            //        Browser = clientInfo?.UA.Family + clientInfo?.UA.Major,
            //        Os = clientInfo?.OS.Family + clientInfo?.OS.Major,
            //        Url = httpRequest.Path,
            //        ClassName = context.Controller.ToString(),
            //        MethodName = actionDescriptor?.ActionName,
            //        ReqMethod = httpRequest.Method,
            //        Param = context.ActionArguments.Count < 1 ? string.Empty : JSON.Serialize(context.ActionArguments),
            //        Result = actionContext.Result?.GetType() == typeof(JsonResult) ? JSON.Serialize(actionContext.Result) : string.Empty,
            //        ElapsedTime = sw.ElapsedMilliseconds,
            //        UserName = httpContext.User?.FindFirstValue(ClaimConst.UserName),
            //        RealName = httpContext.User?.FindFirstValue(ClaimConst.RealName)
            //    }));
        }
    }
}