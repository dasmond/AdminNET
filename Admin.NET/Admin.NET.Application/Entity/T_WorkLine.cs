using Admin.NET.Core;
namespace Admin.NET.Application.Entity;

/// <summary>
/// 生产线
/// </summary>
[SugarTable("T_WorkLine","生产线")]
public class T_WorkLine  : EntityTenant
{
    /// <summary>
    /// 生产线编号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkLineCode", ColumnDescription = "生产线编号", Length = 128)]
    public string WorkLineCode { get; set; }
    
    /// <summary>
    /// 生产线名称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkLineName", ColumnDescription = "生产线名称", Length = 128)]
    public string WorkLineName { get; set; }
    
    /// <summary>
    /// 生产线简称
    /// </summary>
    [SugarColumn(ColumnName = "WorkLineSimpleName", ColumnDescription = "生产线简称", Length = 128)]
    public string? WorkLineSimpleName { get; set; }
    
    /// <summary>
    /// 允许领料
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "IfAllowed", ColumnDescription = "允许领料", Length = 1)]
    public string IfAllowed { get; set; }
    
    /// <summary>
    /// 允许计件
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "IfPriceAllowed", ColumnDescription = "允许计件", Length = 1)]
    public string IfPriceAllowed { get; set; }
    
    /// <summary>
    /// 所属生产中心
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkGroupID", ColumnDescription = "所属生产中心")]
    public long WorkGroupID { get; set; }
    
}
