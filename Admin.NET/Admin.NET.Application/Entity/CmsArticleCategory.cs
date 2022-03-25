using System;
using SqlSugar;
using System.ComponentModel;
using Admin.NET.Core;
namespace Admin.NET.Application
{
     /// <summary>
     /// 文章分类
     /// </summary>
      [SugarTable("cms_article_category")]
      [Description("文章分类")]
      public class CmsArticleCategory  : EntityBase
      {
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