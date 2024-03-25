using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 库存表基础输入参数
    /// </summary>
    public class InventoryBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 仓库id
        /// </summary>
        public virtual long StorageId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        public virtual string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 现有数量
        /// </summary>
        public virtual decimal OnhandNumber { get; set; }
        
        /// <summary>
        /// 采购在途数量
        /// </summary>
        public virtual decimal ProcureNumber { get; set; }
        
        /// <summary>
        /// 加工在途
        /// </summary>
        public virtual decimal ProcessingIntransit { get; set; }
        
        /// <summary>
        /// 冻结量
        /// </summary>
        public virtual decimal FrozenNumber { get; set; }
        
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
    /// 库存表分页查询输入参数
    /// </summary>
    public class InventoryInput : BasePageInput
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
        /// 仓库id
        /// </summary>
        public long? StorageId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        public string? GoodsSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 现有数量
        /// </summary>
        public decimal? OnhandNumber { get; set; }
        
        /// <summary>
        /// 采购在途数量
        /// </summary>
        public decimal? ProcureNumber { get; set; }
        
        /// <summary>
        /// 加工在途
        /// </summary>
        public decimal? ProcessingIntransit { get; set; }
        
        /// <summary>
        /// 冻结量
        /// </summary>
        public decimal? FrozenNumber { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 库存表增加输入参数
    /// </summary>
    public class AddInventoryInput : InventoryBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 仓库id
        /// </summary>
        [Required(ErrorMessage = "仓库id不能为空")]
        public override long StorageId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        [Required(ErrorMessage = "商品编码不能为空")]
        public override string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 现有数量
        /// </summary>
        [Required(ErrorMessage = "现有数量不能为空")]
        public override decimal OnhandNumber { get; set; }
        
        /// <summary>
        /// 采购在途数量
        /// </summary>
        [Required(ErrorMessage = "采购在途数量不能为空")]
        public override decimal ProcureNumber { get; set; }
        
        /// <summary>
        /// 加工在途
        /// </summary>
        [Required(ErrorMessage = "加工在途不能为空")]
        public override decimal ProcessingIntransit { get; set; }
        
        /// <summary>
        /// 冻结量
        /// </summary>
        [Required(ErrorMessage = "冻结量不能为空")]
        public override decimal FrozenNumber { get; set; }
        
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
    /// 库存表删除输入参数
    /// </summary>
    public class DeleteInventoryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 库存表更新输入参数
    /// </summary>
    public class UpdateInventoryInput : InventoryBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 库存表主键查询输入参数
    /// </summary>
    public class QueryByIdInventoryInput : DeleteInventoryInput
    {

    }
