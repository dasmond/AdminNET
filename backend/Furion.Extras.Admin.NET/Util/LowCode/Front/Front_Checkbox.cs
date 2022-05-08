using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 多选框
    /// </summary>
    [FrontType("checkbox")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(200)")]
    public class Front_Checkbox : Front_Base<Front_Checkbox_Options>, IFrontDynamic
    {
    }

    public class Front_Checkbox_Options : IFrontDynamicOptions
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
        public string[] DefaultValue { get; set; }

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
