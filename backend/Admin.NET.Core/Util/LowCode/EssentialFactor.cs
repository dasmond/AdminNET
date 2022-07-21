using Furion.Extras.Admin.NET.Util.LowCode.Factor.Interface;

namespace Furion.Extras.Admin.NET.Util.LowCode
{
    /// <summary>
    /// 要素项
    /// </summary>
    public class EssentialFactor
    {
        /// <summary>
        /// 要素名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字段集
        /// </summary>
        public IList<IFactor> Factors { get; set; } = new List<IFactor>();
    }
}