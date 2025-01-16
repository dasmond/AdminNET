// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Business.Core.Enum;
using SqlSugar;
using System.ComponentModel.DataAnnotations;
namespace Business.Core.Entity;

/// <summary>
/// 消息表
/// </summary>
[SugarTable("T_Message", "消息表")]
[Tenant("chatTest")]
public class TMessage : EntityBase
{
    /// <summary>
    /// 接收人Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "F_ReceiveUserId", ColumnDescription = "接收人Id", Length = 32)]
    public long F_ReceiveUserId { get; set; }

    /// <summary>
    /// 发送人Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "F_SendUserId", ColumnDescription = "发送人Id", Length = 32)]
    public long F_SendUserId { get; set; }

    /// <summary>
    /// 发送消息
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "F_Message", ColumnDescription = "发送消息", Length = 500)]
    public string F_Message { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "F_MessageType", ColumnDescription = "消息类型", Length = 32)]
    public MsgType F_MessageType { get; set; } = 0;

    /// <summary>
    /// 发送时间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "F_SendTime", ColumnDescription = "发送时间")]
    public DateTime F_SendTime { get; set; }

    /// <summary>
    /// 创建者部门Id
    /// </summary>
    [SugarColumn(ColumnName = "CreateOrgId", ColumnDescription = "创建者部门Id")]
    public long? CreateOrgId { get; set; }

    /// <summary>
    /// 创建者部门名称
    /// </summary>
    [SugarColumn(ColumnName = "CreateOrgName", ColumnDescription = "创建者部门名称", Length = 64)]
    public string? CreateOrgName { get; set; }

}
