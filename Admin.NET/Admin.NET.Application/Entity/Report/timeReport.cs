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
[SugarTable("time_report", "生产时段报表")]
[Tenant(MesExpandConst.ConfigId)]
public class timeReport : EntityBase
{
    /// <summary>
    /// 修改时间
    /// </summary>
    [SugarColumn(ColumnDescription = "修改时间")]
    public DateTime last_modified_date { get; set; }
    /// <summary>
    /// 动态数据Id
    /// </summary>
    [SugarColumn(ColumnDescription = "动态数据Id")]
    public long procedure_batch_work_detail_id { get; set; }
    /// <summary>
    /// Desc:工单id
    /// Default:
    /// Nullable:True
    /// </summary>         
    [SugarColumn(ColumnDescription = "工单id")]
    public long? work_sheet_id { get; set; }
    /// <summary>
    /// 合同号
    /// </summary>
    [SugarColumn(ColumnDescription = "合同号")]
    public string? custom2 { get; set; }
    /// <summary>
    /// Desc:名称
    /// Default:
    /// Nullable:False
    /// </summary>           
    [SugarColumn(ColumnDescription = "名称")]
    public string pedigree_name { get; set; }

    /// <summary>
    /// Desc:编码
    /// Default:
    /// Nullable:False
    /// </summary>       
    [SugarColumn(ColumnDescription = "名称")]
    public string pedigree_code { get; set; }
    /// <summary>
    /// Desc:计划开工日期
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn(ColumnDescription = "计划开工日期")]
    public DateTime? plan_start_date { get; set; }

    /// <summary>
    /// Desc:计划结单日期
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn(ColumnDescription = "计划结单日期")]
    public DateTime? plan_end_date { get; set; }

    /// <summary>
    /// Desc:实际开工日期
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn(ColumnDescription = "实际开工日期")]
    public DateTime? actual_start_date { get; set; }

    /// <summary>
    /// Desc:实际完成日期
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn(ColumnDescription = "实际完成日期")]
    public DateTime? actual_end_date { get; set; }
    /// <summary>
    /// Desc:子工单id
    /// Default:
    /// Nullable:True
    /// </summary>   
    [SugarColumn(ColumnDescription = "子工单id")]
    public long sub_work_sheet_id { get; set; }
    /// <summary>
    /// 工单编号
    /// </summary>
    [SugarColumn(ColumnDescription = "工单编号")]
    public string work_sheet_sn { get; set; }
    /// <summary>
    /// 投产数
    /// </summary>
    [SugarColumn(ColumnDescription = "投产数")]
    public int work_sheet_number { get; set; }
    /// <summary>
    /// 工单合格数
    /// </summary>
    [SugarColumn(ColumnDescription = "工单合格数")]
    public int work_sheet_qualified_number { get; set; }
    /// <summary>
    /// 工单不合格数
    /// </summary>
    [SugarColumn(ColumnDescription = "工单不合格数")]
    public int work_sheet_unqualified_number { get; set; }
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
    /// Desc:工序编号
    /// Default:
    /// Nullable:False
    /// </summary>           
    [SugarColumn(ColumnDescription = "工序编号")]
    public string step_code { get; set; }
    /// <summary>
    /// Desc:工序名
    /// Default:
    /// Nullable:False
    /// </summary>           
    [SugarColumn(ColumnDescription = "工序名")]
    public string step_name { get; set; }
    /// <summary>
    /// 工序投产数
    /// </summary>
    [SugarColumn(ColumnDescription = "工序投产数")]
    public int step_number { get; set; }
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
}
