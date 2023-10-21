using Admin.NET.Core;
namespace Admin.NET.Application.Entity;

/// <summary>
/// 生产中心
/// </summary>
[SugarTable("T_WorkGroup","生产中心")]
public class T_WorkGroup  : EntityTenant
{
    /// <summary>
    /// 生产中心编号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupCode", ColumnDescription = "生产中心编号", Length = 128)]
    public string WorkGroupCode { get; set; }
    
    /// <summary>
    /// 生产中心名称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupName", ColumnDescription = "生产中心名称", Length = 128)]
    public string WorkGroupName { get; set; }
    
    /// <summary>
    /// 生产中心简称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupSimpleName", ColumnDescription = "生产中心简称", Length = 128)]
    public string WorkGroupSimpleName { get; set; }
    
    /// <summary>
    /// 所属车间
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkShopID", ColumnDescription = "所属车间")]
    public long WorkShopID { get; set; }
    
}
