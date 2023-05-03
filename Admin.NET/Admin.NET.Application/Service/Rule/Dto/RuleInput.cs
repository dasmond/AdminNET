namespace Admin.NET.Application;

/// <summary>
/// 规则基础输入参数
/// </summary>
public class MaterialBaseInput
{
    /// <summary>
    /// 类型
    /// </summary>
    public virtual MaterialType Type { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// 上传
    /// </summary>
    public virtual string? Url { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public virtual string? Content { get; set; }

    /// <summary>
    /// 起始(秒)
    /// </summary>
    public virtual long Start { get; set; }

    /// <summary>
    /// 持续(秒)
    /// </summary>
    public virtual long Range { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public virtual long SortIndex { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public virtual string? Remark { get; set; }

}

/// <summary>
/// 规则分页查询输入参数
/// </summary>
public class RuleInput : BasePageInput
{
    /// <summary>
    /// 类型
    /// </summary>
    public MaterialType? Type { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Content { get; set; }

}

/// <summary>
/// 规则增加输入参数
/// </summary>
public class AddMaterialInput : MaterialBaseInput
{
    /// <summary>
    /// 类型
    /// </summary>
    [Required(ErrorMessage = "类型不能为空")]
    public override MaterialType Type { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Required(ErrorMessage = "名称不能为空")]
    public override string Name { get; set; }

}

/// <summary>
/// 规则删除输入参数
/// </summary>
public class DeleteMaterialInput : BaseIdInput
{
}

/// <summary>
/// 规则更新输入参数
/// </summary>
public class UpdateMaterialInput : MaterialBaseInput
{
    /// <summary>
    /// Id
    /// </summary>
    [Required(ErrorMessage = "Id不能为空")]
    public long Id { get; set; }

}

/// <summary>
/// 规则主键查询输入参数
/// </summary>
public class QueryByIdMaterialInput : DeleteMaterialInput
{

}
