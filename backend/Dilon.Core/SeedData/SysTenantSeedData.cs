﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Dilon.Core
{
    /// <summary>
    /// 租户种子数据
    /// </summary>
    public class SysTenantSeedData : IEntitySeedData<SysTenant, MultiTenantDbContextLocator>
    {
        public IEnumerable<SysTenant> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new List<SysTenant>
            {
                new SysTenant
                {
                    Id = 142307070918780,
                    Name = "平台开发域",
                    AdminName = "SuperAdmin",
                    Host = "",
                    CreatedTime = DateTime.Parse("2021-04-03 00:00:00"),
                    Connection = "",
                    Email = "zuohuaijun@163.com",
                    Phone = "18020030720"
                },
                new SysTenant
                {
                    Id = 142307070918781,
                    Name = "公司1租户",
                    AdminName = "Admin1",
                    Host = "",
                    CreatedTime = DateTime.Parse("2021-04-03 00:00:00"),
                    Connection = ""
                },
                new SysTenant
                {
                    Id = 142307070918782,
                    Name = "公司2租户",
                    AdminName = "Admin2",
                    Host = "",
                    CreatedTime = DateTime.Parse("2021-04-03 00:00:00"),
                    Connection = ""
                }
            };
        }
    }
}
