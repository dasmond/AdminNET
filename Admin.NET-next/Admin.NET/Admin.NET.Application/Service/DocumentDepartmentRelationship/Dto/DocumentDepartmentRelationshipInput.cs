using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 文件-部门关系表基础输入参数
    /// </summary>
    public class DocumentDepartmentRelationshipBaseInput
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        public virtual long DbId { get; set; }
        
        /// <summary>
        /// 通知-部门
        /// </summary>
        public virtual long DepartmentRoleId { get; set; }
        
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public virtual bool EditingStatus { get; set; }
        
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
    /// 文件-部门关系表分页查询输入参数
    /// </summary>
    public class DocumentDepartmentRelationshipInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 所属表id
        /// </summary>
        public long? DbId { get; set; }
        
        /// <summary>
        /// 通知-部门
        /// </summary>
        public long? DepartmentRoleId { get; set; }
        
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool? EditingStatus { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 文件-部门关系表增加输入参数
    /// </summary>
    public class AddDocumentDepartmentRelationshipInput : DocumentDepartmentRelationshipBaseInput
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        [Required(ErrorMessage = "所属表id不能为空")]
        public override long DbId { get; set; }
        
        /// <summary>
        /// 通知-部门
        /// </summary>
        [Required(ErrorMessage = "通知-部门不能为空")]
        public override long DepartmentRoleId { get; set; }
        
        /// <summary>
        /// 是否可编辑
        /// </summary>
        [Required(ErrorMessage = "是否可编辑不能为空")]
        public override bool EditingStatus { get; set; }
        
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
    /// 文件-部门关系表删除输入参数
    /// </summary>
    public class DeleteDocumentDepartmentRelationshipInput : BaseIdInput
    {
    }

    /// <summary>
    /// 文件-部门关系表更新输入参数
    /// </summary>
    public class UpdateDocumentDepartmentRelationshipInput : DocumentDepartmentRelationshipBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 文件-部门关系表主键查询输入参数
    /// </summary>
    public class QueryByIdDocumentDepartmentRelationshipInput : DeleteDocumentDepartmentRelationshipInput
    {

    }
