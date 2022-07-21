using Admin.NET.Core;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.Extras.Admin.NET.Entity;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Application
{
    /// <summary>
    /// 代码生成详细配置服务
    /// </summary>
    [ApiDescriptionSettings(Name = "CodeGenConfig", Order = 100)]
    [Route("api")]
    public class SysCodeGenerateConfigService : ICodeGenConfigService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysLowCodeDataBase> _sysLowCodeRep; // 代码生成器仓储
        private readonly IRepository<SysCodeGen> _sysCodeGenRep; // 代码生成器仓储
        private readonly IRepository<SysCodeGenConfig> _sysCodeGenConfigRep; // 代码生成详细配置仓储

        public SysCodeGenerateConfigService(IRepository<SysCodeGenConfig> sysCodeGenConfigRep, IRepository<SysCodeGen> sysCodeGenRep
            , IRepository<SysLowCodeDataBase> sysLowCodeRep
            )
        {
            _sysLowCodeRep = sysLowCodeRep;
            _sysCodeGenConfigRep = sysCodeGenConfigRep;
            _sysCodeGenRep = sysCodeGenRep;
        }

        /// <summary>
        /// 代码生成详细配置列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("sysCodeGenerateConfig/list")]
        public async Task<List<CodeGenConfig>> List([FromQuery] CodeGenConfig input)
        {
            var result = await _sysCodeGenConfigRep.DetachedEntities
                                             .Where(u => u.CodeGenId == input.CodeGenId && u.WhetherCommon != YesOrNot.Y.ToString())
                                             .ProjectToType<CodeGenConfig>()
                                             .Distinct()
                                             .ToListAsync();

            var codeGen = await _sysCodeGenRep.FirstOrDefaultAsync(x => x.Id == input.CodeGenId);
            var codeGenOutput = codeGen.Adapt<CodeGenOutput>();
            result.ForEach(x => x.CodeGen = codeGenOutput);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        [HttpPost("sysCodeGenerateConfig/edit")]
        public async Task Update(List<CodeGenConfig> inputList)
        {
            if (inputList == null || inputList.Count < 1) return;
            var list = inputList.Adapt<List<SysCodeGenConfig>>();
            await _sysCodeGenConfigRep.UpdateAsync(list);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("·/detail")]
        public async Task<SysCodeGenConfig> Detail([FromQuery] CodeGenConfig input)
        {
            return await _sysCodeGenConfigRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="tableColumnOuputList"></param>
        /// <param name="codeGenerate"></param>
        [NonAction]
        public async Task DelAndAddList(List<TableColumnOuput> tableColumnOuputList, SysCodeGen codeGenerate)
        {
            if (tableColumnOuputList == null) return;
            var list = new List<SysCodeGenConfig>();

            List<SysLowCodeDataBase> list_LowCode = new List<SysLowCodeDataBase>();

            if (codeGenerate != null && codeGenerate.LowCodeId > 0 && _sysLowCodeRep.Where(x => x.SysLowCodeId == codeGenerate.LowCodeId).Any())
            {
                list_LowCode = _sysLowCodeRep.Where(x => x.SysLowCodeId == codeGenerate.LowCodeId).ToList();
            }

            foreach (var tableColumn in tableColumnOuputList)
            {
                var codeGenConfig = new SysCodeGenConfig();

                var YesOrNo = YesOrNot.Y.ToString();
                if (Convert.ToBoolean(tableColumn.ColumnKey))
                {
                    YesOrNo = YesOrNot.N.ToString();
                }

                if (CodeGenUtil.IsCommonColumn(tableColumn.ColumnName))
                {
                    codeGenConfig.WhetherCommon = YesOrNot.Y.ToString();
                    YesOrNo = YesOrNot.N.ToString();
                }
                else
                {
                    codeGenConfig.WhetherCommon = YesOrNot.N.ToString();
                }

                codeGenConfig.CodeGenId = codeGenerate.Id;
                codeGenConfig.ColumnName = tableColumn.ColumnName;
                codeGenConfig.ColumnComment = tableColumn.ColumnComment;
                codeGenConfig.NetType = CodeGenUtil.ConvertDataType(tableColumn.DataType);
                codeGenConfig.DtoNetType = list_LowCode.Where(x => x.FieldName == tableColumn.ColumnName).Select(x => x.DtoTypeName).FirstOrDefault();
                if (string.IsNullOrEmpty(codeGenConfig.DtoNetType)) codeGenConfig.DtoNetType = codeGenConfig.NetType;
                codeGenConfig.WhetherRetract = YesOrNot.N.ToString();

                codeGenConfig.WhetherRequired = YesOrNot.N.ToString();
                codeGenConfig.QueryWhether = YesOrNo;
                codeGenConfig.WhetherAddUpdate = YesOrNo;
                codeGenConfig.WhetherTable = YesOrNo;
                codeGenConfig.WhetherOrderBy = YesOrNo;

                codeGenConfig.ColumnKey = tableColumn.ColumnKey;

                codeGenConfig.DataType = tableColumn.DataType;
                codeGenConfig.EffectType = CodeGenUtil.DataTypeToEff(codeGenConfig.NetType);
                codeGenConfig.QueryType = "=="; // QueryTypeEnum.eq.ToString();

                list.Add(codeGenConfig);
            }

            _sysCodeGenConfigRep.Context.DeleteRange<SysCodeGenConfig>(x => x.CodeGenId == codeGenerate.Id);

            await _sysCodeGenConfigRep.InsertAsync(list);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NonAction]
        public async Task Add(CodeGenConfig input)
        {
            var codeGenConfig = input.Adapt<SysCodeGenConfig>();
            await codeGenConfig.InsertAsync();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="codeGenId"></param>
        /// <returns></returns>
        [NonAction]
        public async Task Delete(long codeGenId)
        {
            var codeGenConfigList = await _sysCodeGenConfigRep.Where(u => u.CodeGenId == codeGenId).ToListAsync();
            await _sysCodeGenConfigRep.DeleteAsync(codeGenConfigList);
        }
    }
}