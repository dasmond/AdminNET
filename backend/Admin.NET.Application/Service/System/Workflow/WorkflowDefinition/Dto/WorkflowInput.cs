using Admin.NET.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 输入参数
    /// </summary>
    public class WorkflowInput : PageInputBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 初始表单
        /// </summary>
        public string Inputs { get; set; }

        /// <summary>
        /// 表单Id
        /// </summary>
        public long? FormId { get; set; }

        /// <summary>
        /// 绘画节点
        /// </summary>
        public string DrawNode { get; set; }
    }
}