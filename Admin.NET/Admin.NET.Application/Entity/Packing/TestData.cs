// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。


using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Packing;
[SugarTable("test_data", "测试数据表")]
[Tenant(MesExpandConst.ConfigId)]
public class TestData : EntityBase
{
    /// <summary>
    /// SN
    /// </summary>
    [SugarColumn(ColumnDescription = "内部SN")]
    public string? sn { get; set; }
    /// <summary>
    /// 客户SN
    /// </summary>
    [SugarColumn(ColumnDescription = "客户SN")]
    public string? customer_sn { get; set; }
    /// <summary>
    /// 谱系编码
    /// </summary>
    [SugarColumn(ColumnDescription = "谱系编码")]
    public string? pedigree_code { get; set; }
    /// <summary>
    /// 谱系id
    /// </summary>
    [SugarColumn(ColumnDescription = "谱系Id")]
    public long? pedigree_id { get; set; }
    /// <summary>
    /// 工单id
    /// </summary>
    [SugarColumn(ColumnDescription = "工单id")]
    public long? work_sheet_id { get; set; }
    /// <summary>
    /// 工单号
    /// </summary>
    [SugarColumn(ColumnDescription = "工单号")]
    public string? work_sheet_sn { get; set; }
    /// <summary>
    /// 子工单id
    /// </summary>
    [SugarColumn(ColumnDescription = "子工单id")]
    public long? sub_work_sheet_id { get; set; }
    /// <summary>
    /// 子工单号
    /// </summary>
    [SugarColumn(ColumnDescription = "子工单号")]
    public string? sub_work_sheet_sn { get; set; }
    /// <summary>
    /// 包装序号
    /// </summary>
    [SugarColumn(ColumnDescription = "包装序号")]
    public int order_num { get; set; }
    /// <summary>
    /// 合同号
    /// </summary>
    [SugarColumn(ColumnDescription = "合同号")]
    public string? contract_num { get; set; }
    /// <summary>
    /// 容器编号
    /// </summary>
    [SugarColumn(ColumnDescription = "容器编号")]
    public string? container_code { get; set; }
    /// <summary>
    /// 客户编码
    /// </summary>
    [SugarColumn(ColumnDescription = "客户编码")]
    public string? customer_code { get; set; }
    /// <summary>
    /// 打印次数
    /// </summary>
    [SugarColumn(ColumnDescription = "打印次数")]
    public int print_count { get; set; }
    /// <summary>
    /// 所属包装
    /// </summary>
    [SugarColumn(ColumnDescription = "所属包装")]
    public long pack_id { get; set; }
    /// <summary>
    /// 测试数据
    /// </summary>
    [SugarColumn(ColumnDescription = "测试数据", IsJson = true)]
    public Dictionary<string, object> json_data { get; set; }
}
