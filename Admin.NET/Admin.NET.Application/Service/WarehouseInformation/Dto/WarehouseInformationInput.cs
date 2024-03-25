using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 仓库资料表基础输入参数
    /// </summary>
    public class WarehouseInformationBaseInput
    {
        /// <summary>
        /// 仓库名
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 公司名id
        /// </summary>
        public virtual long CompanyNameId { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Location { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Memo { get; set; }
        
        /// <summary>
        /// 负责人
        /// </summary>
        public virtual long? UserId { get; set; }
        
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
    /// 仓库资料表分页查询输入参数
    /// </summary>
    public class WarehouseInformationInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 仓库名
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 公司名id
        /// </summary>
        public long? CompanyNameId { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public string? Location { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? Memo { get; set; }
        
        /// <summary>
        /// 负责人
        /// </summary>
        public long? UserId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 仓库资料表增加输入参数
    /// </summary>
    public class AddWarehouseInformationInput : WarehouseInformationBaseInput
    {
        /// <summary>
        /// 仓库名
        /// </summary>
        [Required(ErrorMessage = "仓库名不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 公司名id
        /// </summary>
        [Required(ErrorMessage = "公司名id不能为空")]
        public override long CompanyNameId { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        public override string Location { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string Memo { get; set; }
        
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
    /// 仓库资料表删除输入参数
    /// </summary>
    public class DeleteWarehouseInformationInput : BaseIdInput
    {
    }

    /// <summary>
    /// 仓库资料表更新输入参数
    /// </summary>
    public class UpdateWarehouseInformationInput : WarehouseInformationBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 仓库资料表主键查询输入参数
    /// </summary>
    public class QueryByIdWarehouseInformationInput : DeleteWarehouseInformationInput
    {

    }
