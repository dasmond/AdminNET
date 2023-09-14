using Admin.NET.Core;
namespace Admin.NET.Application.Entity;

/// <summary>
/// 工作组
/// </summary>
[SugarTable("T_WorkGroup","工作组")]
public class WorkGroup  : EntityBase
{
    /// <summary>
    /// 工作组编号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupCode", ColumnDescription = "工作组编号", Length = 50)]
    public string WorkGroupCode { get; set; }
    
    /// <summary>
    /// 工作组名称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupName", ColumnDescription = "工作组名称", Length = 100)]
    public string WorkGroupName { get; set; }
    
    /// <summary>
    /// 工作组简称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupSimpleName", ColumnDescription = "工作组简称", Length = 100)]
    public string WorkGroupSimpleName { get; set; }
    
    /// <summary>
    /// 车间Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkShopId", ColumnDescription = "车间Id")]
    public long WorkShopId { get; set; }
    
}
