using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 日期选择框
    /// </summary>
    [FrontType("date")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(DateTimeOffset))]
    public class Front_Date : Front_Base<Front_Date_Options>
    {
    }

    public class Front_Date_Options
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public DateTime? DefaultValue { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public DateTime[] RangeDefaultValue { get; set; }

        /// <summary>
        /// 范围选择
        /// </summary>
        public bool Range { get; set; }

        /// <summary>
        /// 时间选择器
        /// </summary>
        public bool ShowTime { get; set; }

        /// <summary>
        /// 可清除
        /// </summary>
        public bool Clearable { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 占位内容
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// 占位内容
        /// </summary>
        public string[] RangePlaceholder { get; set; }

        /// <summary>
        /// 时间格式
        /// </summary>
        public string Format { get; set; }
    }
}