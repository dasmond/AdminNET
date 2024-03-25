using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    /// <summary>
    /// 文件上传程序类型
    /// </summary>
    public enum ProgramTypeEnum
    {
        /// <summary>
        /// 软件
        /// </summary>
        [Description("软件")]
        Hardware = 0,

        /// <summary>
        /// 硬件
        /// </summary>
        [Description("硬件")]
        Software = 1,

    }
}
