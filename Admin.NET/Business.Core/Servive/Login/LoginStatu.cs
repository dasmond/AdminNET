// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Servive.Login;
/// <summary>
/// 
/// </summary>
public class LoginStatu : IDynamicApiController, ITransient
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LoginStatu(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    /// <summary>
    /// 登录检查 🔖
    /// </summary>
    /// <returns></returns>
    [HttpPost("/api/checkLogin"), NonUnify]
    [ApiDescriptionSettings(Description = "Swagger登录检查", DisableInherite = true)]
    public int SwaggerCheckUrl()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null || httpContext.User?.Identity == null)
        {
            return 401;
        }
        return httpContext.User.Identity.IsAuthenticated ? 200 : 401;
    }
}
