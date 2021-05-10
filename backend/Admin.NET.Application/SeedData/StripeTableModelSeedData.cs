using Admin.NET.Application.Entity.Tables;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Admin.NET.Application.SeedData
{
    public class StripeTableModelSeedData : IEntitySeedData<StripeTableModel>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<StripeTableModel> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new StripeTableModel{Id=142307070898245, Name="张三", Sex="男",Age = 18, Address = "测试地址1",Active="Y", Status=0, Sort=100 },
                new StripeTableModel{Id=142307070922826, Name="李四", Sex="男",Age = 19, Address = "测试地址2", Active="N", Status=0, Sort=200 },
                new StripeTableModel{Id=142307070902341, Name="王五", Sex="女",Age = 20, Address = "测试地址3", Active="N", Status=0, Sort=300 },
                new StripeTableModel{Id=142307070922869, Name="赵六", Sex="女",Age = 21, Address = "测试地址4", Active="N", Status=0, Sort=400 },
            };
        }
    }
}
