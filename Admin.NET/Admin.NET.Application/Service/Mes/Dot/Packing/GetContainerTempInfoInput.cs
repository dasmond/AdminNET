namespace Admin.NET.Application.Service.Mes.Dot.Packing;
public class GetContainerTempInfoInput
{
    public string code { get; set; }
    /// <summary>
    /// 总数
    /// </summary>
    public int? sum_count { get; set; }
    /// <summary>
    /// 分拆数量
    /// </summary>
    public int? split_count { get; set; }
    /// <summary>
    /// Desc:物料id
    /// Default:
    /// Nullable:False
    /// </summary>           
    public long? material_id { get; set; }
    /// <summary>
    /// 子工单id
    /// </summary>
    public long? sub_work_sheet_id { get; set; }
    /// <summary>
    /// 源子工单id
    /// </summary>
    public long? source_sub_work_sheet_id { get; set; }
    /// <summary>
    /// 源物料Id
    /// </summary>
    public long? source_material_id { get; set; }
}
