using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 制造商资料基础输入参数
    /// </summary>
    public class ManufacturerInformationBaseInput
    {
        /// <summary>
        /// 制造商
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 品牌
        /// </summary>
        public virtual string Brand { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        public virtual string Center { get; set; }
        
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
    /// 制造商资料分页查询输入参数
    /// </summary>
    public class ManufacturerInformationInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 品牌
        /// </summary>
        public string? Brand { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        public string? Center { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 制造商资料增加输入参数
    /// </summary>
    public class AddManufacturerInformationInput : ManufacturerInformationBaseInput
    {
        /// <summary>
        /// 制造商
        /// </summary>
        [Required(ErrorMessage = "制造商不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 品牌
        /// </summary>
        [Required(ErrorMessage = "品牌不能为空")]
        public override string Brand { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        [Required(ErrorMessage = "经纬度不能为空")]
        public override string Center { get; set; }
        
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
    /// 制造商资料删除输入参数
    /// </summary>
    public class DeleteManufacturerInformationInput : BaseIdInput
    {
    }

    /// <summary>
    /// 制造商资料更新输入参数
    /// </summary>
    public class UpdateManufacturerInformationInput : ManufacturerInformationBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 制造商资料主键查询输入参数
    /// </summary>
    public class QueryByIdManufacturerInformationInput : DeleteManufacturerInformationInput
    {

    }
