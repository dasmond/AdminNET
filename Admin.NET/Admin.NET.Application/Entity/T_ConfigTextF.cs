namespace Admin.NET.Application.Entity;

/// <summary>
/// 选配1内容
/// </summary>
[SugarTable("T_ConfigTextF","选配1内容")]
public class T_ConfigTextF 
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "Id", IsIdentity = false, ColumnDescription = "主键Id", IsPrimaryKey = true)]
    public long Id { get; set; }
    
    /// <summary>
    /// ConfigTextFName
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "选配1内容", ColumnDescription = "ConfigTextFName", Length = -1)]
    public string ConfigTextFName { get; set; }
    
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
    /// 创建者Id
    /// </summary>
    [SugarColumn(ColumnName = "CreateUserId", ColumnDescription = "创建者Id")]
    public long? CreateUserId { get; set; }
    
    /// <summary>
    /// 软删除
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "IsDelete", ColumnDescription = "软删除")]
    public bool IsDelete { get; set; }
    
}
