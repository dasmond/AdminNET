using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 导出记录表基础输入参数
    /// </summary>
    public class ExportRecordBaseInput
    {
        /// <summary>
        /// 销售合同id
        /// </summary>
        public virtual long AgreementId { get; set; }
        
        /// <summary>
        /// 发货内容
        /// </summary>
        public virtual string ExportRecordContent { get; set; }
        
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
    /// 导出记录表分页查询输入参数
    /// </summary>
    public class ExportRecordInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 销售合同id
        /// </summary>
        public long? AgreementId { get; set; }
        
        /// <summary>
        /// 发货内容
        /// </summary>
        public string? ExportRecordContent { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 导出记录表增加输入参数
    /// </summary>
    public class AddExportRecordInput : ExportRecordBaseInput
    {
        /// <summary>
        /// 销售合同id
        /// </summary>
        [Required(ErrorMessage = "销售合同id不能为空")]
        public override long AgreementId { get; set; }
        
        /// <summary>
        /// 发货内容
        /// </summary>
        [Required(ErrorMessage = "发货内容不能为空")]
        public override string ExportRecordContent { get; set; }
        
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
    /// 导出记录表删除输入参数
    /// </summary>
    public class DeleteExportRecordInput : BaseIdInput
    {
    }

    /// <summary>
    /// 导出记录表更新输入参数
    /// </summary>
    public class UpdateExportRecordInput : ExportRecordBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 导出记录表主键查询输入参数
    /// </summary>
    public class QueryByIdExportRecordInput : DeleteExportRecordInput
    {

    }
