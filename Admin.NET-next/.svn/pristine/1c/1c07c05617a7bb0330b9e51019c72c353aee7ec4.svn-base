using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 商品类别表基础输入参数
    /// </summary>
    public class ClassificationBaseInput
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public virtual string ClassificationName { get; set; }
        
        /// <summary>
        /// 父id
        /// </summary>
        public virtual long ParentId { get; set; }
        
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
    /// 商品类别表分页查询输入参数
    /// </summary>
    public class ClassificationInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string? ClassificationName { get; set; }
        
        /// <summary>
        /// 父id
        /// </summary>
        public long? ParentId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 商品类别表增加输入参数
    /// </summary>
    public class AddClassificationInput : ClassificationBaseInput
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        [Required(ErrorMessage = "类别名称不能为空")]
        public override string ClassificationName { get; set; }
        
        /// <summary>
        /// 父id
        /// </summary>
        [Required(ErrorMessage = "父id不能为空")]
        public override long ParentId { get; set; }
        
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
    /// 商品类别表删除输入参数
    /// </summary>
    public class DeleteClassificationInput : BaseIdInput
    {
    }

    /// <summary>
    /// 商品类别表更新输入参数
    /// </summary>
    public class UpdateClassificationInput : ClassificationBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 商品类别表主键查询输入参数
    /// </summary>
    public class QueryByIdClassificationInput : DeleteClassificationInput
    {

    }
