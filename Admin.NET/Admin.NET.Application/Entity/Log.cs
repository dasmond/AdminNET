namespace Admin.NET.Application.Entity;

[SugarTable("VcLog", "视频合成的日志")]
public class Log : EntityBaseId
{
    [SugarColumn(ColumnDescription = "类型")]
    public LogType Type { get; set; }

    [SugarColumn(ColumnDescription = "人脸Id", Length = 256)]
    public string? FaceId { get; set; }

    [SugarColumn(ColumnDescription = "图片", Length = 512)]
    public string? FaceUrl { get; set; }

    [SugarColumn(ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true)]
    public virtual DateTime? CreateTime { get; set; }
}
