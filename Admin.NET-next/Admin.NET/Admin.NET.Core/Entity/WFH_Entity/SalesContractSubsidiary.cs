using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 销售合同从表
    /// </summary>
    /// 

    [SugarTable(null, "销售合同从表")]
    [SysTable]
    public class SalesContractSubsidiary : EntityBase
    {
        /// <summary>
        /// 主表id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "主表id")]
        [Required]
        public long ParentId { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        [SugarColumn(ColumnDescription = "结算方式", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Settlement { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        [Required]
        public long GoodsId { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品编码", Length = 255)]
        [Required]
        public string GoodsSno { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [SugarColumn(ColumnDescription = "商品名称", Length = 255)]
        [Required]
        public string GoodsName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [SugarColumn(ColumnDescription = "单价")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Price { get; set; }
        ///// <summary>
        ///// 未税单价
        ///// </summary>
        //[Comment("未税单价")]
        //[Required]
        //[Column(TypeName = "decimal(24,6)")]
        //public decimal NoPrice { get; set; }

        /// <summary>
        /// 税点
        /// </summary>
        [SugarColumn(ColumnDescription = "税点")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Tax { get; set; }

        /// <summary>
        /// 含税状态
        /// </summary>
        [SugarColumn(ColumnDescription = "含税状态")]
        public bool TaxCncludedStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnDescription = "数量")]
        public int Quantity { get; set; }
        /// <summary>
        /// 已发数量
        /// </summary>
        [SugarColumn(ColumnDescription = "已发数量")]

        public int LssuedQuantity { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnDescription = "单位", Length = 255, IsNullable = true)]
        [Required]
        public string Unit { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnDescription = "金额")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Amount { get; set; }
        /// <summary>
        /// 交货日期
        /// </summary>
        [SugarColumn(ColumnDescription = "交货日期")]
        public int DeliveryDate { get; set; }
        /// <summary>
        /// 排单交期
        /// </summary>
        [SugarColumn(ColumnDescription = "排单交期")]
        public DateTime? SchedulingDeliveryDate { get; set; }
        /// <summary>
        /// 商品标签模板
        /// </summary>
        [SugarColumn(ColumnDescription = "商品标签模板", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string LabelTemplate { get; set; }
    }
}
