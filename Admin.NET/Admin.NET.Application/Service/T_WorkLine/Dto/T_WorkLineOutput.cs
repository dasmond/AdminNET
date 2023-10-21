namespace Admin.NET.Application;

/// <summary>
/// 生产线输出参数
/// </summary>
public class T_WorkLineOutput
{
    /// <summary>
    /// 生产线编号
    /// </summary>
    public string WorkLineCode { get; set; }
    
    /// <summary>
    /// 生产线名称
    /// </summary>
    public string WorkLineName { get; set; }
    
    /// <summary>
    /// 生产线简称
    /// </summary>
    public string? WorkLineSimpleName { get; set; }
    
    /// <summary>
    /// 允许领料
    /// </summary>
    public string IfAllowed { get; set; }
    
    /// <summary>
    /// 允许计件
    /// </summary>
    public string IfPriceAllowed { get; set; }
    
    /// <summary>
    /// 所属生产中心
    /// </summary>
    public long WorkGroupID { get; set; } 
    
    /// <summary>
    /// 所属生产中心 描述
    /// </summary>
    public string WorkGroupIDWorkGroupName { get; set; } 
    
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }
    
    }
 

