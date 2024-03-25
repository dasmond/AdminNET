using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 调度库详情基础输入参数
    /// </summary>
    public class DispatchLibraryDetailsBaseInput
    {
        /// <summary>
        /// 调度id
        /// </summary>
        public virtual long DispatchId { get; set; }
        
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
        public virtual decimal Quantity { get; set; }
        
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
    /// 调度库详情分页查询输入参数
    /// </summary>
    public class DispatchLibraryDetailsInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 调度id
        /// </summary>
        public long? DispatchId { get; set; }
        
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
        public decimal? Quantity { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 调度库详情增加输入参数
    /// </summary>
    public class AddDispatchLibraryDetailsInput : DispatchLibraryDetailsBaseInput
    {
        /// <summary>
        /// 调度id
        /// </summary>
        [Required(ErrorMessage = "调度id不能为空")]
        public override long DispatchId { get; set; }
        
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
        public override decimal Quantity { get; set; }
        
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
    /// 调度库详情删除输入参数
    /// </summary>
    public class DeleteDispatchLibraryDetailsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 调度库详情更新输入参数
    /// </summary>
    public class UpdateDispatchLibraryDetailsInput : DispatchLibraryDetailsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 调度库详情主键查询输入参数
    /// </summary>
    public class QueryByIdDispatchLibraryDetailsInput : DeleteDispatchLibraryDetailsInput
    {

    }
