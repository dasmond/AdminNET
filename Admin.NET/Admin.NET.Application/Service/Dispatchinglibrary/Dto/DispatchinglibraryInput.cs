using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 调度库基础输入参数
    /// </summary>
    public class DispatchinglibraryBaseInput
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
        /// 合同编码
        /// </summary>
        public virtual string ContractSno { get; set; }
        
        /// <summary>
        /// 加工厂名称
        /// </summary>
        public virtual string ProcessingFactoryName { get; set; }
        
        /// <summary>
        /// 加工厂id
        /// </summary>
        public virtual long ProcessingFactoryId { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 联系人名称
        /// </summary>
        public virtual string ContactsName { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public virtual string Delivery { get; set; }
        
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
    /// 调度库分页查询输入参数
    /// </summary>
    public class DispatchinglibraryInput : BasePageInput
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
        /// 合同编码
        /// </summary>
        public string? ContractSno { get; set; }
        
        /// <summary>
        /// 加工厂名称
        /// </summary>
        public string? ProcessingFactoryName { get; set; }
        
        /// <summary>
        /// 加工厂id
        /// </summary>
        public long? ProcessingFactoryId { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string? ContactsName { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public string? Delivery { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 调度库增加输入参数
    /// </summary>
    public class AddDispatchinglibraryInput : DispatchinglibraryBaseInput
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
        /// 合同编码
        /// </summary>
        [Required(ErrorMessage = "合同编码不能为空")]
        public override string ContractSno { get; set; }
        
        /// <summary>
        /// 加工厂名称
        /// </summary>
        [Required(ErrorMessage = "加工厂名称不能为空")]
        public override string ProcessingFactoryName { get; set; }
        
        /// <summary>
        /// 加工厂id
        /// </summary>
        [Required(ErrorMessage = "加工厂id不能为空")]
        public override long ProcessingFactoryId { get; set; }
        
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
        /// 联系人名称
        /// </summary>
        [Required(ErrorMessage = "联系人名称不能为空")]
        public override string ContactsName { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        [Required(ErrorMessage = "发货方式不能为空")]
        public override string Delivery { get; set; }
        
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
    /// 调度库删除输入参数
    /// </summary>
    public class DeleteDispatchinglibraryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 调度库更新输入参数
    /// </summary>
    public class UpdateDispatchinglibraryInput : DispatchinglibraryBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 调度库主键查询输入参数
    /// </summary>
    public class QueryByIdDispatchinglibraryInput : DeleteDispatchinglibraryInput
    {

    }
