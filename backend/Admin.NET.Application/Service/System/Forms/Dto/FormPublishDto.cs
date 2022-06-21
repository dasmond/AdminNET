using Admin.NET.Core.Service;

namespace Admin.NET.Application
{
    /// <summary>
    /// 发布状态
    /// </summary>
    public class FormPublishDto:BaseId
    {
        /// <summary>
        /// 发布状态
        /// </summary>
        public bool Publish { get; set; }


        /// <summary>
        /// 表单类型Id
        /// </summary>
        public long? Type { get; set; }
    }
}
