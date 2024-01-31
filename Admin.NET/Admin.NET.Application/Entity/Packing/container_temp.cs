using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Packing;
[SugarTable("container_temp", "容器缓存表")]
[Tenant(MesExpandConst.ConfigId)]
public class container_temp: EntityBase
{
    /// <summary>
    /// 容器编号
    /// </summary>
    [SugarColumn(ColumnDescription = "容器编号")]
    public string code { get; set; }
    /// <summary>
    /// 总数
    /// </summary>
    [SugarColumn(ColumnDescription = "总数")]
    public int sum_count { get; set; }
    /// <summary>
    /// 剩余数量
    /// </summary>
    [SugarColumn(ColumnDescription = "剩余数量")]
    public int remainder_count { get; set; }
    /// <summary>
    /// Desc:物料id
    /// Default:
    /// Nullable:False
    /// </summary>           
    [SugarColumn(ColumnDescription = "物料id")]
    public long material_id { get; set; }
    /// <summary>
    /// 分拆次数
    /// </summary>
    [SugarColumn(ColumnDescription = "分拆次数")]
    public int split_num { get; set; }
    /// <summary>
    /// 子工单id
    /// </summary>
    [SugarColumn(ColumnDescription = "子工单id")]
    public long? sub_work_sheet_id { get; set; }
    /// <summary>
    /// 源子工单id
    /// </summary>
    [SugarColumn(ColumnDescription = "源子工单id")]
    public long? source_sub_work_sheet_id { get; set; }
    /// <summary>
    /// 源物料Id
    /// </summary>
    [SugarColumn(ColumnDescription = "源物料Id")]
    public long? source_material_id { get; set; }
}
