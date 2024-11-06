// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core;

/// <summary>
/// 系统用户操作事件类型枚举
/// </summary>
[Description("系统用户操作事件类型枚举")]
public enum SysUserEventTypeEnum
{
    [Description("增加用户")]
    Add = 111,
    [Description("更新用户")]
    Update = 222,
    [Description("授权用户角色")]
    UpdateRole = 333,
    [Description("删除用户")]
    Delete = 444,
    [Description("设置用户状态")]
    SetStatus = 555,
    [Description("修改密码")]
    ChangePwd = 666,
    [Description("重置密码")]
    ResetPwd = 777,
    [Description("解除登录锁定")]
    UnlockLogin = 888
}