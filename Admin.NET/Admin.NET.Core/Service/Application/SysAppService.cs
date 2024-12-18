// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core.Service;

/// <summary>
/// 系统应用服务 🧩
/// </summary>
[ApiDescriptionSettings(Name = "SysApp", Order = 495)]
public class SysAppService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysAppMenu> _sysAppMenuRep;
    private readonly SqlSugarRepository<SysApp> _sysAppRep;
    private readonly SysAuthService _sysAuthService;
    private readonly UserManager _userManager;

    public SysAppService(SqlSugarRepository<SysApp> sysAppRep, SqlSugarRepository<SysAppMenu> sysAppMenuRep, SysAuthService sysAuthService, UserManager userManager)
    {
        _sysAppRep = sysAppRep;
        _userManager = userManager;
        _sysAppMenuRep = sysAppMenuRep;
        _sysAuthService = sysAuthService;
    }

    /// <summary>
    /// 分页查询应用 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("分页查询应用")]
    [ApiDescriptionSettings(Name = "Page"), HttpPost]
    public async Task<SqlSugarPagedList<SysAppOutput>> Page(BasePageInput input)
    {
        input.Keyword = input.Keyword?.Trim();
        var query = _sysAppRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.Keyword), u => u.Name.Contains(input.Keyword) ||
               u.Title.Contains(input.Keyword) || u.ViceTitle.Contains(input.Keyword) ||
               u.ViceDesc.Contains(input.Keyword) || u.Remark.Contains(input.Keyword))
            .OrderBy(u => new { u.OrderNo, u.Id })
            .Select<SysAppOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加应用 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("增加应用")]
    [ApiDescriptionSettings(Name = "Add"), HttpPost]
    public async Task<long> Add(AddSysAppInput input)
    {
        var entity = input.Adapt<SysApp>();
        return await _sysAppRep.InsertAsync(entity) ? entity.Id : 0;
    }

    /// <summary>
    /// 更新应用 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("更新应用")]
    [ApiDescriptionSettings(Name = "Update"), HttpPost]
    public async Task Update(UpdateSysAppInput input)
    {
        _ = await _sysAppRep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);

        var entity = input.Adapt<SysApp>();
        await _sysAppRep.AsUpdateable(entity).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除应用 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("删除应用")]
    [ApiDescriptionSettings(Name = "Delete"), HttpPost]
    public async Task Delete(BaseIdInput input)
    {
        var entity = await _sysAppRep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);

        // 禁止删除存在关联租户的应用
        if (await _sysAppRep.Context.Queryable<SysTenant>().AnyAsync(u => u.AppId == input.Id)) throw Oops.Oh(ErrorCodeEnum.A1001);

        // 禁止删除存在关联菜单的应用
        if (await _sysAppMenuRep.AsQueryable().AnyAsync(u => u.AppId == input.Id)) throw Oops.Oh(ErrorCodeEnum.A1002);

        await _sysAppRep.DeleteAsync(entity);
    }

    /// <summary>
    /// 获取授权菜单 🔖
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [UnitOfWork]
    [DisplayName("获取授权菜单")]
    [ApiDescriptionSettings(Name = "GrantMenu"), HttpGet]
    public async Task<List<long>> GrantMenu([FromQuery] long id)
    {
        return await _sysAppMenuRep.AsQueryable().Where(u => u.AppId == id).Select(u => u.MenuId).ToListAsync();
    }

    /// <summary>
    /// 授权菜单 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [DisplayName("授权菜单")]
    [ApiDescriptionSettings(Name = "GrantMenu"), HttpPost]
    public async Task GrantMenu(UpdateAppMenuInput input)
    {
        input.MenuIdList ??= new();

        await _sysAppMenuRep.DeleteAsync(u => u.AppId == input.Id);

        var list = input.MenuIdList.Select(id => new SysAppMenu { AppId = input.Id, MenuId = id }).ToList();

        await _sysAppMenuRep.InsertRangeAsync(list);

        // 清除应用下其他模块越权的授权数据，包括角色菜单，用户收藏菜单
        var tenantIds = await _sysAppRep.Context.Queryable<SysTenant>().Where(u => u.AppId == input.Id).Select(u => u.Id).ToListAsync();
        var roleIds = await _sysAppRep.Context.Queryable<SysRole>().Where(u => tenantIds.Contains((long)u.TenantId)).Select(u => u.Id).ToListAsync();
        var userIds = await _sysAppRep.Context.Queryable<SysUser>().Where(u => tenantIds.Contains((long)u.TenantId)).Select(u => u.Id).ToListAsync();
        await _sysAppRep.Context.Deleteable<SysRoleMenu>().Where(u => roleIds.Contains(u.RoleId) && !input.MenuIdList.Contains(u.MenuId)).ExecuteCommandAsync();
        await _sysAppRep.Context.Deleteable<SysUserMenu>().Where(u => userIds.Contains(u.UserId) && !input.MenuIdList.Contains(u.MenuId)).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取切换应用数据 🔖
    /// </summary>
    /// <returns></returns>
    [UnitOfWork]
    [DisplayName("切换应用")]
    [ApiDescriptionSettings(Name = "ChangeApp"), HttpGet]
    public async Task<dynamic> GetChangeAppData()
    {
        var list = await _sysAppRep.AsQueryable().Includes(u => u.TenantList).ToListAsync();
        return new
        {
            _userManager.AppId,
            _userManager.TenantId,
            SelectList = list.Select(u => new
            {
                u.Id,
                Value = u.Id,
                Label = u.Name,
                Children = u.TenantList?.Select(t => new
                {
                    t.Id,
                    Value = t.Id,
                    Label = t.Host ?? (t.Id + ""),
                })
            })
        };
    }

    /// <summary>
    /// 切换应用 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [DisplayName("切换应用")]
    [ApiDescriptionSettings(Name = "ChangeApp"), HttpPost]
    public async Task<LoginOutput> ChangeApp(ChangeAppInput input)
    {
        _ = await _sysAppRep.Context.Queryable<SysTenant>().FirstAsync(u => u.Id == input.TenantId) ?? throw Oops.Oh(ErrorCodeEnum.Z1003);
        _ = await _sysAppRep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);

        var user = await _sysAppRep.Context.Queryable<SysUser>().FirstAsync(u => u.Id == _userManager.UserId);
        user.TenantId = input.TenantId;

        return await _sysAuthService.CreateToken(user, input.Id);
    }

    /// <summary>
    /// 获取当前应用信息
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public async Task<SysApp> GetCurrentAppInfo()
    {
        var appId = _userManager.AppId > 0 ? _userManager.AppId : SqlSugarConst.DefaultAppId;
        return await _sysAppRep.GetFirstAsync(u => u.Id == appId) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
    }
}