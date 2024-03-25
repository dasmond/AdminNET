using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 财务应付表基础输入参数
    /// </summary>
    public class FinancialAccountsPayableBaseInput
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        public virtual long DbId { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public virtual string Type { get; set; }
        
        /// <summary>
        /// 财务应付价格
        /// </summary>
        public virtual decimal FinancialPrice { get; set; }
        
        /// <summary>
        /// 财务实付价格
        /// </summary>
        public virtual decimal FinancialConfirmPrice { get; set; }
        
        /// <summary>
        /// 财务未税价格
        /// </summary>
        public virtual decimal FinancialNoPrice { get; set; }
        
        /// <summary>
        /// 付款状态
        /// </summary>
        public virtual bool Status { get; set; }
        
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
    /// 财务应付表分页查询输入参数
    /// </summary>
    public class FinancialAccountsPayableInput : BasePageInput
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
        /// 类型
        /// </summary>
        public string? Type { get; set; }
        
        /// <summary>
        /// 财务应付价格
        /// </summary>
        public decimal? FinancialPrice { get; set; }
        
        /// <summary>
        /// 财务实付价格
        /// </summary>
        public decimal? FinancialConfirmPrice { get; set; }
        
        /// <summary>
        /// 财务未税价格
        /// </summary>
        public decimal? FinancialNoPrice { get; set; }
        
        /// <summary>
        /// 付款状态
        /// </summary>
        public bool? Status { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 财务应付表增加输入参数
    /// </summary>
    public class AddFinancialAccountsPayableInput : FinancialAccountsPayableBaseInput
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        [Required(ErrorMessage = "所属表id不能为空")]
        public override long DbId { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        [Required(ErrorMessage = "类型不能为空")]
        public override string Type { get; set; }
        
        /// <summary>
        /// 财务应付价格
        /// </summary>
        [Required(ErrorMessage = "财务应付价格不能为空")]
        public override decimal FinancialPrice { get; set; }
        
        /// <summary>
        /// 财务实付价格
        /// </summary>
        [Required(ErrorMessage = "财务实付价格不能为空")]
        public override decimal FinancialConfirmPrice { get; set; }
        
        /// <summary>
        /// 财务未税价格
        /// </summary>
        [Required(ErrorMessage = "财务未税价格不能为空")]
        public override decimal FinancialNoPrice { get; set; }
        
        /// <summary>
        /// 付款状态
        /// </summary>
        [Required(ErrorMessage = "付款状态不能为空")]
        public override bool Status { get; set; }
        
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
    /// 财务应付表删除输入参数
    /// </summary>
    public class DeleteFinancialAccountsPayableInput : BaseIdInput
    {
    }

    /// <summary>
    /// 财务应付表更新输入参数
    /// </summary>
    public class UpdateFinancialAccountsPayableInput : FinancialAccountsPayableBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 财务应付表主键查询输入参数
    /// </summary>
    public class QueryByIdFinancialAccountsPayableInput : DeleteFinancialAccountsPayableInput
    {

    }
