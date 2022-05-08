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
    /// 交付物管理服务
    /// </summary>
    [Route("api")]
    [ApiDescriptionSettings("自己的业务", Name = "Deliverables", Order = 100)]
    public class DeliverablesService : IDeliverablesService, IDynamicApiController, ITransient
    {
        private readonly IRepository<Deliverables,MultiTenantDbContextLocator> _deliverablesRep;

        public DeliverablesService(
            IRepository<Deliverables,MultiTenantDbContextLocator> deliverablesRep
        )
        {
            _deliverablesRep = deliverablesRep;
        }

        /// <summary>
        /// 分页查询交付物管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("Deliverables/page")]
        public async Task<PageResult<DeliverablesOutput>> Page([FromQuery] DeliverablesInput input)
        {
            var deliverabless = await _deliverablesRep.DetachedEntities
                                     .Where(false, u => u.Issue == input.Issue)
                                     .Where(!string.IsNullOrEmpty(input.Enterprise), u => EF.Functions.Like(u.Enterprise, $"%{input.Enterprise.Trim()}%"))
                                     .Where(false,u => u.State == input.State)
                                     .Where(!string.IsNullOrEmpty(input.FullName), u => EF.Functions.Like(u.FullName, $"%{input.FullName.Trim()}%"))
                                     .OrderBy(PageInputOrder.OrderBuilder<DeliverablesInput>(input))
                                     .ProjectToType<DeliverablesOutput>()
                                     .ToADPagedListAsync(input.PageNo, input.PageSize);

            return deliverabless;
        }

        /// <summary>
        /// 增加交付物管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("Deliverables/add")]
        public async Task Add(AddDeliverablesInput input)
        {
            var deliverables = input.Adapt<Deliverables>();
            await _deliverablesRep.InsertAsync(deliverables);
        }

        /// <summary>
        /// 删除交付物管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("Deliverables/delete")]
        public async Task Delete(DeleteDeliverablesInput input)
        {
            var deliverables = await _deliverablesRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await _deliverablesRep.DeleteAsync(deliverables);
        }

        /// <summary>
        /// 更新交付物管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("Deliverables/edit")]
        public async Task Update(UpdateDeliverablesInput input)
        {
            var isExist = await _deliverablesRep.AnyAsync(u => u.Id == input.Id, false);
            if (!isExist) throw Oops.Oh(ErrorCode.D3000);

            var deliverables = input.Adapt<Deliverables>();
            await _deliverablesRep.UpdateAsync(deliverables,ignoreNullValues:true);
        }

        /// <summary>
        /// 获取交付物管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("Deliverables/detail")]
        public async Task<DeliverablesOutput> Get([FromQuery] QueryeDeliverablesInput input)
        {
            return (await _deliverablesRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id)).Adapt<DeliverablesOutput>();
        }

        /// <summary>
        /// 获取交付物管理列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("Deliverables/list")]
        public async Task<List<DeliverablesOutput>> List([FromQuery] DeliverablesInput input)
        {
            return await _deliverablesRep.DetachedEntities.ProjectToType<DeliverablesOutput>().ToListAsync();
        }    

    }
}
