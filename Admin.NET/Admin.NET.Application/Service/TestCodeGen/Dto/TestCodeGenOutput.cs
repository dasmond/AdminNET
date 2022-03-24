using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 测试生成输出参数
    /// </summary>
    public class TestCodeGenOutput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 图像
        /// </summary>
        public long Image { get; set; }
        
        /// <summary>
        /// 用户
        /// </summary>
         public long User { get; set; }
         public UserFkUserOutputOutput FkUser { get; set; }
        
    }
    public class UserFkUserOutputOutput
    {
        public string UserName { get; set; }
    }

}
