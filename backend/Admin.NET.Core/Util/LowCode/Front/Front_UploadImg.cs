using Admin.NET.Core.Util.LowCode.Dto;
using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    /// <summary>
    /// 上传图片
    /// </summary>
    [FrontType("uploadImg")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(2000)", dtoType: typeof(Front_FileDto[]))]
    public class Front_UploadImg : Front_Base<Front_UploadImg_Options>
    {
    }

    public class Front_UploadImg_Options
    {
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 多选
        /// </summary>
        public bool Multiple { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 最大上传数量
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 额外参数（JSON格式）
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 文件name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 上传地址
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 占位内容
        /// </summary>
        public string Placeholder { get; set; }

        public object Headers { get; set; }

        public string ListType { get; set; }
    }
}