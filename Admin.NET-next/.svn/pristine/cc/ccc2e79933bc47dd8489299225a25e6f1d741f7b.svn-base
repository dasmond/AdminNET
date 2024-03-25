using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 供应商拒收订单详情基础输入参数
    /// </summary>
    public class SupplierRejectionOrderDetailsBaseInput
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public virtual long OrderId { get; set; }
        
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
        public virtual int Quantity { get; set; }
        
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
    /// 供应商拒收订单详情分页查询输入参数
    /// </summary>
    public class SupplierRejectionOrderDetailsInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 订单id
        /// </summary>
        public long? OrderId { get; set; }
        
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
        public int? Quantity { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 供应商拒收订单详情增加输入参数
    /// </summary>
    public class AddSupplierRejectionOrderDetailsInput : SupplierRejectionOrderDetailsBaseInput
    {
        /// <summary>
        /// 订单id
        /// </summary>
        [Required(ErrorMessage = "订单id不能为空")]
        public override long OrderId { get; set; }
        
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
        public override int Quantity { get; set; }
        
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
    /// 供应商拒收订单详情删除输入参数
    /// </summary>
    public class DeleteSupplierRejectionOrderDetailsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 供应商拒收订单详情更新输入参数
    /// </summary>
    public class UpdateSupplierRejectionOrderDetailsInput : SupplierRejectionOrderDetailsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 供应商拒收订单详情主键查询输入参数
    /// </summary>
    public class QueryByIdSupplierRejectionOrderDetailsInput : DeleteSupplierRejectionOrderDetailsInput
    {

    }
