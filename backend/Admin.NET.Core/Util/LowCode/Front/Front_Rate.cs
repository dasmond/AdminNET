using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 评分
    /// </summary>
    [FrontType("rate")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(int))]
    public class Front_Rate : Front_Base<Front_Rate_Options>
    {
    }

    public class Front_Rate_Options
    {
        /// <summary>
        /// 默认值
        /// </summary>
        public int DefaultValue { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 允许半选
        /// </summary>
        public bool AllowHalf { get; set; }
    }
}