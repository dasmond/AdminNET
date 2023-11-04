using NewLife.Caching;
using NewLife.Caching.Models;

namespace Admin.NET.Core
{
    /// <summary>
    /// 基础
    /// </summary>
    public partial class RedisCacheManager : IRedisCacheManager
    {
        public volatile PrefixedRedis redisConnection;
        public RedisCacheManager(PrefixedRedis redisConnection)
        {
            this.redisConnection = redisConnection;
        }

        #region 普通方法

        /// <inheritdoc />
        public PrefixedRedis GetFullRedis()
        {
            return redisConnection;
        }

        /// <inheritdoc />
        public List<string> AllKeys()
        {
            return redisConnection.Keys.ToList();
        }

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {

            return redisConnection.ContainsKey(key);
        }

        /// <inheritdoc />
        public List<string> Search(SearchModel model)
        {
            return redisConnection.Search(model).ToList();
        }

        /// <inheritdoc />
        public long DelByPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return 0;
            //pattern = Regex.Replace(pattern, @"\{*.\}", "(.*)");
            //var keys = redisConnection.Search(new SearchModel { Pattern = pattern });
            var keys = redisConnection.Keys.Where(k => k.StartsWith(pattern));
            //var keys = GetAllKeys().Where(k => k.StartsWith(pattern));
            if (keys != null && keys.Any())
                return redisConnection.Remove(keys.ToArray());
            return 0;
        }

        /// <inheritdoc />
        public void Clear()
        {
            redisConnection.Clear();
        }

        /// <inheritdoc />
        public void SetExpire(string key, TimeSpan timeSpan)
        {
            redisConnection.SetExpire(key, timeSpan);
        }

        /// <inheritdoc />
        public int RemoveByKey(string key, int count)
        {
            var result = 0;
            var keys = redisConnection.Search(key, count).ToList();
            foreach (var k in keys)
                result += redisConnection.Remove(k);
            return result;
        }

        /// <inheritdoc />
        public int RemoveAllByKey(string key, int count = 999)
        {
            var result = 0;
            while (true)
            {
                var keyList = redisConnection.Search(key, count).ToList();
                if (keyList.Count > 0)
                {
                    foreach (var k in keyList)
                        result += redisConnection.Remove(k);
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        /// <inheritdoc />
        public bool Set<TEntity>(string key, TEntity value, TimeSpan cacheTime)
        {
            return redisConnection.Set(key, value, cacheTime);
        }

        /// <inheritdoc />
        public bool Set<TEntity>(string key, TEntity value, int expire = -1)
        {
            return redisConnection.Set(key, value, expire);
        }

        /// <inheritdoc />
        public TEntity Get<TEntity>(string key)
        {
            return redisConnection.Get<TEntity>(key);
        }

        /// <inheritdoc />
        public void Remove(params string[] key)
        {
            redisConnection.Remove(key);
        }

        /// <inheritdoc />
        public bool Rename(string key, string newKey, bool overwrire = true)
        {
            return redisConnection.Rename(key, newKey, overwrire);
        }

        #endregion
    }
}
