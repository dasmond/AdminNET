namespace Admin.NET.Application;

/// <summary>
/// 设备输出参数
/// </summary>
public class DeviceOutput
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
    /// 类型
    /// </summary>
    public DeviceType Type { get; set; }

    /// <summary>
    /// IP&端口
    /// </summary>
    public string? IpPort { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}