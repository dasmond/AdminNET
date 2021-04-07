﻿using Furion;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.ViewEngine;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dilon.Core.Service.CodeGen
{
    /// <summary>
    /// 代码生成器服务
    /// </summary>
    [ApiDescriptionSettings(Name = "CodeGen", Order = 100)]
    public class CodeGenService : IDynamicApiController, ITransient
    {
        private readonly IRepository<SysCodeGen> _sysCodeGenRep;    // 代码生成器仓储
        private readonly CodeGenConfigService _codeGenConfigService;
        private readonly IViewEngine _viewEngine;

        public CodeGenService(IRepository<SysCodeGen> sysCodeGenRep, CodeGenConfigService codeGenConfigService, IViewEngine viewEngine)
        {
            _sysCodeGenRep = sysCodeGenRep;
            _codeGenConfigService = codeGenConfigService;
            _viewEngine = viewEngine;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/codeGenerate/page")]
        public async Task<dynamic> QueryCodeGenPageList([FromQuery] CodeGenInput input)
        {
            var tableName = !string.IsNullOrEmpty(input.TableName?.Trim());
            var codeGens = await _sysCodeGenRep.DetachedEntities
                                               .Where((tableName, u => EF.Functions.Like(u.TableName, $"%{input.TableName.Trim()}%")))
                                               .ToPagedListAsync(input.PageNo, input.PageSize);
            return XnPageResult<SysCodeGen>.PageResult(codeGens);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/codeGenerate/add")]
        public async Task AddCodeGen(AddCodeGenInput input)
        {
            var isExist = await _sysCodeGenRep.DetachedEntities.AnyAsync(u => u.TableName == input.TableName);
            if (isExist)
                throw Oops.Oh(ErrorCode.D1400);

            var codeGen = input.Adapt<SysCodeGen>();
            var newCodeGen = await codeGen.InsertNowAsync();

            // 加入配置表中
            _codeGenConfigService.AddList(GetColumnList(input), newCodeGen.Entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost("/codeGenerate/delete")]
        public async Task DeleteCodeGen(List<DeleteCodeGenInput> inputs)
        {
            if (inputs == null || inputs.Count < 1) return;

            var codeGenConfigTaskList = new List<Task>();
            inputs.ForEach(u =>
            {
                _sysCodeGenRep.Delete(u.Id);

                // 删除配置表中
                codeGenConfigTaskList.Add(_codeGenConfigService.Delete(u.Id));
            });
            await Task.WhenAll(codeGenConfigTaskList);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/codeGenerate/edit")]
        public async Task UpdateCodeGen(UpdateCodeGenInput input)
        {
            var isExist = await _sysCodeGenRep.DetachedEntities.AnyAsync(u => u.TableName == input.TableName && u.Id != input.Id);
            if (isExist)
                throw Oops.Oh(ErrorCode.D1400);

            var codeGen = input.Adapt<SysCodeGen>();
            await codeGen.UpdateAsync();
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/codeGenerate/detail")]
        public async Task<SysCodeGen> GetCodeGen([FromQuery] QueryCodeGenInput input)
        {
            return await _sysCodeGenRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取数据库表(实体)集合
        /// </summary>
        /// <returns></returns>

        [HttpGet("/codeGenerate/InformationList")]
        public List<TableOutput> GetTableList()
        {
            return Db.GetDbContext().Model.GetEntityTypes().Select(u => new TableOutput
            {
                TableName = u.GetDefaultTableName()
            }).ToList();
        }

        /// <summary>
        /// 获取数据表列（实体属性）集合
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public List<TableColumnOuput> GetColumnList(AddCodeGenInput input)
        {
            var entityType = Db.GetDbContext().Model.GetEntityTypes().FirstOrDefault(u => u.ClrType.Name == input.TableName);
            if (entityType == null) return null;

            return entityType.GetProperties().Select(u => new TableColumnOuput
            {
                ColumnName = u.Name,
                ColumnKey = u.IsKey().ToString(),
                DataType = u.PropertyInfo.PropertyType.ToString(),
                ColumnComment = u.GetComment()
            }).ToList();
        }

        /// <summary>
        /// 代码生成_本地项目
        /// </summary>
        /// <returns></returns>
        [HttpPost("/codeGenerate/runLocal")]
        public async void RunLocal(SysCodeGen input)
        {
            var tContent = File.ReadAllText(App.WebHostEnvironment.WebRootPath + "\\Template\\index.vue.vm");

            var codeGenConfigList = await _codeGenConfigService.List(new CodeGenConfig() { CodeGenId = input.Id });
            var tResult = _viewEngine.RunCompile(tContent, new
            {
                ClassName = input.TableName, // 类名
                QueryWhetherList = codeGenConfigList.Select(u => u.QueryWhether == YesOrNot.Y.ToString()), // 前端查询集合
                TableField = codeGenConfigList // 字段集合
            }); 

            File.WriteAllText("C:\\1.vue", tResult);

        }
    }
}
