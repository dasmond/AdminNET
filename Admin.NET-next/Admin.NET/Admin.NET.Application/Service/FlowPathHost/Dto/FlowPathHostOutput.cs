namespace Admin.NET.Application;

/// <summary>
/// 流程主表输出参数
/// </summary>
public class FlowPathHostOutput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 编码
    /// </summary>
    public string Sno { get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    public string MeMo { get; set; }
    
    /// <summary>
    /// 状态
    /// </summary>
    public string StaTus { get; set; }
    
    /// <summary>
    /// 流程名
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 分类
    /// </summary>
    public long Grouping { get; set; }
    
    /// <summary>
    /// 版本
    /// </summary>
    public string Version { get; set; }
    
    /// <summary>
    /// 绑定表名
    /// </summary>
    public string TableName { get; set; }
    
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
 

