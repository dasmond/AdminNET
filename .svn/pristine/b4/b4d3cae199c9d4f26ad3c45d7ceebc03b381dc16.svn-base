using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 标签库存基础输入参数
    /// </summary>
    public class CkTagStockBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 标签池id
        /// </summary>
        public virtual long CkTagPoolId { get; set; }
        
        /// <summary>
        /// 订单单据编码
        /// </summary>
        public virtual string OrderSno { get; set; }
        
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
    /// 标签库存分页查询输入参数
    /// </summary>
    public class CkTagStockInput : BasePageInput
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
        /// 标签池id
        /// </summary>
        public long? CkTagPoolId { get; set; }
        
        /// <summary>
        /// 订单单据编码
        /// </summary>
        public string? OrderSno { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 标签库存增加输入参数
    /// </summary>
    public class AddCkTagStockInput : CkTagStockBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 标签池id
        /// </summary>
        [Required(ErrorMessage = "标签池id不能为空")]
        public override long CkTagPoolId { get; set; }
        
        /// <summary>
        /// 订单单据编码
        /// </summary>
        [Required(ErrorMessage = "订单单据编码不能为空")]
        public override string OrderSno { get; set; }
        
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
    /// 标签库存删除输入参数
    /// </summary>
    public class DeleteCkTagStockInput : BaseIdInput
    {
    }

    /// <summary>
    /// 标签库存更新输入参数
    /// </summary>
    public class UpdateCkTagStockInput : CkTagStockBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 标签库存主键查询输入参数
    /// </summary>
    public class QueryByIdCkTagStockInput : DeleteCkTagStockInput
    {

    }
