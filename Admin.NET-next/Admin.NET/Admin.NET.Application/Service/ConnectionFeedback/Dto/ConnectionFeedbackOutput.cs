namespace Admin.NET.Application;

/// <summary>
/// 客户反馈表输出参数
/// </summary>
public class ConnectionFeedbackOutput
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
    /// 编码
    /// </summary>
    public string Sno { get; set; }
    
    /// <summary>
    /// 所属表id
    /// </summary>
    public long DbId { get; set; }
    
    /// <summary>
    /// 反馈内容
    /// </summary>
    public string Content { get; set; }
    
    /// <summary>
    /// 跟进类型
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// 业务员
    /// </summary>
    public string BelongtoName { get; set; }
    
    /// <summary>
    /// 助理
    /// </summary>
    public string AssistantName { get; set; }
    
    /// <summary>
    /// 下次跟进时间
    /// </summary>
    public DateTime? NextFollowUpTime { get; set; }
    
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
 

