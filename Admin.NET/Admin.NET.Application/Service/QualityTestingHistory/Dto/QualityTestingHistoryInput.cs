using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 质量检测历史基础输入参数
    /// </summary>
    public class QualityTestingHistoryBaseInput
    {
        /// <summary>
        /// 物流收货id
        /// </summary>
        public virtual long LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 合同id
        /// </summary>
        public virtual long SalesContractSnoId { get; set; }
        
        /// <summary>
        /// 合同编号
        /// </summary>
        public virtual string SalesContractSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public virtual long CustomerId { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public virtual string CustomerName { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        public virtual string Salesman { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 商品编号
        /// </summary>
        public virtual string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品型号
        /// </summary>
        public virtual string MfrModel { get; set; }
        
        /// <summary>
        /// 商品名
        /// </summary>
        public virtual string GoodsName { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 商品来货数量
        /// </summary>
        public virtual int GoodsOrderQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
        
        /// <summary>
        /// 验收数量
        /// </summary>
        public virtual decimal CheckAndAcceptQuantity { get; set; }
        
        /// <summary>
        /// 验退数量
        /// </summary>
        public virtual decimal RejectionQuantity { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        public virtual string Unqualified { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public virtual int TypesOf { get; set; }
        
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
    /// 质量检测历史分页查询输入参数
    /// </summary>
    public class QualityTestingHistoryInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 物流收货id
        /// </summary>
        public long? LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 合同id
        /// </summary>
        public long? SalesContractSnoId { get; set; }
        
        /// <summary>
        /// 合同编号
        /// </summary>
        public string? SalesContractSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public long? CustomerId { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public string? CustomerName { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        public string? Salesman { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 商品编号
        /// </summary>
        public string? GoodsSno { get; set; }
        
        /// <summary>
        /// 商品型号
        /// </summary>
        public string? MfrModel { get; set; }
        
        /// <summary>
        /// 商品名
        /// </summary>
        public string? GoodsName { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 商品来货数量
        /// </summary>
        public int? GoodsOrderQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public string? Unit { get; set; }
        
        /// <summary>
        /// 验收数量
        /// </summary>
        public decimal? CheckAndAcceptQuantity { get; set; }
        
        /// <summary>
        /// 验退数量
        /// </summary>
        public decimal? RejectionQuantity { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        public string? Unqualified { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public int? TypesOf { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 质量检测历史增加输入参数
    /// </summary>
    public class AddQualityTestingHistoryInput : QualityTestingHistoryBaseInput
    {
        /// <summary>
        /// 物流收货id
        /// </summary>
        [Required(ErrorMessage = "物流收货id不能为空")]
        public override long LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 合同id
        /// </summary>
        [Required(ErrorMessage = "合同id不能为空")]
        public override long SalesContractSnoId { get; set; }
        
        /// <summary>
        /// 合同编号
        /// </summary>
        [Required(ErrorMessage = "合同编号不能为空")]
        public override string SalesContractSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        [Required(ErrorMessage = "客户id不能为空")]
        public override long CustomerId { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        [Required(ErrorMessage = "客户名称不能为空")]
        public override string CustomerName { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        [Required(ErrorMessage = "业务员不能为空")]
        public override string Salesman { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 商品编号
        /// </summary>
        [Required(ErrorMessage = "商品编号不能为空")]
        public override string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品型号
        /// </summary>
        [Required(ErrorMessage = "商品型号不能为空")]
        public override string MfrModel { get; set; }
        
        /// <summary>
        /// 商品名
        /// </summary>
        [Required(ErrorMessage = "商品名不能为空")]
        public override string GoodsName { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 商品来货数量
        /// </summary>
        [Required(ErrorMessage = "商品来货数量不能为空")]
        public override int GoodsOrderQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        [Required(ErrorMessage = "单位不能为空")]
        public override string Unit { get; set; }
        
        /// <summary>
        /// 验收数量
        /// </summary>
        [Required(ErrorMessage = "验收数量不能为空")]
        public override decimal CheckAndAcceptQuantity { get; set; }
        
        /// <summary>
        /// 验退数量
        /// </summary>
        [Required(ErrorMessage = "验退数量不能为空")]
        public override decimal RejectionQuantity { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        [Required(ErrorMessage = "不合格原因不能为空")]
        public override string Unqualified { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        [Required(ErrorMessage = "类型不能为空")]
        public override int TypesOf { get; set; }
        
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
    /// 质量检测历史删除输入参数
    /// </summary>
    public class DeleteQualityTestingHistoryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 质量检测历史更新输入参数
    /// </summary>
    public class UpdateQualityTestingHistoryInput : QualityTestingHistoryBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 质量检测历史主键查询输入参数
    /// </summary>
    public class QueryByIdQualityTestingHistoryInput : DeleteQualityTestingHistoryInput
    {

    }
