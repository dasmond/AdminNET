using Dilon.Application.Entity.Tables;
using Dilon.Core;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Threading.Tasks;

namespace Dilon.Application.Service.Tables.StripeTable
{
    /// <summary>
    /// 斑马线表格服务
    /// </summary>
    [ApiDescriptionSettings(Name = "Tables", Order = 100)]
    public class StripeTableService : IStripeTableService, IDynamicApiController, ITransient
    {
        private readonly ISqlSugarRepository<StripeTableModel> _stripeTableRep;
        public StripeTableService(ISqlSugarRepository<StripeTableModel> stripeTableRep)
        {
            _stripeTableRep = stripeTableRep;
        }
        /// <summary>
        /// 获取斑马线表格数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("/stripeTable/list")]
        public async Task<dynamic> GetStripeTableList()
        {
            return await _stripeTableRep.Where(u => u.Status == (int)CommonStatus.ENABLE).ToListAsync();
        }
    }
}
