using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("textarea")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(2000)")]
    public class Front_Textarea : Front_Base<Front_Textarea_Options>
    {
    }

    public class Front_Textarea_Options
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 自适应内容高度
        /// </summary>
        public int? MinRows { get; set; }

        /// <summary>
        /// 自适应内容高度
        /// </summary>
        public int? MaxRows { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

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
        /// 占位内容
        /// </summary>
        public string Placeholder { get; set; }
    }
}