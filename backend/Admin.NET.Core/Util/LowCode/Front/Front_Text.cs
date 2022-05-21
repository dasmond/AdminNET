using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 文本框
    /// </summary>
    [FrontType("text")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(2000)")]
    public class Front_Text : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public Front_Text_Options Options { get; set; }

        public ViewDynamic Dynamic { get { return null; } }
    }

    public class Front_Text_Options
    {
        /// <summary>
        /// 文字对齐方式
        /// </summary>
        public string TextAlign { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 显示必选标记
        /// </summary>
        public bool ShowRequiredMark { get; set; }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 字体类型
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public string FontSize { get; set; }
    }
}
