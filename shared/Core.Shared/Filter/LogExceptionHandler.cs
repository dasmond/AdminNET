
using Dapr.Shared;
using Furion;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using ServiceCore.Shared.Const;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceCore.Shared.Filter
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class LogExceptionHandler : IGlobalExceptionHandler, ISingleton
    { 
         
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            Log.Error(context.Exception, "未捕获异常");
            
            await App.GetService<IEventBus>().PublishAsync(new AddExLogEvent(
                    context.Exception.TargetSite.DeclaringType?.FullName,
                    context.Exception.TargetSite.Name,
                    context.Exception.Message,
                    context.Exception.Message,
                    context.Exception.Source,
                    context.Exception.StackTrace,
                    context.Exception.TargetSite.GetParameters().ToString(),
                    context.HttpContext.User == null ? 0 : long.Parse(context.HttpContext.User.FindFirstValue(ClaimConst.UserId)),
                    context.HttpContext.User?.FindFirst(ClaimConst.UserName)?.Value,
                    context.HttpContext.User?.FindFirst(ClaimConst.RealName)?.Value
                ));
            //await _eventPublisher.PublishAsync(new ChannelEventSource("Add:ExLog",
            //    new
            //    {
            //        ClassName = context.Exception.TargetSite.DeclaringType?.FullName,
            //        MethodName = context.Exception.TargetSite.Name,
            //        ExceptionName = context.Exception.Message,
            //        ExceptionMsg = context.Exception.Message,
            //        ExceptionSource = context.Exception.Source,
            //        context.Exception.StackTrace,
            //        ParamsObj = context.Exception.TargetSite.GetParameters().ToString(),
            //        UserName = context.HttpContext.User?.FindFirst(ClaimConst.UserName)?.Value,
            //        RealName = context.HttpContext.User?.FindFirst(ClaimConst.RealName)?.Value
            //    }));

            //// 写日志文件
            //Log.Error(context.Exception.ToString());
        }
    }
}