namespace Admin.NET.Core;

/// <summary>
/// 是否超级管理菜单枚举
/// </summary>
public enum IsSuperAdminMenuEnum
{
    /// <summary>
    /// 启用
    /// </summary>
    [Description("启用")]
    Enable = 1,

    /// <summary>
    /// 停用
    /// </summary>
    [Description("停用")]
    Disable = 2,
}