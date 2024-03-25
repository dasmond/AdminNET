using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 文件库基础输入参数
    /// </summary>
    public class FileLibraryBaseInput
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        public virtual long DbId { get; set; }
        
        /// <summary>
        /// 文件号
        /// </summary>
        public virtual string FileNumber { get; set; }
        
        /// <summary>
        /// 标准文件号
        /// </summary>
        public virtual string StandardFileNumber { get; set; }
        
        /// <summary>
        /// 所属管理部门
        /// </summary>
        public virtual long Affiliation { get; set; }
        
        /// <summary>
        /// 文件级别
        /// </summary>
        public virtual int Level { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 模块名
        /// </summary>
        public virtual string Module { get; set; }
        
        /// <summary>
        /// 文件名
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 文件类型
        /// </summary>
        public virtual string Type { get; set; }
        
        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string Path { get; set; }
        
        /// <summary>
        /// 文件链接
        /// </summary>
        public virtual string Url { get; set; }
        
        /// <summary>
        /// 文件md5
        /// </summary>
        public virtual string Md5 { get; set; }
        
        /// <summary>
        /// 文件大小
        /// </summary>
        public virtual string Size { get; set; }
        
        /// <summary>
        /// 文件后缀
        /// </summary>
        public virtual string Suffix { get; set; }
        
        /// <summary>
        /// 下载次数
        /// </summary>
        public virtual int Download { get; set; }
        
        /// <summary>
        /// 存储到bucket的名称
        /// </summary>
        public virtual string FileObjectName { get; set; }
        
        /// <summary>
        /// 区分类型
        /// </summary>
        public virtual int DistinguishTypes { get; set; }
        
        /// <summary>
        /// 文件版本号
        /// </summary>
        public virtual int FileVersionNumber { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
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
    /// 文件库分页查询输入参数
    /// </summary>
    public class FileLibraryInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 所属表id
        /// </summary>
        public long? DbId { get; set; }
        
        /// <summary>
        /// 文件号
        /// </summary>
        public string? FileNumber { get; set; }
        
        /// <summary>
        /// 标准文件号
        /// </summary>
        public string? StandardFileNumber { get; set; }
        
        /// <summary>
        /// 所属管理部门
        /// </summary>
        public long? Affiliation { get; set; }
        
        /// <summary>
        /// 文件级别
        /// </summary>
        public int? Level { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 模块名
        /// </summary>
        public string? Module { get; set; }
        
        /// <summary>
        /// 文件名
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 文件类型
        /// </summary>
        public string? Type { get; set; }
        
        /// <summary>
        /// 文件路径
        /// </summary>
        public string? Path { get; set; }
        
        /// <summary>
        /// 文件链接
        /// </summary>
        public string? Url { get; set; }
        
        /// <summary>
        /// 文件md5
        /// </summary>
        public string? Md5 { get; set; }
        
        /// <summary>
        /// 文件大小
        /// </summary>
        public string? Size { get; set; }
        
        /// <summary>
        /// 文件后缀
        /// </summary>
        public string? Suffix { get; set; }
        
        /// <summary>
        /// 下载次数
        /// </summary>
        public int? Download { get; set; }
        
        /// <summary>
        /// 存储到bucket的名称
        /// </summary>
        public string? FileObjectName { get; set; }
        
        /// <summary>
        /// 区分类型
        /// </summary>
        public int? DistinguishTypes { get; set; }
        
        /// <summary>
        /// 文件版本号
        /// </summary>
        public int? FileVersionNumber { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 文件库增加输入参数
    /// </summary>
    public class AddFileLibraryInput : FileLibraryBaseInput
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        [Required(ErrorMessage = "所属表id不能为空")]
        public override long DbId { get; set; }
        
        /// <summary>
        /// 文件号
        /// </summary>
        [Required(ErrorMessage = "文件号不能为空")]
        public override string FileNumber { get; set; }
        
        /// <summary>
        /// 标准文件号
        /// </summary>
        [Required(ErrorMessage = "标准文件号不能为空")]
        public override string StandardFileNumber { get; set; }
        
        /// <summary>
        /// 所属管理部门
        /// </summary>
        [Required(ErrorMessage = "所属管理部门不能为空")]
        public override long Affiliation { get; set; }
        
        /// <summary>
        /// 文件级别
        /// </summary>
        [Required(ErrorMessage = "文件级别不能为空")]
        public override int Level { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 模块名
        /// </summary>
        [Required(ErrorMessage = "模块名不能为空")]
        public override string Module { get; set; }
        
        /// <summary>
        /// 文件名
        /// </summary>
        [Required(ErrorMessage = "文件名不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 文件类型
        /// </summary>
        [Required(ErrorMessage = "文件类型不能为空")]
        public override string Type { get; set; }
        
        /// <summary>
        /// 文件路径
        /// </summary>
        [Required(ErrorMessage = "文件路径不能为空")]
        public override string Path { get; set; }
        
        /// <summary>
        /// 文件链接
        /// </summary>
        [Required(ErrorMessage = "文件链接不能为空")]
        public override string Url { get; set; }
        
        /// <summary>
        /// 文件md5
        /// </summary>
        [Required(ErrorMessage = "文件md5不能为空")]
        public override string Md5 { get; set; }
        
        /// <summary>
        /// 文件大小
        /// </summary>
        [Required(ErrorMessage = "文件大小不能为空")]
        public override string Size { get; set; }
        
        /// <summary>
        /// 文件后缀
        /// </summary>
        [Required(ErrorMessage = "文件后缀不能为空")]
        public override string Suffix { get; set; }
        
        /// <summary>
        /// 下载次数
        /// </summary>
        [Required(ErrorMessage = "下载次数不能为空")]
        public override int Download { get; set; }
        
        /// <summary>
        /// 存储到bucket的名称
        /// </summary>
        [Required(ErrorMessage = "存储到bucket的名称不能为空")]
        public override string FileObjectName { get; set; }
        
        /// <summary>
        /// 区分类型
        /// </summary>
        [Required(ErrorMessage = "区分类型不能为空")]
        public override int DistinguishTypes { get; set; }
        
        /// <summary>
        /// 文件版本号
        /// </summary>
        [Required(ErrorMessage = "文件版本号不能为空")]
        public override int FileVersionNumber { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [Required(ErrorMessage = "审核信息提示不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        [Required(ErrorMessage = "完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
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
    /// 文件库删除输入参数
    /// </summary>
    public class DeleteFileLibraryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 文件库更新输入参数
    /// </summary>
    public class UpdateFileLibraryInput : FileLibraryBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 文件库主键查询输入参数
    /// </summary>
    public class QueryByIdFileLibraryInput : DeleteFileLibraryInput
    {

    }
