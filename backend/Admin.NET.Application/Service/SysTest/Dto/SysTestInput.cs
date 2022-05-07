using Furion.Extras.Admin.NET;
using Furion.Extras.Admin.NET.Service;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 测试模块表输入参数
    /// </summary>
    public class SysTestInput : PageInputBase
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual decimal Value { get; set; }
        
    }

    public class AddSysTestInput : SysTestInput
    {
    }

    public class DeleteSysTestInput : BaseId
    {
    }

    public class UpdateSysTestInput : SysTestInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeSysTestInput : BaseId
    {

    }
}
