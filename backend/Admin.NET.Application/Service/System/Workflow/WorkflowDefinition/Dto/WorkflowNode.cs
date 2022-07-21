namespace Admin.NET.Application
{
    /// <summary>
    /// 流程表单数据
    /// </summary>
    public class WorkflowFormData
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<object> Styles { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// 最小长度
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// 选项
        /// </summary>
        public IEnumerable<object> Items { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public IEnumerable<object> Rules { get; set; } = new List<object>();
    }

    /// <summary>
    /// 步骤输入
    /// </summary>
    public class StepBodyInput
    {
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 输入参数
        /// </summary>
        public Dictionary<string, WorkflowParamInput> Inputs { get; set; } = new Dictionary<string, WorkflowParamInput>();
    }

    /// <summary>
    /// 参数输入
    /// </summary>
    public class WorkflowParamInput
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }
    }

    /// <summary>
    /// 流程节点
    /// </summary>
    public class WorkflowNode
    {
        /// <summary>
        /// 步骤ID
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 表单Id
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public decimal[] Position { get; set; }

        /// <summary>
        /// 类型[left,top]
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 步骤输入
        /// </summary>
        public StepBodyInput StepBody { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public IEnumerable<string> ParentNodes { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public IEnumerable<WorkflowConditionNode> NextNodes { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 下一步骤
        /// </summary>
        public string NextStep { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public bool? Direction { get; set; }

        /// <summary>
        /// 是否自由回退
        /// </summary>
        public bool? BackAutoStep { get; set; }

        /// <summary>
        /// 是否回退至上一步
        /// </summary>
        public bool? BackLastStep { get; set; }

        /// <summary>
        /// 是否质检
        /// </summary>
        public bool? IsQuality { get; set; }

        /// <summary>
        /// 是否附卡节点
        /// </summary>
        public bool? IsSupplementCard { get; set; }

        /// <summary>
        /// ToDo节点
        /// </summary>
        public List<WorkflowNode> ToDo { get; set; }

        /// <summary>
        /// 终止设置
        /// </summary>
        public IEnumerable<EndpointOption> EndpointOptions { get; set; }
    }

    /// <summary>
    /// 终止设置
    /// </summary>
    public class EndpointOption
    {
        /// <summary>
        ///
        /// </summary>
        public string anchor { get; set; }

        /// <summary>
        ///
        /// </summary>
		public string maxConnections { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string uuid { get; set; }
    }

    /// <summary>
    /// 条件节点
    /// </summary>
    public class WorkflowConditionNode
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 连线类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        public IEnumerable<WorkflowConditionCondition> Conditions { get; set; } = new List<WorkflowConditionCondition>();
    }

    /// <summary>
    /// 条件
    /// </summary>
    public class WorkflowConditionCondition
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }
    }
}