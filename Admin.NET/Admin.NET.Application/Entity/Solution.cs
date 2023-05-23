namespace Admin.NET.Application.Entity;

[SugarTable("VcSolution", "视频合成的方案")]
public class Solution : EntityBase
{
    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    public string Name { get; set; }

    [SugarColumn(ColumnDescription = "禁用")]
    public bool IsDisable { get; set; }

    [SugarColumn(ColumnDescription = "备注", Length = 512)]
    public string? Remark { get; set; }

    [Navigate(NavigateType.OneToMany, nameof(SolutionItem.SolutionId))]
    public List<SolutionItem> Items { get; set; }
}

[SugarTable("VcSolutionItem", "视频合成的方案明细")]
public class SolutionItem : EntityBaseId
{
    [SugarColumn(ColumnDescription = "方案Id")]
    public long SolutionId { get; set; }

    [SugarColumn(ColumnDescription = "禁用")]
    public bool IsDisable { get; set; }

    [SugarColumn(ColumnDescription = "类型")]
    public MaterialType Type { get; set; }

    [SugarColumn(ColumnDescription = "起始(秒)")]
    public int Start { get; set; }

    [SugarColumn(ColumnDescription = "持续(秒)")]
    public int Range { get; set; }

    [SugarColumn(ColumnDescription = "设备Id")]
    public long? DeviceId { get; set; }

    [SugarColumn(ColumnDescription = "素材", Length = 256)]
    public string? Url { get; set; }

    [SugarColumn(ColumnDescription = "排序")]
    public int SortIndex { get; set; }

    [SugarColumn(ColumnDescription = "备注", Length = 512)]
    public string? Remark { get; set; }

    [Navigate(NavigateType.OneToOne, nameof(SysFile.Url))]
    public SysFile File { get; set; }
}