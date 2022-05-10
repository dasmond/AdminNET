using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 表单表
    /// </summary>
    [Table("sys_forms")]
    [Comment("表单表")]
    public class SysForm:DEntityBase
    {
        /// <summary>
        ///表单标题 不可重复
        /// </summary>
        [Required(ErrorMessage = "标题不可为空")]
        [Comment("标题")]
        public string Title { get; set; }

        /// <summary>
        /// form表单Json
        /// </summary>
        [Required(ErrorMessage = "form表单Json不可为空")]
        [Comment("form表单Json")]
        public string FormJson { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        [Comment("是否发布")]
        public bool Publish { get; set; } = false;

        /// <summary>
        /// 表单类型ID
        /// </summary>
        [Required(ErrorMessage = "表单类型ID不可为空")]
        [Comment("表单类型ID")]
        public long TypeId { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [Comment("版本")]
        public int Version { get; set; }
    }
}
