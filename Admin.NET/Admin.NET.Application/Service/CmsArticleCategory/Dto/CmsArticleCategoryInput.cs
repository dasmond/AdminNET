using System;
using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 文章分类输入参数
    /// </summary>
    public class CmsArticleCategoryInput : BasePageInput
    {
        /// <summary>
        /// 父级
        /// </summary>
        public virtual long Pid { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 图像
        /// </summary>
        public virtual long Picture { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int OrderNo { get; set; }
        
        /// <summary>
        /// 所属站点
        /// </summary>
        public virtual long WebsiteId { get; set; }
        
    }

    public class AddCmsArticleCategoryInput : CmsArticleCategoryInput
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        public override int OrderNo { get; set; }
        
        /// <summary>
        /// 所属站点
        /// </summary>
        [Required(ErrorMessage = "所属站点不能为空")]
        public override long WebsiteId { get; set; }
        
    }

    public class DeleteCmsArticleCategoryInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateCmsArticleCategoryInput : CmsArticleCategoryInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeCmsArticleCategoryInput : DeleteCmsArticleCategoryInput
    {

    }
}
