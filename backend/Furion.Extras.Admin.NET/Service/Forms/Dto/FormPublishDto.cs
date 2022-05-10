using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.Forms.Dto
{
    /// <summary>
    /// 发布状态
    /// </summary>
    public class FormPublishDto:BaseId
    {
        /// <summary>
        /// 发布状态
        /// </summary>
        public bool Publish { get; set; }


        /// <summary>
        /// 表单类型Id
        /// </summary>
        public long? Type { get; set; }
    }
}
