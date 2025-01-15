// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using NewLife.Reflection;

namespace Admin.NET.Core.Service;

/// <summary>
/// 系统参数配置服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 440)]
public class SysConfigService : IDynamicApiController, ITransient
{
    private static readonly SysTenantService SysTenantService = App.GetService<SysTenantService>();
    private readonly SqlSugarRepository<SysConfigValue> _sysConfigValueRep;
    private readonly SqlSugarRepository<SysConfig> _sysConfigRep;
    private readonly SqlSugarRepository<SysTenant> _sysTenantRep;
    private readonly SysCacheService _sysCacheService;
    private readonly UserManager _userManager;

    public SysConfigService(
        SqlSugarRepository<SysConfigValue> sysConfigValueRep,
        SqlSugarRepository<SysTenant> sysTenantRep,
        SqlSugarRepository<SysConfig> sysConfigRep,
        SysCacheService sysCacheService,
        UserManager userManager)
    {
        _sysConfigValueRep = sysConfigValueRep;
        _sysCacheService = sysCacheService;
        _sysConfigRep = sysConfigRep;
        _sysTenantRep = sysTenantRep;
        _userManager = userManager;
    }

    /// <summary>
    /// 获取参数配置分页列表 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("获取参数配置分页列表")]
    public async Task<SqlSugarPagedList<SysConfig>> Page(PageConfigInput input)
    {
        var queryable = await GetConfigQueryable();
        return await queryable
            .WhereIF(!_userManager.SuperAdmin,  u => u.SysFlag == YesNoEnum.N)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name?.Trim()), u => u.Name.Contains(input.Name))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code?.Trim()), u => u.Code.Contains(input.Code))
            .WhereIF(!string.IsNullOrWhiteSpace(input.GroupCode?.Trim()), u => u.GroupCode.Equals(input.GroupCode))
            .OrderBuilder(input)
            .ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 获取参数配置列表 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取参数配置列表")]
    public async Task<List<SysConfig>> List(PageConfigInput input)
    {
        var queryable = await GetConfigQueryable();
        return await queryable
            .WhereIF(!string.IsNullOrWhiteSpace(input.GroupCode?.Trim()), u => u.GroupCode.Equals(input.GroupCode))
            .ToListAsync();
    }

    /// <summary>
    /// 增加参数配置 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Add"), HttpPost]
    [DisplayName("增加参数配置")]
    public async Task AddConfig(AddConfigInput input)
    {
        if (input.SysFlag == YesNoEnum.Y && !_userManager.SuperAdmin) throw Oops.Oh(ErrorCodeEnum.D3010);

        var isExist = await _sysConfigRep.IsAnyAsync(u => u.Name == input.Name || u.Code == input.Code);
        if (isExist) throw Oops.Oh(ErrorCodeEnum.D9000);

        await _sysConfigRep.InsertAsync(input.Adapt<SysConfig>());
    }

    /// <summary>
    /// 更新参数配置 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Update"), HttpPost]
    [DisplayName("更新参数配置")]
    public async Task UpdateConfig(UpdateConfigInput input)
    {
        if (input.SysFlag == YesNoEnum.Y && !_userManager.SuperAdmin) throw Oops.Oh(ErrorCodeEnum.D3010);

        var isExist = await _sysConfigRep.IsAnyAsync(u => (u.Name == input.Name || u.Code == input.Code) && u.Id != input.Id);
        if (isExist) throw Oops.Oh(ErrorCodeEnum.D9000);

        var config = input.Adapt<SysConfig>();
        if (input.SysFlag != YesNoEnum.Y)
        {
            config.Value = null;
            var configValue = await _sysConfigValueRep.AsQueryable().ClearFilter()
                .WhereIF(_userManager.TenantId > 0, u => u.TenantId == _userManager.TenantId)
                .WhereIF(_userManager.TenantId <= 0, u => u.TenantId == SqlSugarConst.DefaultTenantId)
                .SingleAsync(u => u.ConfigId == config.Id);
            if (configValue == null)
            {
                await _sysConfigValueRep.InsertAsync(new SysConfigValue()
                {
                    ConfigId = config.Id,
                    Value = input.Value
                });
            }
            else
            {
                configValue.Value = input.Value;
                await _sysConfigValueRep.UpdateAsync(configValue);
            }
        }
        else
        {
            await _sysConfigValueRep.DeleteAsync(u => u.ConfigId == input.Id);
        }
        await _sysConfigRep.AsUpdateable(config).ExecuteCommandAsync();
        Remove(config);
    }

    /// <summary>
    /// 删除参数配置 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Delete"), HttpPost]
    [DisplayName("删除参数配置")]
    public async Task DeleteConfig(DeleteConfigInput input)
    {
        var config = await _sysConfigRep.GetFirstAsync(u => u.Id == input.Id);

        // 禁止删除系统参数
        if (config.SysFlag == YesNoEnum.Y) throw Oops.Oh(ErrorCodeEnum.D9001);

        await _sysConfigValueRep.DeleteAsync(u => u.ConfigId == config.Id);
        await _sysConfigRep.DeleteAsync(config);
        Remove(config);
    }

    /// <summary>
    /// 批量删除参数配置 🔖
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "BatchDelete"), HttpPost]
    [DisplayName("批量删除参数配置")]
    public async Task BatchDeleteConfig(List<long> ids)
    {
        foreach (var id in ids)
        {
            var config = await _sysConfigRep.GetFirstAsync(u => u.Id == id);

            // 禁止删除系统参数
            if (config.SysFlag == YesNoEnum.Y) continue;

            await _sysConfigRep.DeleteAsync(config);
            await _sysConfigValueRep.DeleteAsync(u => u.ConfigId == config.Id);

            Remove(config);
        }
    }

    /// <summary>
    /// 获取参数配置详情 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("获取参数配置详情")]
    public async Task<SysConfig> GetDetail([FromQuery] ConfigInput input)
    {
        var query = await GetConfigQueryable();
        return await query.FirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取参数配置值
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [NonAction]
    public async Task<T> GetConfigValue<T>(string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return default;

        var value = _sysCacheService.Get<string>($"{CacheConst.KeyConfig}{code}");
        if (string.IsNullOrEmpty(value))
        {
            var query = await GetConfigQueryable();
            var config = await query.FirstAsync(u => u.Code == code);
            value = config?.Value;
            _sysCacheService.Set($"{CacheConst.KeyConfig}{code}", value);
        }
        if (string.IsNullOrWhiteSpace(value)) return default;
        return (T)Convert.ChangeType(value, typeof(T));
    }

    /// <summary>
    /// 获取参数配置查询器
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public Task<ISugarQueryable<SysConfig>> GetConfigQueryable()
    {
        var tenantId = _userManager.TenantId;
        if (_userManager.TenantId <= 0) tenantId = SqlSugarConst.DefaultTenantId;
        return Task.FromResult(
            _sysConfigRep.AsQueryable()
                .LeftJoin<SysConfigValue>((u, w) => u.Id == w.ConfigId).ClearFilter()
                .Where((u, w) => w.TenantId == null || w.TenantId == tenantId)
                .Select((u, w) => new SysConfig
                {
                    Id = u.Id,
                    Name = u.Name,
                    Code = u.Code,
                    GroupCode = u.GroupCode,
                    SysFlag = u.SysFlag,
                    Remark = u.Remark,
                    Value = w.Value ?? u.Value,
                    CreateTime = SqlFunc.IIF(u.SysFlag == YesNoEnum.Y, u.CreateTime, w.CreateTime),
                    UpdateTime = SqlFunc.IIF(u.SysFlag == YesNoEnum.Y, u.UpdateTime, w.UpdateTime),
                    CreateUserId = SqlFunc.IIF(u.SysFlag == YesNoEnum.Y, u.CreateUserId, w.CreateUserId),
                    CreateUserName = SqlFunc.IIF(u.SysFlag == YesNoEnum.Y, u.CreateUserName, w.CreateUserName),
                    UpdateUserId = SqlFunc.IIF(u.SysFlag == YesNoEnum.Y, u.UpdateUserId, w.UpdateUserId),
                    UpdateUserName = SqlFunc.IIF(u.SysFlag == YesNoEnum.Y, u.UpdateUserName, w.UpdateUserName),
                })
            );
    }

    /// <summary>
    /// 更新参数配置值
    /// </summary>
    /// <param name="code"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [NonAction]
    public async Task UpdateConfigValue(string code, string value)
    {
        var query = await GetConfigQueryable();
        var config = await query.FirstAsync(u => u.Code == code);
        if (config == null) return;

        config.Value = value;
        await UpdateConfig(config.Adapt<UpdateConfigInput>());

        Remove(config);
    }

    /// <summary>
    /// 获取分组列表 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取分组列表")]
    public async Task<List<string>> GetGroupList()
    {
        var query = await GetConfigQueryable();
        return await query.GroupBy(u => u.GroupCode).Select(u => u.GroupCode).ToListAsync();
    }

    /// <summary>
    /// 获取 Token 过期时间
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public async Task<int> GetTokenExpire()
    {
        var tokenExpireStr = await GetConfigValue<string>(ConfigConst.SysTokenExpire);
        _ = int.TryParse(tokenExpireStr, out var tokenExpire);
        return tokenExpire == 0 ? 20 : tokenExpire;
    }

    /// <summary>
    /// 获取 RefreshToken 过期时间
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public async Task<int> GetRefreshTokenExpire()
    {
        var refreshTokenExpireStr = await GetConfigValue<string>(ConfigConst.SysRefreshTokenExpire);
        _ = int.TryParse(refreshTokenExpireStr, out var refreshTokenExpire);
        return refreshTokenExpire == 0 ? 40 : refreshTokenExpire;
    }

    /// <summary>
    /// 批量更新参数配置值
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "BatchUpdate"), HttpPost]
    [DisplayName("批量更新参数配置值")]
    public async Task BatchUpdateConfig(List<BatchConfigInput> input)
    {
        var query = await GetConfigQueryable();
        foreach (var config in input)
        {
            var info = await query.FirstAsync(c => c.Code == config.Code);
            if (info == null || info.SysFlag == YesNoEnum.Y) continue;

            info.Value = config.Value;
            await UpdateConfig(info.Adapt<UpdateConfigInput>());
            Remove(info);
        }
    }

    /// <summary>
    /// 获取系统信息 🔖
    /// </summary>
    /// <returns></returns>
    [SuppressMonitor]
    [AllowAnonymous]
    [DisplayName("获取系统信息")]
    public async Task<dynamic> GetSysInfo()
    {
        var tenant = await SysTenantService.GetCurrentTenant();
        tenant ??= await _sysTenantRep.GetFirstAsync(u => u.Id == SqlSugarConst.DefaultTenantId);
        _ = tenant ?? throw Oops.Oh(ErrorCodeEnum.D1002);

        var wayList = await _sysConfigRep.Change<SysUserRegWay>().AsQueryable().ClearFilter()
            .Where(u => u.TenantId == tenant.Id)
            .Select(u => new { Label = u.Name, Value = u.Id })
            .ToListAsync();

        var captcha = await GetConfigValue<bool>(ConfigConst.SysCaptcha);
        var secondVer = await GetConfigValue<bool>(ConfigConst.SysSecondVer);
        var hideTenantForLogin = await GetConfigValue<bool>(ConfigConst.SysHideTenantLogin);
        return new
        {
            tenant.Logo,
            tenant.Title,
            tenant.ViceTitle,
            tenant.ViceDesc,
            tenant.Watermark,
            tenant.Copyright,
            tenant.Icp,
            tenant.IcpUrl,
            tenant.RegWayId,
            tenant.EnableReg,
            SecondVer = secondVer ? YesNoEnum.Y : YesNoEnum.N,
            Captcha = captcha ? YesNoEnum.Y : YesNoEnum.N,
            HideTenantForLogin = hideTenantForLogin,
            WayList = wayList
        };
    }

    /// <summary>
    /// 保存系统信息 🔖
    /// </summary>
    /// <returns></returns>
    [UnitOfWork]
    [DisplayName("保存系统信息")]
    public async Task SaveSysInfo(InfoSaveInput input)
    {
        var tenant = await SysTenantService.GetCurrentTenant() ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        if (!string.IsNullOrEmpty(input.LogoBase64)) SysTenantService.SetLogoUrl(tenant, input.LogoBase64, input.LogoFileName);
        // await UpdateConfigValue(ConfigConst.SysCaptcha, (input.Captcha == YesNoEnum.Y).ToString());
        // await UpdateConfigValue(ConfigConst.SysSecondVer, (input.SecondVer == YesNoEnum.Y).ToString());

        tenant.Copy(input);
        tenant.RegWayId = input.EnableReg == YesNoEnum.Y ? input.RegWayId : null;
        await _sysConfigRep.Context.Updateable(tenant).ExecuteCommandAsync();
    }

    private void Remove(SysConfig config)
    {
        _sysCacheService.Remove($"{CacheConst.KeyConfig}Value:{config.Code}");
        _sysCacheService.Remove($"{CacheConst.KeyConfig}Remark:{config.Code}");
        _sysCacheService.Remove($"{CacheConst.KeyConfig}{config.GroupCode}:GroupWithCache");
        _sysCacheService.Remove($"{CacheConst.KeyConfig}{config.Code}");
    }
}