using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("switch")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(bool))]
    public class Front_Switch : Front_Base<Front_Switch_Options>
    {
    }

    public class Front_Switch_Options
    {
        /// <summary>
        /// 默认值
        /// </summary>
        public bool DefaultValue { get; set; }

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