// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Plugin.DingTalk;
using Admin.NET.Plugin.DingTalk.Attributes;
using Admin.NET.Plugin.DingTalk.Entity;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;

namespace Admin.NET.Web.Core.Middlewares;

/// <summary>
/// 基于钉钉的角色授权中间件
/// </summary>
public class DingtalkAuthorizationMiddleware : IMiddleware, IScoped
{
    private readonly SqlSugarRepository<DingTalkUserRole> _ddUserRoleRepo;
    private readonly SqlSugarRepository<DingTalkUser> _dduserRepo;
    private readonly UserManager _userManager;

    public DingtalkAuthorizationMiddleware(SqlSugarRepository<DingTalkUserRole> userRoleRepo, UserManager userManager)
    {
        _ddUserRoleRepo = userRoleRepo;
        _userManager = userManager;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        if (endpoint == null) await next.Invoke(context);
        else
        {
            var attrList = endpoint.Metadata.GetOrderedMetadata<DingTalkAuthorizeAttribute>();
            //没有贴钉钉授权则跳过
            if (attrList == null || attrList.Count == 0)
                await next(context);

            //如果贴了钉钉授权
            else
            {
                var ddUser = _dduserRepo.GetFirst(u => u.SysUserId == _userManager.UserId);
                //如果贴的无名授权则只要能找到DingTalkUser就给过
                if (attrList.All(a => string.IsNullOrEmpty(a.RoleName) && string.IsNullOrEmpty(a.GroupName)))
                {
                    if (ddUser != null) await next(context);
                    else context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
                else
                {
                    //如果贴的带名称授权，则查找用户角色
                    if (ddUser != null)
                    {
                        var userRoles = _ddUserRoleRepo.AsQueryable()
                            .IncludesAllFirstLayer()
                            .Where(ur => ur.DdUserId == ddUser.Id)
                            .ToList();
                        if (userRoles.Any(ur => attrList.Any(a => ur.Role.Name == a.RoleName && ur.Role.GroupName == a.GroupName)))
                        {
                            await next(context);
                        }
                        else context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                    else context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
            }
        }
    }
}

public static class DingtalkAuthorizationMiddlewareExtension
{
    public static IApplicationBuilder UseDingTalkAuthorization(this IApplicationBuilder app)
    {
        return app.UseMiddleware<DingtalkAuthorizationMiddleware>();
    }
}