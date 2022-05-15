using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Model
{
    public class Front_Base<T> : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public T Options { get; set; }

        /// <summary>
        /// 数据字段
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 帮助信息
        /// </summary>
        public string Help { get; set; }

        /// <summary>
        /// 校验
        /// </summary>
        public Front_Rule[] Rules { get; set; }
    }
}
