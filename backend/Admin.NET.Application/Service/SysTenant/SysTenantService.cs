using Admin.NET.Application.Entity;
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
    /// 租户表服务
    /// </summary>
    [Route("api")]
    [ApiDescriptionSettings("自己的业务", Name = "SysTenant", Order = 100)]
    public class SysTenantService : ISysTenantService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysTenant,MultiTenantDbContextLocator> _sysTenantRep;

        public SysTenantService(
            IRepository<SysTenant,MultiTenantDbContextLocator> sysTenantRep
        )
        {
            _sysTenantRep = sysTenantRep;
        }

        /// <summary>
        /// 分页查询租户表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("SysTenant/page")]
        public async Task<PageResult<SysTenantOutput>> Page([FromQuery] SysTenantSearch input)
        {
            var sysTenants = await _sysTenantRep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.Name), u => EF.Functions.Like(u.Name, $"%{input.Name.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.AdminName), u => EF.Functions.Like(u.AdminName, $"%{input.AdminName.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Host), u => EF.Functions.Like(u.Host, $"%{input.Host.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Email), u => EF.Functions.Like(u.Email, $"%{input.Email.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Phone), u => EF.Functions.Like(u.Phone, $"%{input.Phone.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Connection), u => EF.Functions.Like(u.Connection, $"%{input.Connection.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Schema), u => EF.Functions.Like(u.Schema, $"%{input.Schema.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Remark), u => EF.Functions.Like(u.Remark, $"%{input.Remark.Trim()}%"))
                                     .OrderBy(PageInputOrder.OrderBuilder<SysTenantSearch>(input))
                                     .ProjectToType<SysTenantOutput>()
                                     .ToADPagedListAsync(input.PageNo, input.PageSize);

            return sysTenants;
        }

        /// <summary>
        /// 增加租户表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SysTenant/add")]
        public async Task Add(AddSysTenantInput input)
        {
            var sysTenant = input.Adapt<SysTenant>();
            await _sysTenantRep.InsertAsync(sysTenant);
        }

        /// <summary>
        /// 删除租户表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SysTenant/delete")]
        public async Task Delete(DeleteSysTenantInput input)
        {
            var sysTenant = await _sysTenantRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await _sysTenantRep.DeleteAsync(sysTenant);
        }

        /// <summary>
        /// 更新租户表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SysTenant/edit")]
        public async Task Update(UpdateSysTenantInput input)
        {
            var isExist = await _sysTenantRep.AnyAsync(u => u.Id == input.Id, false);
            if (!isExist) throw Oops.Oh(ErrorCode.D3000);

            var sysTenant = input.Adapt<SysTenant>();
            await _sysTenantRep.UpdateAsync(sysTenant,ignoreNullValues:true);
        }

        /// <summary>
        /// 获取租户表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("SysTenant/detail")]
        public async Task<SysTenantOutput> Get([FromQuery] QueryeSysTenantInput input)
        {
            return (await _sysTenantRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id)).Adapt<SysTenantOutput>();
        }

        /// <summary>
        /// 获取租户表列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("SysTenant/list")]
        public async Task<List<SysTenantOutput>> List([FromQuery] SysTenantInput input)
        {
            return await _sysTenantRep.DetachedEntities.ProjectToType<SysTenantOutput>().ToListAsync();
        }    

    }
}
