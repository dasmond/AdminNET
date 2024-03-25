using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 资产登记表基础输入参数
    /// </summary>
    public class AssetRegisterBaseInput
    {
        /// <summary>
        /// 管理编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 物品名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public virtual string ModelNumber { get; set; }
        
        /// <summary>
        /// 使用部门
        /// </summary>
        public virtual string UserDepartment { get; set; }
        
        /// <summary>
        /// 存放位置
        /// </summary>
        public virtual string StorageLocation { get; set; }
        
        /// <summary>
        /// 资产类型
        /// </summary>
        public virtual string AssetType { get; set; }
        
        /// <summary>
        /// 管理部门
        /// </summary>
        public virtual long ManagementId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 盘点时间
        /// </summary>
        public virtual DateTime? StocktakingTime { get; set; }
        
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
    /// 资产登记表分页查询输入参数
    /// </summary>
    public class AssetRegisterInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 管理编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 物品名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public string? ModelNumber { get; set; }
        
        /// <summary>
        /// 使用部门
        /// </summary>
        public string? UserDepartment { get; set; }
        
        /// <summary>
        /// 存放位置
        /// </summary>
        public string? StorageLocation { get; set; }
        
        /// <summary>
        /// 资产类型
        /// </summary>
        public string? AssetType { get; set; }
        
        /// <summary>
        /// 管理部门
        /// </summary>
        public long? ManagementId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime? StocktakingTime { get; set; }
        
        /// <summary>
         /// 盘点时间范围
         /// </summary>
         public List<DateTime?> StocktakingTimeRange { get; set; } 
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 资产登记表增加输入参数
    /// </summary>
    public class AddAssetRegisterInput : AssetRegisterBaseInput
    {
        /// <summary>
        /// 管理编码
        /// </summary>
        [Required(ErrorMessage = "管理编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 物品名称
        /// </summary>
        [Required(ErrorMessage = "物品名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        [Required(ErrorMessage = "型号不能为空")]
        public override string ModelNumber { get; set; }
        
        /// <summary>
        /// 使用部门
        /// </summary>
        [Required(ErrorMessage = "使用部门不能为空")]
        public override string UserDepartment { get; set; }
        
        /// <summary>
        /// 存放位置
        /// </summary>
        [Required(ErrorMessage = "存放位置不能为空")]
        public override string StorageLocation { get; set; }
        
        /// <summary>
        /// 资产类型
        /// </summary>
        [Required(ErrorMessage = "资产类型不能为空")]
        public override string AssetType { get; set; }
        
        /// <summary>
        /// 管理部门
        /// </summary>
        [Required(ErrorMessage = "管理部门不能为空")]
        public override long ManagementId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public override string Status { get; set; }
        
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
    /// 资产登记表删除输入参数
    /// </summary>
    public class DeleteAssetRegisterInput : BaseIdInput
    {
    }

    /// <summary>
    /// 资产登记表更新输入参数
    /// </summary>
    public class UpdateAssetRegisterInput : AssetRegisterBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 资产登记表主键查询输入参数
    /// </summary>
    public class QueryByIdAssetRegisterInput : DeleteAssetRegisterInput
    {

    }
