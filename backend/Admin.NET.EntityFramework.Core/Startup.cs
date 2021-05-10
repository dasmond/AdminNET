using Furion;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace Admin.NET.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.CustomizeMultiTenants(); // 自定义租户

                options.AddDb<DefaultDbContext>(providerName: default, optionBuilder: opt =>
                {
                    opt.UseBatchEF_Sqlite(); // EF批量组件
                });
                options.AddDb<MultiTenantDbContext, MultiTenantDbContextLocator>();
            }, "Admin.NET.Database.Migrations");
            #region 配置sqlsuagr
            List<ConnectionConfig> connectConfigList = new List<ConnectionConfig>();
            connectConfigList.Add(new ConnectionConfig
            {
                ConnectionString = $"{App.Configuration["ConnectionStrings:DefaultConnection"]}",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
                ConfigId = "0"
            });
            //connectConfigList.Add(new ConnectionConfig
            //{
            //    ConnectionString = $"{App.Configuration["ConnectionStrings:MultiTenantConnection"]}",
            //    DbType = DbType.SqlServer,
            //    IsAutoCloseConnection = true,
            //    InitKeyType = InitKeyType.Attribute,
            //    ConfigId = "1"
            //});

            services.AddSqlSugar(connectConfigList.ToArray()
                , db =>
                {
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    };
                });
			#endregion	
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //// 自动迁移数据库（update-database命令）
            //if (env.IsDevelopment())
            //{
            //    Scoped.Create((_, scope) =>
            //    {
            //        var context = scope.ServiceProvider.GetRequiredService<DefaultDbContext>();
            //        context.Database.Migrate();
            //    });
            //}
        }
    }
}