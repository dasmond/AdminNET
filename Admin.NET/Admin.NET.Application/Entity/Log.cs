namespace Admin.NET.Application.Entity;

[SugarTable("VcLog", "视频合成的日志")]
public class Log : EntityBaseId
{
    [SugarColumn(ColumnDescription = "类型")]
    public LogType Type { get; set; }

    [SugarColumn(ColumnDescription = "人脸Id", Length = 256)]
    public string? FaceId { get; set; }


}
