using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("button")]
    public class Front_Button : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public Front_Button_Options Options { get; set; }

        public ViewDynamic Dynamic
        { get { return null; } }
    }

    public class Front_Button_Options
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 按钮操作
        /// </summary>
        public string Handle { get; set; }

        /// <summary>
        /// 动态函数
        /// </summary>
        public string DynamicFun { get; set; }

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