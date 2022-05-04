using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using OnceMi.AspNetCore.OSS;
using Serilog;
using Yitter.IdGenerator;
using Microsoft.Extensions.Hosting;
using ServiceCore.Shared.Option;
using ServiceCore.Shared.Cache;
using ServiceCore.Shared.SqlSugar;
using ServiceCore.Shared.Handlers;
using ServiceCore.Shared.Filter;
using ServiceCore.Shared.Util; 
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Dapr.Shared; 

namespace ServiceCore.Shared
{
    [AppStartup(100)]

    public class Startup : AppStartup
    {
        public void ConfigureServices( IServiceCollection services)
        {
            services.AddConfigurableOptions<ConnectionStringsOptions>();
            services.AddConfigurableOptions<RefreshTokenOptions>();
            services.AddConfigurableOptions<SnowIdOptions>();
            services.AddConfigurableOptions<CacheOptions>();
            services.AddConfigurableOptions<OSSProviderOptions>();
            services.AddSqlSugarSetup(App.Configuration);

            services.AddJwt<JwtHandler>(enableGlobalAuthorize: true);

            services.AddCorsAccessor();
            services.AddRemoteRequest();

            services.AddTaskScheduler();

            services.AddControllersWithViews() 
                .AddDapr()
                .AddMvcFilter<RequestActionFilter>()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // 响应驼峰命名
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // 忽略大小写
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // 忽略循环引用
                    options.JsonSerializerOptions.Converters.AddDateFormatString("yyyy-MM-dd HH:mm:ss"); // 时间格式化
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All); // 中文编码
                })
                .AddInjectWithUnifyResult<AdminResultProvider>();


            // 注册OSS对象存储            
            services.AddOSSService(option =>
            {
                var ossOptions = App.GetOptions<OSSProviderOptions>();
                option.Provider = (OSSProvider)ossOptions.Provider;
                option.Endpoint = ossOptions.Endpoint;
                option.AccessKey = ossOptions.AccessKey;
                option.SecretKey = ossOptions.SecretKey;
                option.Region = ossOptions.Region;
                option.IsEnableCache = ossOptions.IsEnableCache;
                option.IsEnableHttps = ossOptions.IsEnableHttps;
            });

            // 注册CSRedis缓存
            services.AddCSRedisSetup();

            // 注册模板引擎
            services.AddViewEngine();


            // 注册日志事件订阅者(支持自定义消息队列组件)
            services.AddEventBus(); 

            //注册Dapr事件
            services.AddScoped<IEventBus, DaprEventBus>();

            //添加健康检查
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDapr();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // 添加状态码拦截中间件
            app.UseUnifyResultStatusCodes();

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Serilog请求日志中间件---必须在 UseStaticFiles 和 UseRouting 之间
            app.UseSerilogRequestLogging();

            app.UseCloudEvents();
            app.UseRouting();

            app.UseCorsAccessor();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseInject();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapSubscribeHandler();
            }); 

            // 设置雪花Id算法机器码
            YitIdHelper.SetIdGenerator(new IdGeneratorOptions
            {
                WorkerId = App.GetOptions<SnowIdOptions>().WorkerId
            }); 
        }
    }
}
