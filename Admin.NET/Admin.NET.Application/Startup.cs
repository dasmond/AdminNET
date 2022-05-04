using Dapr.Shared;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Admin.NET.Application
{
    [AppStartup(100)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //添加健康检查
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDapr();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}