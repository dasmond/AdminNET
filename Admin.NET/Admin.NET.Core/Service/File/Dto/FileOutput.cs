using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.Service
{
    public class FileOutput
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get { return this.Id + this.Suffix; } }
        /// <summary>
        /// 文件URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string SizeKb { get; set; }
        /// <summary>
        /// 文件后缀
        /// </summary>
        public string Suffix { get; set; }
    }
}
