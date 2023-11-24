using Microsoft.Extensions.Options;
using NewLife.Caching;

namespace Admin.NET.Core
{
    public static class RedisServiceCollectionExtension
    {
        /// <summary>
        /// 添加键前缀的PrefixedRedis缓存
        /// </summary>
        /// <param name="services"></param>  
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddPrefixedRedis(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.Configure<RedisOptions>(App.Configuration.GetSection("RedisOptions"));
            var redisOption = App.GetRequiredService<IOptions<RedisOptions>>();
            services.AddSingleton(sp => new PrefixedRedis(redisOption.Value));
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();

            return services;
        }

    }
}