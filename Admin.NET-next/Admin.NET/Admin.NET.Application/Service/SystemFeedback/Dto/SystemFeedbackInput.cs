using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 系统反馈基础输入参数
    /// </summary>
    public class SystemFeedbackBaseInput
    {
        /// <summary>
        /// 反馈内容
        /// </summary>
        public virtual string Content { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
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
        /// 状态
        /// </summary>
        public virtual string Status { get; set; }
        
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
    /// 系统反馈分页查询输入参数
    /// </summary>
    public class SystemFeedbackInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 反馈内容
        /// </summary>
        public string? Content { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
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
        /// 状态
        /// </summary>
        public string? Status { get; set; }
        
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
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 系统反馈增加输入参数
    /// </summary>
    public class AddSystemFeedbackInput : SystemFeedbackBaseInput
    {
        /// <summary>
        /// 反馈内容
        /// </summary>
        [Required(ErrorMessage = "反馈内容不能为空")]
        public override string Content { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
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
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public override string Status { get; set; }
        
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
    /// 系统反馈删除输入参数
    /// </summary>
    public class DeleteSystemFeedbackInput : BaseIdInput
    {
    }

    /// <summary>
    /// 系统反馈更新输入参数
    /// </summary>
    public class UpdateSystemFeedbackInput : SystemFeedbackBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 系统反馈主键查询输入参数
    /// </summary>
    public class QueryByIdSystemFeedbackInput : DeleteSystemFeedbackInput
    {

    }
