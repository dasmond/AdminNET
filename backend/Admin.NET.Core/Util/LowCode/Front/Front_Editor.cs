using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 富文本框
    /// </summary>
    [FrontType("editor")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(8000)")]
    public class Front_Editor : Front_Base<Front_Editor_Options>
    {
    }

    public class Front_Editor_Options
    {
        /// <summary>
        /// 高度
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 占位内容
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 汉化
        /// </summary>
        public bool Chinesization { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 显示Label
        /// </summary>
        public bool ShowLabel { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }
    }
}