namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 历史流程记录表
    /// </summary>
    /// 

    [SugarTable(null, "历史流程记录表")]
    [SysTable]
    public class ProcessInstanceRecord : EntityBase
    {
        /// <summary>
        /// 业务ID 
        /// </summary>
        [SugarColumn(ColumnDescription = "业务ID")]
        [Required]
        public long BusinessKey { get; set; }
        /// <summary>
        /// 流程实例id
        /// </summary>
        [SugarColumn(ColumnDescription = "流程实例id")]
        [Required]
        public long ProcessInstanceId { get; set; }
        /// <summary>
        /// 流程模板ID 
        /// </summary>
        [SugarColumn(ColumnDescription = "流程模板ID")]
        [Required]
        public long FlowId { get; set; }
        /// <summary>
        /// 当前流程任务id 详情表节点
        /// </summary>
        [SugarColumn(ColumnDescription = "当前流程任务id")]
        public long FlowTaskId { get; set; }
        /// <summary>
        /// 当前流程任务名称 详情表节点
        /// </summary>
        [SugarColumn(ColumnDescription = "当前流程任务名称", Length = 255, IsNullable = true)]
        public string FlowTaskName { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [SugarColumn(ColumnDescription = "操作人", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string StartUserName { get; set; }
        /// <summary>
        /// 操作人id
        /// </summary>
        [SugarColumn(ColumnDescription = "操作人id")]
        public long StartUserId { get; set; }

        /// <summary>
        /// 审批结果
        /// </summary>
        [SugarColumn(ColumnDescription = "审批结果")]
        public int ApprovalResults { get; set; }
        /// <summary>
        /// 审批人意见
        /// </summary>
        [SugarColumn(ColumnDescription = "审批人意见", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string OpinionOfApprover { get; set; }
        /// <summary>
        /// 角色组
        /// </summary>
        [SugarColumn(ColumnDescription = "角色组")]
        [MaxLength(255)]
        public long RoleGroup { get; set; }
        /// <summary>
        /// 流程分支业务id
        /// </summary>
        [SugarColumn(ColumnDescription = "流程分支业务id")]
        public long ProcessBranchId { get; set; }
    }
}
