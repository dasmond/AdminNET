using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;
using System.Collections.Generic;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 输入框
    /// </summary>
    [FrontType("input")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(200)")]
    public class Front_Input : Front_Base<Front_Input_Options>
    {

    }

    public class Front_Input_Options
    {
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 占位内容
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// 可清除
        /// </summary>
        public bool Clearable { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        public string AddonBefore { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string AddonAfter { get; set; }
    }


}
