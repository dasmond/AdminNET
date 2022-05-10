using System.ComponentModel;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 单据类型
    /// </summary>
    public enum OrderTypeEnum
    {
        /// <summary>
        /// 正常单据
        /// </summary>
        [Description("正常单据")]
        Normal = 0,

        /// <summary>
        /// 回退单据
        /// </summary>
        [Description("回退单据")]
        BackOff = 2
    }
}
