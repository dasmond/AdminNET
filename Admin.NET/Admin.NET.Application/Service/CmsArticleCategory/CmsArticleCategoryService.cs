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
    /// 文章分类服务
    /// </summary>
    [ApiDescriptionSettings(Name = "CmsArticleCategory", Order = 100)]
    public class CmsArticleCategoryService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<CmsArticleCategory> _rep;
        public CmsArticleCategoryService(SqlSugarRepository<CmsArticleCategory> rep)
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询文章分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CmsArticleCategory/page")]
        public async Task<dynamic> Page([FromQuery] CmsArticleCategoryInput input)
        {
            return await _rep.Context.Queryable<CmsArticleCategory>()
                        .Select(u => new CmsArticleCategoryOutput
                        {
                            Id = u.Id,
                            Pid = u.Pid,
                            Name = u.Name,
                            Picture = u.Picture,
                            Description = u.Description,
                            OrderNo = u.OrderNo,
                            WebsiteId = u.WebsiteId,
                        })
                        .Mapper(c => c.PictureAttachment, c => c.Picture)
                        .Mapper(u => u.FkWebsiteId, u => u.WebsiteId)
                        .WhereIF(input.Pid > 0, u => u.Pid == input.Pid)
                        .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
                        .WhereIF(input.WebsiteId > 0, u => u.WebsiteId == input.WebsiteId)
                        .ToPagedListAsync(input.Page, input.PageSize);
        }

        /// <summary>
        /// 增加文章分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CmsArticleCategory/add")]
        public async Task Add(AddCmsArticleCategoryInput input)
        {
            var entity = input.Adapt<CmsArticleCategory>();
            await _rep.InsertAsync(entity);
        }

        /// <summary>
        /// 删除文章分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CmsArticleCategory/delete")]
        public async Task Delete(DeleteCmsArticleCategoryInput input)
        {
            var entity = await _rep.GetFirstAsync(u => u.Id == input.Id);
            await _rep.DeleteAsync(entity);
        }

        /// <summary>
        /// 更新文章分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CmsArticleCategory/edit")]
        public async Task Update(UpdateCmsArticleCategoryInput input)
        {
            var entity = input.Adapt<CmsArticleCategory>();
            await _rep.Context.Updateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        }

        /// <summary>
        /// 获取文章分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CmsArticleCategory/detail")]
        public async Task<CmsArticleCategory> Get([FromQuery] QueryeCmsArticleCategoryInput input)
        {
            return await _rep.GetFirstAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取文章分类列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CmsArticleCategory/list")]
        public async Task<dynamic> List([FromQuery] CmsArticleCategoryInput input)
        {
            return await _rep.AsQueryable().ToListAsync();
        }
        [HttpGet("/CmsArticleCategory/CmsWebsiteDropdown")]
        public async Task<dynamic> CmsWebsiteDropdown()
        {
            return await _rep.Context.Queryable<CmsWebsite>()
                  .Select(u => new
                  {
                      Label = u.Name,
                      Value = u.Id
                  }
                  ).ToListAsync();
        }
        [HttpGet("/CmsArticleCategory/CmsWebsiteTree")]
        public async Task<dynamic> Tree()
        {
            return await _rep.Context.Queryable<CmsWebsite>()
             .Select(u => new CmsArticleCategoryOutput
             {
                 Id = u.Id.SelectAll()
             }).ToListAsync();
        }

    }
}
