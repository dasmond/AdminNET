using Admin.NET.Application.Entity.Tables;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.SeedData
{
    /// <summary>
    /// 基本表格表种子数据
    /// </summary>
    public class BasicTableModelSeedData: IEntitySeedData<BasicTableModel>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<BasicTableModel> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new BasicTableModel{Id=142307070898245, Name="平台管理", Code="system", Active="Y", Status=0, Sort=100 },
                new BasicTableModel{Id=142307070922826, Name="运营管理", Code="platform", Active="N", Status=0, Sort=200 },
                new BasicTableModel{Id=142307070902341, Name="系统管理", Code="manage", Active="N", Status=0, Sort=300 },
                new BasicTableModel{Id=142307070922869, Name="业务应用", Code="busiapp", Active="N", Status=0, Sort=400 },
            };
        }
    }
}
