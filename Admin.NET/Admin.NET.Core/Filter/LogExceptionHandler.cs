using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class LogExceptionHandler : IGlobalExceptionHandler, ISingleton
    {
 
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            // 写日志
            Log.Error(context.Exception, context.Exception.ToString());
        }
    }
}