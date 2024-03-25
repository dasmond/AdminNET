using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 文件目录基础输入参数
    /// </summary>
    public class FileDirectoryBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 上层id
        /// </summary>
        public virtual long UpperLevelsId { get; set; }
        
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public virtual string FolderName { get; set; }
        
        /// <summary>
        /// 层级
        /// </summary>
        public virtual int Level { get; set; }
        
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
    /// 文件目录分页查询输入参数
    /// </summary>
    public class FileDirectoryInput : BasePageInput
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
        /// 上层id
        /// </summary>
        public long? UpperLevelsId { get; set; }
        
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string? FolderName { get; set; }
        
        /// <summary>
        /// 层级
        /// </summary>
        public int? Level { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 文件目录增加输入参数
    /// </summary>
    public class AddFileDirectoryInput : FileDirectoryBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 上层id
        /// </summary>
        [Required(ErrorMessage = "上层id不能为空")]
        public override long UpperLevelsId { get; set; }
        
        /// <summary>
        /// 文件夹名称
        /// </summary>
        [Required(ErrorMessage = "文件夹名称不能为空")]
        public override string FolderName { get; set; }
        
        /// <summary>
        /// 层级
        /// </summary>
        [Required(ErrorMessage = "层级不能为空")]
        public override int Level { get; set; }
        
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
    /// 文件目录删除输入参数
    /// </summary>
    public class DeleteFileDirectoryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 文件目录更新输入参数
    /// </summary>
    public class UpdateFileDirectoryInput : FileDirectoryBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 文件目录主键查询输入参数
    /// </summary>
    public class QueryByIdFileDirectoryInput : DeleteFileDirectoryInput
    {

    }
