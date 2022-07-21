using Admin.NET.Core.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Interface
{
    public interface IFront
    {
        /// <summary>
        /// 唯一组件编号
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// 数据属性
        /// </summary>
        string Model { get; set; }

        /// <summary>
        /// 获取动态数据
        /// </summary>
        public ViewDynamic Dynamic { get; }
    }
}