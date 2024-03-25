using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 项目附件版本打包表基础输入参数
    /// </summary>
    public class AppendixVersionsBaseInput
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
        /// 所属项目id
        /// </summary>
        public virtual long DbId { get; set; }
        
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
    /// 项目附件版本打包表分页查询输入参数
    /// </summary>
    public class AppendixVersionsInput : BasePageInput
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
        /// 所属项目id
        /// </summary>
        public long? DbId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 项目附件版本打包表增加输入参数
    /// </summary>
    public class AddAppendixVersionsInput : AppendixVersionsBaseInput
    {
    public AddAppendixVersionsInput()
    {

        Children = new List<AppendixVersionsDetailsInput>();


    }
    /// <summary>
    /// 附件集合
    /// </summary>
    public List<AppendixVersionsDetailsInput> Children { get; set; }

}




    /// <summary>
    /// 项目附件版本打包表删除输入参数
    /// </summary>
    public class DeleteAppendixVersionsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 项目附件版本打包表更新输入参数
    /// </summary>
    public class UpdateAppendixVersionsInput : AppendixVersionsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 项目附件版本打包表主键查询输入参数
    /// </summary>
    public class QueryByIdAppendixVersionsInput : DeleteAppendixVersionsInput
    {

    }
