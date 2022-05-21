using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.Extras.Admin.NET.Entity;
using Furion.Extras.Admin.NET.Service.LowCode.Dto;
using Furion.ViewEngine;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Furion.FriendlyException;
using Mapster;
using Furion.DatabaseAccessor.Extensions;
using Furion.Extras.Admin.NET.Util;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using System.Linq;
using System.Text;
using Furion.Extras.Admin.NET.Service.CodeGen;

namespace Furion.Extras.Admin.NET.Service.LowCode
{
    /// <summary>
    /// 低代码模块服务
    /// </summary>
    [ApiDescriptionSettings(Name = "LowCode", Order = 100)]
    [Route("api/lowcode")]
    public class LowCodeService : ILowCodeService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysLowCode> _sysLowCodeRep;
        private readonly IRepository<SysLowCodeDataBase> _sysLowCodeDataBaseRep;
        private readonly IViewEngine _viewEngine;
        private readonly ICodeGenService _codeGenService;

        public LowCodeService(IRepository<SysLowCode> sysLowCodeRep,
            IRepository<SysLowCodeDataBase> sysLowCodeDataBaseRep,
            ICodeGenService codeGenService,
                              IViewEngine viewEngine)
        {
            _sysLowCodeRep = sysLowCodeRep;
            _sysLowCodeDataBaseRep = sysLowCodeDataBaseRep;
            _codeGenService = codeGenService;
            _viewEngine = viewEngine;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("page")]
        public async Task<PageResult<SysLowCode>> QueryPageList([FromQuery] LowCodePageInput input)
        {
            var busName = !string.IsNullOrEmpty(input.BusName?.Trim());
            var lowCodes = await _sysLowCodeRep.DetachedEntities
                                    .Where((busName, u => EF.Functions.Like(u.BusName, $"%{input.BusName.Trim()}%")))
                                    .ToADPagedListAsync(input.PageNo, input.PageSize);
            return lowCodes;
        }

        /// <summary>
        /// 获取模块详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("info/{id}")]
        public SysLowCode Info(long id)
        {
            return _sysLowCodeRep.Where(x => x.Id == id).Include(x => x.Databases).FirstOrDefault();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("add")]
        public async Task Add(AddLowCodeInput input)
        {
            var isExist = await _sysLowCodeRep.DetachedEntities.AnyAsync(u => u.BusName == input.BusName);
            if (isExist)
                throw Oops.Oh(ErrorCode.D1600);

            var lowCode = input.Adapt<SysLowCode>();
            var newLowCode = await lowCode.InsertNowAsync();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("del")]
        public async Task Delete(List<DeleteLowCodeInput> inputs)
        {
            if (inputs == null || inputs.Count < 1) return;

            foreach(var u in inputs)
            {
                await _sysLowCodeRep.DeleteAsync(u.Id);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("edit")]
        public async Task Update(UpdateLowCodeInput input)
        {
            var lowCode = input.Adapt<SysLowCode>();
            await lowCode.UpdateAsync();

            await _sysLowCodeDataBaseRep.Context.DeleteRangeAsync<SysLowCodeDataBase>(x => x.SysLowCodeId == input.Id);
            await _sysLowCodeDataBaseRep.InsertAsync(lowCode.Databases);
        }

        /// <summary>
        /// 对比组件
        /// </summary>
        /// <param name="contrast"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("contrast")]
        public List<ContrastLowCode_Database> Contrast(ContrastLowCode contrast)
        {
            List<IFront> fronts = contrast.Controls.ConvertToFront().AllFront();

            DataCompareUtil<IFront, ContrastLowCode_Database> dataCompare 
                = new DataCompareUtil<IFront, ContrastLowCode_Database>(x => x.Key, x => x.Id);

            dataCompare.PushCompare(x => x.Key, x => x.Control_Key);
            dataCompare.PushCompare(x => x.Label, x => x.Control_Label);
            dataCompare.PushCompare(x => x.Model, x => x.Control_Model);
            dataCompare.PushCompare(x => x.Type, x => x.Control_Type);

            var compare = dataCompare.Compare(fronts, contrast.Databases);

            List<ContrastLowCode_Database> list = new List<ContrastLowCode_Database>();

            compare.NoContain_2.ForEach(item => {
                list.AddRange(item.ReadFront_BindDatabase(_sysLowCodeRep.ProviderName).Select(x => new ContrastLowCode_Database() { 
                    Control_Key = item.Key,
                    Control_Label = item.Label,
                    Control_Model = item.Model,
                    Control_Type = item.Type,
                    DbParam = x.DbParam,
                    DbType = x.DbType,
                    DbTypeName = x.DbType.Name,
                    FieldName = $"{item.Model}{x.Suffix}",
                    IsRequired = true,
                    Id = Guid.NewGuid(),
                    TableName = String.Empty,
                    ClassName = string.Empty,
                    TableDesc = string.Empty
                }));
            });

            return list;
        }

        /// <summary>
        /// 生成ORM模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("runLocal/{id}")]
        public bool RunLocal(long id)
        {
            var info = Info(id);

            var list = info.Databases.Select(x => new GenEntity() { 
                NameSpace = info.NameSpace,
                ClassName = x.ClassName,
                TableDesc = x.TableDesc,
                TableName = x.TableName,
                DatabaseName = info.DatabaseName
            }).Distinct(new GenEntityComparer()).ToList();

            list.ForEach(item =>
            {
                item.Fields = info.Databases.Where(x => x.ClassName == item.ClassName).Select(x => new GenEntity_Field()
                {
                    ColumnComment = x.Control_Label,
                    DbParam = x.DbParam,
                    FieldName = x.FieldName,
                    IsRequired = x.IsRequired == null ? false : x.IsRequired.Value,
                    NetType = x.DbTypeName
                }).ToList();
            });

            var templatePathList = GetTemplatePathList();
            list.ForEach(item =>
            {
                var targetPathList = GetTargetPathList(item);

                for (var i = 0; i < templatePathList.Count; i++)
                {
                    var tContent = File.ReadAllText(templatePathList[i]);

                    var tResult = _viewEngine.RunCompileFromCached(tContent, new {
                        TableName = item.TableName,
                        NameSpace = item.NameSpace,
                        Fields = item.Fields.Select(x => new { x.ColumnComment, x.DbParam, x.FieldName, x.IsRequired, x.NetType }).ToList(),
                        ClassName = item.ClassName,
                        TableDesc = item.TableDesc,
                        DatabaseName = item.DatabaseName
                    });

                    var dirPath = new DirectoryInfo(targetPathList[i]).Parent.FullName;
                    if (!Directory.Exists(dirPath))
                        Directory.CreateDirectory(dirPath);
                    File.WriteAllText(targetPathList[i], tResult, Encoding.UTF8);
                }

                _codeGenService.AddCodeGen(new AddCodeGenInput()
                {
                    LowCodeId = id,
                    NameSpace = info.NameSpace,
                    AuthorName = info.AuthorName,
                    BusName = info.BusName,
                    ClassName = item.ClassName,
                    DatabaseName = info.DatabaseName,
                    GenerateType = info.GenerateType,
                    MenuApplication = info.MenuApplication,
                    MenuPid = info.MenuPid,
                    TableComment = item.TableDesc,
                    TableName = item.TableName,
                    TablePrefix = null
                }).Wait();
            });

            

            return true;
        }

        private List<string> GetTemplatePathList()
        {
            var templatePath = App.WebHostEnvironment.WebRootPath + @"\Template\";
            return new List<string>()
            {
                templatePath + "Entity.cs.vm"
            };
        }

        /// <summary>
        /// 设置生成文件路径
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<string> GetTargetPathList(GenEntity input)
        {
            var backendPath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.FullName + @"\" + input.NameSpace + @"\Entity\";
            var outputPath = backendPath + @"\" + input.ClassName + ".cs";

            return new List<string>()
            {
                outputPath
            };
        }
    }
}
