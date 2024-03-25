using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 数据权限角色表基础输入参数
    /// </summary>
    public class TAclRoleFunctionBaseInput
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public virtual long RoleId { get; set; }
        
        /// <summary>
        /// 所属id
        /// </summary>
        public virtual long FunctionId { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public virtual long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public virtual string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public virtual long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public virtual string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public virtual bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public virtual int ReVision { get; set; }
        
    }

    /// <summary>
    /// 数据权限角色表分页查询输入参数
    /// </summary>
    public class TAclRoleFunctionInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public long? RoleId { get; set; }
        
        /// <summary>
        /// 所属id
        /// </summary>
        public long? FunctionId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 数据权限角色表增加输入参数
    /// </summary>
    public class AddTAclRoleFunctionInput : TAclRoleFunctionBaseInput
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [Required(ErrorMessage = "角色id不能为空")]
        public override long RoleId { get; set; }
        
        /// <summary>
        /// 所属id
        /// </summary>
        [Required(ErrorMessage = "所属id不能为空")]
        public override long FunctionId { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        [Required(ErrorMessage = "软删除不能为空")]
        public override bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        [Required(ErrorMessage = "乐观锁不能为空")]
        public override int ReVision { get; set; }
        
    }

    /// <summary>
    /// 数据权限角色表删除输入参数
    /// </summary>
    public class DeleteTAclRoleFunctionInput : BaseIdInput
    {
    }

    /// <summary>
    /// 数据权限角色表更新输入参数
    /// </summary>
    public class UpdateTAclRoleFunctionInput : TAclRoleFunctionBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 数据权限角色表主键查询输入参数
    /// </summary>
    public class QueryByIdTAclRoleFunctionInput : DeleteTAclRoleFunctionInput
    {

    }
