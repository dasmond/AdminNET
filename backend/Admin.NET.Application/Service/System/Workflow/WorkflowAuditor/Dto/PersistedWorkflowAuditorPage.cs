using Admin.NET.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 审核分页查询
    /// </summary>
    public class PersistedWorkflowAuditorPage: PageInputBase
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public EnumAuditStatus? Status { get; set; }

        
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
