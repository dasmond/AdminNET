using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 历史流程记录表基础输入参数
    /// </summary>
    public class ProcessInstanceRecordBaseInput
    {
        /// <summary>
        /// 业务ID
        /// </summary>
        public virtual long BusinessKey { get; set; }
        
        /// <summary>
        /// 流程实例id
        /// </summary>
        public virtual long ProcessInstanceId { get; set; }
        
        /// <summary>
        /// 流程模板ID
        /// </summary>
        public virtual long FlowId { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        public virtual long FlowTaskId { get; set; }
        
        /// <summary>
        /// 当前流程任务名称
        /// </summary>
        public virtual string FlowTaskName { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        public virtual string StartUserName { get; set; }
        
        /// <summary>
        /// 操作人id
        /// </summary>
        public virtual long StartUserId { get; set; }
        
        /// <summary>
        /// 审批结果
        /// </summary>
        public virtual int ApprovalResults { get; set; }
        
        /// <summary>
        /// 审批人意见
        /// </summary>
        public virtual string OpinionOfApprover { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        public virtual long RoleGroup { get; set; }
        
        /// <summary>
        /// 流程分支业务id
        /// </summary>
        public virtual long ProcessBranchId { get; set; }
        
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
    /// 历史流程记录表分页查询输入参数
    /// </summary>
    public class ProcessInstanceRecordInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        public long? BusinessKey { get; set; }
        
        /// <summary>
        /// 流程实例id
        /// </summary>
        public long? ProcessInstanceId { get; set; }
        
        /// <summary>
        /// 流程模板ID
        /// </summary>
        public long? FlowId { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        public long? FlowTaskId { get; set; }
        
        /// <summary>
        /// 当前流程任务名称
        /// </summary>
        public string? FlowTaskName { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        public string? StartUserName { get; set; }
        
        /// <summary>
        /// 操作人id
        /// </summary>
        public long? StartUserId { get; set; }
        
        /// <summary>
        /// 审批结果
        /// </summary>
        public int? ApprovalResults { get; set; }
        
        /// <summary>
        /// 审批人意见
        /// </summary>
        public string? OpinionOfApprover { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        public long? RoleGroup { get; set; }
        
        /// <summary>
        /// 流程分支业务id
        /// </summary>
        public long? ProcessBranchId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 历史流程记录表增加输入参数
    /// </summary>
    public class AddProcessInstanceRecordInput : ProcessInstanceRecordBaseInput
    {
        /// <summary>
        /// 业务ID
        /// </summary>
        [Required(ErrorMessage = "业务ID不能为空")]
        public override long BusinessKey { get; set; }
        
        /// <summary>
        /// 流程实例id
        /// </summary>
        [Required(ErrorMessage = "流程实例id不能为空")]
        public override long ProcessInstanceId { get; set; }
        
        /// <summary>
        /// 流程模板ID
        /// </summary>
        [Required(ErrorMessage = "流程模板ID不能为空")]
        public override long FlowId { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        [Required(ErrorMessage = "当前流程任务id不能为空")]
        public override long FlowTaskId { get; set; }
        
        /// <summary>
        /// 当前流程任务名称
        /// </summary>
        [Required(ErrorMessage = "当前流程任务名称不能为空")]
        public override string FlowTaskName { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        [Required(ErrorMessage = "操作人不能为空")]
        public override string StartUserName { get; set; }
        
        /// <summary>
        /// 操作人id
        /// </summary>
        [Required(ErrorMessage = "操作人id不能为空")]
        public override long StartUserId { get; set; }
        
        /// <summary>
        /// 审批结果
        /// </summary>
        [Required(ErrorMessage = "审批结果不能为空")]
        public override int ApprovalResults { get; set; }
        
        /// <summary>
        /// 审批人意见
        /// </summary>
        [Required(ErrorMessage = "审批人意见不能为空")]
        public override string OpinionOfApprover { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        [Required(ErrorMessage = "角色组不能为空")]
        public override long RoleGroup { get; set; }
        
        /// <summary>
        /// 流程分支业务id
        /// </summary>
        [Required(ErrorMessage = "流程分支业务id不能为空")]
        public override long ProcessBranchId { get; set; }
        
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
    /// 历史流程记录表删除输入参数
    /// </summary>
    public class DeleteProcessInstanceRecordInput : BaseIdInput
    {
    }

    /// <summary>
    /// 历史流程记录表更新输入参数
    /// </summary>
    public class UpdateProcessInstanceRecordInput : ProcessInstanceRecordBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 历史流程记录表主键查询输入参数
    /// </summary>
    public class QueryByIdProcessInstanceRecordInput : DeleteProcessInstanceRecordInput
    {

    }
