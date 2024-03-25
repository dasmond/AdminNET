using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 业务字典配置详情表基础输入参数
    /// </summary>
    public class BusinessDictionaryConfigurationDetailsBaseInput
    {
        /// <summary>
        /// 主表id
        /// </summary>
        public virtual long ParentId { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Code { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
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
    /// 业务字典配置详情表分页查询输入参数
    /// </summary>
    public class BusinessDictionaryConfigurationDetailsInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 主表id
        /// </summary>
        public long? ParentId { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string? Code { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 业务字典配置详情表增加输入参数
    /// </summary>
    public class AddBusinessDictionaryConfigurationDetailsInput : BusinessDictionaryConfigurationDetailsBaseInput
    {
        /// <summary>
        /// 主表id
        /// </summary>
        [Required(ErrorMessage = "主表id不能为空")]
        public override long ParentId { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Code { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        public override int Sort { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
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
    /// 业务字典配置详情表删除输入参数
    /// </summary>
    public class DeleteBusinessDictionaryConfigurationDetailsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 业务字典配置详情表更新输入参数
    /// </summary>
    public class UpdateBusinessDictionaryConfigurationDetailsInput : BusinessDictionaryConfigurationDetailsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 业务字典配置详情表主键查询输入参数
    /// </summary>
    public class QueryByIdBusinessDictionaryConfigurationDetailsInput : DeleteBusinessDictionaryConfigurationDetailsInput
    {

    }
