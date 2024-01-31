using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Packing;
[SugarTable("packing", "包装表")]
[Tenant(MesExpandConst.ConfigId)]
public class Packing : EntityBase
{
    /// <summary>
    /// 所属包装id
    /// </summary>
    [SugarColumn(ColumnDescription = "所属包装id")]
    public long? pack_id { get; set; }
    /// <summary>
    /// 包装编号
    /// </summary>
    [SugarColumn(ColumnDescription = "包装编号")]
    public string pack_code { get; set; }
    /// <summary>
    /// 客户编号
    /// </summary>
    [SugarColumn(ColumnDescription = "客户编号")]
    public string? customer_code { get; set; }
    /// <summary>
    /// 工单id
    /// </summary>
    [SugarColumn(ColumnDescription = "工单id")]
    public long? work_sheet_id { get; set; }
    /// <summary>
    /// 工单号
    /// </summary>
    [SugarColumn(ColumnDescription = "工单号")]
    public string work_sheet_sn { get; set; }
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
    /// 合同号
    /// </summary>
    [SugarColumn(ColumnDescription = "合同号")]
    public string? contract_num { get; set; }
    /// <summary>
    /// 谱系/物料编号
    /// </summary>
    [SugarColumn(ColumnDescription = "谱系编码")]
    public string pedigree_code { get; set; }
    /// <summary>
    /// 谱系/物料id
    /// </summary>
    [SugarColumn(ColumnDescription = "谱系Id")]
    public long? pedigree_id { get; set; }
    /// <summary>
    /// 是否为盒装
    /// </summary>
    [SugarColumn(ColumnDescription = "盒装")]
    public bool small_box { get; set; }
    /// <summary>
    /// 完成打包
    /// </summary>
    [SugarColumn(ColumnDescription = "完成打包")]
    public bool pack { get; set; }
    /// <summary>
    /// 标签容量
    /// </summary>
    [SugarColumn(ColumnDescription = "标签容量")]
    public int count { get; set; }
    /// <summary>
    /// 打印次数
    /// </summary>
    [SugarColumn(ColumnDescription = "打印次数")]
    public int print_count { get; set; }
}
