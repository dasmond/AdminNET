using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 供应商资料基础输入参数
    /// </summary>
    public class SupplierBaseInput
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
        /// 供应商
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 简称
        /// </summary>
        public virtual string ShortName { get; set; }
        
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
    /// 供应商资料分页查询输入参数
    /// </summary>
    public class SupplierInput : BasePageInput
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
        /// 供应商
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 简称
        /// </summary>
        public string? ShortName { get; set; }
        
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
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 供应商资料增加输入参数
    /// </summary>
    public class AddSupplierInput : SupplierBaseInput
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
        /// 供应商
        /// </summary>
        [Required(ErrorMessage = "供应商不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 简称
        /// </summary>
        [Required(ErrorMessage = "简称不能为空")]
        public override string ShortName { get; set; }
        
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
    /// 供应商资料删除输入参数
    /// </summary>
    public class DeleteSupplierInput : BaseIdInput
    {
    }

    /// <summary>
    /// 供应商资料更新输入参数
    /// </summary>
    public class UpdateSupplierInput : SupplierBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 供应商资料主键查询输入参数
    /// </summary>
    public class QueryByIdSupplierInput : DeleteSupplierInput
    {

    }
