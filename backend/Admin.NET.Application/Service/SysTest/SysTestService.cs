using Admin.NET.Application.Test.Entity;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.Extras.Admin.NET;
using Furion.FriendlyException;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    /// <summary>
    /// 测试模块表服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "SysTest", Order = 100)]
    [Route("api")]
    public class SysTestService : ISysTestService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysTest,MultiTenantDbContextLocator> _sysTestRep;

        public SysTestService(
            IRepository<SysTest,MultiTenantDbContextLocator> sysTestRep
        )
        {
            _sysTestRep = sysTestRep;
        }

        /// <summary>
        /// 分页查询测试模块表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("SysTest/page")]
        public async Task<PageResult<SysTestOutput>> Page([FromQuery] SysTestInput input)
        {
            var sysTests = await _sysTestRep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.Name), u => u.Name == input.Name)
                                     .Where(u => u.Value == input.Value)
                                     .OrderBy(PageInputOrder.OrderBuilder<SysTestInput>(input))
                                     .ProjectToType<SysTestOutput>()
                                     .ToADPagedListAsync(input.PageNo, input.PageSize);

            return sysTests;
        }

        /// <summary>
        /// 增加测试模块表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SysTest/add")]
        public async Task Add(AddSysTestInput input)
        {
            var sysTest = input.Adapt<SysTest>();
            await _sysTestRep.InsertAsync(sysTest);
        }

        /// <summary>
        /// 删除测试模块表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SysTest/delete")]
        public async Task Delete(DeleteSysTestInput input)
        {
            var sysTest = await _sysTestRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await _sysTestRep.DeleteAsync(sysTest);
        }

        /// <summary>
        /// 更新测试模块表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SysTest/edit")]
        public async Task Update(UpdateSysTestInput input)
        {
            var isExist = await _sysTestRep.AnyAsync(u => u.Id == input.Id, false);
            if (!isExist) throw Oops.Oh(ErrorCode.D3000);

            var sysTest = input.Adapt<SysTest>();
            await _sysTestRep.UpdateAsync(sysTest,ignoreNullValues:true);
        }

        /// <summary>
        /// 获取测试模块表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("SysTest/detail")]
        public async Task<SysTestOutput> Get([FromQuery] QueryeSysTestInput input)
        {
            return (await _sysTestRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id)).Adapt<SysTestOutput>();
        }

        /// <summary>
        /// 获取测试模块表列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("SysTest/list")]
        public async Task<List<SysTestOutput>> List([FromQuery] SysTestInput input)
        {
            return await _sysTestRep.DetachedEntities.ProjectToType<SysTestOutput>().ToListAsync();
        }    

    }
}
