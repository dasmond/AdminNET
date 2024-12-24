// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Plugin.Handler;
using Admin.NET.Web.Core.Middlewares;

using Jusoft.DingtalkStream.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.NET.Plugin.DingTalk;

[AppStartup(200)]
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConfigurableOptions<DingTalkOptions>();
        var ddConfig = App.GetOptions<DingTalkOptions>();

        //添加钉钉Stream事件订阅
        services.AddDingtalkStream(options =>
        {
            options.ClientId = ddConfig.ClientId;
            options.ClientSecret = ddConfig.ClientSecret;

            // options.UA = "dingtalk-stream-demo/1.0.0"; // 扩展的自定义的UA
            // options.Subscriptions.Add //  订阅，也可以在这里配置

            options.AutoReplySystemMessage = true; // 自动回复 SYSTEM 的消息（ping,disconnect）
        })
          .RegisterEventSubscription()  // 注册事件订阅 （可选）
          .RegisterCardInstanceCallback()// 注册卡片回调 （可选）
          .AddMessageHandler<DingtalkStreamMessageHandler>() //添加消息处理服务
          .AddHostServices();// 添加主机服务，用于启动 DingtalkStreamClient
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //使用基于钉钉的角色授权
        app.UseDingTalkAuthorization();
    }
}