
namespace Admin.NET.Application.Service.Mes.Dot.Packing;
public class ContainerTempOutput
{
    public long sub_id { get; set; }
    /// <summary>
    /// 容器编号
    /// </summary>
    public string code { get; set; }
    /// <summary>
    /// 序号id
    /// </summary>
    public int order_id { get; set; }
    /// <summary>
    /// 总数
    /// </summary>
    public int sum_count { get; set; }
    /// <summary>
    /// 拆分总数
    /// </summary>
    public int split_sum_count { get; set; }
    /// <summary>
    /// 总剩余数量
    /// </summary>
    public int remainder_count { get; set; }
    /// <summary>
    /// 拆分剩余数量
    /// </summary>
    public int split_remainder_count { get; set; }
    /// <summary>
    /// Desc:物料id
    /// Default:
    /// Nullable:False
    /// </summary>           
    public long material_id { get; set; }
    /// <summary>
    /// 分拆次数
    /// </summary>
    public int split_num { get; set; }
    /// <summary>
    /// 子工单id
    /// </summary>
    public long? sub_work_sheet_id { get; set; }
    /// <summary>
    /// 容器缓存id
    /// </summary>
    public long? container_temp_id { get; set; }
    /// <summary>
    /// 源子工单id
    /// </summary>
    public long? source_sub_work_sheet_id { get; set; }
    /// <summary>
    /// 源物料Id
    /// </summary>
    public long? source_material_id { get; set; }
}
