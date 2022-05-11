using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    /// <summary>
    /// 流程审核表
    /// </summary>
    [Table("sys_persisted_Workflow_auditor")]
    [Comment("流程审核表")]
    public class PersistedWorkflowAuditor: DEntityBase, IEntityTypeBuilder<PersistedWorkflowAuditor>
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        public long WorkflowId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PersistedWorkflow Workflow { get; set; }

        /// <summary>
        /// ExecutionPointerId
        /// </summary>
        public Guid ExecutionPointerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PersistedExecutionPointer ExecutionPointer { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")]
        public EnumAuditStatus Status { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [Comment("审核时间")]
        public DateTime? AuditTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 审核人Id
        /// </summary>
        [Comment("审核人Id")]
        public long UserId { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [Comment("审核人")]
        public string UserIdentityName { get; set; }

        /// <summary>
        /// 步骤Id
        /// </summary>
        [Comment("步骤Id")]
        public string StepId { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        [Comment("步骤名称")]
        public string StepName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        public void Configure(EntityTypeBuilder<PersistedWorkflowAuditor> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
