using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 滑动输入条
    /// </summary>
    [FrontType("slider")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(int))]
    public class Front_Slider : Front_Base<Front_Slider_Options>
    {
    }

    public class Front_Slider_Options
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public int DefaultValue { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// 步长
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// 显示输入框
        /// </summary>
        public bool ShowInput { get; set; }
    }
}