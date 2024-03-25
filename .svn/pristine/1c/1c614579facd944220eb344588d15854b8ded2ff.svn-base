using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 销售合同从表基础输入参数
    /// </summary>
    public class SalesContractSubsidiaryBaseInput
    {
        /// <summary>
        /// 主表id
        /// </summary>
        public virtual long ParentId { get; set; }
        
        /// <summary>
        /// 结算方式
        /// </summary>
        public virtual string Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        public virtual string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        public virtual string GoodsName { get; set; }
        
        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal Price { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        public virtual decimal Tax { get; set; }
        
        /// <summary>
        /// 含税状态
        /// </summary>
        public virtual bool TaxCncludedStatus { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Quantity { get; set; }
        
        /// <summary>
        /// 已发数量
        /// </summary>
        public virtual int LssuedQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
        
        /// <summary>
        /// 金额
        /// </summary>
        public virtual decimal Amount { get; set; }
        
        /// <summary>
        /// 交货日期
        /// </summary>
        public virtual int DeliveryDate { get; set; }
        
        /// <summary>
        /// 排单交期
        /// </summary>
        public virtual DateTime? SchedulingDeliveryDate { get; set; }
        
        /// <summary>
        /// 商品标签模板
        /// </summary>
        public virtual string LabelTemplate { get; set; }
        
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
    /// 销售合同从表分页查询输入参数
    /// </summary>
    public class SalesContractSubsidiaryInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 主表id
        /// </summary>
        public long? ParentId { get; set; }
        
        /// <summary>
        /// 结算方式
        /// </summary>
        public string? Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        public string? GoodsSno { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        public string? GoodsName { get; set; }
        
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Price { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        public decimal? Tax { get; set; }
        
        /// <summary>
        /// 含税状态
        /// </summary>
        public bool? TaxCncludedStatus { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }
        
        /// <summary>
        /// 已发数量
        /// </summary>
        public int? LssuedQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public string? Unit { get; set; }
        
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Amount { get; set; }
        
        /// <summary>
        /// 交货日期
        /// </summary>
        public int? DeliveryDate { get; set; }
        
        /// <summary>
        /// 排单交期
        /// </summary>
        public DateTime? SchedulingDeliveryDate { get; set; }
        
        /// <summary>
         /// 排单交期范围
         /// </summary>
         public List<DateTime?> SchedulingDeliveryDateRange { get; set; } 
        /// <summary>
        /// 商品标签模板
        /// </summary>
        public string? LabelTemplate { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 销售合同从表增加输入参数
    /// </summary>
    public class AddSalesContractSubsidiaryInput : SalesContractSubsidiaryBaseInput
    {
        /// <summary>
        /// 主表id
        /// </summary>
        [Required(ErrorMessage = "主表id不能为空")]
        public override long ParentId { get; set; }
        
        /// <summary>
        /// 结算方式
        /// </summary>
        [Required(ErrorMessage = "结算方式不能为空")]
        public override string Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        [Required(ErrorMessage = "商品编码不能为空")]
        public override string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        public override string GoodsName { get; set; }
        
        /// <summary>
        /// 单价
        /// </summary>
        [Required(ErrorMessage = "单价不能为空")]
        public override decimal Price { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        [Required(ErrorMessage = "税点不能为空")]
        public override decimal Tax { get; set; }
        
        /// <summary>
        /// 含税状态
        /// </summary>
        [Required(ErrorMessage = "含税状态不能为空")]
        public override bool TaxCncludedStatus { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        public override int Quantity { get; set; }
        
        /// <summary>
        /// 已发数量
        /// </summary>
        [Required(ErrorMessage = "已发数量不能为空")]
        public override int LssuedQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        [Required(ErrorMessage = "单位不能为空")]
        public override string Unit { get; set; }
        
        /// <summary>
        /// 金额
        /// </summary>
        [Required(ErrorMessage = "金额不能为空")]
        public override decimal Amount { get; set; }
        
        /// <summary>
        /// 交货日期
        /// </summary>
        [Required(ErrorMessage = "交货日期不能为空")]
        public override int DeliveryDate { get; set; }
        
        /// <summary>
        /// 商品标签模板
        /// </summary>
        [Required(ErrorMessage = "商品标签模板不能为空")]
        public override string LabelTemplate { get; set; }
        
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
    /// 销售合同从表删除输入参数
    /// </summary>
    public class DeleteSalesContractSubsidiaryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 销售合同从表更新输入参数
    /// </summary>
    public class UpdateSalesContractSubsidiaryInput : SalesContractSubsidiaryBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 销售合同从表主键查询输入参数
    /// </summary>
    public class QueryByIdSalesContractSubsidiaryInput : DeleteSalesContractSubsidiaryInput
    {

    }
