using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

/// <summary>
/// 上传硬件Layout基础输入参数
/// </summary>
public class LayoutBaseInput
{
    /// <summary>
    /// 商品id
    /// </summary>
    public virtual long GoodsId { get; set; }

    /// <summary>
    /// 项目Id
    /// </summary>
    public virtual long ProjectId { get; set; }

    /// <summary>
    /// 任务Id
    /// </summary>
    public virtual long TaskId { get; set; }

    /// <summary>
    /// 开发工具
    /// </summary>
    public virtual string DevelopmentTool { get; set; }

    /// <summary>
    /// PCB文件
    /// </summary>
    public virtual string PCBUrl { get; set; }

    /// <summary>
    /// 原理图
    /// </summary>
    public virtual string SchematicDiagramImageUrl { get; set; }

    /// <summary>
    /// 贴片图
    /// </summary>
    public virtual string SMTImageUrl { get; set; }

    /// <summary>
    /// Gerber文件
    /// </summary>
    public virtual string GerberUrl { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public virtual string Sno { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public virtual DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public virtual DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 创建者Id
    /// </summary>
    public virtual long? CreateUserId { get; set; }

    /// <summary>
    /// 创建者姓名
    /// </summary>
    public virtual string? CreateUserName { get; set; }

    /// <summary>
    /// 修改者Id
    /// </summary>
    public virtual long? UpdateUserId { get; set; }

    /// <summary>
    /// 修改者姓名
    /// </summary>
    public virtual string? UpdateUserName { get; set; }

    /// <summary>
    /// 软删除
    /// </summary>
    public virtual bool IsDelete { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public virtual int ReVision { get; set; }

}

/// <summary>
/// 上传硬件Layout分页查询输入参数
/// </summary>
public class LayoutInput : BasePageInput
{
    /// <summary>
    /// 关键字查询
    /// </summary>
    public string? SearchKey { get; set; }

    /// <summary>
    /// 模块名
    /// </summary>
    public virtual string Module { get; set; }
    /// <summary>
    /// 商品id
    /// </summary>
    public long? GoodsId { get; set; }

    /// <summary>
    /// 项目Id
    /// </summary>
    public long? ProjectId { get; set; }

    /// <summary>
    /// 任务Id
    /// </summary>
    public long? TaskId { get; set; }

    /// <summary>
    /// 开发工具
    /// </summary>
    public string? DevelopmentTool { get; set; }

    /// <summary>
    /// PCB文件
    /// </summary>
    public string? PCBUrl { get; set; }

    /// <summary>
    /// 原理图
    /// </summary>
    public string? SchematicDiagramImageUrl { get; set; }

    /// <summary>
    /// 贴片图
    /// </summary>
    public string? SMTImageUrl { get; set; }

    /// <summary>
    /// Gerber文件
    /// </summary>
    public string? GerberUrl { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Sno { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public int? ReVision { get; set; }

}



/// <summary>
/// 上传硬件Layout增加输入参数
/// </summary>
public class AddLayoutInput : LayoutBaseInput
{
    /// <summary>
    /// 商品id
    /// </summary>
    [Required(ErrorMessage = "商品id不能为空")]
    public override long GoodsId { get; set; }

    /// <summary>
    /// 项目Id
    /// </summary>
    [Required(ErrorMessage = "项目Id不能为空")]
    public override long ProjectId { get; set; }

    /// <summary>
    /// 任务Id
    /// </summary>
    [Required(ErrorMessage = "任务Id不能为空")]
    public override long TaskId { get; set; }

    /// <summary>
    /// 开发工具
    /// </summary>
    [Required(ErrorMessage = "开发工具不能为空")]
    public override string DevelopmentTool { get; set; }

    /// <summary>
    /// PCB文件
    /// </summary>
    [Required(ErrorMessage = "PCB文件不能为空")]
    public override string PCBUrl { get; set; }

    /// <summary>
    /// 原理图
    /// </summary>
    [Required(ErrorMessage = "原理图不能为空")]
    public override string SchematicDiagramImageUrl { get; set; }

    /// <summary>
    /// 贴片图
    /// </summary>
    [Required(ErrorMessage = "贴片图不能为空")]
    public override string SMTImageUrl { get; set; }

    /// <summary>
    /// Gerber文件
    /// </summary>
    [Required(ErrorMessage = "Gerber文件不能为空")]
    public override string GerberUrl { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public override string Sno { get; set; }

    /// <summary>
    /// 软删除
    /// </summary>
    [Required(ErrorMessage = "软删除不能为空")]
    public override bool IsDelete { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    [Required(ErrorMessage = "乐观锁不能为空")]
    public override int ReVision { get; set; }

}

/// <summary>
/// 上传硬件Layout删除输入参数
/// </summary>
public class DeleteLayoutInput : BaseIdInput
{
}

/// <summary>
/// 上传硬件Layout更新输入参数
/// </summary>
public class UpdateLayoutInput : LayoutBaseInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }

}

/// <summary>
/// 上传硬件Layout主键查询输入参数
/// </summary>
public class QueryByIdLayoutInput : DeleteLayoutInput
{

}
