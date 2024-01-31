// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

namespace Admin.NET.Application.Service.Mes.Dot.Mes;
public class SubWorkSheetOutput
{
    public long id { get; set; }
    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string serial_number { get; set; }

    /// <summary>
    /// Desc:总工单id
    /// Default:
    /// Nullable:False
    /// </summary>           
    public long work_sheet_id { get; set; }
    /// <summary>
    /// Desc:总工单id
    /// Default:
    /// Nullable:False
    /// </summary>           
    public string work_sheet_sn { get; set; }


    /// <summary>
    /// Desc:投产数
    /// Default:0
    /// Nullable:False
    /// </summary>           
    public int number { get; set; }

    /// <summary>
    /// Desc:合格数
    /// Default:0
    /// Nullable:False
    /// </summary>           
    public int qualified_number { get; set; }

    /// <summary>
    /// Desc:不合格数
    /// Default:0
    /// Nullable:False
    /// </summary>           
    public int unqualified_number { get; set; }

    /// <summary>
    /// Desc:在线返修合格数
    /// Default:0
    /// Nullable:False
    /// </summary>           
    public int rework_qualified_number { get; set; }

    /// <summary>
    /// Desc:工单状态(;1:正常态;2:终止态;3:已完成;5:异常结单)
    /// Default:0
    /// Nullable:False
    /// </summary>           
    public int status { get; set; }
    /// <summary>
    /// 合同号
    /// </summary>
    public string contract_num { get; set; }
    /// <summary>
    /// 客户编号
    /// </summary>
    public string customer_code { get; set; }
    /// <summary>
    /// 谱系编码
    /// </summary>
    public string pedigree_code { get; set; }
    /// <summary>
    /// 谱系id
    /// </summary>
    public long pedigree_id { get; set; }
    /// <summary>
    /// 物料id
    /// </summary>
    public long? material_id { get; set; }
    /// <summary>
    /// Desc:流程框图id
    /// Default:
    /// Nullable:True
    /// </summary>           
    public long? work_flow_id { get; set; }
    /// <summary>
    /// 工序完成数
    /// </summary>
    public int step_num { get; set; }
}
