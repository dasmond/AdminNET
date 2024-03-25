namespace Admin.NET.Application;

/// <summary>
/// BOM资料表副本输出参数
/// </summary>
public class BomDetailsCopyOutput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    public string MeMo { get; set; }
    
    /// <summary>
    /// Bom主表id
    /// </summary>
    public long BomId { get; set; }
    
    /// <summary>
    /// 上级物料id
    /// </summary>
    public long ParentPartId { get; set; }
    
    /// <summary>
    /// 上级物料编码
    /// </summary>
    public string ParentPartNo { get; set; }
    
    /// <summary>
    /// 当前物料编码
    /// </summary>
    public string PartNo { get; set; }
    
    /// <summary>
    /// 用量
    /// </summary>
    public decimal Qty { get; set; }
    
    /// <summary>
    /// 不良率
    /// </summary>
    public decimal DefectRate { get; set; }
    
    /// <summary>
    /// 工序号
    /// </summary>
    public string Locator { get; set; }
    
    /// <summary>
    /// 不发料
    /// </summary>
    public bool NoPur { get; set; }
    
    /// <summary>
    /// 位号
    /// </summary>
    public string Rem { get; set; }
    
    /// <summary>
    /// 版本
    /// </summary>
    public string Ver { get; set; }
    
    /// <summary>
    /// 层级
    /// </summary>
    public int Level { get; set; }
    
    /// <summary>
    /// 完成状态
    /// </summary>
    public int CompleteStatus { get; set; }
    
    /// <summary>
    /// 变更状态
    /// </summary>
    public int ChangeStatus { get; set; }
    
    /// <summary>
    /// 替代料状态
    /// </summary>
    public int AlternativeMaterialStatus { get; set; }
    
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
 

