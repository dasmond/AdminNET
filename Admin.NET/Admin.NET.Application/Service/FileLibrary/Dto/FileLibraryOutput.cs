namespace Admin.NET.Application;

/// <summary>
/// 文件库输出参数
/// </summary>
public class FileLibraryOutput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 所属表id
    /// </summary>
    public long DbId { get; set; }
    
    /// <summary>
    /// 文件号
    /// </summary>
    public string FileNumber { get; set; }
    
    /// <summary>
    /// 标准文件号
    /// </summary>
    public string StandardFileNumber { get; set; }
    
    /// <summary>
    /// 所属管理部门
    /// </summary>
    public long Affiliation { get; set; }
    
    /// <summary>
    /// 文件级别
    /// </summary>
    public int Level { get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    public string MeMo { get; set; }
    
    /// <summary>
    /// 编码
    /// </summary>
    public string Sno { get; set; }
    
    /// <summary>
    /// 模块名
    /// </summary>
    public string Module { get; set; }
    
    /// <summary>
    /// 文件名
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 文件类型
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// 文件路径
    /// </summary>
    public string Path { get; set; }
    
    /// <summary>
    /// 文件链接
    /// </summary>
    public string Url { get; set; }
    
    /// <summary>
    /// 文件md5
    /// </summary>
    public string Md5 { get; set; }
    
    /// <summary>
    /// 文件大小
    /// </summary>
    public string Size { get; set; }
    
    /// <summary>
    /// 文件后缀
    /// </summary>
    public string Suffix { get; set; }
    
    /// <summary>
    /// 下载次数
    /// </summary>
    public int Download { get; set; }
    
    /// <summary>
    /// 存储到bucket的名称
    /// </summary>
    public string FileObjectName { get; set; }
    
    /// <summary>
    /// 区分类型
    /// </summary>
    public int DistinguishTypes { get; set; }
    
    /// <summary>
    /// 文件版本号
    /// </summary>
    public int FileVersionNumber { get; set; }
    
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
 

