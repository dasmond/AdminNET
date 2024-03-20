// 大名科技（天津）有限公司版权所有  电话：18020030720  QQ：515096995
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证

namespace Admin.NET.Core.Service;

/// <summary>
/// 角色列表输出参数
/// </summary>
public class RoleOutput
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }
}

/// <summary>
/// 角色选项输出参数
/// </summary>
public class RoleOptionOutput : RoleOutput
{
    /// <summary>
    /// 是否禁用
    /// </summary>
    public bool Disabled { get; set; } = true;
}

/// <summary>
/// 角色已分配可分配输出参数
/// </summary>
public class GrantRoleOutput
{
    /// <summary>
    /// 以分配
    /// </summary>
    public IEnumerable<RoleOptionOutput> Granted { get; set; }
    /// <summary>
    /// 可分配
    /// </summary>
    public IEnumerable<RoleOptionOutput> Available { get; set; }
}