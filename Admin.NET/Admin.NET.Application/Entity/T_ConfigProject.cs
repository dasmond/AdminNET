namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品选配项
/// </summary>
[SugarTable("T_ConfigProject","产品选配项")]
public class T_ConfigProject 
{
    /// <summary>
    /// 产品选配项ID
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "Id", IsIdentity = false, ColumnDescription = "选配项ID", IsPrimaryKey = true)]
    public long Id { get; set; }
    
    /// <summary>
    /// 产品选配项目ID
    /// </summary>
    [SugarColumn(ColumnName = "ConfigTypeId", ColumnDescription = "选配类型ID")]
    public long? ConfigTypeId { get; set; }
    
    /// <summary>
    /// 产品选配项录入类型
    /// </summary>
    [SugarColumn(ColumnName = "Inputtype", ColumnDescription = "选配项录入类型", Length = 1)]
    public string? Inputtype { get; set; }
    
    /// <summary>
    /// 产品选配项编号
    /// </summary>
    [SugarColumn(ColumnName = "ConfigProjectCode", ColumnDescription = "选配项编号", Length = 32)]
    public string? ConfigProjectCode { get; set; }
    
    /// <summary>
    /// 产品选配项名称
    /// </summary>
    [SugarColumn(ColumnName = "ConfigProjectName", ColumnDescription = "选配项名称", Length = 128)]
    public string? ConfigProjectName { get; set; }
    
    /// <summary>
    /// 启用
    /// </summary>
    [SugarColumn(ColumnName = "Ifuse", ColumnDescription = "启用", Length = 1)]
    public string? Ifuse { get; set; }
    
    /// <summary>
    /// 必填
    /// </summary>
    [SugarColumn(ColumnName = "IfRequired", ColumnDescription = "必填", Length = 1)]
    public string? IfRequired { get; set; }
    
    /// <summary>
    /// 租户Id
    /// </summary>
    [SugarColumn(ColumnName = "TenantId", ColumnDescription = "租户Id")]
    public long? TenantId { get; set; }
    
}
