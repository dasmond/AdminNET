using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 交付物管理输出参数
    /// </summary>
    public class DeliverablesOutput
    {
        /// <summary>
        /// 当前月份
        /// </summary>
        public DateTimeOffset Issue { get; set; }
        
        /// <summary>
        /// 所属企业
        /// </summary>
        public string Enterprise { get; set; }
        
        /// <summary>
        /// 上传验收单
        /// </summary>
        public string Acceptance { get; set; }
        
        /// <summary>
        /// 任务
        /// </summary>
        public string Job { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public long State { get; set; }
        
        /// <summary>
        /// 上传交付物
        /// </summary>
        public string Deliver { get; set; }
        
        /// <summary>
        /// 创客姓名
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        
    }
}
