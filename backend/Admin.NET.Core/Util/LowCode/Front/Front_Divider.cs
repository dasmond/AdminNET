using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("divider")]
    public class Front_Divider : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// 分割线配置
        /// </summary>
        public Front_Divider_Options Options { get; set; }

        public ViewDynamic Dynamic
        { get { return null; } }
    }

    public class Front_Divider_Options
    {
        /// <summary>
        /// 标签位置
        /// </summary>
        public string Orientation { get; set; }
    }
}