using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 时间选择框
    /// </summary>
    [FrontType("time")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(10)")]
    public class Front_Time : Front_Base<Front_Time_Options>
    {
    }

    public class Front_Time_Options
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

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
        /// 时间格式
        /// </summary>
        public string Format { get; set; }
    }
}