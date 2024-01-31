// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Service.Mes.Dot.Mes;

namespace Admin.NET.Application.Service.Mes.Dot.Packing;
public class GetTestDataInput
{
    public string sn { get; set; }
    /// <summary>
    /// 客户SN
    /// </summary>
    public string customer_sn { get; set; }
    /// <summary>
    /// 工单号
    /// </summary>
    public string work_sheet_sn { get; set; }
    /// <summary>
    /// 工单Id
    /// </summary>
    public long? work_sheet_id { get; set; }
    /// <summary>
    /// 谱系编码
    /// </summary>
    public string pedigree_code { get; set; }
    /// <summary>
    /// 谱系id
    /// </summary>
    public long? pedigree_id { get; set; }
    /// <summary>
    /// 合同号
    /// </summary>
    public string contract_num { get; set; }
    /// <summary>
    /// 容器号
    /// </summary>
    public string container_code { get; set; }
    /// <summary>
    /// 包装编号
    /// </summary>
    public string pack_code { get; set; }
    /// <summary>
    /// 所属包装,0为未包装
    /// </summary>
    public long? pack_id { get; set; }
    /// <summary>
    /// 批量查询数
    /// </summary>
    public int? get_count { get; set; }
}
