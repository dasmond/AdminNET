using System.Collections.Generic;

namespace Admin.NET.Core
{
    public interface ISqlSugarEntitySeedData<TEntity>
        where TEntity : class, new()
    {
        /// <summary>
        /// 配置数据库标识
        /// </summary>
        /// <returns></returns>
        string DbConfigId();

        /// <summary>
        /// 配置种子数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> HasData();
    }
}