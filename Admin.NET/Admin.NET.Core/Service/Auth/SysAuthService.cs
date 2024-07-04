// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.SpecificationDocument;
using Lazy.Captcha.Core;

namespace Admin.NET.Core.Service;

/// <summary>
/// 系统登录授权服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 500)]
public class SysAuthService : IDynamicApiController, ITransient
{
    private readonly UserManager _userManager;
    private readonly SqlSugarRepository<SysUser> _sysUserRep;
    private readonly SqlSugarRepository<SysUserLdap> _sysUserLdap;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SysMenuService _sysMenuService;
    private readonly SysOnlineUserService _sysOnlineUserService;
    private readonly SysConfigService _sysConfigService;
    private readonly ICaptcha _captcha;
    private readonly SysCacheService _sysCacheService;
    private readonly SysLdapService _sysLdapService;

    public SysAuthService(UserManager userManager,
        SqlSugarRepository<SysUser> sysUserRep,
        SqlSugarRepository<SysUserLdap> sysUserLdapRep,
        IHttpContextAccessor httpContextAccessor,
        SysMenuService sysMenuService,
        SysOnlineUserService sysOnlineUserService,
        SysConfigService sysConfigService,
        ICaptcha captcha,
        SysCacheService sysCacheService,
        SysLdapService sysLdapService)
    {
        _userManager = userManager;
        _sysUserRep = sysUserRep;
        _sysUserLdap = sysUserLdapRep;
        _httpContextAccessor = httpContextAccessor;
        _sysMenuService = sysMenuService;
        _sysOnlineUserService = sysOnlineUserService;
        _sysConfigService = sysConfigService;
        _captcha = captcha;
        _sysCacheService = sysCacheService;
        _sysLdapService = sysLdapService;
    }

    /// <summary>
    /// 测试多线程查库
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "TestMutilQuery")]
    [AllowAnonymous]
    public async Task TestMutilQuery()
    {
        Console.WriteLine("进入 TestMutilQuery\n\n\n");
        var fun = async (int x) =>
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss:fff")} 线程{x} Start");
            IServiceProvider serviceProvider = App.GetRequiredService<IServiceProvider>().CreateScope().ServiceProvider;

            //用 IServiceProvider.GetRequiredService 得到的对像Scope不相关，确保每次都是新的对象
            SqlSugarRepository<SysFile> _repSysFile = serviceProvider.GetService<SqlSugarRepository<SysFile>>();
            SysFileService _sysFileService = serviceProvider.GetService<SysFileService>();
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    var files = _repSysFile.AsQueryable().ToList();
                    /*
                    for (int j = 0; j < 5; j++)
                    {
                        try
                        {
                            string str = await _sysFileService.DownloadFileBase64(files[j].Url);
                            str += "";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss:fff")} 线程{x},{_repSysFile.Id}，第{j}次 出错：{ex.Message}");
                        }
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss:fff")} 线程{x},{_repSysFile.Id} ERROR:{ex.Message}");
                return;
            }
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss:fff")} {x} End");
        };
        List<Task> tasks = new List<Task>();

        //创建15个线程同步进行查询
        for (int i = 0; i < 15; i++)
        {
            // 注意事项一：如果不把i赋给一个生命期不一样的变量，在 fun(i) 时，所有的task都是同一个引用
            var a = i;
            Task t1 = Task.Run(() =>
            {
                fun(a);
            });
            tasks.Add(t1);
        }
        await Task.WhenAll(tasks);
        Console.WriteLine($"{DateTime.Now.ToString("HHmmss_fff")} 所有完成");
    }

    /// <summary>
    /// 账号密码登录 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>用户名/密码：superadmin/123456</remarks>
    /// <returns></returns>
    [AllowAnonymous]
    [DisplayName("账号密码登录")]
    public virtual async Task<LoginOutput> Login([Required] LoginInput input)
    {
        //// 可以根据域名获取具体租户
        //var host = _httpContextAccessor.HttpContext.Request.Host;

        // 判断密码错误次数（缓存30分钟）
        var keyPasswordErrorTimes = $"{CacheConst.KeyPasswordErrorTimes}{input.Account}";
        var passwordErrorTimes = _sysCacheService.Get<int>(keyPasswordErrorTimes);
        var passwordMaxErrorTimes = await _sysConfigService.GetConfigValue<int>(CommonConst.SysPasswordMaxErrorTimes);
        if (passwordErrorTimes >= passwordMaxErrorTimes)
            throw Oops.Oh(ErrorCodeEnum.D1027);

        // 是否开启验证码
        if (await _sysConfigService.GetConfigValue<bool>(CommonConst.SysCaptcha))
        {
            // 判断验证码
            if (!_captcha.Validate(input.CodeId.ToString(), input.Code))
                throw Oops.Oh(ErrorCodeEnum.D0008);
        }

        // 账号是否存在
        var user = await _sysUserRep.AsQueryable().Includes(t => t.SysOrg).ClearFilter().FirstAsync(u => u.Account.Equals(input.Account));
        _ = user ?? throw Oops.Oh(ErrorCodeEnum.D0009);

        // 账号是否被冻结
        if (user.Status == StatusEnum.Disable)
            throw Oops.Oh(ErrorCodeEnum.D1017);

        // 租户是否被禁用
        var tenant = await _sysUserRep.ChangeRepository<SqlSugarRepository<SysTenant>>().GetFirstAsync(u => u.Id == user.TenantId);
        if (tenant != null && tenant.Status == StatusEnum.Disable)
            throw Oops.Oh(ErrorCodeEnum.Z1003);

        // 国密SM2解密（前端密码传输SM2加密后的）
        try
        {
            input.Password = CryptogramUtil.SM2Decrypt(input.Password);
        }
        catch
        {
            throw Oops.Oh(ErrorCodeEnum.D0010);
        }

        // 是否开启域登录验证
        if (await _sysConfigService.GetConfigValue<bool>(CommonConst.SysDomainLogin))
        {
            var userLdap = await _sysUserLdap.GetFirstAsync(u => u.UserId == user.Id && u.TenantId == tenant.Id);
            if (userLdap == null)
            {
                VerifyPassword(input, keyPasswordErrorTimes, passwordErrorTimes, user);
            }
            else if (!await _sysLdapService.AuthAccount(tenant.Id, userLdap.Account, input.Password))
            {
                _sysCacheService.Set(keyPasswordErrorTimes, ++passwordErrorTimes, TimeSpan.FromMinutes(30));
                throw Oops.Oh(ErrorCodeEnum.D1000);
            }
        }
        else
            VerifyPassword(input, keyPasswordErrorTimes, passwordErrorTimes, user);

        // 登录成功则清空密码错误次数
        _sysCacheService.Remove(keyPasswordErrorTimes);

        return await CreateToken(user);
    }

    /// <summary>
    /// 验证用户密码
    /// </summary>
    /// <param name="input"></param>
    /// <param name="keyPasswordErrorTimes"></param>
    /// <param name="passwordErrorTimes"></param>
    /// <param name="user"></param>
    private void VerifyPassword(LoginInput input, string keyPasswordErrorTimes, int passwordErrorTimes, SysUser user)
    {
        if (CryptogramUtil.CryptoType == CryptogramEnum.MD5.ToString())
        {
            if (!user.Password.Equals(MD5Encryption.Encrypt(input.Password)))
            {
                _sysCacheService.Set(keyPasswordErrorTimes, ++passwordErrorTimes, TimeSpan.FromMinutes(30));
                throw Oops.Oh(ErrorCodeEnum.D1000);
            }
        }
        else
        {
            if (!CryptogramUtil.Decrypt(user.Password).Equals(input.Password))
            {
                _sysCacheService.Set(keyPasswordErrorTimes, ++passwordErrorTimes, TimeSpan.FromMinutes(30));
                throw Oops.Oh(ErrorCodeEnum.D1000);
            }
        }
    }

    /// <summary>
    /// 验证锁屏密码 🔖
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    [DisplayName("验证锁屏密码")]
    public virtual async Task<bool> UnLockScreen([Required, FromQuery] string password)
    {
        // 账号是否存在
        var user = await _sysUserRep.GetFirstAsync(u => u.Id == _userManager.UserId);
        _ = user ?? throw Oops.Oh(ErrorCodeEnum.D0009);

        // 国密SM2解密（前端密码传输SM2加密后的）
        password = CryptogramUtil.SM2Decrypt(password);

        // 密码是否正确
        if (CryptogramUtil.CryptoType == CryptogramEnum.MD5.ToString())
        {
            if (!user.Password.Equals(MD5Encryption.Encrypt(password)))
                throw Oops.Oh(ErrorCodeEnum.D1000);
        }
        else
        {
            if (!CryptogramUtil.Decrypt(user.Password).Equals(password))
                throw Oops.Oh(ErrorCodeEnum.D1000);
        }

        return true;
    }

    /// <summary>
    /// 手机号登录 🔖
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [DisplayName("手机号登录")]
    public virtual async Task<LoginOutput> LoginPhone([Required] LoginPhoneInput input)
    {
        var verifyCode = _sysCacheService.Get<string>($"{CacheConst.KeyPhoneVerCode}{input.Phone}");
        if (string.IsNullOrWhiteSpace(verifyCode))
            throw Oops.Oh("验证码不存在或已失效，请重新获取！");
        if (verifyCode != input.Code)
            throw Oops.Oh("验证码错误！");

        // 账号是否存在
        var user = await _sysUserRep.AsQueryable().Includes(t => t.SysOrg).ClearFilter().FirstAsync(u => u.Phone.Equals(input.Phone));
        _ = user ?? throw Oops.Oh(ErrorCodeEnum.D0009);

        return await CreateToken(user);
    }

    /// <summary>
    /// 生成Token令牌 🔖
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [NonAction]
    internal virtual async Task<LoginOutput> CreateToken(SysUser user)
    {
        // 单用户登录
        await _sysOnlineUserService.SingleLogin(user.Id);

        // 生成Token令牌
        var tokenExpire = await _sysConfigService.GetTokenExpire();
        var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>
        {
            { ClaimConst.UserId, user.Id },
            { ClaimConst.TenantId, user.TenantId },
            { ClaimConst.Account, user.Account },
            { ClaimConst.RealName, user.RealName },
            { ClaimConst.AccountType, user.AccountType },
            { ClaimConst.OrgId, user.OrgId },
            { ClaimConst.OrgName, user.SysOrg?.Name },
            { ClaimConst.OrgType, user.SysOrg?.Type },
        }, tokenExpire);

        // 生成刷新Token令牌
        var refreshTokenExpire = await _sysConfigService.GetRefreshTokenExpire();
        var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, refreshTokenExpire);

        // 设置响应报文头
        _httpContextAccessor.HttpContext.SetTokensOfResponseHeaders(accessToken, refreshToken);

        // Swagger Knife4UI-AfterScript登录脚本
        // ke.global.setAllHeader('Authorization', 'Bearer ' + ke.response.headers['access-token']);

        // 更新用户登录信息
        user.LastLoginIp = _httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4(true);
        (user.LastLoginAddress, double? longitude, double? latitude) = CommonUtil.GetIpAddress(user.LastLoginIp);
        user.LastLoginTime = DateTime.Now;
        user.LastLoginDevice = CommonUtil.GetClientDeviceInfo(_httpContextAccessor.HttpContext?.Request?.Headers?.UserAgent);
        await _sysUserRep.AsUpdateable(user).UpdateColumns(u => new
        {
            u.LastLoginIp,
            u.LastLoginAddress,
            u.LastLoginTime,
            u.LastLoginDevice,
        }).ExecuteCommandAsync();

        return new LoginOutput
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    /// <summary>
    /// 获取登录账号 🔖
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取登录账号")]
    public virtual async Task<LoginUserOutput> GetUserInfo()
    {
        var user = await _sysUserRep.GetFirstAsync(u => u.Id == _userManager.UserId) ?? throw Oops.Oh(ErrorCodeEnum.D1011).StatusCode(401);
        // 获取机构
        var org = await _sysUserRep.ChangeRepository<SqlSugarRepository<SysOrg>>().GetFirstAsync(u => u.Id == user.OrgId);
        // 获取职位
        var pos = await _sysUserRep.ChangeRepository<SqlSugarRepository<SysPos>>().GetFirstAsync(u => u.Id == user.PosId);
        // 获取按钮集合
        var buttons = await _sysMenuService.GetOwnBtnPermList();
        // 获取角色集合
        var roleIds = await _sysUserRep.ChangeRepository<SqlSugarRepository<SysUserRole>>().AsQueryable()
            .Where(u => u.UserId == user.Id).Select(u => u.RoleId).ToListAsync();
        // 获取水印文字（若系统水印为空则全局为空）
        var watermarkText = await _sysConfigService.GetConfigValue<string>("sys_web_watermark");
        if (!string.IsNullOrWhiteSpace(watermarkText))
            watermarkText += $"-{user.RealName}"; // $"-{user.RealName}-{_httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4(true)}-{DateTime.Now}";
        return new LoginUserOutput
        {
            Id = user.Id,
            Account = user.Account,
            RealName = user.RealName,
            Phone = user.Phone,
            IdCardNum = user.IdCardNum,
            Email = user.Email,
            AccountType = user.AccountType,
            Avatar = user.Avatar,
            Address = user.Address,
            Signature = user.Signature,
            OrgId = user.OrgId,
            OrgName = org?.Name,
            OrgType = org?.Type,
            PosName = pos?.Name,
            Buttons = buttons,
            RoleIds = roleIds,
            WatermarkText = watermarkText
        };
    }

    /// <summary>
    /// 获取刷新Token 🔖
    /// </summary>
    /// <param name="accessToken"></param>
    /// <returns></returns>
    [DisplayName("获取刷新Token")]
    public virtual string GetRefreshToken([FromQuery] string accessToken)
    {
        var refreshTokenExpire = _sysConfigService.GetRefreshTokenExpire().GetAwaiter().GetResult();
        return JWTEncryption.GenerateRefreshToken(accessToken, refreshTokenExpire);
    }

    /// <summary>
    /// 退出系统 🔖
    /// </summary>
    [DisplayName("退出系统")]
    public void Logout()
    {
        if (string.IsNullOrWhiteSpace(_userManager.Account))
            throw Oops.Oh(ErrorCodeEnum.D1011);

        _httpContextAccessor.HttpContext.SignoutToSwagger();
    }

    /// <summary>
    /// 获取登录配置 🔖
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [SuppressMonitor]
    [DisplayName("获取登录配置")]
    public async Task<dynamic> GetLoginConfig()
    {
        var secondVerEnabled = await _sysConfigService.GetConfigValue<bool>(CommonConst.SysSecondVer);
        var captchaEnabled = await _sysConfigService.GetConfigValue<bool>(CommonConst.SysCaptcha);
        return new { SecondVerEnabled = secondVerEnabled, CaptchaEnabled = captchaEnabled };
    }

    /// <summary>
    /// 获取验证码 🔖
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [SuppressMonitor]
    [DisplayName("获取验证码")]
    public dynamic GetCaptcha()
    {
        var codeId = YitIdHelper.NextId().ToString();
        var captcha = _captcha.Generate(codeId);
        return new { Id = codeId, Img = captcha.Base64 };
    }

    /// <summary>
    /// Swagger登录检查 🔖
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("/api/swagger/checkUrl"), NonUnify]
    [DisplayName("Swagger登录检查")]
    public int SwaggerCheckUrl()
    {
        return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ? 200 : 401;
    }

    /// <summary>
    /// Swagger登录提交 🔖
    /// </summary>
    /// <param name="auth"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("/api/swagger/submitUrl"), NonUnify]
    [DisplayName("Swagger登录提交")]
    public async Task<int> SwaggerSubmitUrl([FromForm] SpecificationAuth auth)
    {
        try
        {
            _sysCacheService.Set($"{CacheConst.KeyConfig}{CommonConst.SysCaptcha}", false);

            await Login(new LoginInput
            {
                Account = auth.UserName,
                Password = CryptogramUtil.SM2Encrypt(auth.Password),
            });

            _sysCacheService.Remove($"{CacheConst.KeyConfig}{CommonConst.SysCaptcha}");

            return 200;
        }
        catch (Exception)
        {
            return 401;
        }
    }
}