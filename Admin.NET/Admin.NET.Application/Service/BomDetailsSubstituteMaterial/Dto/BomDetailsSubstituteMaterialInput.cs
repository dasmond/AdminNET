using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// BOM详情代替料表基础输入参数
    /// </summary>
    public class BomDetailsSubstituteMaterialBaseInput
    {
        /// <summary>
        /// Bom主表id
        /// </summary>
        public virtual long BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        public virtual long ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        public virtual string ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料id
        /// </summary>
        public virtual long PartId { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        public virtual string PartNo { get; set; }
        
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
    /// BOM详情代替料表分页查询输入参数
    /// </summary>
    public class BomDetailsSubstituteMaterialInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// Bom主表id
        /// </summary>
        public long? BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        public long? ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        public string? ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料id
        /// </summary>
        public long? PartId { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        public string? PartNo { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// BOM详情代替料表增加输入参数
    /// </summary>
    public class AddBomDetailsSubstituteMaterialInput : BomDetailsSubstituteMaterialBaseInput
    {
        /// <summary>
        /// Bom主表id
        /// </summary>
        [Required(ErrorMessage = "Bom主表id不能为空")]
        public override long BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        [Required(ErrorMessage = "上级物料id不能为空")]
        public override long ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        [Required(ErrorMessage = "上级物料编码不能为空")]
        public override string ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料id
        /// </summary>
        [Required(ErrorMessage = "当前物料id不能为空")]
        public override long PartId { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        [Required(ErrorMessage = "当前物料编码不能为空")]
        public override string PartNo { get; set; }
        
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
    /// BOM详情代替料表删除输入参数
    /// </summary>
    public class DeleteBomDetailsSubstituteMaterialInput : BaseIdInput
    {
    }

    /// <summary>
    /// BOM详情代替料表更新输入参数
    /// </summary>
    public class UpdateBomDetailsSubstituteMaterialInput : BomDetailsSubstituteMaterialBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// BOM详情代替料表主键查询输入参数
    /// </summary>
    public class QueryByIdBomDetailsSubstituteMaterialInput : DeleteBomDetailsSubstituteMaterialInput
    {

    }
