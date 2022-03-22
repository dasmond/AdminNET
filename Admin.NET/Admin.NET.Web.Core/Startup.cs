using Admin.NET.Core;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnceMi.AspNetCore.OSS;
using Serilog;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Yitter.IdGenerator;

namespace Admin.NET.Web.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //添加配置选项
            services.AddConfigurableOptions<RefreshTokenOptions>();
            services.AddConfigurableOptions<SnowIdOptions>();
            services.AddConfigurableOptions<CacheOptions>();
            services.AddConfigurableOptions<OSSProviderOptions>();
            services.AddConfigurableOptions<UploadOptions>();
            services.AddConfigurableOptions<WechatOptions>();
            services.AddConfigurableOptions<WechatPayOptions>();
            services.AddConfigurableOptions<PayCallBackOptions>();
            services.AddConfigurableOptions<ConnectionStringsOptions>();

            services.AddSqlSugarSetup(App.Configuration);

            services.AddJwt<JwtHandler>(enableGlobalAuthorize: true);

            services.AddCorsAccessor();
            services.AddRemoteRequest();

            services.AddControllersWithViews()
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

            // 注册日志事件订阅者(支持自定义消息队列组件)
            services.AddEventBus(builder =>
            {
                builder.AddSubscriber<LogEventSubscriber>();
            });

            // 注册OSS对象存储
            var ossOptions = App.GetOptions<OSSProviderOptions>();
            services.AddOSSService(option =>
            {
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Serilog请求日志中间件---必须在 UseStaticFiles 和 UseRouting 之间
            app.UseSerilogRequestLogging();

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
            });

            // 设置雪花Id算法机器码
            YitIdHelper.SetIdGenerator(new IdGeneratorOptions
            {
                WorkerId = App.GetOptions<SnowIdOptions>().WorkerId
            });
        }
    }
}