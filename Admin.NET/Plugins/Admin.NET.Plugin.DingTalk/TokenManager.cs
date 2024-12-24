// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

using Admin.NET.Plugin.DingTalk.Entity;
using Admin.NET.Plugin.DingTalk.RequestProxy.Top;

using Microsoft.Extensions.DependencyInjection;

namespace Admin.NET.Plugin.DingTalk;

public class TokenManager : IScoped
{
    private readonly IServiceScopeFactory _scopeFactory;

    public TokenManager(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<string> GetAccessToken(DdAppMeta ddAppMeta)
    {
        if (!string.IsNullOrEmpty(ddAppMeta.AccessToken) && ddAppMeta.AccessTokenExpire.HasValue && ddAppMeta.AccessTokenExpire > DateTime.Now)
        {
            return ddAppMeta.AccessToken;
        }
        using var serviceScope = _scopeFactory.CreateScope();
        var topRequest = serviceScope.ServiceProvider.GetRequiredService<TopRequest>();
        var ddAppMetaRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DdAppMeta>>();
        var rsp = await topRequest.GetAccessToken(ddAppMeta.Appkey, ddAppMeta.Appsecret);
        if (rsp == null || string.IsNullOrEmpty(rsp.AccessToken)) return null;
        ddAppMeta.AccessToken = rsp.AccessToken;
        ddAppMeta.AccessTokenExpire = DateTime.Now.AddSeconds((double)rsp.ExpireIn);
        await ddAppMetaRepo.UpdateAsync(ddAppMeta);
        return rsp.AccessToken;
    }

    public async Task<string> GetJsApiTicket(DdAppMeta ddAppMeta)
    {
        if (!string.IsNullOrEmpty(ddAppMeta.JsApiTicket) && ddAppMeta.JsApiTicketExpire.HasValue && ddAppMeta.JsApiTicketExpire > DateTime.Now)
        {
            return ddAppMeta.JsApiTicket;
        }
        using var serviceScope = _scopeFactory.CreateScope();
        var topRequest = serviceScope.ServiceProvider.GetRequiredService<TopRequest>();
        var ddAppMetaRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DdAppMeta>>();
        var AccessToken = await GetAccessToken(ddAppMeta);
        var rsp = await topRequest.GetJsApiTicket(AccessToken);
        if (rsp == null) return null;
        ddAppMeta.JsApiTicket = rsp.JsApiTicket;
        ddAppMeta.JsApiTicketExpire = DateTime.Now.AddSeconds((double)rsp.ExpiresIn);
        await ddAppMetaRepo.UpdateAsync(ddAppMeta);
        return rsp.JsApiTicket;
    }
}