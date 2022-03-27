using SqlSugar;
using Admin.NET.Core;
using Admin.NET.Core.Service;
using System.Collections.Generic;

namespace Admin.NET.Application
{
    /// <summary>
    /// 文章分类输出参数
    /// </summary>
    public class CmsArticleCategoryOutput
    {
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
        public MapperSysFileOutput PictureAttachment { get; set; }
    
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
       public WebsiteIdFkCmsWebsiteOutput FkWebsiteId { get; set; }

       public List<CmsArticleCategoryOutput> Children { get; set; }

    }
    [SugarTable("cms_website")]
    [NotTable]
    public class WebsiteIdFkCmsWebsiteOutput: EntityBaseId
    {
        public string Name { get; set; }
    }
}
