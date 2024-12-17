// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core.Service;

/// <summary>
/// 系统字典类型服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 430)]
public class SysDictTypeService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysDictType> _sysDictTypeRep;
    private readonly SysDictDataService _sysDictDataService;
    private readonly SysCacheService _sysCacheService;
    private readonly UserManager _userManager;

    public SysDictTypeService(SqlSugarRepository<SysDictType> sysDictTypeRep,
        SysDictDataService sysDictDataService,
        SysCacheService sysCacheService,
        UserManager userManager)
    {
        _sysDictTypeRep = sysDictTypeRep;
        _sysDictDataService = sysDictDataService;
        _sysCacheService = sysCacheService;
        _userManager = userManager;
    }

    /// <summary>
    /// 获取字典类型分页列表 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取字典类型分页列表")]
    public async Task<SqlSugarPagedList<SysDictType>> Page(PageDictTypeInput input)
    {
        return await _sysDictTypeRep.AsQueryable()
            .WhereIF(!_userManager.SuperAdmin, u => !SqlFunc.EndsWith(SqlFunc.ToLower(u.Code), nameof(Enum).ToLower()))
            .WhereIF(_userManager.SuperAdmin && input.TenantId > 0, u => u.TenantId ==  input.TenantId)
            .WhereIF(!string.IsNullOrEmpty(input.Code?.Trim()), u => u.Code.Contains(input.Code))
            .WhereIF(!string.IsNullOrEmpty(input.Name?.Trim()), u => u.Name.Contains(input.Name))
            .OrderBy(u => new { u.OrderNo, u.Code })
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 获取字典类型列表 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取字典类型列表")]
    public async Task<List<SysDictType>> GetList()
    {
        return await GetSysDictDataQueryable().OrderBy(u => new { u.OrderNo, u.Code }).ToListAsync();
    }

    /// <summary>
    /// 获取字典类型-值列表 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("获取字典类型-值列表")]
    public async Task<List<SysDictData>> GetDataList([FromQuery] GetDataDictTypeInput input)
    {
        var dictType = await GetSysDictDataQueryable().FirstAsync(u => u.Code == input.Code) ?? throw Oops.Oh(ErrorCodeEnum.D3000);
        return await _sysDictDataService.GetDictDataListByDictTypeId(dictType.Id);
    }

    /// <summary>
    /// 添加字典类型 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Add"), HttpPost]
    [DisplayName("添加字典类型")]
    public async Task AddDictType(AddDictTypeInput input)
    {
        if (input.Code.ToLower().EndsWith(nameof(Enum).ToLower())) throw Oops.Oh(ErrorCodeEnum.D3006);

        var isExist = await _sysDictTypeRep.AsQueryable().ClearFilter().AnyAsync(u => u.Code == input.Code);
        if (isExist) throw Oops.Oh(ErrorCodeEnum.D3001);

        await _sysDictTypeRep.InsertAsync(input.Adapt<SysDictType>());
    }

    /// <summary>
    /// 更新字典类型 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [ApiDescriptionSettings(Name = "Update"), HttpPost]
    [DisplayName("更新字典类型")]
    public async Task UpdateDictType(UpdateDictTypeInput input)
    {
        var dict = await _sysDictTypeRep.GetFirstAsync(x => x.Id == input.Id);
        if (dict == null) throw Oops.Oh(ErrorCodeEnum.D3000);

        if (dict.Code.ToLower().EndsWith(nameof(Enum).ToLower()) && input.Code != dict.Code) throw Oops.Oh(ErrorCodeEnum.D3007);

        var isExist = await _sysDictTypeRep.AsQueryable().ClearFilter().AnyAsync(u => u.Code == input.Code && u.Id != input.Id);
        if (isExist) throw Oops.Oh(ErrorCodeEnum.D3001);

        _sysCacheService.Remove($"{CacheConst.KeyDict}{input.Code}");
        await _sysDictTypeRep.UpdateAsync(input.Adapt<SysDictType>());
    }

    /// <summary>
    /// 删除字典类型 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [ApiDescriptionSettings(Name = "Delete"), HttpPost]
    [DisplayName("删除字典类型")]
    public async Task DeleteDictType(DeleteDictTypeInput input)
    {
        var dictType = await _sysDictTypeRep.GetByIdAsync(input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D3000);

        // 删除字典值
        await _sysDictTypeRep.DeleteAsync(dictType);
        await _sysDictDataService.DeleteDictData(input.Id);
    }

    /// <summary>
    /// 获取字典类型详情 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("获取字典类型详情")]
    public async Task<SysDictType> GetDetail([FromQuery] DictTypeInput input)
    {
        return await _sysDictTypeRep.GetByIdAsync(input.Id);
    }

    /// <summary>
    /// 修改字典类型状态 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [DisplayName("修改字典类型状态")]
    public async Task SetStatus(DictTypeInput input)
    {
        var dictType = await _sysDictTypeRep.GetByIdAsync(input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D3000);

        _sysCacheService.Remove($"{CacheConst.KeyDict}{dictType.Code}");

        dictType.Status = input.Status;
        await _sysDictTypeRep.AsUpdateable(dictType).UpdateColumns(u => new { u.Status }, true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取所有字典集合 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取所有字典集合")]
    public async Task<dynamic> GetAllDictList()
    {
        var ds = await GetSysDictDataQueryable().ClearFilter()
            .InnerJoin<SysDictData>((u, a) => u.Id == a.DictTypeId)
            .Where((u, a) => u.IsDelete == false && u.Status == StatusEnum.Enable && a.IsDelete == false && a.Status == StatusEnum.Enable)
            .Select((u, a) => new { TypeCode = u.Code, a.Label, a.Value, a.Name, a.TagType, a.StyleSetting, a.ClassSetting, a.ExtData, a.Remark, a.OrderNo, a.Status })
            .ToListAsync();
        return ds.OrderBy(u => u.OrderNo).GroupBy(u => u.TypeCode).ToDictionary(u => u.Key, u => u);
    }
    
    /// <summary>
    /// 获取SysDictData表查询实例
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public ISugarQueryable<SysDictType> GetSysDictDataQueryable()
    {
        var ids = GetTenantIdList();
        return _sysDictTypeRep.AsQueryable().ClearFilter().WhereIF(!_userManager.SuperAdmin, u => ids.Contains(u.TenantId.Value));
    }
    
    /// <summary>
    /// 获取租户Id列表
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public List<long> GetTenantIdList()
    {
        List<long> tenantIdList = new() { SqlSugarConst.DefaultTenantId };
        if (_userManager.TenantId > 0) tenantIdList.Add(_userManager.TenantId);
        return tenantIdList;
    }
}