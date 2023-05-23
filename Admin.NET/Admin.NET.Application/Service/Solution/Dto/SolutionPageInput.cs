namespace Admin.NET.Application;

/// <summary>
/// 方案分页查询参数
/// </summary>
public class SolutionPageInput : BasePageInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 禁用
    /// </summary>
    public bool? IsDisable { get; set; }
}
