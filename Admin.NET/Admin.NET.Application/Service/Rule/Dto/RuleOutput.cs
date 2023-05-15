namespace Admin.NET.Application;

/// <summary>
/// 规则输出参数
/// </summary>
public class RuleOutput
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 禁用
    /// </summary>
    public bool IsDisable { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public MaterialType Type { get; set; }

    /// <summary>
    /// 起始(秒)
    /// </summary>
    public long Start { get; set; }

    /// <summary>
    /// 持续(秒)
    /// </summary>
    public long Range { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 素材
    /// </summary>
    public string? Url { get; set; }
    public SysFile File { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public long SortIndex { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}