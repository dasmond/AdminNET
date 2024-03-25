using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// BOM主表基础输入参数
    /// </summary>
    public class BomMasterBaseInput
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public virtual string PartNo { get; set; }
        
        /// <summary>
        /// 生命周期阶段
        /// </summary>
        public virtual int Cycle { get; set; }
        
        /// <summary>
        /// 工程变更通知书
        /// </summary>
        public virtual string Ecn { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        public virtual int RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        public virtual int Statuses { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
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
    /// BOM主表分页查询输入参数
    /// </summary>
    public class BomMasterInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string? PartNo { get; set; }
        
        /// <summary>
        /// 生命周期阶段
        /// </summary>
        public int? Cycle { get; set; }
        
        /// <summary>
        /// 工程变更通知书
        /// </summary>
        public string? Ecn { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        public int? RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        public int? Statuses { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// BOM主表增加输入参数
    /// </summary>
    public class AddBomMasterInput : BomMasterBaseInput
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        [Required(ErrorMessage = "物料编码不能为空")]
        public override string PartNo { get; set; }
        
        /// <summary>
        /// 生命周期阶段
        /// </summary>
        [Required(ErrorMessage = "生命周期阶段不能为空")]
        public override int Cycle { get; set; }
        
        /// <summary>
        /// 工程变更通知书
        /// </summary>
        [Required(ErrorMessage = "工程变更通知书不能为空")]
        public override string Ecn { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        [Required(ErrorMessage = "限制批数不能为空")]
        public override int RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        [Required(ErrorMessage = "生产状态不能为空")]
        public override int Statuses { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [Required(ErrorMessage = "审核信息提示不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        [Required(ErrorMessage = "完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
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
    /// BOM主表删除输入参数
    /// </summary>
    public class DeleteBomMasterInput : BaseIdInput
    {
    }

    /// <summary>
    /// BOM主表更新输入参数
    /// </summary>
    public class UpdateBomMasterInput : BomMasterBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// BOM主表主键查询输入参数
    /// </summary>
    public class QueryByIdBomMasterInput : DeleteBomMasterInput
    {

    }
