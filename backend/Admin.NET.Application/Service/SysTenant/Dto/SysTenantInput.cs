using Furion.Extras.Admin.NET;
using Furion.Extras.Admin.NET.Service;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{    
    
    /// <summary>
    /// 租户表查询参数
    /// </summary>
    public class SysTenantSearch : PageInputBase
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 管理员名称
        /// </summary>
        public virtual string AdminName { get; set; }
        
        /// <summary>
        /// 主机
        /// </summary>
        public virtual string Host { get; set; }
        
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public virtual string Email { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Phone { get; set; }
        
        /// <summary>
        /// 数据库连接
        /// </summary>
        public virtual string Connection { get; set; }
        
        /// <summary>
        /// 架构
        /// </summary>
        public virtual string Schema { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        
    }

    /// <summary>
    /// 租户表输入参数
    /// </summary>
    public class SysTenantInput
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 管理员名称
        /// </summary>
        public virtual string AdminName { get; set; }
        
        /// <summary>
        /// 主机
        /// </summary>
        public virtual string Host { get; set; }
        
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public virtual string Email { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Phone { get; set; }
        
        /// <summary>
        /// 数据库连接
        /// </summary>
        public virtual string Connection { get; set; }
        
        /// <summary>
        /// 架构
        /// </summary>
        public virtual string Schema { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        
    }

    public class AddSysTenantInput : SysTenantInput
    {
    }

    public class DeleteSysTenantInput : BaseId
    {
    }

    public class UpdateSysTenantInput : SysTenantInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeSysTenantInput : BaseId
    {

    }
}
