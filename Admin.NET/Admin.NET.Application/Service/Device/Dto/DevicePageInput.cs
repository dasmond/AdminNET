namespace Admin.NET.Application;

/// <summary>
/// 设备分页查询参数
/// </summary>
public class DevicePageInput : BasePageInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public DeviceType? Type { get; set; }

    /// <summary>
    /// IP&端口
    /// </summary>
    public string? IpPort { get; set; }
}
