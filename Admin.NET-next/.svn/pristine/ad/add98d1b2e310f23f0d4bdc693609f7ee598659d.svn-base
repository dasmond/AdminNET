using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

/// <summary>
/// 客户资料基础输入参数
/// </summary>
public class CustomerBaseInput
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
    /// 客户名称
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// 客户所属人id
    /// </summary>
    public virtual long BelongtoId { get; set; }

    /// <summary>
    /// 上任业务员id
    /// </summary>
    public virtual long Predecessor { get; set; }

    /// <summary>
    /// 助理id
    /// </summary>
    public virtual long AssistantId { get; set; }

    /// <summary>
    /// 助理分配时间
    /// </summary>
    public virtual DateTime? AssistantAllocationTime { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    public virtual string ShortName { get; set; }

    /// <summary>
    /// 客户类型
    /// </summary>
    public virtual string CustomerType { get; set; }

    /// <summary>
    /// 省
    /// </summary>
    public virtual string Province { get; set; }

    /// <summary>
    /// 市
    /// </summary>
    public virtual string City { get; set; }

    /// <summary>
    /// 区
    /// </summary>
    public virtual string Area { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    public virtual string Zip { get; set; }

    /// <summary>
    /// 固定电话
    /// </summary>
    public virtual string FixedPhoen { get; set; }

    /// <summary>
    /// 传真
    /// </summary>
    public virtual string Fax { get; set; }

    /// <summary>
    /// 开户银行
    /// </summary>
    public virtual string Bank { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    public virtual string BankId { get; set; }

    /// <summary>
    /// 纳税号
    /// </summary>
    public virtual string TaxId { get; set; }

    /// <summary>
    /// 公司主页
    /// </summary>
    public virtual string Url { get; set; }

    /// <summary>
    /// 主营业务
    /// </summary>
    public virtual string MainBusiness { get; set; }

    /// <summary>
    /// 信用评级
    /// </summary>
    public virtual string CreditRating { get; set; }

    /// <summary>
    /// 经纬度
    /// </summary>
    public virtual string Center { get; set; }

    /// <summary>
    /// 结算方式
    /// </summary>
    public virtual string Settlement { get; set; }

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
/// 客户资料分页查询输入参数
/// </summary>
public class CustomerInput : BasePageInput
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
    /// 客户名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 客户所属人id
    /// </summary>
    public long? BelongtoId { get; set; }

    /// <summary>
    /// 上任业务员id
    /// </summary>
    public long? Predecessor { get; set; }

    /// <summary>
    /// 助理id
    /// </summary>
    public long? AssistantId { get; set; }

    /// <summary>
    /// 助理分配时间
    /// </summary>
    public DateTime? AssistantAllocationTime { get; set; }

    /// <summary>
    /// 助理分配时间范围
    /// </summary>
    public List<DateTime?> AssistantAllocationTimeRange { get; set; }
    /// <summary>
    /// 简称
    /// </summary>
    public string? ShortName { get; set; }

    /// <summary>
    /// 客户类型
    /// </summary>
    public string? CustomerType { get; set; }

    /// <summary>
    /// 省
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// 市
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// 区
    /// </summary>
    public string? Area { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    /// 固定电话
    /// </summary>
    public string? FixedPhoen { get; set; }

    /// <summary>
    /// 传真
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// 开户银行
    /// </summary>
    public string? Bank { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    public string? BankId { get; set; }

    /// <summary>
    /// 纳税号
    /// </summary>
    public string? TaxId { get; set; }

    /// <summary>
    /// 公司主页
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// 主营业务
    /// </summary>
    public string? MainBusiness { get; set; }

    /// <summary>
    /// 信用评级
    /// </summary>
    public string? CreditRating { get; set; }

    /// <summary>
    /// 经纬度
    /// </summary>
    public string? Center { get; set; }

    /// <summary>
    /// 结算方式
    /// </summary>
    public string? Settlement { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public int? ReVision { get; set; }

}

/// <summary>
/// 客户资料增加输入参数
/// </summary>
public class AddCustomerInput : CustomerBaseInput
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
    /// 客户名称
    /// </summary>
    [Required(ErrorMessage = "客户名称不能为空")]
    public override string Name { get; set; }

    /// <summary>
    /// 客户所属人id
    /// </summary>
    [Required(ErrorMessage = "客户所属人id不能为空")]
    public override long BelongtoId { get; set; }

    /// <summary>
    /// 上任业务员id
    /// </summary>
    [Required(ErrorMessage = "上任业务员id不能为空")]
    public override long Predecessor { get; set; }

    /// <summary>
    /// 助理id
    /// </summary>
    [Required(ErrorMessage = "助理id不能为空")]
    public override long AssistantId { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    [Required(ErrorMessage = "简称不能为空")]
    public override string ShortName { get; set; }

    /// <summary>
    /// 客户类型
    /// </summary>
    [Required(ErrorMessage = "客户类型不能为空")]
    public override string CustomerType { get; set; }

    /// <summary>
    /// 省
    /// </summary>
    [Required(ErrorMessage = "省不能为空")]
    public override string Province { get; set; }

    /// <summary>
    /// 市
    /// </summary>
    [Required(ErrorMessage = "市不能为空")]
    public override string City { get; set; }

    /// <summary>
    /// 区
    /// </summary>
    [Required(ErrorMessage = "区不能为空")]
    public override string Area { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    [Required(ErrorMessage = "邮编不能为空")]
    public override string Zip { get; set; }

    /// <summary>
    /// 固定电话
    /// </summary>
    [Required(ErrorMessage = "固定电话不能为空")]
    public override string FixedPhoen { get; set; }

    /// <summary>
    /// 传真
    /// </summary>
    [Required(ErrorMessage = "传真不能为空")]
    public override string Fax { get; set; }

    /// <summary>
    /// 开户银行
    /// </summary>
    [Required(ErrorMessage = "开户银行不能为空")]
    public override string Bank { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    [Required(ErrorMessage = "银行账号不能为空")]
    public override string BankId { get; set; }

    /// <summary>
    /// 纳税号
    /// </summary>
    [Required(ErrorMessage = "纳税号不能为空")]
    public override string TaxId { get; set; }

    /// <summary>
    /// 公司主页
    /// </summary>
    [Required(ErrorMessage = "公司主页不能为空")]
    public override string Url { get; set; }

    /// <summary>
    /// 主营业务
    /// </summary>
    [Required(ErrorMessage = "主营业务不能为空")]
    public override string MainBusiness { get; set; }

    /// <summary>
    /// 信用评级
    /// </summary>
    [Required(ErrorMessage = "信用评级不能为空")]
    public override string CreditRating { get; set; }

    /// <summary>
    /// 经纬度
    /// </summary>
    [Required(ErrorMessage = "经纬度不能为空")]
    public override string Center { get; set; }

    /// <summary>
    /// 结算方式
    /// </summary>
    [Required(ErrorMessage = "结算方式不能为空")]
    public override string Settlement { get; set; }

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
/// 客户资料删除输入参数
/// </summary>
public class DeleteCustomerInput : BaseIdInput
{
}

/// <summary>
/// 客户资料更新输入参数
/// </summary>
public class UpdateCustomerInput : CustomerBaseInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }

}

/// <summary>
/// 客户资料主键查询输入参数
/// </summary>
public class QueryByIdCustomerInput : DeleteCustomerInput
{

}
public class CustomerManagementBusinessCardInput
{
    /// <summary>
    /// 备注
    /// </summary>

    public string MeMo { get; set; }
    /// <summary>
    /// 编码 唯一
    /// </summary>

    public string Sno { get; set; }

    /// <summary>
    /// 所属表id
    /// </summary>

    public long DbId { get; set; }
    /// <summary>
    /// 模块名
    /// </summary>
    public virtual string Module { get; set; }
    /// <summary>
    /// 名片名称
    /// </summary>

    public string Name { get; set; }
    /// <summary>
    /// 名片在线地址1
    /// </summary>

    public string Imang1 { get; set; }
    /// <summary>
    /// 文件物理路径1
    /// </summary>

    public string Path1 { get; set; }

    /// <summary>
    /// 名片在线地址2
    /// </summary>

    public string Imang2 { get; set; }
    /// <summary>
    /// 文件物理路径2
    /// </summary>

    public string Path2 { get; set; }


}
