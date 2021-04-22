using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dilon.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.CustomizeMultiTenants(); // 自定义租户

                options.AddDb<DefaultDbContext>($"{DbProvider.MySql}@8.0.19");
                options.AddDb<MultiTenantDbContext, MultiTenantDbContextLocator>($"{DbProvider.MySql}@8.0.19");
            }, "Dilon.Database.Migrations");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //// 自动迁移数据库（update-database命令）
            //Scoped.Create((_, scope) =>
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<DefaultDbContext>();
            //    context.Database.Migrate();
            //});
        }
    }
}