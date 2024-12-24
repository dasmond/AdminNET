// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Plugin.DingTalk.Attributes;
using Admin.NET.Plugin.DingTalk.Entity;
using Admin.NET.Plugin.DingTalk.RequestProxy.HRM;
using Admin.NET.Plugin.DingTalk.RequestProxy.HRM.DTO;
using Admin.NET.Plugin.DingTalk.RequestProxy.Top;
using Admin.NET.Plugin.DingTalk.RequestProxy.Top.DTO;
using Admin.NET.Plugin.DingTalk.RequestProxy.User;
using Admin.NET.Plugin.DingTalk.RequestProxy.User.DTO;

namespace Admin.NET.Plugin.DingTalk.Service;

/// <summary>
/// 钉钉服务 🧩
/// </summary>
[ApiDescriptionSettings(DingTalkConst.GroupName, Order = 100)]
public class DingTalkService : IDynamicApiController, IScoped
{
    private readonly IDingTalkApi _dingTalkApi;
    private readonly DingTalkOptions _dingTalkOptions;
    private readonly TopRequest _topRequest;
    private readonly HrmRequest _hrmRequest;
    private readonly DdAppMeta _ddAppMeta;
    private readonly UserRequest _userRequest;
    private readonly TokenManager _tokenManager;
    private readonly UserManager _userManager;

    public DingTalkService(IDingTalkApi dingTalkApi,
        IOptions<DingTalkOptions> dingTalkOptions,
        TopRequest topRequest,
        HrmRequest hrmRequest,
        UserManager userManager,
        UserRequest userRequest,
        TokenManager tokenManager)
    {
        _dingTalkApi = dingTalkApi;
        _dingTalkOptions = dingTalkOptions.Value;
        _topRequest = topRequest;
        _hrmRequest = hrmRequest;
        _userRequest = userRequest;
        _tokenManager = tokenManager;
        _userManager = userManager;
        var ddAppMeta = App.GetRequiredService<SqlSugarRepository<DdAppMeta>>().GetFirst(t => t.TenantId == userManager.TenantId);
        ArgumentNullException.ThrowIfNull(ddAppMeta);
        _ddAppMeta = ddAppMeta;
    }

    /// <summary>
    /// 获取企业内部应用的access_token
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取企业内部应用的access_token")]
    public async Task<GetAccessTokenResponse> GetDingTalkToken()
    {
        var tokenRes = await _topRequest.GetAccessToken(_dingTalkOptions.ClientId, _dingTalkOptions.ClientSecret);
        _ddAppMeta.AccessToken = tokenRes.AccessToken;
        _ddAppMeta.AccessTokenExpire = DateTime.Now.AddSeconds(tokenRes.ExpireIn);
        App.GetRequiredService<SqlSugarRepository<DdAppMeta>>().Update(_ddAppMeta);
        return tokenRes;
    }

    [HttpGet, DingTalkAuthorize]
    public async Task<UserDetailResponse> GetUserDetail()
    {
        var AccessToken = await _tokenManager.GetAccessToken(_ddAppMeta);
        var ddUser = App.GetRequiredService<SqlSugarRepository<DingTalkUser>>().GetFirst(u => u.SysUserId == _userManager.UserId);
        var res = await _userRequest.UserDetail(AccessToken, ddUser.DingTalkUserId);
        return res;
    }

    [HttpGet,DingTalkAuthorize("主管理员", "默认")]
    public async Task<UserDetailResponse> GetUserDetail(string userid)
    {
        var AccessToken = await _tokenManager.GetAccessToken(_ddAppMeta);
        var ddUser = App.GetRequiredService<SqlSugarRepository<DingTalkUser>>().GetFirst(u => u.DingTalkUserId == userid);
        ArgumentNullException.ThrowIfNull(ddUser);
        var res = await _userRequest.UserDetail(AccessToken, ddUser.DingTalkUserId);
        return res;
    }

    /// <summary>
    /// 获取在职员工列表 🔖
    /// </summary>
    /// <param name="access_token"></param>
    /// <param name="statusList"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [HttpPost, DisplayName("获取在职员工列表")]
    public async Task<EmployeeQueryonjobResponse> GetDingTalkCurrentEmployeesList(string access_token, List<string> statusList, int size, int offset)
    {
        return await _hrmRequest.EmployeeQueryonjob(access_token, statusList, size, offset);
    }

    /// <summary>
    /// 获取员工花名册字段信息 🔖
    /// </summary>
    /// <param name="access_token"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost, DisplayName("获取员工花名册字段信息")]
    public async Task<RosterListsQueryResponse> GetDingTalkCurrentEmployeesRosterList(string access_token, List<string> useridList, List<string> fieldFilterList, long appAgentId)
    {
        return await _hrmRequest.RosterListsQuery(access_token, useridList, fieldFilterList, appAgentId);
    }

    /// <summary>
    /// 发送钉钉互动卡片 🔖
    /// </summary>
    /// <param name="token"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("给指定用户发送钉钉互动卡片")]
    public async Task<DingTalkSendInteractiveCardsOutput> DingTalkSendInteractiveCards(string token, DingTalkSendInteractiveCardsInput input)
    {
        return await _dingTalkApi.DingTalkSendInteractiveCards(token, input);
    }
}