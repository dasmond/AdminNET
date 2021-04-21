using Furion;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.DependencyInjection;

namespace Dilon.EntityFramework.Core
{
    [AppStartup(95)]
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
    }
}