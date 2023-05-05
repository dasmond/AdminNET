namespace Admin.NET.Application;

/// <summary>
/// 设备基础输入参数
/// </summary>
public class DeviceBaseInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public virtual DeviceType Type { get; set; }

    /// <summary>
    /// IP&端口
    /// </summary>
    public virtual string? IpPort { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public virtual string? Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public virtual string? Password { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public virtual string? Remark { get; set; }

}

/// <summary>
/// 设备分页查询输入参数
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

    /// <summary>
    /// 账号
    /// </summary>
    public string? Account { get; set; }

}

/// <summary>
/// 设备主键查询输入参数
/// </summary>
public class DeviceGetInput : BaseIdInput
{

}

/// <summary>
/// 设备增加输入参数
/// </summary>
public class DeviceAddInput : DeviceBaseInput
{
    /// <summary>
    /// 名称
    /// </summary>
    [Required(ErrorMessage = "名称不能为空")]
    public override string Name { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    [Required(ErrorMessage = "类型不能为空")]
    public override DeviceType Type { get; set; }
}

/// <summary>
/// 设备更新输入参数
/// </summary>
public class DeviceUpdInput : DeviceBaseInput
{
    /// <summary>
    /// Id
    /// </summary>
    [Required(ErrorMessage = "Id不能为空")]
    public long Id { get; set; }
}

/// <summary>
/// 设备删除输入参数
/// </summary>
public class DeviceDelInput : BaseIdInput
{
}
