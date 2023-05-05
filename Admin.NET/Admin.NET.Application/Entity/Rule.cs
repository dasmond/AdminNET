namespace Admin.NET.Application.Entity;

[SugarTable("VcRule", "视频合成的规则")]
public class Rule : EntityBase
{
    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    public string Name { get; set; }

    [SugarColumn(ColumnDescription = "类型")]
    public MaterialType Type { get; set; }

    [SugarColumn(ColumnDescription = "禁用")]
    public bool IsDisable { get; set; }

    [SugarColumn(ColumnDescription = "起始(秒)")]
    public int Start { get; set; }

    [SugarColumn(ColumnDescription = "持续(秒)")]
    public int Range { get; set; }

    [SugarColumn(ColumnDescription = "内容", Length = 512)]
    public string? Content { get; set; }

    [SugarColumn(ColumnDescription = "素材", Length = 256)]
    public string? Url { get; set; }

    [SugarColumn(ColumnDescription = "排序")]
    public int SortIndex { get; set; }

    [SugarColumn(ColumnDescription = "备注", Length = 512)]
    public string? Remark { get; set; }
}
