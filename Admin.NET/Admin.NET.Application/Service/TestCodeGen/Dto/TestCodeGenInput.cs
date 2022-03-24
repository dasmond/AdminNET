using System;
using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 测试生成输入参数
    /// </summary>
    public class TestCodeGenInput : BasePageInput
    {
        /// <summary>
        /// 图像
        /// </summary>
        public virtual long Image { get; set; }
        
        /// <summary>
        /// 用户
        /// </summary>
        public virtual long User { get; set; }
        
    }

    public class AddTestCodeGenInput : TestCodeGenInput
    {
        /// <summary>
        /// 用户
        /// </summary>
        [Required(ErrorMessage = "用户不能为空")]
        public override long User { get; set; }
        
    }

    public class DeleteTestCodeGenInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateTestCodeGenInput : TestCodeGenInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeTestCodeGenInput : DeleteTestCodeGenInput
    {

    }
}
