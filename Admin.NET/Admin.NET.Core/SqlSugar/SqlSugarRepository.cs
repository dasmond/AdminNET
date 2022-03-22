using Furion;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Reflection;

namespace Admin.NET.Core
{
    /// <summary>
    /// SqlSugar仓储类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlSugarRepository<T> : SimpleClient<T> where T : class, new()
    {
        public SqlSugarRepository(ISqlSugarClient context = null) : base(context) // 默认值等于null不能少
        {
            base.Context = App.GetService<ISqlSugarClient>(); // 用手动获取方式支持切换仓储
             // 数据库上下文根据实体切换,业务分库(使用环境例如微服务)
            var entityType = typeof(T);
            if (entityType.IsDefined(typeof(TenantAttribute), false))
            {
                var tenantAttribute = entityType.GetCustomAttribute<TenantAttribute>(false)!;
                Context.AsTenant().ChangeDatabase(tenantAttribute.configId);
            }
            ////base.Context.Aop.OnLogExecuting = (s, p) =>
            ////{
            ////    Console.WriteLine(s);
            ////};
        }
    }
    public class SqlSugarRepository 
    {
        /// <summary>
        /// 服务提供器
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        public SqlSugarRepository(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 切换仓储
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>仓储</returns>
        public virtual SqlSugarRepository<TEntity> Change<TEntity>()
            where TEntity : class, new()
        {
            return _serviceProvider.GetService<SqlSugarRepository<TEntity>>();
        }
    }
}