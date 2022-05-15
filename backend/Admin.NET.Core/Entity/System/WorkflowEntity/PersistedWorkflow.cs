using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WorkflowCore.Models;

namespace Admin.NET.Core
{
    /// <summary>
    /// 流程实例表
    /// </summary>
    [Table("sys_persised_workflow")]
    [Comment("流程实例表")]
    public class PersistedWorkflow : DEntityBase
    {
        
        public long PersistenceId { get; set; }

        [MaxLength(200)]
        public Guid InstanceId { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        [MaxLength(200)]
        public string WorkflowDefinitionId { get; set; }


        /// <summary>
        /// 流程版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }


        [MaxLength(200)]
        public string Reference { get; set; }

        public virtual PersistedExecutionPointerCollection ExecutionPointers { get; set; } = new PersistedExecutionPointerCollection();

        public long? NextExecution { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? CompleteTime { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public WorkflowStatus Status { get; set; }
        
    }
}
