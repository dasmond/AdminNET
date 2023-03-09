namespace Admin.NET.Core;

/// <summary>
/// ApiJson配置选项
/// </summary>
public sealed class ApiJsonOptions : IConfigurableOptions
{
    /// <summary>
    /// 角色集合
    /// </summary>
    public List<ApiJson_Role> Roles { get; set; }
}

/// <summary>
/// ApiJson角色权限
/// </summary>
public class ApiJson_Role
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    /// 查询
    /// </summary>
    public ApiJson_RoleItem Select { get; set; }

    /// <summary>
    /// 增加
    /// </summary>
    public ApiJson_RoleItem Insert { get; set; }

    /// <summary>
    /// 更新
    /// </summary>
    public ApiJson_RoleItem Update { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public ApiJson_RoleItem Delete { get; set; }
}

/// <summary>
/// ApiJson角色权限内容
/// </summary>
public class ApiJson_RoleItem
{
    /// <summary>
    /// 表集合
    /// </summary>
    public string[] Table { get; set; }

    /// <summary>
    /// 列集合
    /// </summary>
    public string[] Column { get; set; }

    /// <summary>
    /// 过滤器
    /// </summary>
    public string[] Filter { get; set; }
}