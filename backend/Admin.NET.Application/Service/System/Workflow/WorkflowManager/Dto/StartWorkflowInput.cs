namespace Admin.NET.Application
{
    /// <summary>
    /// 开始流程输入
    /// </summary>
    public class StartWorkflowInput
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 输入信息
        /// </summary>
        public Dictionary<string, object> Inputs { get; set; }
    }
}
