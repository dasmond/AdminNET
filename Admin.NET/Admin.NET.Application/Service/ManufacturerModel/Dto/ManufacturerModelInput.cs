using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 制造商型号基础输入参数
    /// </summary>
    public class ManufacturerModelBaseInput
    {
        /// <summary>
        /// 制造商Id
        /// </summary>
        public virtual long ManufacturerId { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public virtual string Model { get; set; }
        
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
    /// 制造商型号分页查询输入参数
    /// </summary>
    public class ManufacturerModelInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 制造商Id
        /// </summary>
        public long? ManufacturerId { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public string? Model { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 制造商型号增加输入参数
    /// </summary>
    public class AddManufacturerModelInput : ManufacturerModelBaseInput
    {
        /// <summary>
        /// 制造商Id
        /// </summary>
        [Required(ErrorMessage = "制造商Id不能为空")]
        public override long ManufacturerId { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        [Required(ErrorMessage = "型号不能为空")]
        public override string Model { get; set; }
        
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
    /// 制造商型号删除输入参数
    /// </summary>
    public class DeleteManufacturerModelInput : BaseIdInput
    {
    }

    /// <summary>
    /// 制造商型号更新输入参数
    /// </summary>
    public class UpdateManufacturerModelInput : ManufacturerModelBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 制造商型号主键查询输入参数
    /// </summary>
    public class QueryByIdManufacturerModelInput : DeleteManufacturerModelInput
    {

    }
