namespace Admin.NET.Application;

/// <summary>
/// BOM主表输出参数
/// </summary>
public class BomMasterOutput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 物料编码
    /// </summary>
    public string PartNo { get; set; }
    
    /// <summary>
    /// 生命周期阶段
    /// </summary>
    public int Cycle { get; set; }
    
    /// <summary>
    /// 工程变更通知书
    /// </summary>
    public string Ecn { get; set; }
    
    /// <summary>
    /// 限制批数
    /// </summary>
    public int RestrictedLots { get; set; }
    
    /// <summary>
    /// 生产状态
    /// </summary>
    public int Statuses { get; set; }
    
    /// <summary>
    /// 审核信息提示
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// 完成状态
    /// </summary>
    public int CompleteStatus { get; set; }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }
    
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
    
    /// <summary>
    /// 创建者Id
    /// </summary>
    public long? CreateUserId { get; set; }
    
    /// <summary>
    /// 创建者姓名
    /// </summary>
    public string? CreateUserName { get; set; }
    
    /// <summary>
    /// 修改者Id
    /// </summary>
    public long? UpdateUserId { get; set; }
    
    /// <summary>
    /// 修改者姓名
    /// </summary>
    public string? UpdateUserName { get; set; }
    
    /// <summary>
    /// 软删除
    /// </summary>
    public bool IsDelete { get; set; }
    
    /// <summary>
    /// 乐观锁
    /// </summary>
    public int ReVision { get; set; }
    
    }
 

