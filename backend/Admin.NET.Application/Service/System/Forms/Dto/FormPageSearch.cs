using Admin.NET.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 分页查询条件
    /// </summary>
    public class FormPageSearch: PageInputBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 表单类型
        /// </summary>
        public long? TypeId { get; set; }
    }
}
