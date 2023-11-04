namespace Admin.NET.Application.Entity;

/// <summary>
/// 产品选配项目
/// </summary>
[SugarTable("T_ConfigType","产品选配项目")]
public class T_ConfigType 
{
    /// <summary>
    /// 产品选配项目名称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "ConfigTypeName", ColumnDescription = "产品选配项目名称", Length = 32)]
    public string ConfigTypeName { get; set; }
    
    /// <summary>
    /// 审核者ID
    /// </summary>
    [SugarColumn(ColumnName = "AuditUserId", ColumnDescription = "审核者ID")]
    public long? AuditUserId { get; set; }
    
    /// <summary>
    /// 审核时间
    /// </summary>
    [SugarColumn(ColumnName = "AuditTime", ColumnDescription = "审核时间")]
    public DateTime? AuditTime { get; set; }
    
    /// <summary>
    /// 租户Id
    /// </summary>
    [SugarColumn(ColumnName = "TenantId", ColumnDescription = "租户Id")]
    public long? TenantId { get; set; }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(ColumnName = "CreateTime", ColumnDescription = "创建时间")]
    public DateTime? CreateTime { get; set; }
    
    /// <summary>
    /// 更新时间
    /// </summary>
    [SugarColumn(ColumnName = "UpdateTime", ColumnDescription = "更新时间")]
    public DateTime? UpdateTime { get; set; }
    
    /// <summary>
    /// 创建者Id
    /// </summary>
    [SugarColumn(ColumnName = "CreateUserId", ColumnDescription = "创建者Id")]
    public long? CreateUserId { get; set; }
    
    /// <summary>
    /// 修改者Id
    /// </summary>
    [SugarColumn(ColumnName = "UpdateUserId", ColumnDescription = "修改者Id")]
    public long? UpdateUserId { get; set; }
    
    /// <summary>
    /// 软删除
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "IsDelete", ColumnDescription = "软删除")]
    public bool IsDelete { get; set; }
    
    /// <summary>
    /// Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "Id", IsIdentity = false, ColumnDescription = "Id", IsPrimaryKey = true)]
    public long Id { get; set; }
    
}
