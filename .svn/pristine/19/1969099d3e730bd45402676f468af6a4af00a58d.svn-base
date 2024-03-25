using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 物流收货单基础输入参数
    /// </summary>
    public class LogisticsReceiptBaseInput
    {
        /// <summary>
        /// 合同id
        /// </summary>
        public virtual long ContractId { get; set; }
        
        /// <summary>
        /// 物流收货编码
        /// </summary>
        public virtual string LogisticsReceiptSno { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        public virtual string ContractSno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        public virtual string PurchaserSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        public virtual string GoodsName { get; set; }
        
        /// <summary>
        /// 来货数量
        /// </summary>
        public virtual int Quantity { get; set; }
        
        /// <summary>
        /// 送货方式
        /// </summary>
        public virtual string Delivery { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        public virtual string TrackingNumber { get; set; }
        
        /// <summary>
        /// 物流公司
        /// </summary>
        public virtual string LogisticsCompany { get; set; }
        
        /// <summary>
        /// 送货单号
        /// </summary>
        public virtual string DeliveryNoteNumber { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public virtual int TypesOf { get; set; }
        
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
    /// 物流收货单分页查询输入参数
    /// </summary>
    public class LogisticsReceiptInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 合同id
        /// </summary>
        public long? ContractId { get; set; }
        
        /// <summary>
        /// 物流收货编码
        /// </summary>
        public string? LogisticsReceiptSno { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        public string? ContractSno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        public string? PurchaserSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        public string? GoodsName { get; set; }
        
        /// <summary>
        /// 来货数量
        /// </summary>
        public int? Quantity { get; set; }
        
        /// <summary>
        /// 送货方式
        /// </summary>
        public string? Delivery { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        public string? TrackingNumber { get; set; }
        
        /// <summary>
        /// 物流公司
        /// </summary>
        public string? LogisticsCompany { get; set; }
        
        /// <summary>
        /// 送货单号
        /// </summary>
        public string? DeliveryNoteNumber { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public int? TypesOf { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 物流收货单增加输入参数
    /// </summary>
    public class AddLogisticsReceiptInput : LogisticsReceiptBaseInput
    {
        /// <summary>
        /// 合同id
        /// </summary>
        [Required(ErrorMessage = "合同id不能为空")]
        public override long ContractId { get; set; }
        
        /// <summary>
        /// 物流收货编码
        /// </summary>
        [Required(ErrorMessage = "物流收货编码不能为空")]
        public override string LogisticsReceiptSno { get; set; }
        
        /// <summary>
        /// 合同编码
        /// </summary>
        [Required(ErrorMessage = "合同编码不能为空")]
        public override string ContractSno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        [Required(ErrorMessage = "购方合同编码不能为空")]
        public override string PurchaserSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        public override string GoodsName { get; set; }
        
        /// <summary>
        /// 来货数量
        /// </summary>
        [Required(ErrorMessage = "来货数量不能为空")]
        public override int Quantity { get; set; }
        
        /// <summary>
        /// 送货方式
        /// </summary>
        [Required(ErrorMessage = "送货方式不能为空")]
        public override string Delivery { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        [Required(ErrorMessage = "快递单号不能为空")]
        public override string TrackingNumber { get; set; }
        
        /// <summary>
        /// 物流公司
        /// </summary>
        [Required(ErrorMessage = "物流公司不能为空")]
        public override string LogisticsCompany { get; set; }
        
        /// <summary>
        /// 送货单号
        /// </summary>
        [Required(ErrorMessage = "送货单号不能为空")]
        public override string DeliveryNoteNumber { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        [Required(ErrorMessage = "类型不能为空")]
        public override int TypesOf { get; set; }
        
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
    /// 物流收货单删除输入参数
    /// </summary>
    public class DeleteLogisticsReceiptInput : BaseIdInput
    {
    }

    /// <summary>
    /// 物流收货单更新输入参数
    /// </summary>
    public class UpdateLogisticsReceiptInput : LogisticsReceiptBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 物流收货单主键查询输入参数
    /// </summary>
    public class QueryByIdLogisticsReceiptInput : DeleteLogisticsReceiptInput
    {

    }
