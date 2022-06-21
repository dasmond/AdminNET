using Admin.NET.Core;
using Admin.NET.Core.Util.LowCode.Front.Code;
using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.Extras.Admin.NET.Entity;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.FriendlyException;
using Furion.ViewEngine;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using System.Text;

namespace Admin.NET.Application.CodeGen
{
    /// <summary>
    /// 代码生成器服务
    /// </summary>
    [Route("api/[Controller]")]
    [ApiDescriptionSettings(Name = "CodeGenerate", Order = 100)]
    public class CodeGenerateService : ICodeGenService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysCodeGen> _sysCodeGenRep; // 代码生成器仓储
        private readonly IRepository<SysLowCode> _sysLowCodeRep; // 代码生成器仓储
        private readonly ICodeGenConfigService _codeGenConfigService;
        private readonly IViewEngine _viewEngine;

        private readonly IRepository<SysMenu> _sysMenuRep; // 菜单表仓储

        public CodeGenerateService(IRepository<SysCodeGen> sysCodeGenRep,
                              IRepository<SysLowCode> sysLowCodeRep,
                              ICodeGenConfigService codeGenConfigService,
                              IViewEngine viewEngine,
                              IRepository<SysMenu> sysMenuRep)
        {
            _sysCodeGenRep = sysCodeGenRep;
            _sysLowCodeRep = sysLowCodeRep;
            _codeGenConfigService = codeGenConfigService;
            _viewEngine = viewEngine;
            _sysMenuRep = sysMenuRep;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public async Task<PageResult<SysCodeGen>> QueryCodeGenPageList([FromQuery] CodeGenPageInput input)
        {
            //if(input.)
            //// 加入配置表中
            //_codeGenConfigService.AddList(GetColumnList(input.Adapt<AddCodeGenInput>()), codeGen);

            var tableName = !string.IsNullOrEmpty(input.TableName?.Trim());
            var codeGens = await _sysCodeGenRep.DetachedEntities
                                               .Where((tableName, u => EF.Functions.Like(u.TableName, $"%{input.TableName.Trim()}%")))
                                               .ToADPagedListAsync(input.PageNo, input.PageSize);
            return codeGens;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task AddCodeGen(AddCodeGenInput input)
        {
            var isExist = await _sysCodeGenRep.DetachedEntities.AnyAsync(u => u.TableName == input.TableName);
            if (isExist)
                throw Oops.Oh(ErrorCode.D1400);

            if (input.LowCodeId != null && input.LowCodeId > 0)
            {
                isExist = await _sysCodeGenRep.DetachedEntities.AnyAsync(u => u.LowCodeId == input.LowCodeId);
            }

            if (!isExist)
            {
                var codeGen = input.Adapt<SysCodeGen>();
                var newCodeGen = await codeGen.InsertNowAsync();

                // 加入配置表中
                await _codeGenConfigService.DelAndAddList(GetColumnList(input), newCodeGen.Entity);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public Task DeleteCodeGen(List<DeleteCodeGenInput> inputs)
        {
            if (inputs == null || inputs.Count < 1) return Task.Run(() => { });

            var taskList = new List<Task>();
            inputs.ForEach(u =>
            {
                taskList.Add(_sysCodeGenRep.DeleteAsync(u.Id));
                    // 删除配置表中
                    taskList.Add(_codeGenConfigService.Delete(u.Id));
            });
            return Task.WhenAll(taskList);//等待所有任务完成
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task UpdateCodeGen(UpdateCodeGenInput input)
        {
            var isExist = await _sysCodeGenRep.DetachedEntities.AnyAsync(u => u.TableName == input.TableName && u.Id != input.Id);
            if (isExist)
                throw Oops.Oh(ErrorCode.D1400);

            var codeGen = input.Adapt<SysCodeGen>();

            // 加入配置表中
            _codeGenConfigService.DelAndAddList(GetColumnList(input.Adapt<AddCodeGenInput>()), codeGen);
        }

        /// <summary>
        /// 刷新配置表
        /// </summary>
        /// <returns></returns>
        [HttpGet("refresh/{id}")]
        public void Refresh(long id)
        {
            var item = _sysCodeGenRep.Where(x => x.Id == id).FirstOrDefault();
            // 加入配置表中
            _codeGenConfigService.DelAndAddList(GetColumnList(item.Adapt<AddCodeGenInput>()), item);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("detail")]
        public async Task<SysCodeGen> GetCodeGen([FromQuery] QueryCodeGenInput input)
        {
            return await _sysCodeGenRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取数据库库集合
        /// </summary>
        /// <returns></returns>
        [HttpGet("DatabaseList")]
        public List<DatabaseOutput> GetDatabaseList()
        {
            var DbContextLocators = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(
                            a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDbContextLocator)))
                        )
                        .Select(x => new DatabaseOutput { DatabaseName = x.Name, DatabaseComment = x.FullName })
                        .ToList();

            return DbContextLocators;
        }

        /// <summary>
        /// 获取数据库表(实体)集合
        /// </summary>
        /// <returns></returns>
        [HttpGet("InformationList")]
        public List<TableOutput> GetTableList(string dbContextLocatorName)
        {
            var dbContext = Db.GetDbContext();//默认数据库
            if (!string.IsNullOrEmpty(dbContextLocatorName))
            {
                var dbContentLocator = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDbContextLocator)))).Where(x => x.Name == dbContextLocatorName).FirstOrDefault();

                dbContext = Db.GetDbContext(dbContentLocator);
            }
            // 获取实体类型属性
            //var entityType = dbContext.Model.GetEntityTypes()要改成 var entityType = dbContext.GetService<IDesignTimeModel>().Model.GetEntityTypes()

            return dbContext.GetService<IDesignTimeModel>().Model.GetEntityTypes().Select(u => new TableOutput
            {
                DatabaseName = dbContextLocatorName,
                TableName = u.GetDefaultTableName(),
                TableComment = u.GetComment()
            }).ToList();
        }

        /// <summary>
        /// 根据表名获取列
        /// </summary>
        /// <returns></returns>
        [HttpGet("ColumnList/{databaseName}/{tableName}")]
        public List<TableColumnOuput> GetColumnListByTableName(string databaseName, string tableName)
        {
            var dbContext = Db.GetDbContext();//默认数据库
            if (!string.IsNullOrEmpty(databaseName))
            {
                var dbContentLocator = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDbContextLocator)))).Where(x => x.Name == databaseName).FirstOrDefault();

                dbContext = Db.GetDbContext(dbContentLocator);
            }
            // 获取实体类型属性
            var entityType = dbContext.GetService<IDesignTimeModel>().Model.GetEntityTypes().FirstOrDefault(u => u.ClrType.Name == tableName);
            if (entityType == null) return null;

            // 获取原始类型属性
            var type = entityType.ClrType;
            if (type == null) return null;

            // 按原始类型的顺序获取所有实体类型属性（不包含导航属性，会返回null）
            return type.GetProperties().Select(propertyInfo => entityType.FindProperty(propertyInfo.Name))
                       .Where(p => p != null).Select(p => new TableColumnOuput
                       {
                           ColumnName = p.Name,
                           ColumnKey = p.IsKey().ToString(),
                           DataType = p.PropertyInfo.PropertyType.ToString(),
                           NetType = CodeGenUtil.ConvertDataType(p.PropertyInfo.PropertyType.ToString()),
                           ColumnComment = p.GetComment()
                       }).ToList();
        }

        /// <summary>
        /// 获取数据表列（实体属性）集合
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public List<TableColumnOuput> GetColumnList([FromQuery] AddCodeGenInput input)
        {
            var dbContext = Db.GetDbContext();//默认数据库
            if (!string.IsNullOrEmpty(input.DatabaseName))
            {
                var dbContentLocator = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDbContextLocator)))).Where(x => x.Name == input.DatabaseName).FirstOrDefault();

                dbContext = Db.GetDbContext(dbContentLocator);
            }
            // 获取实体类型属性
            var entityType = dbContext.GetService<IDesignTimeModel>().Model.GetEntityTypes()
                .FirstOrDefault(u => u.ClrType.Name == input.TableName);
            if (entityType == null) return null;

            // 获取原始类型属性
            var type = entityType.ClrType;
            if (type == null) return null;

            // 按原始类型的顺序获取所有实体类型属性（不包含导航属性，会返回null）
            return type.GetProperties().Select(propertyInfo => entityType.FindProperty(propertyInfo.Name))
                       .Where(p => p != null)
                       .Select(p => new TableColumnOuput
                       {
                           ColumnName = p.Name,
                           ColumnKey = p.IsKey().ToString(),
                           DataType = p.PropertyInfo.PropertyType.ToString(),
                           ColumnComment = p.GetComment()
                       }).ToList();
        }

        /// <summary>
        /// 代码生成_本地项目
        /// </summary>
        /// <returns></returns>
        [HttpPost("runLocal")]
        public async Task RunLocal(SysCodeGen input)
        {
            var templatePathList = GetTemplatePathList();
            var targetPathList = GetTargetPathList(input);
            for (var i = 0; i < templatePathList.Count; i++)
            {
                var tContent = File.ReadAllText(templatePathList[i]);

               var tableFieldList = await _codeGenConfigService.List(new CodeGenConfig() { CodeGenId = input.Id }); // 字段集合

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

                if (i >= 6) // 适应前端首字母小写
                {
                    tableFieldList.ForEach(u =>
                    {
                        u.ColumnName = u.ColumnName.Substring(0, 1).ToLower() + u.ColumnName[1..];
                    });
                }

                var queryWhetherList = tableFieldList.Where(u => u.QueryWhether == YesOrNot.Y.ToString()).ToList(); // 前端查询集合

                string FormDesign = "";

                if (input.LowCodeId != null && input.LowCodeId > 0)
                {
                    FormDesign = _sysLowCodeRep.Where(x => x.Id == input.LowCodeId).Select(x => x.FormDesign).FirstOrDefault();
                }

                List<Front_Dynamic> dynamicLoad_dict = new List<Front_Dynamic>();
                Dictionary<string, List<string>> dynamicData = new Dictionary<string, List<string>>();

                if (!string.IsNullOrEmpty(FormDesign))
                {
                    try
                    {
                        var AllDynamic = FormDesign.ConvertToFront().AllFront().AllDynamic();

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
                    }
                    catch { }
                }

                try
                {
                    var tResult = _viewEngine.RunCompileFromCached(tContent, new
                    {
                        input.AuthorName,
                        input.BusName,
                        input.NameSpace,
                        input.ProName,
                        input.DatabaseName,
                        ClassName = input.TableName,
                        CamelizeClassName = input.TableName.Substring(0, 1).ToLower() + input.TableName[1..], //首字母小写
                        QueryWhetherList = queryWhetherList,
                        TableField = tableFieldList,
                        input.LowCodeId,
                        FormDesign,
                        DynamicData = JsonConvert.SerializeObject(dynamicData),
                        DynamicLoad_Dict = dynamicLoad_dict,
                        IsFile = tableFieldList.Where(x => x.DtoNetType.Contains("Front_FileDto")).Any(),
                        FileTableField = tableFieldList.Where(x => x.DtoNetType.Contains("Front_FileDto")).ToList()
                    });

                    var dirPath = new DirectoryInfo(targetPathList[i]).Parent.FullName;
                    if (!Directory.Exists(dirPath))
                        Directory.CreateDirectory(dirPath);
                    File.WriteAllText(targetPathList[i], tResult, Encoding.UTF8);
                }
                catch(Exception ex)
                {
                    throw Oops.Oh($"错误模板：{templatePathList[i]}。错误信息：{ex.Message}。");
                }
            }

            await AddMenu(input.DatabaseName.Substring(0, 5), input.TableName, input.BusName, input.MenuApplication, input.MenuPid);
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

        /// <summary>
        /// 获取模板文件路径集合
        /// </summary>
        /// <returns></returns>
        private List<string> GetTemplatePathList()
        {
            var templatePath = App.WebHostEnvironment.WebRootPath + @"\Template\";
            return new List<string>()
            {
                templatePath + "Service.cs.vm",
                templatePath + "IService.cs.vm",
                templatePath + "Input.cs.vm",
                templatePath + "Output.cs.vm",
                templatePath + "Dto.cs.vm",
                templatePath + "Mapper.cs.vm",
                templatePath + "index.vue.vm",
                templatePath + "addForm.vue.vm",
                templatePath + "editForm.vue.vm",
                templatePath + "Manage.js.vm",
            };
        }

        /// <summary>
        /// 设置生成文件路径
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<string> GetTargetPathList(SysCodeGen input)
        {
            var backendPath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.FullName + @"\" + input.NameSpace + @"\Service\" + input.TableName + @"\";
            var servicePath = backendPath + input.TableName + "Service.cs";
            var iservicePath = backendPath + "I" + input.TableName + "Service.cs";
            var inputPath = backendPath + @"Dto\" + input.TableName + "Input.cs";
            var outputPath = backendPath + @"Dto\" + input.TableName + "Output.cs";
            var viewPath = backendPath + @"Dto\" + input.TableName + "Dto.cs";
            var mapperPath = backendPath + @"Map\" + input.TableName + "Mapper.cs";
            var frontendPath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.Parent.FullName + @"\frontend\src\views\main\";
            var indexPath = frontendPath + input.TableName + @"\index.vue";
            var addFormPath = frontendPath + input.TableName + @"\addForm.vue";
            var editFormPath = frontendPath + input.TableName + @"\editForm.vue";
            var apiJsPath = new DirectoryInfo(App.WebHostEnvironment.ContentRootPath).Parent.Parent.FullName + @"\frontend\src\api\modular\main\" + input.TableName + "Manage.js";
            
            return new List<string>()
            {
                servicePath,
                iservicePath,
                inputPath,
                outputPath,
                viewPath,
                mapperPath,
                indexPath,
                addFormPath,
                editFormPath,
                apiJsPath
            };
        }
    }

}