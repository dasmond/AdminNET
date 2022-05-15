namespace Admin.NET.Application
{
    /// <summary>
    /// 流程定义分页实体
    /// </summary>
    public class WorkflowPageListDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedUserName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// 表单Id
        /// </summary>
        public long? FormId { get; set; }

        /// <summary>
        /// 初始化表单
        /// </summary>
        public string Inputs { get; set; }

        /// <summary>
        /// 绘画节点
        /// </summary>

        public string DrawNode { get; set; }
    }
}
