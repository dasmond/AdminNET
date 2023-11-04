namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品选配项值
/// </summary>
[SugarTable("T_ConfigProjectValue","产品选配项值")]
public class T_ConfigProjectValue 
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "Id", IsIdentity = false, ColumnDescription = "主键Id", IsPrimaryKey = true)]
    public long Id { get; set; }
    
    /// <summary>
    /// 选配项ID
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "ConfigProjectId", ColumnDescription = "选配项ID")]
    public long ConfigProjectId { get; set; }
    
    /// <summary>
    /// 序号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "PrintId", ColumnDescription = "序号")]
    public int PrintId { get; set; }
    
    /// <summary>
    /// 项值编号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "ConfigProjectValueCode", ColumnDescription = "项值编号", Length = 32)]
    public string ConfigProjectValueCode { get; set; }
    
    /// <summary>
    /// 项值名称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "ConfigProjectValueName", ColumnDescription = "项值名称", Length = 128)]
    public string ConfigProjectValueName { get; set; }
    
    /// <summary>
    /// 是否默认值
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "IfDft", ColumnDescription = "是否默认值", Length = 1)]
    public string IfDft { get; set; }
    
    /// <summary>
    /// 项值等级
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "Level", ColumnDescription = "项值等级", Length = 1)]
    public string Level { get; set; }
    
    /// <summary>
    /// 启用
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "Ifuse", ColumnDescription = "启用", Length = 1)]
    public string Ifuse { get; set; }
    
    /// <summary>
    /// 必填
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "IfRequired", ColumnDescription = "必填", Length = 1)]
    public string IfRequired { get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnName = "Remarks", ColumnDescription = "备注", Length = 255)]
    public string? Remarks { get; set; }
    
    /// <summary>
    /// 租户Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "TenantId", ColumnDescription = "租户Id")]
    public long TenantId { get; set; }
    
}
