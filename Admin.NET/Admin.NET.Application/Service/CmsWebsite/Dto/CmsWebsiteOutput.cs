using Admin.NET.Core;
using SqlSugar;
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
        public long Logo { get; set; }

        public CmsWebsiteMapperSysFile LogoAttachment { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
    }
    [SugarTable("sys_file")]
    [NotTable]
    public class CmsWebsiteMapperSysFile
    {
        /// <summary>
        /// 雪花Id
        /// </summary>
        [SugarColumn(ColumnDescription = "Id", IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        public string BucketName { get; set; }

        public string FileName { get; set; }

        public string Suffix { get; set; }

        public string FilePath { get; set; }
    }
}
