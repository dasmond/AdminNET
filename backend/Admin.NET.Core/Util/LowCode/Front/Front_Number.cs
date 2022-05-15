using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;
using System.Collections.Generic;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 数字输入框
    /// </summary>
    [FrontType("number")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(decimal), "decimal(25,11)")]
    public class Front_Number : Front_Base<Front_Number_Options>
    {

    }

    public class Front_Number_Options
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public decimal? DefaultValue { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public decimal? Min { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public decimal? Max { get; set; }

        /// <summary>
        /// 数值精度
        /// </summary>
        public int? Precision { get; set; }

        /// <summary>
        /// 步长
        /// </summary>
        public int? Step { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 占位内容
        /// </summary>
        public string Placeholder { get; set; }
    }
}
