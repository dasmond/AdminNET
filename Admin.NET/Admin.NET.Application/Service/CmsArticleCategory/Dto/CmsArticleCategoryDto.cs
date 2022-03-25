using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 文章分类输出参数
    /// </summary>
    public class CmsArticleCategoryDto
    {
        /// <summary>
        /// 所属站点
        /// </summary>
        public string CmsWebsiteName { get; set; }
        
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 父级
        /// </summary>
        public long Pid { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 图像
        /// </summary>
        public long Picture { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNo { get; set; }
        
        /// <summary>
        /// 所属站点
        /// </summary>
        public long WebsiteId { get; set; }
        
    }
}
