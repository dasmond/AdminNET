using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 加工厂价格报备表
    /// </summary>
    /// 


    [SugarTable(null, "加工厂价格报备表")]
    [SysTable]
    public class ProcessingFactoryPriceReporting : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        [SugarColumn(ColumnDescription = "客户id")]
        [Required]
        public long CustomerId { get; set; }
        /// <summary>
        /// 联系人id
        /// </summary>
        [SugarColumn(ColumnDescription = "联系人id")]
        [Required]
        public long LinkmanId { get; set; }
        /// <summary>
        /// bom主表id
        /// </summary>
        [SugarColumn(ColumnDescription = "bom主表id")]
        [Required]
        public long BomId { get; set; }
        /// <summary>
        /// bom主表物料编码
        /// </summary>
        [SugarColumn(ColumnDescription = "bom主表物料编码", Length = 255)]
        [Required]
        public string PartNo { get; set; }
        /// <summary>
        /// 审批提示信息状态
        /// </summary>
        [SugarColumn(ColumnDescription = "审批提示信息状态", Length = 255)]
        [Required]
        public string Status { get; set; }
        /// <summary>
        /// 0:未审核 1已审核 2：回退 3：过期
        /// </summary>
        [SugarColumn(ColumnDescription = "审批完成状态")]
        public int CompleteStatus { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        [SugarColumn(ColumnDescription = "生效日期")]

        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// 交货周期
        /// </summary>
        [SugarColumn(ColumnDescription = "交货周期")]
        public int ExpireCycle { get; set; }

        /// <summary>
        /// 失效日期 默认一个月
        /// </summary>
        [SugarColumn(ColumnDescription = "失效日期")]
        public DateTime LoseEfficacyDate { get; set; }

        /// <summary>
        /// 交货时间
        /// </summary>
        [SugarColumn(ColumnDescription = "交货时间")]
        public DateTime LeadTime { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        [SugarColumn(ColumnDescription = "结算方式", Length = 255)]
        [Required, MaxLength(255)]
        public string Settlement { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id", Length = 255)]
        [Required]
        public long GoodsId { get; set; }
        /// <summary>
        /// 含税单价
        /// </summary>
        [SugarColumn(ColumnDescription = "含税单价")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Price { get; set; }
        /// <summary>
        /// 默认值 是否含税 
        /// </summary>
        [SugarColumn(ColumnDescription = "默认值")]

        public bool DefaultValue { get; set; }
        /// <summary>
        /// 税点
        /// </summary>
        [SugarColumn(ColumnDescription = "税点")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Tax { get; set; }
        /// <summary>
        /// 未税单价
        /// </summary>
        [SugarColumn(ColumnDescription = "未税单价")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal NoPrice { get; set; }
        /// <summary>
        /// 客户商品编号
        /// </summary>
        [SugarColumn(ColumnDescription = "客户商品编号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string CustomGoodsId { get; set; }

        /// <summary>
        /// 客户商品名
        /// </summary>
        [SugarColumn(ColumnDescription = "客户商品名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string CustomGoodsName { get; set; }
        /// <summary>
        /// 商品标签模板
        /// </summary>
        [SugarColumn(ColumnDescription = "商品标签模板", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string LabelTemplate { get; set; }
        /// <summary>
        /// 允许导出
        /// </summary>
        [SugarColumn(ColumnDescription = "允许导出")]
        public bool AllowExport { get; set; }
    }
}
