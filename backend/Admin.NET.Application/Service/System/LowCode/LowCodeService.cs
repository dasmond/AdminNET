using Admin.NET.Application;
using Admin.NET.Application.CodeGen;
using Admin.NET.Application.Service.System.LowCode.Dto;
using Admin.NET.Core;
using Admin.NET.Core.Util.LowCode.Front.Code;
using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.Extras.Admin.NET.Entity;
using Furion.Extras.Admin.NET.Service.LowCode.Dto;
using Furion.Extras.Admin.NET.Util;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.FriendlyException;
using Furion.ViewEngine;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using NString;

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
        private readonly IRepository<SysMenu> _sysMenuRep; // 菜单表仓储
        private readonly IConfiguration _configuration;
        private readonly IViewEngine _viewEngine;

        public LowCodeService(IRepository<SysLowCode> sysLowCodeRep,
            IRepository<SysLowCodeDataBase> sysLowCodeDataBaseRep,
            IRepository<SysMenu> sysMenuRep,
            IConfiguration configuration,
            IViewEngine viewEngine)
        {
            _sysLowCodeRep = sysLowCodeRep;
            _sysLowCodeDataBaseRep = sysLowCodeDataBaseRep;
            _sysMenuRep = sysMenuRep;
            _configuration = configuration;
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

            foreach (var u in inputs)
            {
                _sysLowCodeDataBaseRep.Where(x => x.SysLowCodeId == u.Id).DeleteRange(_sysLowCodeDataBaseRep.Context);
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
        public ContrasOutput Contrast(ContrastLowCode contrast)
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

            var tables = contrast.Databases.Where(x => !string.IsNullOrEmpty(x.TableName) && !string.IsNullOrEmpty(x.TableName))
                .Select(x => new { x.TableName, x.ClassName, x.TableDesc })
                .Distinct()
                .ToList();


            if(tables.Count != 1)
            {
                tables.Clear();
            }

            compare.NoContain_2.ForEach(item => {
                list.AddRange(item.ReadFront_BindDatabase(_sysLowCodeRep.ProviderName).Select(x => new ContrastLowCode_Database()
                {
                    Control_Key = item.Key,
                    Control_Label = item.Label,
                    Control_Model = item.Model,
                    Control_Type = item.Type,
                    DbParam = x.DbParam,
                    DbType = x.DbType,
                    DbTypeName = x.DbType.Name,
                    DtoTypeName = x.DtoType == null ? x.DbType.Name : x.DtoType.Name,
                    FieldName = $"{item.Model}{x.Suffix}",
                    IsRequired = true,
                    Id = Guid.NewGuid(),
                    TableName = tables.Select(x => x.TableName).FirstOrDefault(),
                    ClassName = tables.Select(x => x.ClassName).FirstOrDefault(),
                    TableDesc = tables.Select(x => x.TableDesc).FirstOrDefault(),
                    QueryType = "equery",
                    QueryWhether = true,
                    whetherAddUpdate = true,
                    WhetherOrderBy = true,
                    WhetherTable = true
                }));
            });

            return new ContrasOutput() { 
                Add = list,
                Del = compare.NoContain_1
            };
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("runLocal/{id}")]
        public async Task<bool> RunLocal(long id)
        {
            var info = Info(id);

            var list = info.Databases.Select(x => new GenEntity()
            {
                NameSpace = info.NameSpace,
                ClassName = x.ClassName,
                TableDesc = x.TableDesc,
                TableName = x.TableName,
                DatabaseName = info.DatabaseName,
                AuthorName = info.AuthorName,
                BusName = info.BusName,
                ProName = info.ProName,
                FormDesign = info.FormDesign
            }).Distinct(new GenEntityComparer()).ToList();

            list.ForEach(item =>
            {
                item.DataBase = info.Databases.ToList();
                item.Fields = info.Databases.Where(x => x.ClassName == item.ClassName).Select(x => new GenEntity_Field()
                {
                    ColumnComment = x.Control_Label,
                    DbParam = x.DbParam,
                    FieldName = x.FieldName,
                    IsRequired = x.IsRequired == null ? false : x.IsRequired.Value,
                    NetType = x.DbTypeName,
                    DtoNetType = x.DtoTypeName == null ? x.DbTypeName : x.DtoTypeName,
                }).ToList();
            });

            string TableName = string.Empty;

            list.ForEach(item =>
            {
                TableName = item.TableName;

                var AllDynamic = item.FormDesign.ConvertToFront().AllFront().AllDynamic();
                Dictionary<string, List<string>> dynamicData = new Dictionary<string, List<string>>();
                List<Front_Dynamic> dynamicLoad_dict = new List<Front_Dynamic>();

                AllDynamic.Where(x => x.Dynamic).Select(x => x.DynamicKey).ToList().ForEach(item =>
                {
                    dynamicData.Add(item, new List<string>());
                    var d = item.GetDynamic();
                    if (d != null)
                    {
                        if (d.Head == "dict")
                        {
                            dynamicLoad_dict.Add(d);
                        }
                    }
                });


                List<CodeGenConfig> tableFieldList = item.DataBase.Select(x => new CodeGenConfig()
                {
                    ColumnComment = x.Control_Label,
                    ColumnKey = String.Empty,
                    ColumnName = x.FieldName,
                    DataType = x.DbTypeName,
                    DtoNetType = x.DtoTypeName,
                    NetType = x.DbTypeName,
                    OriginalColumnName = x.FieldName,
                    QueryType = x.QueryType,
                    QueryWhether = x.QueryWhether.HasValue && x.QueryWhether.Value ? YesOrNot.Y.ToString() : YesOrNot.N.ToString(),
                    WhetherAddUpdate = x.WhetherAddUpdate.HasValue && x.WhetherAddUpdate.Value ? YesOrNot.Y.ToString() : YesOrNot.N.ToString(),
                    WhetherOrderBy = x.WhetherOrderBy.HasValue && x.WhetherOrderBy.Value ? YesOrNot.Y.ToString() : YesOrNot.N.ToString(),
                    WhetherRequired = x.IsRequired.HasValue && x.IsRequired.Value ? YesOrNot.Y.ToString() : YesOrNot.N.ToString(),
                    WhetherTable = x.WhetherTable.HasValue && x.WhetherTable.Value ? YesOrNot.Y.ToString() : YesOrNot.N.ToString(),
                    WhetherRetract = YesOrNot.N.ToString(),
                    WhetherCommon = YesOrNot.Y.ToString(),
                    NetTypeIsNullLable = String.Empty,
                    Id = 0,
                    FkEntityName = null,
                    FkColumnNetType = null,
                    FkColumnName = null,
                    EffectType = null,
                    DictTypeCode = null,
                    CodeGen = null,
                    CodeGenId = 0,
                }).ToList();

                tableFieldList.Add(new CodeGenConfig()
                {
                    ColumnComment = "Id",
                    ColumnKey = "True",
                    ColumnName = "Id",
                    DataType = null,
                    DtoNetType = "long",
                    NetType = "long",
                    OriginalColumnName = "Id",
                    QueryType = null,
                    QueryWhether = YesOrNot.N.ToString(),
                    WhetherAddUpdate = YesOrNot.N.ToString(),
                    WhetherOrderBy = YesOrNot.N.ToString(),
                    WhetherRequired = YesOrNot.N.ToString(),
                    WhetherTable = YesOrNot.N.ToString(),
                    WhetherRetract = YesOrNot.N.ToString(),
                    WhetherCommon = YesOrNot.Y.ToString(),
                    NetTypeIsNullLable = String.Empty,
                    Id = 0,
                    FkEntityName = null,
                    FkColumnNetType = null,
                    FkColumnName = null,
                    EffectType = null,
                    DictTypeCode = null,
                    CodeGen = null,
                    CodeGenId = 0,
                });

                tableFieldList.ForEach(u =>
                {
                    switch (u.NetType.ToLower())
                    {
                        case "int":
                        case "int32":
                        case "long":
                        case "guid":
                        case "decimal":
                        case "datetime":
                        case "datetimeoffset":
                            u.NetTypeIsNullLable = "?";
                            break;
                    }
                    u.OriginalColumnName = u.ColumnName;
                });

                var queryWhetherList = tableFieldList.Where(u => u.QueryWhether == YesOrNot.Y.ToString()).ToList(); // 前端查询集合

                var ss = App.Configuration.GetSection("CodeGenConfig");

                int config_index = 0;
                string ResultHead = "@model Admin.NET.Application.Service.System.LowCode.Dto.Front_CodeGenerate\r\n";
                while (!string.IsNullOrEmpty(_configuration.GetValue<string>($"LowCodeConfig:{config_index}:Name")))
                {
                    var config_data = new {
                        HostPath = App.WebHostEnvironment.WebRootPath,
                        CodePath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.FullName,
                        FrontendPath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.Parent.FullName + @"\frontend\src\views\main\",
                        ApiJsPath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.Parent.FullName + @"\frontend\src\api\modular\main\",
                        NameSpace = item.NameSpace,
                        ClassName = item.ClassName
                    };
                    var SourceFile = StringTemplate.Format(_configuration.GetValue<string>($"LowCodeConfig:{config_index}:Source:File"), config_data);
                    var TargetFile = StringTemplate.Format(_configuration.GetValue<string>($"LowCodeConfig:{config_index}:Target:File"), config_data);
                    var TargetDir = StringTemplate.Format(_configuration.GetValue<string>($"LowCodeConfig:{config_index}:Target:Dir"), config_data);
                    var IsFrontend = _configuration.GetValue<bool?>($"LowCodeConfig:{config_index}:IsFrontend");

                    if (IsFrontend.HasValue && IsFrontend.Value == true) // 适应前端首字母小写
                    {
                        tableFieldList.ForEach(u =>
                        {
                            u.ColumnName = u.ColumnName.Substring(0, 1).ToLower() + u.ColumnName[1..];
                        });
                    }

                    #region 执行代码生成
                    var tContent = File.ReadAllText(SourceFile);

                    if (tContent.IndexOf(ResultHead) == 0) tContent = tContent.Substring(ResultHead.Length);

                    var data = new
                    {
                        TableName = item.TableName,
                        NameSpace = item.NameSpace,
                        Fields = item.Fields,
                        ClassName = item.ClassName,
                        TableDesc = item.TableDesc,
                        DatabaseName = item.DatabaseName,
                        AuthorName = item.AuthorName,
                        BusName = item.BusName,
                        ProName = item.ProName,
                        CamelizeClassName = item.TableName.Substring(0, 1).ToLower() + item.TableName[1..], //首字母小写
                        QueryWhetherList = queryWhetherList,
                        TableField = tableFieldList,
                        LowCodeId = id,
                        FormDesign = item.FormDesign,
                        DynamicData = JsonConvert.SerializeObject(dynamicData),
                        DynamicLoad_Dict = dynamicLoad_dict,
                        IsFile = tableFieldList.Where(x => x.DtoNetType.Contains("Front_FileDto")).Any(),
                        FileTableField = tableFieldList.Where(x => x.DtoNetType.Contains("Front_FileDto")).ToList()
                    };

                    var tResult = _viewEngine.RunCompileFromCached(tContent, data);
                    if (!Directory.Exists(TargetDir)) Directory.CreateDirectory(TargetDir);
                    File.WriteAllText($"{TargetDir}{TargetFile}", tResult, Encoding.UTF8);
                    #endregion

                    config_index++;
                }

            });

            if (!string.IsNullOrEmpty(TableName))
            {
                await AddMenu(info.DatabaseName.Substring(0, 5), TableName, info.BusName, info.MenuApplication, info.MenuPid);
            }

            return true;
        }

        private async Task AddMenu(string menucodePre, string className, string busName, string application, long pid)
        {
            // 定义菜单编码前缀
            var codePrefix = menucodePre + "_" + className.ToLower();//改为取数据库定位器的前五个字母方便区分业务 //"dilon_" + className.ToLower();

            // 先删除该表已生成的菜单列表
            var menus = await _sysMenuRep.DetachedEntities.Where(u => u.Code == codePrefix || u.Code.StartsWith(codePrefix + "_")).ToListAsync();
            await _sysMenuRep.DeleteAsync(menus);

            // 如果 pid 为 0 说明为顶级菜单, 需要创建顶级目录
            if (pid == 0)
            {
                // 目录
                var menuType0 = new SysMenu
                {
                    Pid = 0,
                    Pids = "[0],",
                    Name = busName + "管理",
                    Code = codePrefix,
                    Type = MenuType.DIR,
                    Icon = "robot",
                    Router = "/" + className.ToLower(),
                    Component = "PageView",
                    Application = application
                };
                pid = _sysMenuRep.InsertNowAsync(menuType0).GetAwaiter().GetResult().Entity.Id;
            }
            // 由于后续菜单会有修改, 需要判断下 pid 是否存在, 不存在报错
            else if (!await _sysMenuRep.DetachedEntities.AnyAsync(e => e.Id == pid))
                throw Oops.Oh(ErrorCode.D1505);

            // 菜单
            var menuType1 = new SysMenu
            {
                Pid = pid,
                Pids = "[0],[" + pid + "],",
                Name = busName + "管理",
                Code = codePrefix + "_mgr",
                Type = MenuType.MENU,
                Router = "/" + className.ToLower(),
                Component = "main/" + className + "/index",
                Application = application,
                OpenType = MenuOpenType.COMPONENT
            };
            var pid1 = _sysMenuRep.InsertNowAsync(menuType1).GetAwaiter().GetResult().Entity.Id;

            // 按钮-page
            var menuType2 = new SysMenu
            {
                Pid = pid1,
                Pids = "[0],[" + pid + "],[" + pid1 + "],",
                Name = busName + "查询",
                Code = codePrefix + "_mgr_page",
                Type = MenuType.BTN,
                Permission = className + ":page",
                Application = application,
            }.InsertAsync();

            // 按钮-detail
            var menuType2_1 = new SysMenu
            {
                Pid = pid1,
                Pids = "[0],[" + pid + "],[" + pid1 + "],",
                Name = busName + "详情",
                Code = codePrefix + "_mgr_detail",
                Type = MenuType.BTN,
                Permission = className + ":detail",
                Application = application,
            }.InsertAsync();

            // 按钮-add
            var menuType2_2 = new SysMenu
            {
                Pid = pid1,
                Pids = "[0],[" + pid + "],[" + pid1 + "],",
                Name = busName + "增加",
                Code = codePrefix + "_mgr_add",
                Type = MenuType.BTN,
                Permission = className + ":add",
                Application = application,
            }.InsertAsync();

            // 按钮-delete
            var menuType2_3 = new SysMenu
            {
                Pid = pid1,
                Pids = "[0],[" + pid + "],[" + pid1 + "],",
                Name = busName + "删除",
                Code = codePrefix + "_mgr_delete",
                Type = MenuType.BTN,
                Permission = className + ":delete",
                Application = application,
            }.InsertAsync();

            // 按钮-edit
            var menuType2_4 = new SysMenu
            {
                Pid = pid1,
                Pids = "[0],[" + pid + "],[" + pid1 + "],",
                Name = busName + "编辑",
                Code = codePrefix + "_mgr_edit",
                Type = MenuType.BTN,
                Permission = className + ":edit",
                Application = application,
            }.InsertAsync();
        }

        private List<string> GetTemplatePathList()
        {
            var templatePath = App.WebHostEnvironment.WebRootPath + @"\Template\";
            return new List<string>()
            {
                templatePath + "Entity.cs.cshtml"
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
