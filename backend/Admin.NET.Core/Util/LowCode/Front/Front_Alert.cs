using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 警告提示
    /// </summary>
    [FrontType("alert")]
    public class Front_Alert : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public Front_Alert_Options Options { get; set; }
    }

    public class Front_Alert_Options
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 辅助表述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 显示图标
        /// </summary>
        public bool ShowIcon { get; set; }

        /// <summary>
        /// 无边框
        /// </summary>
        public bool Banner { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }
    }

}
