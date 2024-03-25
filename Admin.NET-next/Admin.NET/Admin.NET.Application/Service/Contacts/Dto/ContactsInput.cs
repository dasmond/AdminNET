using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 客户联系人资料基础输入参数
    /// </summary>
    public class ContactsBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 上级ID
        /// </summary>
        public virtual long ParentId { get; set; }
        
        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string Contact { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Phone { get; set; }
        
        /// <summary>
        /// 传真
        /// </summary>
        public virtual string Fax { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        
        /// <summary>
        /// 职位关系
        /// </summary>
        public virtual string Post { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        public virtual string Center { get; set; }
        
        /// <summary>
        /// 设置默认联系人
        /// </summary>
        public virtual bool DefaultValue { get; set; }
        
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
    /// 客户联系人资料分页查询输入参数
    /// </summary>
    public class ContactsInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 上级ID
        /// </summary>
        public long? ParentId { get; set; }
        
        /// <summary>
        /// 联系人
        /// </summary>
        public string? Contact { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public string? Phone { get; set; }
        
        /// <summary>
        /// 传真
        /// </summary>
        public string? Fax { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public string? Address { get; set; }
        
        /// <summary>
        /// 职位关系
        /// </summary>
        public string? Post { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        public string? Center { get; set; }
        
        /// <summary>
        /// 设置默认联系人
        /// </summary>
        public bool? DefaultValue { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 客户联系人资料增加输入参数
    /// </summary>
    public class AddContactsInput : ContactsBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 上级ID
        /// </summary>
        [Required(ErrorMessage = "上级ID不能为空")]
        public override long ParentId { get; set; }
        
        /// <summary>
        /// 联系人
        /// </summary>
        [Required(ErrorMessage = "联系人不能为空")]
        public override string Contact { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        [Required(ErrorMessage = "电话不能为空")]
        public override string Phone { get; set; }
        
        /// <summary>
        /// 传真
        /// </summary>
        [Required(ErrorMessage = "传真不能为空")]
        public override string Fax { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        public override string Address { get; set; }
        
        /// <summary>
        /// 职位关系
        /// </summary>
        [Required(ErrorMessage = "职位关系不能为空")]
        public override string Post { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        [Required(ErrorMessage = "经纬度不能为空")]
        public override string Center { get; set; }
        
        /// <summary>
        /// 设置默认联系人
        /// </summary>
        [Required(ErrorMessage = "设置默认联系人不能为空")]
        public override bool DefaultValue { get; set; }
        
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
    /// 客户联系人资料删除输入参数
    /// </summary>
    public class DeleteContactsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 客户联系人资料更新输入参数
    /// </summary>
    public class UpdateContactsInput : ContactsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 客户联系人资料主键查询输入参数
    /// </summary>
    public class QueryByIdContactsInput : DeleteContactsInput
    {

    }
