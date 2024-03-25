namespace Admin.NET.Application;

    /// <summary>
    /// 历史流程记录表输出参数
    /// </summary>
    public class ProcessInstanceRecordDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 业务ID
        /// </summary>
        public long BusinessKey { get; set; }
        
        /// <summary>
        /// 流程实例id
        /// </summary>
        public long ProcessInstanceId { get; set; }
        
        /// <summary>
        /// 流程模板ID
        /// </summary>
        public long FlowId { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        public long FlowTaskId { get; set; }
        
        /// <summary>
        /// 当前流程任务名称
        /// </summary>
        public string FlowTaskName { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        public string StartUserName { get; set; }
        
        /// <summary>
        /// 操作人id
        /// </summary>
        public long StartUserId { get; set; }
        
        /// <summary>
        /// 审批结果
        /// </summary>
        public int ApprovalResults { get; set; }
        
        /// <summary>
        /// 审批人意见
        /// </summary>
        public string OpinionOfApprover { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        public long RoleGroup { get; set; }
        
        /// <summary>
        /// 流程分支业务id
        /// </summary>
        public long ProcessBranchId { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int ReVision { get; set; }
        
    }
