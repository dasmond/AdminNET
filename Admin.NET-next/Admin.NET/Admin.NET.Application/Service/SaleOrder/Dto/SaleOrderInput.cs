using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 销售订单基础输入参数
    /// </summary>
    public class SaleOrderBaseInput
    {
        /// <summary>
        /// 合同id
        /// </summary>
        public virtual long SnoId { get; set; }
        
        /// <summary>
        /// 助理id
        /// </summary>
        public virtual long AssistantId { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 订单编码
        /// </summary>
        public virtual string OrderSno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        public virtual string PurchaserSno { get; set; }
        
        /// <summary>
        /// 合同详情id
        /// </summary>
        public virtual long SnoDetailsId { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal Quantity { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 打印次数
        /// </summary>
        public virtual int Count { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public virtual string Delivery { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        public virtual string TrackingNumber { get; set; }
        
        /// <summary>
        /// 联系人名称
        /// </summary>
        public virtual string ContactsName { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public virtual string CustomerName { get; set; }
        
        /// <summary>
        /// 收货人
        /// </summary>
        public virtual string ConsigneeName { get; set; }
        
        /// <summary>
        /// 是否允许回签
        /// </summary>
        public virtual bool AllowSignatureBack { get; set; }
        
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
    /// 销售订单分页查询输入参数
    /// </summary>
    public class SaleOrderInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 合同id
        /// </summary>
        public long? SnoId { get; set; }
        
        /// <summary>
        /// 助理id
        /// </summary>
        public long? AssistantId { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 订单编码
        /// </summary>
        public string? OrderSno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        public string? PurchaserSno { get; set; }
        
        /// <summary>
        /// 合同详情id
        /// </summary>
        public long? SnoDetailsId { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? Quantity { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 打印次数
        /// </summary>
        public int? Count { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public string? Delivery { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        public string? TrackingNumber { get; set; }
        
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string? ContactsName { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public string? CustomerName { get; set; }
        
        /// <summary>
        /// 收货人
        /// </summary>
        public string? ConsigneeName { get; set; }
        
        /// <summary>
        /// 是否允许回签
        /// </summary>
        public bool? AllowSignatureBack { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 销售订单增加输入参数
    /// </summary>
    public class AddSaleOrderInput : SaleOrderBaseInput
    {
        /// <summary>
        /// 合同id
        /// </summary>
        [Required(ErrorMessage = "合同id不能为空")]
        public override long SnoId { get; set; }
        
        /// <summary>
        /// 助理id
        /// </summary>
        [Required(ErrorMessage = "助理id不能为空")]
        public override long AssistantId { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        [Required(ErrorMessage = "合同编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 订单编码
        /// </summary>
        [Required(ErrorMessage = "订单编码不能为空")]
        public override string OrderSno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        [Required(ErrorMessage = "购方合同编码不能为空")]
        public override string PurchaserSno { get; set; }
        
        /// <summary>
        /// 合同详情id
        /// </summary>
        [Required(ErrorMessage = "合同详情id不能为空")]
        public override long SnoDetailsId { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        public override decimal Quantity { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [Required(ErrorMessage = "审核信息提示不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        [Required(ErrorMessage = "审批完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
        /// <summary>
        /// 打印次数
        /// </summary>
        [Required(ErrorMessage = "打印次数不能为空")]
        public override int Count { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        [Required(ErrorMessage = "发货方式不能为空")]
        public override string Delivery { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        [Required(ErrorMessage = "快递单号不能为空")]
        public override string TrackingNumber { get; set; }
        
        /// <summary>
        /// 联系人名称
        /// </summary>
        [Required(ErrorMessage = "联系人名称不能为空")]
        public override string ContactsName { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        [Required(ErrorMessage = "客户名称不能为空")]
        public override string CustomerName { get; set; }
        
        /// <summary>
        /// 收货人
        /// </summary>
        [Required(ErrorMessage = "收货人不能为空")]
        public override string ConsigneeName { get; set; }
        
        /// <summary>
        /// 是否允许回签
        /// </summary>
        [Required(ErrorMessage = "是否允许回签不能为空")]
        public override bool AllowSignatureBack { get; set; }
        
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
    /// 销售订单删除输入参数
    /// </summary>
    public class DeleteSaleOrderInput : BaseIdInput
    {
    }

    /// <summary>
    /// 销售订单更新输入参数
    /// </summary>
    public class UpdateSaleOrderInput : SaleOrderBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 销售订单主键查询输入参数
    /// </summary>
    public class QueryByIdSaleOrderInput : DeleteSaleOrderInput
    {

    }
