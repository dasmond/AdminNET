namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Model
{
    public class Front_Rule
    {
        /// <summary>
        /// 必填项
        /// </summary>
        public bool? Required { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Pattern { get; set; }
    }
}