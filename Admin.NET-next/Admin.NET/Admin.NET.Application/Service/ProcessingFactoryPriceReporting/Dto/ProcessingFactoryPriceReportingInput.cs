using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 加工厂价格报备表基础输入参数
    /// </summary>
    public class ProcessingFactoryPriceReportingBaseInput
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
        /// 客户id
        /// </summary>
        public virtual long CustomerId { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        public virtual long LinkmanId { get; set; }
        
        /// <summary>
        /// bom主表id
        /// </summary>
        public virtual long BomId { get; set; }
        
        /// <summary>
        /// bom主表物料编码
        /// </summary>
        public virtual string PartNo { get; set; }
        
        /// <summary>
        /// 审批提示信息状态
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        public virtual DateTime ExpireDate { get; set; }
        
        /// <summary>
        /// 交货周期
        /// </summary>
        public virtual int ExpireCycle { get; set; }
        
        /// <summary>
        /// 失效日期
        /// </summary>
        public virtual DateTime LoseEfficacyDate { get; set; }
        
        /// <summary>
        /// 交货时间
        /// </summary>
        public virtual DateTime LeadTime { get; set; }
        
        /// <summary>
        /// 结算方式
        /// </summary>
        public virtual string Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 含税单价
        /// </summary>
        public virtual decimal Price { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public virtual bool DefaultValue { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        public virtual decimal Tax { get; set; }
        
        /// <summary>
        /// 未税单价
        /// </summary>
        public virtual decimal NoPrice { get; set; }
        
        /// <summary>
        /// 客户商品编号
        /// </summary>
        public virtual string CustomGoodsId { get; set; }
        
        /// <summary>
        /// 客户商品名
        /// </summary>
        public virtual string CustomGoodsName { get; set; }
        
        /// <summary>
        /// 商品标签模板
        /// </summary>
        public virtual string LabelTemplate { get; set; }
        
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
    /// 加工厂价格报备表分页查询输入参数
    /// </summary>
    public class ProcessingFactoryPriceReportingInput : BasePageInput
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
        /// 客户id
        /// </summary>
        public long? CustomerId { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        public long? LinkmanId { get; set; }
        
        /// <summary>
        /// bom主表id
        /// </summary>
        public long? BomId { get; set; }
        
        /// <summary>
        /// bom主表物料编码
        /// </summary>
        public string? PartNo { get; set; }
        
        /// <summary>
        /// 审批提示信息状态
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? ExpireDate { get; set; }
        
        /// <summary>
         /// 生效日期范围
         /// </summary>
         public List<DateTime?> ExpireDateRange { get; set; } 
        /// <summary>
        /// 交货周期
        /// </summary>
        public int? ExpireCycle { get; set; }
        
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? LoseEfficacyDate { get; set; }
        
        /// <summary>
         /// 失效日期范围
         /// </summary>
         public List<DateTime?> LoseEfficacyDateRange { get; set; } 
        /// <summary>
        /// 交货时间
        /// </summary>
        public DateTime? LeadTime { get; set; }
        
        /// <summary>
         /// 交货时间范围
         /// </summary>
         public List<DateTime?> LeadTimeRange { get; set; } 
        /// <summary>
        /// 结算方式
        /// </summary>
        public string? Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 含税单价
        /// </summary>
        public decimal? Price { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public bool? DefaultValue { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        public decimal? Tax { get; set; }
        
        /// <summary>
        /// 未税单价
        /// </summary>
        public decimal? NoPrice { get; set; }
        
        /// <summary>
        /// 客户商品编号
        /// </summary>
        public string? CustomGoodsId { get; set; }
        
        /// <summary>
        /// 客户商品名
        /// </summary>
        public string? CustomGoodsName { get; set; }
        
        /// <summary>
        /// 商品标签模板
        /// </summary>
        public string? LabelTemplate { get; set; }
        
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
    /// 加工厂价格报备表增加输入参数
    /// </summary>
    public class AddProcessingFactoryPriceReportingInput : ProcessingFactoryPriceReportingBaseInput
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
        /// bom主表id
        /// </summary>
        [Required(ErrorMessage = "bom主表id不能为空")]
        public override long BomId { get; set; }
        
        /// <summary>
        /// bom主表物料编码
        /// </summary>
        [Required(ErrorMessage = "bom主表物料编码不能为空")]
        public override string PartNo { get; set; }
        
        /// <summary>
        /// 审批提示信息状态
        /// </summary>
        [Required(ErrorMessage = "审批提示信息状态不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        [Required(ErrorMessage = "审批完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        [Required(ErrorMessage = "生效日期不能为空")]
        public override DateTime ExpireDate { get; set; }
        
        /// <summary>
        /// 交货周期
        /// </summary>
        [Required(ErrorMessage = "交货周期不能为空")]
        public override int ExpireCycle { get; set; }
        
        /// <summary>
        /// 失效日期
        /// </summary>
        [Required(ErrorMessage = "失效日期不能为空")]
        public override DateTime LoseEfficacyDate { get; set; }
        
        /// <summary>
        /// 交货时间
        /// </summary>
        [Required(ErrorMessage = "交货时间不能为空")]
        public override DateTime LeadTime { get; set; }
        
        /// <summary>
        /// 结算方式
        /// </summary>
        [Required(ErrorMessage = "结算方式不能为空")]
        public override string Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 含税单价
        /// </summary>
        [Required(ErrorMessage = "含税单价不能为空")]
        public override decimal Price { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        [Required(ErrorMessage = "默认值不能为空")]
        public override bool DefaultValue { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        [Required(ErrorMessage = "税点不能为空")]
        public override decimal Tax { get; set; }
        
        /// <summary>
        /// 未税单价
        /// </summary>
        [Required(ErrorMessage = "未税单价不能为空")]
        public override decimal NoPrice { get; set; }
        
        /// <summary>
        /// 客户商品编号
        /// </summary>
        [Required(ErrorMessage = "客户商品编号不能为空")]
        public override string CustomGoodsId { get; set; }
        
        /// <summary>
        /// 客户商品名
        /// </summary>
        [Required(ErrorMessage = "客户商品名不能为空")]
        public override string CustomGoodsName { get; set; }
        
        /// <summary>
        /// 商品标签模板
        /// </summary>
        [Required(ErrorMessage = "商品标签模板不能为空")]
        public override string LabelTemplate { get; set; }
        
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
    /// 加工厂价格报备表删除输入参数
    /// </summary>
    public class DeleteProcessingFactoryPriceReportingInput : BaseIdInput
    {
    }

    /// <summary>
    /// 加工厂价格报备表更新输入参数
    /// </summary>
    public class UpdateProcessingFactoryPriceReportingInput : ProcessingFactoryPriceReportingBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 加工厂价格报备表主键查询输入参数
    /// </summary>
    public class QueryByIdProcessingFactoryPriceReportingInput : DeleteProcessingFactoryPriceReportingInput
    {

    }
