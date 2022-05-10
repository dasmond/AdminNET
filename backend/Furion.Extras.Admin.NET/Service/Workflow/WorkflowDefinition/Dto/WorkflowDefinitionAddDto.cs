namespace Furion.Extras.Admin.NET.Service.Workflows.Dto
{
    /// <summary>
    /// 流程添加
    /// </summary>
    public class WorkflowDefinitionAddDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }


        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 输入
        /// </summary>
        public string Inputs { get; set; }
        /// <summary>
        /// 流程节点 
        /// </summary>
        public string Nodes { get; set; }

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
