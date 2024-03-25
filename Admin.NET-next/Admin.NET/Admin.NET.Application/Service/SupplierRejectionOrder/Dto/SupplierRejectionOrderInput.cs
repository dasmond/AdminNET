using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 供应商拒收订单基础输入参数
    /// </summary>
    public class SupplierRejectionOrderBaseInput
    {
        /// <summary>
        /// 合同id
        /// </summary>
        public virtual long SnoId { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 订单编码
        /// </summary>
        public virtual string OrderSno { get; set; }
        
        /// <summary>
        /// 物流收货单id
        /// </summary>
        public virtual long LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 物流收货单id
        /// </summary>
        public virtual long LogisticsReceipt { get; set; }
        
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
        /// 审批完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Quantity { get; set; }
        
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
        /// 客户名称
        /// </summary>
        public virtual string ConsigneeName { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        public virtual string Unqualified { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
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
    /// 供应商拒收订单分页查询输入参数
    /// </summary>
    public class SupplierRejectionOrderInput : BasePageInput
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
        /// 合同编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 订单编码
        /// </summary>
        public string? OrderSno { get; set; }
        
        /// <summary>
        /// 物流收货单id
        /// </summary>
        public long? LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 物流收货单id
        /// </summary>
        public long? LogisticsReceipt { get; set; }
        
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
        /// 审批完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }
        
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
        /// 客户名称
        /// </summary>
        public string? ConsigneeName { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        public string? Unqualified { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 供应商拒收订单增加输入参数
    /// </summary>
    public class AddSupplierRejectionOrderInput : SupplierRejectionOrderBaseInput
    {
        /// <summary>
        /// 合同id
        /// </summary>
        [Required(ErrorMessage = "合同id不能为空")]
        public override long SnoId { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        [Required(ErrorMessage = "合同编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [Required(ErrorMessage = "审核信息提示不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 订单编码
        /// </summary>
        [Required(ErrorMessage = "订单编码不能为空")]
        public override string OrderSno { get; set; }
        
        /// <summary>
        /// 物流收货单id
        /// </summary>
        [Required(ErrorMessage = "物流收货单id不能为空")]
        public override long LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 物流收货单id
        /// </summary>
        [Required(ErrorMessage = "物流收货单id不能为空")]
        public override long LogisticsReceipt { get; set; }
        
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
        /// 审批完成状态
        /// </summary>
        [Required(ErrorMessage = "审批完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        public override int Quantity { get; set; }
        
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
        /// 客户名称
        /// </summary>
        [Required(ErrorMessage = "客户名称不能为空")]
        public override string ConsigneeName { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        [Required(ErrorMessage = "不合格原因不能为空")]
        public override string Unqualified { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
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
    /// 供应商拒收订单删除输入参数
    /// </summary>
    public class DeleteSupplierRejectionOrderInput : BaseIdInput
    {
    }

    /// <summary>
    /// 供应商拒收订单更新输入参数
    /// </summary>
    public class UpdateSupplierRejectionOrderInput : SupplierRejectionOrderBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 供应商拒收订单主键查询输入参数
    /// </summary>
    public class QueryByIdSupplierRejectionOrderInput : DeleteSupplierRejectionOrderInput
    {

    }
