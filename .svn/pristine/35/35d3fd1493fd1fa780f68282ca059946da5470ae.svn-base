using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 项目表基础输入参数
    /// </summary>
    public class ProjectDataBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 项目名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string CompanyName { get; set; }
        
        /// <summary>
        /// 公司名称id
        /// </summary>
        public virtual long CompanyNameId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }
        
        /// <summary>
        /// 项目类型
        /// </summary>
        public virtual int Type { get; set; }
        
        /// <summary>
        /// 项目需求描述
        /// </summary>
        public virtual string Desc { get; set; }
        
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
    /// 项目表分页查询输入参数
    /// </summary>
    public class ProjectDataInput : BasePageInput
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
        /// 编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 项目名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 公司名称
        /// </summary>
        public string? CompanyName { get; set; }
        
        /// <summary>
        /// 公司名称id
        /// </summary>
        public long? CompanyNameId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
        
        /// <summary>
        /// 项目类型
        /// </summary>
        public int? Type { get; set; }
        
        /// <summary>
        /// 项目需求描述
        /// </summary>
        public string? Desc { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 项目表增加输入参数
    /// </summary>
    public class AddProjectDataInput : ProjectDataBaseInput
    {
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
        /// 项目名称
        /// </summary>
        [Required(ErrorMessage = "项目名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 公司名称
        /// </summary>
        [Required(ErrorMessage = "公司名称不能为空")]
        public override string CompanyName { get; set; }
        
        /// <summary>
        /// 公司名称id
        /// </summary>
        [Required(ErrorMessage = "公司名称id不能为空")]
        public override long CompanyNameId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public override int Status { get; set; }
        
        /// <summary>
        /// 项目类型
        /// </summary>
        [Required(ErrorMessage = "项目类型不能为空")]
        public override int Type { get; set; }
        
        /// <summary>
        /// 项目需求描述
        /// </summary>
        [Required(ErrorMessage = "项目需求描述不能为空")]
        public override string Desc { get; set; }
        
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
    /// 项目表删除输入参数
    /// </summary>
    public class DeleteProjectDataInput : BaseIdInput
    {
    }

    /// <summary>
    /// 项目表更新输入参数
    /// </summary>
    public class UpdateProjectDataInput : ProjectDataBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 项目表主键查询输入参数
    /// </summary>
    public class QueryByIdProjectDataInput : DeleteProjectDataInput
    {

    }
