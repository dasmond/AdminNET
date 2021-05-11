using Admin.NET.Core;
using Admin.NET.Application.Entity.Tables;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Service.Tables.BasicTable
{
    /// <summary>
    /// 基本表格服务
    /// </summary>
    [ApiDescriptionSettings(Name = "Tables", Order = 100)]
    public class BasicTableService : IBasicTableService, IDynamicApiController, ITransient
    {
        private readonly ISqlSugarRepository<BasicTableModel> _basicTableRep;
        public BasicTableService(ISqlSugarRepository<BasicTableModel> basicTableRep)
        {
            _basicTableRep = basicTableRep;
        }
        /// <summary>
        /// 获取基本表格数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("/basicTable/list")]
        public async Task<dynamic> GetBasicTableList()
        {
            return await _basicTableRep.Where(u => u.Status == (int)CommonStatus.ENABLE).ToListAsync();
        }
    }
}
