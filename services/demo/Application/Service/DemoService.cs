 
using Admin.NET.Core;
using Admin.NET.Core.Shared;
using Admin.NET.Demo.Application.Entity;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.NET.Demo.Application.Serice
{
    /// <summary>
    /// 自己业务服务
    /// </summary>
    [ApiDescriptionSettings(  Name = "自己业务", Order = 200)]
    public class DemoService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<DemoEntity> _testRep;

        public DemoService(SqlSugarRepository<DemoEntity> testRep)
        {
            _testRep = testRep;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/test/list")]
        public async Task<List<DemoEntity>> GetTestList()
        {
            return await _testRep.GetListAsync();
        }
    }
}
