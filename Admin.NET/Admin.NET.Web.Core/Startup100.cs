// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using AspNetCoreRateLimit;
using Furion;
using Furion.SpecificationDocument;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Admin.NET.Web.Core;

[AppStartup(100)]
public class Startup100 : AppStartup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // 限流组件（在跨域之后）
        app.UseIpRateLimiting();
        app.UseClientRateLimiting();
        app.UsePolicyRateLimit();

        // 任务调度看板
        app.UseScheduleUI(options =>
        {
            options.RequestPath = "/schedule";  // 必须以 / 开头且不以 / 结尾
            options.DisableOnProduction = true; // 生产环境关闭
            options.DisplayEmptyTriggerJobs = true; // 是否显示空作业触发器的作业
            options.DisplayHead = false; // 是否显示页头
            options.DefaultExpandAllJobs = false; // 是否默认展开所有作业
        });

        // 配置Swagger-Knife4UI（路由前缀一致代表独立，不同则代表共存）
        app.UseKnife4UI(options =>
        {
            options.RoutePrefix = "kapi";
            foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
            {
                options.SwaggerEndpoint("/" + groupInfo.RouteTemplate, groupInfo.Title);
            }
        });

        app.UseInject(string.Empty, options =>
        {
            foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
            {
                groupInfo.Description += "<br/><u><b><font color='FF0000'> 👮不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！</font></b></u>";
            }
        });

        app.UseEndpoints(endpoints =>
        {
            // 注册集线器
            endpoints.MapHubs();

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}