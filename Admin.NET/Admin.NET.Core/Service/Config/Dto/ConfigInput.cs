namespace Admin.NET.Core.Service;

public class ConfigInput : BaseIdInput
{
}

public class PageConfigInput : BasePageInput
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 常量所属分类的编码
    /// </summary>
    public string GroupCode { get; set; }
}

[NotTable]
public class AddConfigInput : SysConfig
{
}

[NotTable]
public class UpdateConfigInput : AddConfigInput
{
}

public class DeleteConfigInput : BaseIdInput
{
}