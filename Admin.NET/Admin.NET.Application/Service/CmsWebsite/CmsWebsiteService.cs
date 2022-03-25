using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Admin.NET.Core;
using Admin.NET.Core.Service;
namespace Admin.NET.Application
{
    /// <summary>
    /// 站点服务
    /// </summary>
    [ApiDescriptionSettings(Name = "CmsWebsite", Order = 100)]
    public class CmsWebsiteService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<CmsWebsite> _rep;

        public CmsWebsiteService(SqlSugarRepository<CmsWebsite> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询站点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CmsWebsite/pageList")]
        public async Task<dynamic> Page([FromQuery] CmsWebsiteInput input)
        {
            return await _rep.Context.Queryable<CmsWebsite>()
              
                 .Select(c=> new CmsWebsiteOutput { 
                     Id = c.Id,
                     Name = c.Name,
                     Logo = c.Logo,
                     Domain = c.Domain,
                 })
                 .Mapper(c => c.LogoAttachment, c => c.Logo)
                 .WhereIF(!string.IsNullOrWhiteSpace(input.Name), c => c.Name.Contains(input.Name.Trim()))
                 .ToPagedListAsync(input.Page, input.PageSize);
        }

        /// <summary>
        /// 增加站点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CmsWebsite/add")]
        public async Task Add(AddCmsWebsiteInput input)
        {
            var entity = input.Adapt<CmsWebsite>();
            await _rep.InsertAsync(entity);
        }

        /// <summary>
        /// 删除站点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CmsWebsite/delete")]
        public async Task Delete(DeleteCmsWebsiteInput input)
        {
            var entity = await _rep.GetFirstAsync(u => u.Id == input.Id);
            await _rep.DeleteAsync(entity);
        }

        /// <summary>
        /// 更新站点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CmsWebsite/edit")]
        public async Task Update(UpdateCmsWebsiteInput input)
        {
            var entity = input.Adapt<CmsWebsite>();
            await _rep.Context.Updateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        }

        /// <summary>
        /// 获取站点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CmsWebsite/detail")]
        public async Task<CmsWebsite> Get([FromQuery] QueryeCmsWebsiteInput input)
        {
            return await _rep.GetFirstAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取站点列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CmsWebsite/list")]
        public async Task<dynamic> List([FromQuery] CmsWebsiteInput input)
        {
            return await _rep.AsQueryable().ToListAsync();
        }

    }
}
