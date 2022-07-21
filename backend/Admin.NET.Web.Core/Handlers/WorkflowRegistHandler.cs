using Admin.NET.Application;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowCore.Interface;
using WorkflowCore.Services.DefinitionStorage;

namespace Admin.NET.Web.Core
{
    public static class WorkflowRegistHandler
    {
        public static IApplicationBuilder UseWorkflow(this IApplicationBuilder app)
        {
            var host = app.ApplicationServices.GetService<IWorkflowHost>();
            var res = app.ApplicationServices.GetService<IWorkflowRegistry>();
            var definitionLoader = app.ApplicationServices.GetService<IDefinitionLoader>();
            // 获取定义的流程
            var worlflowDefinition = App.GetService<WorkflowDefinitionService>().GetAllWorkflow().Result;

            // 循环注册
            foreach (var item in worlflowDefinition)
            {
                var json = App.GetService<WorkflowManagerService>().LoadDefinition(item);
                definitionLoader?.LoadDefinition(json, Deserializers.Json);
            }

            // 启动
            host?.Start();

            var appLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            appLifetime?.ApplicationStopping.Register(() =>
            {
                host?.Stop();
            });

            return app;
        }
    }
}