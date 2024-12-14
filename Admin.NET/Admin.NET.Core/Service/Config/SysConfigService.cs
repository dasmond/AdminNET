// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core.Service;

/// <summary>
/// 系统参数配置服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 440)]
public class SysConfigService : IDynamicApiController, ITransient
{
    private readonly SysCacheService _sysCacheService;
    private readonly SqlSugarRepository<SysConfig> _sysConfigRep;

    public SysConfigService(SysCacheService sysCacheService,
        SqlSugarRepository<SysConfig> sysConfigRep)
    {
        _sysCacheService = sysCacheService;
        _sysConfigRep = sysConfigRep;
    }

    /// <summary>
    /// 获取参数配置分页列表 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("获取参数配置分页列表")]
    public async Task<SqlSugarPagedList<SysConfig>> Page(PageConfigInput input)
    {
        return await _sysConfigRep.AsQueryable()
            .Where(u => u.GroupCode != ConfigConst.SysWebConfigGroup || u.GroupCode == null) // 不显示 WebConfig 分组
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
        return await _sysConfigRep.AsQueryable()
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
        var isExist = await _sysConfigRep.IsAnyAsync(u => (u.Name == input.Name || u.Code == input.Code) && u.Id != input.Id);
        if (isExist) throw Oops.Oh(ErrorCodeEnum.D9000);

        var config = input.Adapt<SysConfig>();
        await _sysConfigRep.AsUpdateable(config).IgnoreColumns(true).ExecuteCommandAsync();

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
        return await _sysConfigRep.GetFirstAsync(u => u.Id == input.Id);
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
            var config = await _sysConfigRep.CopyNew().GetFirstAsync(u => u.Code == code);
            value = config != null ? config.Value : default;
            _sysCacheService.Set($"{CacheConst.KeyConfig}{code}", value);
        }
        if (string.IsNullOrWhiteSpace(value)) return default;
        return (T)Convert.ChangeType(value, typeof(T));
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
        var config = await _sysConfigRep.GetFirstAsync(u => u.Code == code);
        if (config == null) return;

        config.Value = value;
        await _sysConfigRep.AsUpdateable(config).ExecuteCommandAsync();

        Remove(config);
    }

    /// <summary>
    /// 获取分组列表 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取分组列表")]
    public async Task<List<string>> GetGroupList()
    {
        return await _sysConfigRep.AsQueryable()
            .Where(u => u.GroupCode != ConfigConst.SysWebConfigGroup || u.GroupCode == null) // 不显示 WebConfig 分组
            .GroupBy(u => u.GroupCode)
            .Select(u => u.GroupCode).ToListAsync();
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
        foreach (var config in input)
        {
            var info = await _sysConfigRep.GetFirstAsync(c => c.Code == config.Code);
            if (info == null) continue;

            await _sysConfigRep.AsUpdateable().SetColumns(u => u.Value == config.Value).Where(u => u.Code == config.Code).ExecuteCommandAsync();
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
        var tenant = await App.GetService<SysTenantService>().GetCurrentTenant();
        tenant ??= await _sysConfigRep.Context.Queryable<SysTenant>().FirstAsync(u => u.Id == SqlSugarConst.DefaultTenantId);
        _ = tenant ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        
        var sysSecondVer = await GetConfigValue<bool>(ConfigConst.SysSecondVer);
        var sysCaptcha = await GetConfigValue<bool>(ConfigConst.SysCaptcha);
        return new
        {
            SysLogo = tenant.Logo,
            SysTitle = tenant.Title,
            SysViceTitle = tenant.ViceTitle,
            SysViceDesc = tenant.ViceDesc,
            SysWatermark = tenant.Watermark,
            SysCopyright = tenant.Copyright,
            SysIcp = tenant.Icp,
            SysIcpUrl = tenant.IcpUrl,
            SysRegWayId = tenant.RegWayId,
            SysRegistration = tenant.EnableReg == YesNoEnum.Y,
            SysSecondVer = sysSecondVer,
            SysCaptcha = sysCaptcha,
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
        var tenant = await App.GetService<SysTenantService>().GetCurrentTenant() ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        if (!string.IsNullOrEmpty(input.SysLogoBase64)) App.GetService<SysTenantService>().SetLogoUrl(tenant, input.SysLogoBase64, input.SysLogoFileName);

        tenant.Title = input.SysTitle;
        tenant.ViceTitle = input.SysViceTitle;
        tenant.ViceDesc = input.SysViceDesc;
        tenant.Watermark = input.SysWatermark;
        tenant.Copyright = input.SysCopyright;
        tenant.IcpUrl = input.SysIcpUrl;
        tenant.Icp = input.SysIcp;
        tenant.RegWayId = input.SysRegistration ? input.SysRegWayId : null;
        tenant.EnableReg = input.SysRegistration ? YesNoEnum.Y : YesNoEnum.N;

        await _sysConfigRep.Context.Updateable(tenant).ExecuteCommandAsync();
        await UpdateConfigValue(ConfigConst.SysSecondVer, input.SysSecondVer.ToString());
        await UpdateConfigValue(ConfigConst.SysCaptcha, input.SysCaptcha.ToString());
    }

    private void Remove(SysConfig config)
    {
        _sysCacheService.Remove($"{CacheConst.KeyConfig}Value:{config.Code}");
        _sysCacheService.Remove($"{CacheConst.KeyConfig}Remark:{config.Code}");
        _sysCacheService.Remove($"{CacheConst.KeyConfig}{config.GroupCode}:GroupWithCache");
        _sysCacheService.Remove($"{CacheConst.KeyConfig}{config.Code}");
    }
}