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
    /// 测试生成服务
    /// </summary>
    [ApiDescriptionSettings(Name = "TestCodeGen", Order = 100)]
    public class TestCodeGenService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<TestCodeGen> _rep;
        public TestCodeGenService(SqlSugarRepository<TestCodeGen> rep)
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询测试生成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/TestCodeGen/page")]
        public async Task<dynamic> Page([FromQuery] TestCodeGenInput input)
        {
            return await _rep.Context.Queryable<TestCodeGen>()
                        .Select(u=> new TestCodeGenOutput{
                            Id = u.Id,        
                            Image = u.Image,        
                            User = u.User,        
                            Status = u.Status,        
                        })
                        .Mapper(c => c.ImageAttachment, c => c.Image)
                        .Mapper(u => u.FkUser, u => u.User)
                        .WhereIF(input.User>0, u => u.User == input.User)
                .ToPagedListAsync(input.Page, input.PageSize);
        }

        /// <summary>
        /// 增加测试生成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/TestCodeGen/add")]
        public async Task Add(AddTestCodeGenInput input)
        {
            var entity = input.Adapt<TestCodeGen>();
            await _rep.InsertAsync(entity);
        }

        /// <summary>
        /// 删除测试生成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/TestCodeGen/delete")]
        public async Task Delete(DeleteTestCodeGenInput input)
        {
            var entity = await _rep.GetFirstAsync(u => u.Id == input.Id);
            await _rep.DeleteAsync(entity);
        }

        /// <summary>
        /// 更新测试生成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/TestCodeGen/edit")]
        public async Task Update(UpdateTestCodeGenInput input)
        {
            var entity = input.Adapt<TestCodeGen>();
            await _rep.Context.Updateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        }

        /// <summary>
        /// 获取测试生成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/TestCodeGen/detail")]
        public async Task<TestCodeGen> Get([FromQuery] QueryeTestCodeGenInput input)
        {
            return await _rep.GetFirstAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取测试生成列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/TestCodeGen/list")]
        public async Task<dynamic> List([FromQuery] TestCodeGenInput input)
        {
            return await _rep.AsQueryable().ToListAsync();
        }
        [HttpGet("/TestCodeGen/SysUserDropdown")]
        public async Task<dynamic> SysUserDropdown()
        {
            return await _rep.Context.Queryable<SysUser>()
                  .Select(u => new
                  {
                      Label = u.NickName,
                      Value = u.Id
                  }
                  ).ToListAsync();
        }

    }
}
