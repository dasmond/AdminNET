using System;
using SqlSugar;
using System.ComponentModel;
using Admin.NET.Core;
namespace Admin.NET.Application
{
    /// <summary>
    /// 站点表
    /// </summary>
    [SugarTable("cms_website")]
    [Description("站点表")]
    public class CmsWebsite : EntityBase
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public long Logo { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
    }
}