using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 销售关系表基础输入参数
    /// </summary>
    public class SalesRelationshipBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 替代品id
        /// </summary>
        public virtual long SimilarGoodsId { get; set; }
        
        /// <summary>
        /// 设置默认
        /// </summary>
        public virtual int Priority { get; set; }
        
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
    /// 销售关系表分页查询输入参数
    /// </summary>
    public class SalesRelationshipInput : BasePageInput
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
        /// 状态
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 替代品id
        /// </summary>
        public long? SimilarGoodsId { get; set; }
        
        /// <summary>
        /// 设置默认
        /// </summary>
        public int? Priority { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 销售关系表增加输入参数
    /// </summary>
    public class AddSalesRelationshipInput : SalesRelationshipBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 替代品id
        /// </summary>
        [Required(ErrorMessage = "替代品id不能为空")]
        public override long SimilarGoodsId { get; set; }
        
        /// <summary>
        /// 设置默认
        /// </summary>
        [Required(ErrorMessage = "设置默认不能为空")]
        public override int Priority { get; set; }
        
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
    /// 销售关系表删除输入参数
    /// </summary>
    public class DeleteSalesRelationshipInput : BaseIdInput
    {
    }

    /// <summary>
    /// 销售关系表更新输入参数
    /// </summary>
    public class UpdateSalesRelationshipInput : SalesRelationshipBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 销售关系表主键查询输入参数
    /// </summary>
    public class QueryByIdSalesRelationshipInput : DeleteSalesRelationshipInput
    {

    }
