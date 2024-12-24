// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Plugin.DingTalk;

/// <summary>
/// 钉钉用户表
/// </summary>
[SugarTable(null, "钉钉用户表")]
public class DingTalkUser : EntityTenant
{
    /// <summary>
    /// 系统用户Id
    /// </summary>
    [SugarColumn(ColumnDescription = "系统用户Id")]
    public long SysUserId { get; set; }

    /// <summary>
    /// 系统用户
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToOne, nameof(SysUserId))]
    public SysUser SysUser { get; set; }

    /// <summary>
    /// 钉钉用户id
    /// </summary>
    [SugarColumn(ColumnDescription = "钉钉用户id", Length = 64)]
    [Required, MaxLength(64)]
    public virtual string? DingTalkUserId { get; set; }

    /// <summary>
    /// UnionId
    /// </summary>
    [SugarColumn(ColumnDescription = "UnionId", Length = 64)]
    [MaxLength(64)]
    public string? UnionId { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [SugarColumn(ColumnDescription = "用户名", Length = 64)]
    [MaxLength(64)]
    public string? Name { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    [SugarColumn(ColumnDescription = "手机号码", Length = 16)]
    [MaxLength(16)]
    public string? Mobile { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [SugarColumn(ColumnDescription = "性别")]
    public int? Sex { get; set; }

    /// <summary>
    /// 工号
    /// </summary>
    [SugarColumn(ColumnDescription = "工号", Length = 16)]
    [MaxLength(16)]
    public string? JobNumber { get; set; }

    /// <summary>
    /// 主部门Id
    /// </summary>
    [SugarColumn(ColumnDescription = "主部门Id", Length = 16)]
    [MaxLength(16)]
    public string? DeptId { get; set; }

    /// <summary>
    /// 主部门
    /// </summary>
    [SugarColumn(ColumnDescription = "主部门", Length = 16)]
    [MaxLength(16)]
    public string? Dept { get; set; }

    /// <summary>
    /// 职位
    /// </summary>
    [SugarColumn(ColumnDescription = "职位", Length = 16)]
    [MaxLength(16)]
    public string? Position { get; set; }

    /// <summary>
    /// 国际电话区号
    /// </summary>
    public string StateCode { get; set; }

    /// <summary>
    /// 员工的直属主管
    /// </summary>
    public string ManagerUserId { get; set; }

    /// <summary>
    /// 是否号码隐藏
    /// </summary>
    public bool HideMobile { get; set; }

    /// <summary>
    /// 分机号
    /// </summary>
    public string Telephone { get; set; }

    /// <summary>
    /// 职位
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 员工邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 办公地点
    /// </summary>
    public string WorkPlace { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 是否为企业账号
    /// </summary>
    public bool ExclusiveAccount { get; set; }

    /// <summary>
    /// 员工的企业邮箱。如果员工的企业邮箱没有开通，返回信息中不包含该数据
    /// </summary>
    public string OrgEmail { get; set; }

    /// <summary>
    /// 扩展属性，最大长度2000个字符
    /// </summary>
    public string Extension { get; set; }

    /// <summary>
    /// 入职时间，Unix时间戳，单位毫秒
    /// </summary>
    public long HiredDate { get; set; }

    /// <summary>
    /// 是否激活了钉钉
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// 是否完成了实名认证
    /// </summary>
    public bool RealAuthed { get; set; }

    /// <summary>
    /// 是否为企业的高管
    /// </summary>
    public bool Senior { get; set; }

    /// <summary>
    /// 是否为企业的管理员
    /// </summary>
    public bool Admin { get; set; }

    /// <summary>
    /// 是否为企业的老板
    /// </summary>
    public bool Boss { get; set; }
}