// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Report;
[SugarTable("produce_time_report", "生产时段产能表")]
[Tenant(MesExpandConst.ConfigId)]
public class produceTimeReport : EntityBase
{
    /// <summary>
    /// 产线Id
    /// </summary>
    [SugarColumn(ColumnDescription = "产线Id")]
    public long line_id { get; set; }
    /// <summary>
    /// 产线编号
    /// </summary>
    [SugarColumn(ColumnDescription = "产线编号")]
    public string line_code { get; set; }
    /// <summary>
    /// 产线名
    /// </summary>
    [SugarColumn(ColumnDescription = "产线名")]
    public string line_name { get; set; }
    /// <summary>
    /// 工单Id
    /// </summary>
    [SugarColumn(ColumnDescription = "工单Id")]
    public long work_sheet_id { get; set; }
    /// <summary>
    /// 工单编号
    /// </summary>
    [SugarColumn(ColumnDescription = "工单编号")]
    public string work_sheet_sn { get; set; }
    /// <summary>
    /// 子工单
    /// </summary>
    [SugarColumn(ColumnDescription = "子工单")]
    public long sub_work_sheet_id { get; set; }
    /// <summary>
    /// 子工单编号
    /// </summary>
    [SugarColumn(ColumnDescription = "子工单编号")]
    public string sub_work_sheet_sn { get; set; }

    /// <summary>
    /// 工序id
    /// </summary>
    [SugarColumn(ColumnDescription = "工序id")]
    public long step_id { get; set; }
    /// <summary>
    /// 工序编码
    /// </summary>
    [SugarColumn(ColumnDescription = "工序编码")]
    public string step_code { get; set; }
    /// <summary>
    /// 工序名
    /// </summary>
    [SugarColumn(ColumnDescription = "工序名")]
    public string step_name { get; set; }
    /// <summary>
    /// 工序合格数
    /// </summary>

    [SugarColumn(ColumnDescription = "工序合格数")]
    public int step_qualified_number { get; set; }
    /// <summary>
    /// 工序不合格数
    /// </summary>
    [SugarColumn(ColumnDescription = "工序不合格数")]
    public int step_unqualified_number { get; set; }
    /// <summary>
    /// 工单合格数
    /// </summary>
    [SugarColumn(ColumnDescription = "工单合格数")]
    public int qualified_number { get; set; }
    /// <summary>
    /// 工单不合格数
    /// </summary>
    [SugarColumn(ColumnDescription = "工单不合格数")]
    public int unqualified_number { get; set; }
}
