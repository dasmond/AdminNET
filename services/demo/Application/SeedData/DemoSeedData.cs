 
using Admin.NET.Core;
using Admin.NET.Core.Shared;
using Admin.NET.Demo.Application.Entity;
using System;
using System.Collections.Generic;

namespace Admin.NET.Demo.Application.SeedData
{
    /// <summary>
    /// 自己业务表种子数据
    /// </summary>
    public class DemoSeedData : ISqlSugarEntitySeedData<DemoEntity>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DemoEntity> HasData()
        {
            return new[]
            {
                new DemoEntity{ Id=252885263003800, Name="123", Age=20, CreateTime=DateTime.Parse("2022-04-12 00:00:00") },
                new DemoEntity{ Id=252885263003801, Name="456", Age=30, CreateTime=DateTime.Parse("2022-04-12 00:00:00") },        
            };
        }
    }
}
