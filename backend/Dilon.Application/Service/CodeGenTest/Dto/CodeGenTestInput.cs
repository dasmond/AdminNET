using Dilon.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dilon.Application
{
    /// <summary>
    /// 代码生成业务输入参数
    /// </summary>
    public class CodeGenTestInput : PageInputBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }
        
        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTimeOffset Birthday { get; set; }
        
        /// <summary>
        /// 年龄
        /// </summary>
        public virtual int Age { get; set; }
        
    }

    public class AddCodeGenTestInput : CodeGenTestInput
    {
    }

    public class DeleteCodeGenTestInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateCodeGenTestInput : CodeGenTestInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeCodeGenTestInput : DeleteCodeGenTestInput
    {

    }
}
