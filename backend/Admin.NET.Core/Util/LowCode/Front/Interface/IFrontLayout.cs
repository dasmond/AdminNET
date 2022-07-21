using Newtonsoft.Json.Linq;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Interface
{
    public interface IFrontLayout
    {
        /// <summary>
        /// 布局子组件解析
        /// </summary>
        /// <param name="JData"></param>
        /// <returns></returns>
        IFront ConvertFront(JObject JData);

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="action"></param>
        void ReadFront(Action<IFront> action);
    }
}