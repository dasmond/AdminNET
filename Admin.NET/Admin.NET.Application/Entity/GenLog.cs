namespace Admin.NET.Application.Entity;

[SugarTable("VcGenLog", "视频合成的日志")]
public class GenLog : EntityBaseId
{
    [SugarColumn(ColumnDescription = "类型")]
    public GenLogType Type { get; set; }

    [SugarColumn(ColumnDescription = "人脸Id", Length = 256)]
    public string? FaceId { get; set; }

    [SugarColumn(ColumnDescription = "图片", Length = 512)]
    public string? FaceUrl { get; set; }

    [SugarColumn(ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true)]
    public virtual DateTime? CreateTime { get; set; }
}
