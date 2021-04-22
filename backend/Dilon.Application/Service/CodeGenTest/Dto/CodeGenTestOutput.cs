using System;

namespace Dilon.Application
{
    /// <summary>
    /// 代码生成业务输出参数
    /// </summary>
    public class CodeGenTestOutput
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        
        /// <summary>
        /// 生日
        /// </summary>
        public DateTimeOffset Birthday { get; set; }
        
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        
    }
}
