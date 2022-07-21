using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 单选框
    /// </summary>
    [FrontType("radio")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(long))]
    public class Front_Radio : Front_Base<Front_Radio_Options>, IFrontDynamic
    {
        public override ViewDynamic Dynamic
        { get { return new ViewDynamic() { Dynamic = this.Options.Dynamic, DynamicKey = this.Options.DynamicKey }; } }
    }

    public class Front_Radio_Options : IFrontDynamicOptions
    {
        /// <summary>
        /// 动态数据
        /// </summary>
        public string DynamicKey { get; set; }

        /// <summary>
        /// 是否是动态数据
        /// </summary>
        public bool Dynamic { get; set; }

        /// <summary>
        /// 选项配置
        /// </summary>
        public Front_Option[] Options { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }
    }
}