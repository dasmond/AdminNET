using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 商品附件基础输入参数
    /// </summary>
    public class ProductAttachmentsBaseInput
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 附件标题
        /// </summary>
        public virtual string PhotoTitle { get; set; }
        
        /// <summary>
        /// 商品描述
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// Url
        /// </summary>
        public virtual string Url { get; set; }
        
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
    /// 商品附件分页查询输入参数
    /// </summary>
    public class ProductAttachmentsInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 附件标题
        /// </summary>
        public string? PhotoTitle { get; set; }
        
        /// <summary>
        /// 商品描述
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// Url
        /// </summary>
        public string? Url { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 商品附件增加输入参数
    /// </summary>
    public class AddProductAttachmentsInput : ProductAttachmentsBaseInput
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 附件标题
        /// </summary>
        [Required(ErrorMessage = "附件标题不能为空")]
        public override string PhotoTitle { get; set; }
        
        /// <summary>
        /// 商品描述
        /// </summary>
        [Required(ErrorMessage = "商品描述不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// Url
        /// </summary>
        [Required(ErrorMessage = "Url不能为空")]
        public override string Url { get; set; }
        
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
    /// 商品附件删除输入参数
    /// </summary>
    public class DeleteProductAttachmentsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 商品附件更新输入参数
    /// </summary>
    public class UpdateProductAttachmentsInput : ProductAttachmentsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 商品附件主键查询输入参数
    /// </summary>
    public class QueryByIdProductAttachmentsInput : DeleteProductAttachmentsInput
    {

    }
