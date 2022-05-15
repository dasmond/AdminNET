using Admin.NET.Core;
using WorkflowCore.Models;

namespace Admin.NET.Application
{
    public class WorkflowDto:BaseDto
    {
        public long PersistenceId { get; set; }

        public Guid InstanceId { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        public string WorkflowDefinitionId { get; set; }


        /// <summary>
        /// 流程版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }


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

        /// <summary>
        /// 表单Id
        /// </summary>
        public long? FormId { get; set; }
    }
}
