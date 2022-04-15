using System;
using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 租户管理输入参数
    /// </summary>
    public class SysTenantInput : BasePageInput
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
        /// <summary>
        /// 公司名称
        /// </summary>
        [Required(ErrorMessage = "公司名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 管理员名称
        /// </summary>
        [Required(ErrorMessage = "管理员名称不能为空")]
        public override string AdminName { get; set; }
        
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Required(ErrorMessage = "电子邮箱不能为空")]
        public override string Email { get; set; }
        
    }

    public class DeleteSysTenantInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateSysTenantInput : SysTenantInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeSysTenantInput : DeleteSysTenantInput
    {

    }
}
