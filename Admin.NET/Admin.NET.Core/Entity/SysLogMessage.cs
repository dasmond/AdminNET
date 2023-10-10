// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

namespace Admin.NET.Core;

/// <summary>
/// 系统运行日志表（记录系统的LogMessage机构体对应的日志）
/// </summary>
[SugarTable(null, "系统运行日志表")]
[SysTable]
[LogTable]
public class SysLogMessage : EntityBase
{
    /// <summary>
    /// 记录器类别名称
    /// </summary>
    [SugarColumn(ColumnDescription = "记录器类别名称", Length = 1024)]
    [MaxLength(1024)]
    public string? LogName { get; set; }

    /// <summary>
    /// 日志级别
    /// </summary>
    [SugarColumn(ColumnDescription = "日志级别")]
    public LogLevel? LogLevel { get; set; }

    /// <summary>
    /// 事件Id
    /// </summary>
    [SugarColumn(ColumnDescription = "事件Id")]
    public int? EventId { get; set; }

    /// <summary>
    /// 日志消息Json
    /// </summary>
    [SugarColumn(ColumnDescription = "日志消息Json", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? Message { get; set; }

    /// <summary>
    /// 异常信息
    /// </summary>
    [SugarColumn(ColumnDescription = "异常信息", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? Exception { get; set; }

    /// <summary>
    /// 当前状态值
    /// </summary>
    /// <remarks>可以是任意类型</remarks>
    [SugarColumn(ColumnDescription = "当前状态值", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? State { get; set; }

    /// <summary>
    /// 日志记录时间
    /// </summary>
    [SugarColumn(ColumnDescription = "日志时间")]
    public DateTime? LogDateTime { get; set; }

    /// <summary>
    /// 线程Id
    /// </summary>
    [SugarColumn(ColumnDescription = "线程Id")]
    public int? ThreadId { get; set; }

    /// <summary>
    /// 是否使用 UTC 时间戳
    /// </summary>
    [SugarColumn(ColumnDescription = "是否使用 UTC 时间戳")]
    public bool? UseUtcTimestamp { get; set; }

    /// <summary>
    /// 请求跟踪Id
    /// </summary>
    [SugarColumn(ColumnDescription = "请求跟踪Id", Length = 128)]
    [MaxLength(128)]
    public string? TraceId { get; set; }

    /// <summary>
    /// 日志上下文
    /// </summary>
    [SugarColumn(ColumnDescription = "日志上下文", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? Context { get; set; }
}