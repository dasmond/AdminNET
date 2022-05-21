using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("batch")]
    public class Front_Batch : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public Front_Batch_Options Options { get; set; }

        /// <summary>
        /// 数据字段
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 帮助信息
        /// </summary>
        public string Help { get; set; }

        public ViewDynamic Dynamic { get { return null; } }
    }


    public class Front_Batch_Options
    {
        public int ScrollY { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 显示Label
        /// </summary>
        public bool ShowLabel { get; set; }

        /// <summary>
        /// 隐藏序号
        /// </summary>
        public bool HideSequence { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }
    }

}
