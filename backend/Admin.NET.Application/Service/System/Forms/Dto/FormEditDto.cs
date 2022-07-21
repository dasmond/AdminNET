namespace Admin.NET.Application
{
    /// <summary>
    /// 表单编辑
    /// </summary>
    public class FormEditDto : BaseDto
    {
        /// <summary>
        ///表单标题 不可重复
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// form表单Json
        /// </summary>
        public string FormJson { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool Publish { get; set; }

        /// <summary>
        /// 表单类型ID
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }
    }
}