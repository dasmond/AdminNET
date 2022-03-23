using System;
namespace Admin.NET.Application
{
    /// <summary>
    /// 站点输出参数
    /// </summary>
    public class CmsWebsiteOutput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 站点名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { get; set; }
        
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
        
    }
}
