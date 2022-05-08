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
    /// 上传文件
    /// </summary>
    [FrontType("uploadFile")]
    [FrontTypeBindDatabase(DbProvider.SqlServer, typeof(string), "nvarchar(2000)")]
    public class Front_UploadFile : Front_Base<Front_UploadFile_Options>
    {

    }

    public class Front_UploadFile_Options
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
        /// 允许拖拽
        /// </summary>
        public bool Drag { get; set; }

        /// <summary>
        /// 下载方式
        /// </summary>
        public string DownloadWay { get; set; }

        /// <summary>
        /// 动态函数
        /// </summary>
        public string DynamicFun { get; set; }

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
    }

}
