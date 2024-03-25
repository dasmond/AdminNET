using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 标签池基础输入参数
    /// </summary>
    public class CkTagPoolBaseInput
    {
        /// <summary>
        /// 订单单据编码
        /// </summary>
        public virtual string OrderSno { get; set; }
        
        /// <summary>
        /// 库位
        /// </summary>
        public virtual string WarehouseLocation { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
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
        /// 数量
        /// </summary>
        public virtual int Quantity { get; set; }
        
        /// <summary>
        /// 二维码内容
        /// </summary>
        public virtual string Qrcode { get; set; }
        
        /// <summary>
        /// 标签模板文件名
        /// </summary>
        public virtual string ModuleName { get; set; }
        
        /// <summary>
        /// 货架位
        /// </summary>
        public virtual string ShelfSpace { get; set; }
        
        /// <summary>
        /// 兼容旧系统字段
        /// </summary>
        public virtual string CompatibleWithOldSystems { get; set; }
        
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
    /// 标签池分页查询输入参数
    /// </summary>
    public class CkTagPoolInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 订单单据编码
        /// </summary>
        public string? OrderSno { get; set; }
        
        /// <summary>
        /// 库位
        /// </summary>
        public string? WarehouseLocation { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
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
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }
        
        /// <summary>
        /// 二维码内容
        /// </summary>
        public string? Qrcode { get; set; }
        
        /// <summary>
        /// 标签模板文件名
        /// </summary>
        public string? ModuleName { get; set; }
        
        /// <summary>
        /// 货架位
        /// </summary>
        public string? ShelfSpace { get; set; }
        
        /// <summary>
        /// 兼容旧系统字段
        /// </summary>
        public string? CompatibleWithOldSystems { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 标签池增加输入参数
    /// </summary>
    public class AddCkTagPoolInput : CkTagPoolBaseInput
    {
        /// <summary>
        /// 订单单据编码
        /// </summary>
        [Required(ErrorMessage = "订单单据编码不能为空")]
        public override string OrderSno { get; set; }
        
        /// <summary>
        /// 库位
        /// </summary>
        [Required(ErrorMessage = "库位不能为空")]
        public override string WarehouseLocation { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
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
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        public override int Quantity { get; set; }
        
        /// <summary>
        /// 二维码内容
        /// </summary>
        [Required(ErrorMessage = "二维码内容不能为空")]
        public override string Qrcode { get; set; }
        
        /// <summary>
        /// 标签模板文件名
        /// </summary>
        [Required(ErrorMessage = "标签模板文件名不能为空")]
        public override string ModuleName { get; set; }
        
        /// <summary>
        /// 货架位
        /// </summary>
        [Required(ErrorMessage = "货架位不能为空")]
        public override string ShelfSpace { get; set; }
        
        /// <summary>
        /// 兼容旧系统字段
        /// </summary>
        [Required(ErrorMessage = "兼容旧系统字段不能为空")]
        public override string CompatibleWithOldSystems { get; set; }
        
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
    /// 标签池删除输入参数
    /// </summary>
    public class DeleteCkTagPoolInput : BaseIdInput
    {
    }

    /// <summary>
    /// 标签池更新输入参数
    /// </summary>
    public class UpdateCkTagPoolInput : CkTagPoolBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 标签池主键查询输入参数
    /// </summary>
    public class QueryByIdCkTagPoolInput : DeleteCkTagPoolInput
    {

    }
