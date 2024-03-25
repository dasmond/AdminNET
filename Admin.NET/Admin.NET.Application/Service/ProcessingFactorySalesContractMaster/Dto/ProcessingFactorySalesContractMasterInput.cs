using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 加工厂合同主表基础输入参数
    /// </summary>
    public class ProcessingFactorySalesContractMasterBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 加工厂合同编码
        /// </summary>
        public virtual string PurchaserSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public virtual long CustomerId { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        public virtual long LinkmanId { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public virtual string Shipping { get; set; }
        
        /// <summary>
        /// 加工目标
        /// </summary>
        public virtual long ProcessingTarget { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public virtual bool DefaultValue { get; set; }
        
        /// <summary>
        /// 加工总数
        /// </summary>
        public virtual int ProcessingQuantity { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 允许导出
        /// </summary>
        public virtual bool AllowExport { get; set; }
        
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
    /// 加工厂合同主表分页查询输入参数
    /// </summary>
    public class ProcessingFactorySalesContractMasterInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 加工厂合同编码
        /// </summary>
        public string? PurchaserSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public long? CustomerId { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        public long? LinkmanId { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public string? Shipping { get; set; }
        
        /// <summary>
        /// 加工目标
        /// </summary>
        public long? ProcessingTarget { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public bool? DefaultValue { get; set; }
        
        /// <summary>
        /// 加工总数
        /// </summary>
        public int? ProcessingQuantity { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 允许导出
        /// </summary>
        public bool? AllowExport { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 加工厂合同主表增加输入参数
    /// </summary>
    public class AddProcessingFactorySalesContractMasterInput : ProcessingFactorySalesContractMasterBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 加工厂合同编码
        /// </summary>
        [Required(ErrorMessage = "加工厂合同编码不能为空")]
        public override string PurchaserSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        [Required(ErrorMessage = "客户id不能为空")]
        public override long CustomerId { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        [Required(ErrorMessage = "联系人id不能为空")]
        public override long LinkmanId { get; set; }
        
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
        /// 发货方式
        /// </summary>
        [Required(ErrorMessage = "发货方式不能为空")]
        public override string Shipping { get; set; }
        
        /// <summary>
        /// 加工目标
        /// </summary>
        [Required(ErrorMessage = "加工目标不能为空")]
        public override long ProcessingTarget { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        [Required(ErrorMessage = "默认值不能为空")]
        public override bool DefaultValue { get; set; }
        
        /// <summary>
        /// 加工总数
        /// </summary>
        [Required(ErrorMessage = "加工总数不能为空")]
        public override int ProcessingQuantity { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 允许导出
        /// </summary>
        [Required(ErrorMessage = "允许导出不能为空")]
        public override bool AllowExport { get; set; }
        
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
    /// 加工厂合同主表删除输入参数
    /// </summary>
    public class DeleteProcessingFactorySalesContractMasterInput : BaseIdInput
    {
    }

    /// <summary>
    /// 加工厂合同主表更新输入参数
    /// </summary>
    public class UpdateProcessingFactorySalesContractMasterInput : ProcessingFactorySalesContractMasterBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 加工厂合同主表主键查询输入参数
    /// </summary>
    public class QueryByIdProcessingFactorySalesContractMasterInput : DeleteProcessingFactorySalesContractMasterInput
    {

    }
