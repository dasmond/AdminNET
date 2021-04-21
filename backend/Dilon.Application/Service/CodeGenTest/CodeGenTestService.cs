using Dilon.Core;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dilon.Application
{
    /// <summary>
    /// 代码生成业务服务
    /// </summary>
    [ApiDescriptionSettings(Name = "CodeGenTest", Order = 100)]
    public class CodeGenTestService : ICodeGenTestService, IDynamicApiController, ITransient
    {
        private readonly IRepository<CodeGenTest> _rep;

        public CodeGenTestService(IRepository<CodeGenTest> rep)
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询代码生成业务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CodeGenTest/page")]
        public async Task<dynamic> Page([FromQuery] CodeGenTestInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.Name), u => u.Name == input.Name)
                                     .Where(!string.IsNullOrEmpty(input.NickName), u => u.NickName == input.NickName)
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            return XnPageResult<CodeGenTest>.PageResult(entities);
        }

        /// <summary>
        /// 增加代码生成业务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CodeGenTest/add")]
        public async Task Add(AddCodeGenTestInput input)
        {
            var entity = input.Adapt<CodeGenTest>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除代码生成业务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CodeGenTest/delete")]
        public async Task Delete(DeleteCodeGenTestInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新代码生成业务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/CodeGenTest/edit")]
        public async Task Update(UpdateCodeGenTestInput input)
        {
            var entity = input.Adapt<CodeGenTest>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取代码生成业务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CodeGenTest/detail")]
        public async Task<CodeGenTest> Get([FromQuery] QueryeCodeGenTestInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取代码生成业务列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/CodeGenTest/list")]
        public async Task<dynamic> List([FromQuery] CodeGenTestInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }
    }
}
