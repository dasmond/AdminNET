namespace Admin.NET.Application.Entity;

[SugarTable("VcDevice", "视频合成的设备")]
public class Device : EntityBase
{
    [SugarColumn(ColumnDescription = "类型")]
    public DeviceType Type { get; set; }

    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    public string Name { get; set; }

    [SugarColumn(ColumnDescription = "IP&端口", Length = 64)]
    public string? IpPort { get; set; }

    [SugarColumn(ColumnDescription = "账号", Length = 64)]
    public string? Account { get; set; }

    [SugarColumn(ColumnDescription = "密码", Length = 64)]
    public string? Password { get; set; }

    [SugarColumn(ColumnDescription = "备注", Length = 512)]
    public string? Remark { get; set; }
}
