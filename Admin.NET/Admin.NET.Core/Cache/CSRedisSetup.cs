using CSRedis;
using Furion;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.NET.Core
{
    public static class CSRedisSetup
    {
        /// <summary>
        /// CSRedis初始化
        /// </summary>
        /// <param name="services"></param>
        public static void AddCSRedisSetup(this IServiceCollection services)
        {
            var cacheOptions = App.GetOptions<CacheOptions>();
            if (cacheOptions.CacheType == CacheTypeEnum.RedisCache.ToString())
            {
                var redisStr = $"{cacheOptions.RedisConnectionString},prefix={cacheOptions.InstanceName}";

                var redis = new CSRedisClient(redisStr);
                services.AddSingleton(redis);
                RedisHelper.Initialization(redis);

                services.AddSingleton<IDistributedCache>(new CSRedisCache(redis));
            }
        }
    }
}