using Admin.NET.Core.Service;
using Furion;
using Furion.FriendlyException;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
            var dbOptions = App.GetOptions<ConnectionStringsOptions>();
            //处理Sqlite链接字符串为"./Admin.Net.db"报错的情况
            DealConnectionStr(ref dbOptions);
            List<ConnectionConfig> configs = new List<ConnectionConfig>();
            var configureExternalServices = new ConfigureExternalServices
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
            };


            var defaultConnection = new ConnectionConfig()
            {
                DbType = (DbType)Convert.ToInt32(Enum.Parse(typeof(DbType), dbOptions.DefaultDbType)),
                ConnectionString = dbOptions.DefaultConnection,
                IsAutoCloseConnection = true,
                ConfigId = dbOptions.DefaultConfigId,
                ConfigureExternalServices = configureExternalServices
            };
            configs.Add(defaultConnection);
            if (dbOptions.DbConfigs == null)
                dbOptions.DbConfigs = new List<DbConfig>();
            dbOptions.DbConfigs.ForEach(config => {
                var connection = new ConnectionConfig()
                {
                    DbType = (DbType)Convert.ToInt32(Enum.Parse(typeof(DbType), config.DbType)),
                    ConnectionString = config.DbConnection,
                    IsAutoCloseConnection = true,
                    ConfigId = config.DbConfigId,
                    ConfigureExternalServices = configureExternalServices
                };
                configs.Add(connection);
            });

            SqlSugarScope sqlSugar = new(configs,
                db =>
                {
                    configs.ForEach(config => {
                        string configId = config.ConfigId;
                        var thisDb = db.GetConnection(configId);
                        // 打印SQL语句-执行前
                        thisDb.Aop.OnLogExecuting = (sql, pars) =>
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
                        thisDb.Aop.DataExecuting = (oldValue, entityInfo) =>
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
                        SetDataEntityFilter(thisDb);
                    });
                   
                });

            services.AddSingleton<ISqlSugarClient>(sqlSugar); // SqlSugarScope用AddSingleton单例
            services.AddScoped(typeof(SqlSugarRepository<>)); // 注册仓储
            services.AddScoped(typeof(SqlSugarRepository));
            // 初始化数据库结构及种子数据
            if (dbOptions.InitTable)
                InitDataBase(sqlSugar);
        }

        public static void DealConnectionStr(ref ConnectionStringsOptions dbOptions)
        {
            if (dbOptions.DefaultDbType.Trim().ToLower() == "sqlite" && dbOptions.DefaultConnection.Contains("./"))
            {
                var file = Path.GetFileName(dbOptions.DefaultConnection.Replace("DataSource=", ""));
                dbOptions.DefaultConnection = $"DataSource={Environment.CurrentDirectory.Replace(@"\bin\Debug", "")}\\{file}";
            }
            if (dbOptions.DbConfigs == null)
                dbOptions.DbConfigs = new List<DbConfig>();
            dbOptions.DbConfigs.ForEach(cofing => {
                if (cofing.DbType.Trim().ToLower() == "sqlite" && cofing.DbConnection.Contains("./"))
                {
                    var file = Path.GetFileName(cofing.DbConnection.Replace("DataSource=", ""));
                    cofing.DbConnection = $"DataSource={Environment.CurrentDirectory.Replace(@"\bin\Debug", "")}\\{file}";
                }
            });
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
        public static async void SetDataEntityFilter(SqlSugarProvider db)
        {
            // 获取业务数据表集合
            var dataEntityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.BaseType == typeof(DataEntityBase));
            if (!dataEntityTypes.Any()) return;

            var userId = App.User?.FindFirst(ClaimConst.UserId)?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return;

            // 获取用户机构Id集合
            var orgIds = await App.GetService<SysCacheService>().GetOrgIdList(long.Parse(userId));
            if (orgIds == null) return;

            foreach (var dataEntityType in dataEntityTypes)
            {
                foreach (var orgId in orgIds)
                {
                    Expression<Func<DataEntityBase, bool>> dynamicExpression = u => u.CreateOrgId == orgId;
                    Expression exp = dynamicExpression;
                    db.QueryFilter.Add(new TableFilterItem<object>(dataEntityType, exp)); // 设置表过滤器 
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