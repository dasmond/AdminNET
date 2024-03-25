using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 业务员关系基础输入参数
    /// </summary>
    public class SalespersonRelationshipBaseInput
    {
        /// <summary>
        /// 管理员id
        /// </summary>
        public virtual long AdministratorsId { get; set; }
        
        /// <summary>
        /// 业务员id
        /// </summary>
        public virtual long SalespersonId { get; set; }
        
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
    /// 业务员关系分页查询输入参数
    /// </summary>
    public class SalespersonRelationshipInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 管理员id
        /// </summary>
        public long? AdministratorsId { get; set; }
        
        /// <summary>
        /// 业务员id
        /// </summary>
        public long? SalespersonId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 业务员关系增加输入参数
    /// </summary>
    public class AddSalespersonRelationshipInput : SalespersonRelationshipBaseInput
    {
        /// <summary>
        /// 管理员id
        /// </summary>
        [Required(ErrorMessage = "管理员id不能为空")]
        public override long AdministratorsId { get; set; }
        
        /// <summary>
        /// 业务员id
        /// </summary>
        [Required(ErrorMessage = "业务员id不能为空")]
        public override long SalespersonId { get; set; }
        
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
    /// 业务员关系删除输入参数
    /// </summary>
    public class DeleteSalespersonRelationshipInput : BaseIdInput
    {
    }

    /// <summary>
    /// 业务员关系更新输入参数
    /// </summary>
    public class UpdateSalespersonRelationshipInput : SalespersonRelationshipBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 业务员关系主键查询输入参数
    /// </summary>
    public class QueryByIdSalespersonRelationshipInput : DeleteSalespersonRelationshipInput
    {

    }
