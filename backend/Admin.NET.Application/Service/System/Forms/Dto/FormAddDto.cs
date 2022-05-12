using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 表单添加
    /// </summary>
    public class FormAddDto
    {
        /// <summary>
        ///表单标题 不可重复
        /// </summary>
        [Required(ErrorMessage ="标题不能为空")]
        public string Title { get; set; }

        /// <summary>
        /// 表单类型ID
        /// </summary>
        [Required(ErrorMessage = "表单类型ID不可为空")]
        public long TypeId { get; set; }

        /// <summary>
        /// form表单Json
        /// </summary>
        public string FormJson { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool Publish { get; set; } = false;

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }
    }
}
