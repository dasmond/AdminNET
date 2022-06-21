using Admin.NET.Core;
using Admin.NET.Core.Service;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Application
{
    /// <summary>
    /// 表单管理
    /// </summary>
    [Route("api/formmanager")]
    [ApiDescriptionSettings("表单管理", Name = "FormManager", Order = 100)]
    public class FormService:IFormService,ITransient,IDynamicApiController
    {
        private readonly IRepository<SysForm> _sysformRep;
        private readonly IRepository<SysDictData> _sysDictDataRep;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysformRep">表单数据表</param>
        public FormService(IRepository<SysForm> sysformRep, IRepository<SysDictData> sysDictDataRep)
        {
            _sysformRep = sysformRep;
            _sysDictDataRep = sysDictDataRep;
        }

        /// <summary>
        /// 获取表单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public async Task<PageResult<FormDto>> GetPageList([FromQuery] FormPageSearch input)
        {
            var formList = await _sysformRep.DetachedEntities
                    .Join(_sysDictDataRep.DetachedEntities,f=>f.TypeId,d=>d.Id, (f, d) => new {f,d })
                    .Where(!string.IsNullOrWhiteSpace(input.Title),x=>x.f.Title.Contains(input.Title))
                    .Where(input.TypeId != null,x=>x.f.TypeId == input.TypeId)
                    .Select(x=> new FormDto(){
                        Id = x.f.Id,
                        Title = x.f.Title,
                        FormJson = x.f.FormJson,
                        Publish = x.f.Publish,
                        TypeId = x.f.TypeId,
                        TypeName = x.d.Value,
                        Version = x.f.Version,
                        CreatedUserName = x.f.CreatedUserName,
                        CreatedUserId = x.f.CreatedUserId,
                        CreatedTime = x.f.CreatedTime
                     })
                    .ToADPagedListAsync(input.PageNo,input.PageSize);
            return   formList;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<FormDto> FormAdd(FormAddDto input)
        {
            bool bl = await CheckTitle(input.Title);
            if (bl)
            {
                var form = await _sysformRep.InsertNowAsync(input.Adapt<SysForm>());
                return form.Entity.Adapt<FormDto>();
            }
            else
                throw Oops.Oh("存在相同标题表单，请修改表单标题");
        }


        /// <summary>
        /// 更新表单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork]
        [HttpPost("edit")]
        public async Task UpdateEditForm(FormEditDto input)
        {
            var form = await _sysformRep.DetachedEntities.FirstOrDefaultAsync(x=>x.Id == input.Id);
            if (form == null)
                throw Oops.Oh("未找到对应表单！");
            form.FormJson = input.FormJson;
            await _sysformRep.UpdateIncludeNowAsync(form, new[] { "FormJson" }, ignoreNullValues:true);
        }

        /// <summary>
        /// 删除表单
        /// </summary>
        /// <param name="input"></param>
        [HttpDelete("delete")]
        public async Task Delete(BaseId input)
        {
            // 这里可以先判断表单是否已经在流程中使用了
            // 使用了则不能删除

            // 我这里没有做判断
            await _sysformRep.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 发布表单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("publish")]
        public async Task Publish(FormPublishDto input)
        {
            var form = await _sysformRep.DetachedEntities.FirstOrDefaultAsync(x=>x.Id == input.Id);
            if(form == null)
                throw Oops.Oh("未找到对应表单！");
            form.Publish = input.Publish;
            await _sysformRep.UpdateIncludeNowAsync(form,new []{ nameof(form.Publish) });
        }

        /// <summary>
        /// 获取单一实体
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet("entity")]
        public async Task<FormDto> Get([FromQuery] BaseId Input)
        {
            var form = await _sysformRep.DetachedEntities.FirstOrDefaultAsync(x => x.Id == Input.Id);
            FormDto formDto = new FormDto();
            formDto = form.Adapt<FormDto>();
            formDto.NodesList = formDto.FormJson.FromJson<FormList>();
            return formDto;
        }

        /// <summary>
        /// 获取单一实体查看
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet("entityview")]
        public async Task<FormDto> GetView([FromQuery] BaseId Input)
        {
            var form = await _sysformRep.DetachedEntities.FirstOrDefaultAsync(x => x.Id == Input.Id);
            FormDto formDto = new FormDto();
            formDto = form.Adapt<FormDto>();
            formDto.NodesList = formDto.FormJson.FromJson<FormList>();
            foreach (var node in formDto.NodesList.List)
            {
                node.Options.Disabled = true;
            }
            return formDto;
        }


        /// <summary>
        /// 获取已发布表单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("publislist")]
        public async Task<dynamic> GetPulishList(long? typeId)
        {
            var form = await _sysformRep.DetachedEntities.Where(x => x.Publish == true)
                                .Where(typeId != null, x => x.TypeId == typeId)
                                .OrderByDescending(x=>x.CreatedTime)
                                .Select(x=>new { x.Title,x.Id,x.TypeId, NodeList=x.FormJson.FromJson<FormList>() })
                                .ToListAsync();
            return form;
        }


        /// <summary>
        /// 判断标题是否重复
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        private async Task<bool> CheckTitle(string Title)
        {
            var form = await _sysformRep.DetachedEntities.FirstOrDefaultAsync(x => x.Title == Title);
            if (form == null)
                return true;
            return false;
        }

    }
}
