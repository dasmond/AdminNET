using System.ComponentModel;

namespace Admin.NET.Core
{
    /// <summary>
    /// 生命周期阶段
    /// </summary>
    public enum lifeCycleEnum
    {
        /// <summary>
        /// 提交
        /// </summary>
        [Description("提交")]
        Submit = 0,
        /// <summary>
        /// 归档
        /// </summary>
        [Description("归档")]
        File = 1,
        /// <summary>
        /// 发布
        /// </summary>
        [Description("发布")]
        Release = 2,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Frozen = 3,
        /// <summary>
        /// 报废
        /// </summary>
        [Description("报废")]
        Scrap = 4,
    }
}
