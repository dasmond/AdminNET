using Admin.NET.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 审核Dto
    /// </summary>
    public class PersistedWorkflowAuditorDto
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTimeOffset? CreateTime { get; set; }

        /// <summary>
        /// 完工时间
        /// </summary>
        public DateTimeOffset? UpdateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastUserName { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public EnumAuditStatus Status { get; set; }

        /// <summary>
        /// 审核人ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 通过状态
        /// </summary>
        public int PassFlag { get; set; }

        
        /// <summary>
        /// 审核用户姓名
        /// </summary>
        public string UserIdentityName { get; set; }

        /// <summary>
        /// 流程InstanceId
        /// </summary>
        public Guid InstanceId { get; set; }

        /// <summary>
        /// 流程ID
        /// </summary>
        public long WorkflowId { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 任务码
        /// </summary>
        public Guid ExecutionPointerId { get; set; }

        /// <summary>
        /// 表单Id
        /// </summary>
        public long? FormId { get; set; }


        /// <summary>
        /// 任务名称
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// StepId
        /// </summary>
        public string StepId { get; set; }


        /// <summary>
        /// 备注信息
        /// </summary>
        public string ReMark { get; set; }
    }

    /// <summary>
    /// 单据流程路径信息
    /// </summary>
    public class AuditorWorkflowInfo
    {
        /// <summary>
        /// 步骤Id
        /// </summary>
        public string StepId { get; set; }

        /// <summary>
        /// 节点状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 当前节点操作用户
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTimeOffset? CreateTime { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string ReMark { get; set; }

    }
}
