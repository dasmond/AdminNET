using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 质量检测历史
    /// </summary>
    /// 

    [SugarTable(null, "质量检测历史")]
    [SysTable]
    public class QualityTestingHistory : EntityBase
    {
        /// <summary>
        /// 物流收货id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "物流收货id")]
        public long LogisticsReceiptId { get; set; }

        /// 合同id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "合同id")]

        public long SalesContractSnoId { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "合同编号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string SalesContractSno { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "客户id")]
        public long CustomerId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "客户名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string CustomerName { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "业务员", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Salesman { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品编号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string GoodsSno { get; set; }
        /// <summary>
        /// 商品型号
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品型号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MfrModel { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string GoodsName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 商品来货数量
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品来货数量")]
        public int GoodsOrderQuantity { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "单位", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Unit { get; set; }
        /// <summary>
        /// 验收数量
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "验收数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal CheckAndAcceptQuantity { get; set; }
        /// <summary>
        /// 验退数量
        /// </summary>
        /// 

        [SugarColumn(ColumnDescription = "验退数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal RejectionQuantity { get; set; }
        /// <summary>
        /// 不合格原因
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "不合格原因", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Unqualified { get; set; }
        /// <summary>
        /// 类型 加工/来料
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "类型")]
        public int TypesOf { get; set; }

    }
}
