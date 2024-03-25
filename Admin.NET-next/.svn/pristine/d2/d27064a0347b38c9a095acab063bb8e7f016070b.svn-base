using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 客户名片基础输入参数
    /// </summary>
    public class CustomerBusinessCardBaseInput
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
        /// 所属表id
        /// </summary>
        public virtual long DbId { get; set; }
        
        /// <summary>
        /// 名片名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 名片在线地址1
        /// </summary>
        public virtual string Imang_1 { get; set; }
        
        /// <summary>
        /// 文件物理路径1
        /// </summary>
        public virtual string Path1 { get; set; }
        
        /// <summary>
        /// 名片在线地址2
        /// </summary>
        public virtual string Imang_2 { get; set; }
        
        /// <summary>
        /// 文件物理路径2
        /// </summary>
        public virtual string Path2 { get; set; }
        
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
    /// 客户名片分页查询输入参数
    /// </summary>
    public class CustomerBusinessCardInput : BasePageInput
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
        /// 所属表id
        /// </summary>
        public long? DbId { get; set; }
        
        /// <summary>
        /// 名片名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 名片在线地址1
        /// </summary>
        public string? Imang_1 { get; set; }
        
        /// <summary>
        /// 文件物理路径1
        /// </summary>
        public string? Path1 { get; set; }
        
        /// <summary>
        /// 名片在线地址2
        /// </summary>
        public string? Imang_2 { get; set; }
        
        /// <summary>
        /// 文件物理路径2
        /// </summary>
        public string? Path2 { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 客户名片增加输入参数
    /// </summary>
    public class AddCustomerBusinessCardInput : CustomerBusinessCardBaseInput
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
        /// 所属表id
        /// </summary>
        [Required(ErrorMessage = "所属表id不能为空")]
        public override long DbId { get; set; }
        
        /// <summary>
        /// 名片名称
        /// </summary>
        [Required(ErrorMessage = "名片名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 名片在线地址1
        /// </summary>
        [Required(ErrorMessage = "名片在线地址1不能为空")]
        public override string Imang_1 { get; set; }
        
        /// <summary>
        /// 文件物理路径1
        /// </summary>
        [Required(ErrorMessage = "文件物理路径1不能为空")]
        public override string Path1 { get; set; }
        
        /// <summary>
        /// 名片在线地址2
        /// </summary>
        [Required(ErrorMessage = "名片在线地址2不能为空")]
        public override string Imang_2 { get; set; }
        
        /// <summary>
        /// 文件物理路径2
        /// </summary>
        [Required(ErrorMessage = "文件物理路径2不能为空")]
        public override string Path2 { get; set; }
        
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
    /// 客户名片删除输入参数
    /// </summary>
    public class DeleteCustomerBusinessCardInput : BaseIdInput
    {
    }

    /// <summary>
    /// 客户名片更新输入参数
    /// </summary>
    public class UpdateCustomerBusinessCardInput : CustomerBusinessCardBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 客户名片主键查询输入参数
    /// </summary>
    public class QueryByIdCustomerBusinessCardInput : DeleteCustomerBusinessCardInput
    {

    }
