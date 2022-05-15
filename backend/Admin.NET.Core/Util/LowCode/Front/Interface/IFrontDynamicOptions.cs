using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Interface
{
    public interface IFrontDynamicOptions
    {
        /// <summary>
        /// 动态数据
        /// </summary>
        string DynamicKey { get; set; }

        /// <summary>
        /// 是否是动态数据
        /// </summary>
        bool Dynamic { get; set; }
    }
}
