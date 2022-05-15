using Admin.NET.Core;

namespace Admin.NET.Application
{
    public class WorkflowPageDto:PageInputBase
    {
        /// <summary>
        /// 流程标题
        /// </summary>
        public string Description { get; set; }
    }
}
