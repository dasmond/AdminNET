using Admin.NET.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 审核传入参数
    /// </summary>
    public class WorkflowAuditInput
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public string ExecutionPointerId { get; set; }

        /// <summary>
        /// 是否通过
        /// </summary>
        public EnumAuditStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}