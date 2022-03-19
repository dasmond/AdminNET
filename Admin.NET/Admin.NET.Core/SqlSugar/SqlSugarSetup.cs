using Admin.NET.Core.Service;
using Furion;
using Furion.FriendlyException;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace Admin.NET.Core
{
    public static class SqlSugarSetup
    {
        /// <summary>
        /// Sqlsugar上下文初始化
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSqlSugarSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var configConnection = new ConnectionConfig()
            {
                DbType = (DbType)Enum.Parse(typeof(DbType), configuration.GetConnectionString("DbType")),
                ConnectionString = configuration.GetConnectionString("DefaultConnection"),
                IsAutoCloseConnection = true,
                ConfigId = SqlSugarConst.ConfigId,
                ConfigureExternalServices = new ConfigureExternalServices
                {
                    EntityService = (type, column) => // 修改列
                    {
                        // 带?问号类型则可空
                        if (type.PropertyType.IsGenericType && type.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            column.IsNullable = true;
                        }
                        // string类型没有Required则可空
                        else if (type.PropertyType == typeof(string) && type.GetCustomAttribute<RequiredAttribute>() == null)
                        {
                            column.IsNullable = true;
                        }
                    },
                }
            };

            SqlSugarScope sqlSugar = new(configConnection,
                db =>
                {
                    // 打印SQL语句-执行前
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        if (sql.StartsWith("SELECT"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (sql.StartsWith("UPDATE") || sql.StartsWith("INSERT"))
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (sql.StartsWith("DELETE"))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }

                        Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                        App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    };

                    //// 是否演示环境
                    //var isDemoEnv = App.GetService<SysConfigService>().GetDemoEnvFlag().GetAwaiter().GetResult();
                    //if (isDemoEnv)
                    //    throw Oops.Oh(ErrorCodeEnum.D1200);

                    // 数据审计
                    db.Aop.DataExecuting = (oldValue, entityInfo) =>
                    {
                        // 新增操作
                        if (entityInfo.OperationType == DataFilterType.InsertByObject)
                        {
                            // 主键、long类型-赋值雪花Id
                            if (entityInfo.EntityColumnInfo.IsPrimarykey && entityInfo.EntityColumnInfo.PropertyInfo.PropertyType == typeof(long))
                                entityInfo.SetValue(Yitter.IdGenerator.YitIdHelper.NextId());
                            if (entityInfo.PropertyName == "CreateTime")
                                entityInfo.SetValue(DateTime.Now);
                            if (App.User != null)
                            {
                                if (entityInfo.PropertyName == "CreateUserId")
                                    entityInfo.SetValue(App.User.FindFirst(ClaimConst.UserId)?.Value);
                                if (entityInfo.PropertyName == "CreateOrgId")
                                    entityInfo.SetValue(App.User.FindFirst(ClaimConst.OrgId)?.Value);
                            }
                        }
                        // 更新操作
                        if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                        {
                            if (entityInfo.PropertyName == "UpdateTime")
                                entityInfo.SetValue(DateTime.Now);
                            if (entityInfo.PropertyName == "UpdateUserId" && App.User != null)
                                entityInfo.SetValue(App.User.FindFirst(ClaimConst.UserId)?.Value);
                        }
                    };

                    // 配置业务数据权限过滤器
                    SetDataEntityFilter(db);
                });

            services.AddSingleton<ISqlSugarClient>(sqlSugar); // 这边是SqlSugarScope用AddSingleton
            services.AddScoped(typeof(SqlSugarRepository<>)); // 注册仓储

            // 初始化数据库结构
            if (!bool.Parse(configuration.GetConnectionString("InitTable")))
                return;
            InitDataBase(sqlSugar);
        }

        /// <summary>
        /// 初始化数据库结构
        /// </summary>
        public static void InitDataBase(SqlSugarScope db)
        {
            // 不存在则创建数据库
            db.DbMaintenance.CreateDatabase();

            // 获取所有实体表
            var entityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.IsDefined(typeof(SqlSugarEntityAttribute), false))
                .OrderByDescending(u => GetSqlSugarEntityOrder(u));
            if (!entityTypes.Any()) return;
            // 初始化库表结构
            foreach (var entityType in entityTypes)
            {
                var dbConfigId = entityType.GetCustomAttribute<SqlSugarEntityAttribute>(true).DbConfigId;
                db.ChangeDatabase(dbConfigId);
                db.CodeFirst.InitTables(entityType);
            }

            // 获取所有实体种子数据
            var seedDataTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.GetInterfaces().Any(i => i.HasImplementedRawGeneric(typeof(ISqlSugarEntitySeedData<>))));
            if (!seedDataTypes.Any()) return;

            foreach (var seedType in seedDataTypes)
            {
                var instance = Activator.CreateInstance(seedType);

                var hasDataMethod = seedType.GetMethod("HasData");
                var seedData = ((IList)hasDataMethod?.Invoke(instance, null))?.Cast<object>();
                if (seedData == null) continue;
                var dbConfigIdMethod = seedType.GetMethod("DbConfigId");
                var dbConfigId = dbConfigIdMethod?.Invoke(instance, null);

                db.ChangeDatabase(dbConfigId);
                var seedDataTable = seedData.ToList().ToDataTable();
                if (seedDataTable.Columns.Contains(SqlSugarConst.PrimaryKey))
                {
                    var storage = db.Storageable(seedDataTable).WhereColumns(SqlSugarConst.PrimaryKey).ToStorage();
                    storage.AsInsertable.ExecuteCommand();
                    storage.AsUpdateable.ExecuteCommand();
                }
                else //没有主键或者不是预定义的主键(没主键有重复的可能)
                {
                    var storage = db.Storageable(seedDataTable).ToStorage();
                    storage.AsInsertable.ExecuteCommand();
                }
            }
        }

        /// <summary>
        /// 获取 SqlSugarEntity 排序
        /// </summary>
        /// <param name="type">排序类型</param>
        /// <returns>int</returns>
        private static int GetSqlSugarEntityOrder(Type type)
        {
            return !type.IsDefined(typeof(SqlSugarEntityAttribute), true) ? 0 : type.GetCustomAttribute<SqlSugarEntityAttribute>(true).Order;
        }

        /// <summary>
        /// 配置业务数据表过滤器
        /// </summary>
        public static async void SetDataEntityFilter(SqlSugarClient db)
        {
            // 取当前用户机构Id集合缓存
            var userId = App.User?.FindFirst(ClaimConst.UserId)?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return;
            var orgIds = await App.GetService<SysCacheService>().GetOrgIdList(long.Parse(userId));
            if (orgIds == null) return;
            var orgIdList = orgIds.ConvertAll(x => x.ToString());

            // 获取业务数据表集合
            var dataEntityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.BaseType == typeof(DataEntityBase));
            if (!dataEntityTypes.Any()) return;
            foreach (var dataEntityType in dataEntityTypes)
            {
                foreach (var orgId in orgIds)
                {
                    //动态构造这种表达式
                    Expression<Func<DataEntityBase, bool>> dynamicExpression = it => it.CreateUserId == orgId;
                    Expression exp = dynamicExpression;
                    db.QueryFilter.Add(new TableFilterItem<object>(dataEntityType, exp)); // 设置过滤器 
                }
            }
        }

        /// <summary>
        /// 判断是否演示环境
        /// </summary>
        /// <returns></returns>
        private static bool IsDemoEnv()
        {
            return App.GetService<SysConfigService>().GetDemoEnvFlag().GetAwaiter().GetResult() ? throw Oops.Oh(ErrorCodeEnum.D1200) : false;
        }
    }
}