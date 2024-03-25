using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 供应商入库订单
    /// </summary>
    /// 
    [SugarTable(null, "供应商订单")]
    [SysTable]
    public class SupplierOrder : EntityBase
    {
        /// <summary>
        /// 合同id 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同id")]
        [Required]
        public long SnoId { get; set; }
        /// <summary>
        /// 合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 订单编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "订单编码", Length = 255)]
        [Required, MaxLength(255)]
        public string OrderSno { get; set; }
        /// <summary>
        /// 物流收货单id
        /// </summary>
        [SugarColumn(ColumnDescription = "物流收货单id")]
        [Required]
        public long LogisticsReceiptId { get; set; }
        /// <summary>
        /// 购方合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "购方合同编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PurchaserSno { get; set; }
        /// <summary>
        /// 合同详情id
        /// </summary>
        [SugarColumn(ColumnDescription = "合同详情id")]
        [Required]
        public long SnoDetailsId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        [Required]
        public long GoodsId { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [SugarColumn(ColumnDescription = "入库数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 超出数量
        /// </summary>
        [SugarColumn(ColumnDescription = "超出数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal ExceedQuantity { get; set; }
        /// <summary>
        /// 打印次数 
        /// </summary>
        [SugarColumn(ColumnDescription = "打印次数")]
        public int Count { get; set; }

        /// <summary>
        /// 发货方式
        /// </summary>
        [SugarColumn(ColumnDescription = "发货方式", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Delivery { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        [SugarColumn(ColumnDescription = "快递单号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string TrackingNumber { get; set; }
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [SugarColumn(ColumnDescription = "审核信息提示", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 0:未审核 1已审核 2：回退 3：过期
        /// </summary>
        [SugarColumn(ColumnDescription = "审批完成状态")]
        public int CompleteStatus { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        [SugarColumn(ColumnDescription = "联系人名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]

        public string ContactsName { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [SugarColumn(ColumnDescription = "客户名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]

        public string CustomerName { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        [SugarColumn(ColumnDescription = "收货人", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ConsigneeName { get; set; }
    }
}
