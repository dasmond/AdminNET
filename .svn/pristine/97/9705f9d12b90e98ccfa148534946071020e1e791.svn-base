using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

/// <summary>
/// 项目附件版本打包详情表基础输入参数
/// </summary>
public class AppendixVersionsDetailsBaseInput
{
    /// <summary>
    /// 备注
    /// </summary>
    public virtual string MeMo { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public virtual string Sno { get; set; }

    /// <summary>
    /// 所属打包版本id
    /// </summary>
    public virtual long DbId { get; set; }

    /// <summary>
    /// 附件id
    /// </summary>
    public virtual long DnnexesId { get; set; }

    /// <summary>
    /// Url
    /// </summary>
    public virtual string Url { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// 程序类型
    /// </summary>
    public virtual int ProgramType { get; set; }

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
/// 项目附件版本打包详情表分页查询输入参数
/// </summary>
public class AppendixVersionsDetailsInput : BasePageInput
{
    /// <summary>
    /// 关键字查询
    /// </summary>
    public string? SearchKey { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? MeMo { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Sno { get; set; }

    /// <summary>
    /// 所属打包版本id
    /// </summary>
    public long? DbId { get; set; }

    /// <summary>
    /// 附件id
    /// </summary>
    public long? DnnexesId { get; set; }

    /// <summary>
    /// Url
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 程序类型-0:软件 1：硬件
    /// </summary>
    public int? ProgramType { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public int? ReVision { get; set; }
    /// <summary>
    /// 下载次数
    /// </summary>
    public int Download { get; set; }

}

/// <summary>
/// 项目附件版本打包详情表增加输入参数
/// </summary>
public class AddAppendixVersionsDetailsInput : AppendixVersionsDetailsBaseInput
{
    /// <summary>
    /// 备注
    /// </summary>
    [Required(ErrorMessage = "备注不能为空")]
    public override string MeMo { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public override string Sno { get; set; }

    /// <summary>
    /// 所属打包版本id
    /// </summary>
    [Required(ErrorMessage = "所属打包版本id不能为空")]
    public override long DbId { get; set; }

    /// <summary>
    /// 附件id
    /// </summary>
    [Required(ErrorMessage = "附件id不能为空")]
    public override long DnnexesId { get; set; }

    /// <summary>
    /// Url
    /// </summary>
    [Required(ErrorMessage = "Url不能为空")]
    public override string Url { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Required(ErrorMessage = "名称不能为空")]
    public override string Name { get; set; }

    /// <summary>
    /// 程序类型
    /// </summary>
    [Required(ErrorMessage = "程序类型不能为空")]
    public override int ProgramType { get; set; }

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
/// 项目附件版本打包详情表删除输入参数
/// </summary>
public class DeleteAppendixVersionsDetailsInput : BaseIdInput
{
}

/// <summary>
/// 项目附件版本打包详情表更新输入参数
/// </summary>
public class UpdateAppendixVersionsDetailsInput : AppendixVersionsDetailsBaseInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }

}

/// <summary>
/// 项目附件版本打包详情表主键查询输入参数
/// </summary>
public class QueryByIdAppendixVersionsDetailsInput : DeleteAppendixVersionsDetailsInput
{

}
