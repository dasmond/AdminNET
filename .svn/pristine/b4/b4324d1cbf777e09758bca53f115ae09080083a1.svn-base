using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

/// <summary>
/// 销售合同主表基础输入参数
/// </summary>
public class SalesContractMasterBaseInput
{
    /// <summary>
    /// 编码
    /// </summary>
    public virtual string Sno { get; set; }

    /// <summary>
    /// 购方合同编码
    /// </summary>
    public virtual string PurchaserSno { get; set; }

    /// <summary>
    /// 客户id
    /// </summary>
    public virtual long CustomerId { get; set; }

    /// <summary>
    /// 联系人id
    /// </summary>
    public virtual long LinkmanId { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public virtual string Status { get; set; }

    /// <summary>
    /// 完成状态
    /// </summary>
    public virtual int CompleteStatus { get; set; }

    /// <summary>
    /// 发货方式
    /// </summary>
    public virtual string Shipping { get; set; }

    /// <summary>
    /// 收货人id
    /// </summary>
    public virtual long Consignee { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public virtual string MeMo { get; set; }

    /// <summary>
    /// 是否允许回签
    /// </summary>
    public virtual bool AllowSignatureBack { get; set; }

    /// <summary>
    /// 允许导出
    /// </summary>
    public virtual bool AllowExport { get; set; }

    /// <summary>
    /// 是否送样
    /// </summary>
    public virtual bool SampleDelivery { get; set; }

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
/// 销售合同主表分页查询输入参数
/// </summary>
public class SalesContractMasterInput : BasePageInput
{
    /// <summary>
    /// 关键字查询
    /// </summary>
    public string? SearchKey { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Sno { get; set; }

    /// <summary>
    /// 购方合同编码
    /// </summary>
    public string? PurchaserSno { get; set; }

    /// <summary>
    /// 客户id
    /// </summary>
    public long? CustomerId { get; set; }

    /// <summary>
    /// 联系人id
    /// </summary>
    public long? LinkmanId { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// 完成状态
    /// </summary>
    public int? CompleteStatus { get; set; }

    /// <summary>
    /// 发货方式
    /// </summary>
    public string? Shipping { get; set; }

    /// <summary>
    /// 收货人id
    /// </summary>
    public long? Consignee { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? MeMo { get; set; }

    /// <summary>
    /// 是否允许回签
    /// </summary>
    public bool? AllowSignatureBack { get; set; }

    /// <summary>
    /// 允许导出
    /// </summary>
    public bool? AllowExport { get; set; }

    /// <summary>
    /// 合同类型
    /// </summary>


    public int? TypesOf { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public int? ReVision { get; set; }

}

/// <summary>
/// 销售合同主表增加输入参数
/// </summary>
public class AddSalesContractMasterInput : SalesContractMasterBaseInput
{
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public override string Sno { get; set; }

    /// <summary>
    /// 购方合同编码
    /// </summary>
    [Required(ErrorMessage = "购方合同编码不能为空")]
    public override string PurchaserSno { get; set; }

    /// <summary>
    /// 客户id
    /// </summary>
    [Required(ErrorMessage = "客户id不能为空")]
    public override long CustomerId { get; set; }

    /// <summary>
    /// 联系人id
    /// </summary>
    [Required(ErrorMessage = "联系人id不能为空")]
    public override long LinkmanId { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [Required(ErrorMessage = "状态不能为空")]
    public override string Status { get; set; }

    /// <summary>
    /// 完成状态
    /// </summary>
    [Required(ErrorMessage = "完成状态不能为空")]
    public override int CompleteStatus { get; set; }

    /// <summary>
    /// 发货方式
    /// </summary>
    [Required(ErrorMessage = "发货方式不能为空")]
    public override string Shipping { get; set; }

    /// <summary>
    /// 收货人id
    /// </summary>
    [Required(ErrorMessage = "收货人id不能为空")]
    public override long Consignee { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Required(ErrorMessage = "备注不能为空")]
    public override string MeMo { get; set; }

    /// <summary>
    /// 是否允许回签
    /// </summary>
    [Required(ErrorMessage = "是否允许回签不能为空")]
    public override bool AllowSignatureBack { get; set; }

    /// <summary>
    /// 允许导出
    /// </summary>
    [Required(ErrorMessage = "允许导出不能为空")]
    public override bool AllowExport { get; set; }

    /// <summary>
    /// 是否送样
    /// </summary>
    [Required(ErrorMessage = "是否送样不能为空")]
    public override bool SampleDelivery { get; set; }

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
/// 销售合同主表删除输入参数
/// </summary>
public class DeleteSalesContractMasterInput : BaseIdInput
{
}

/// <summary>
/// 销售合同主表更新输入参数
/// </summary>
public class UpdateSalesContractMasterInput : SalesContractMasterBaseInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }

}

/// <summary>
/// 销售合同主表主键查询输入参数
/// </summary>
public class QueryByIdSalesContractMasterInput : DeleteSalesContractMasterInput
{

}
