namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 物流收货单
    /// </summary>
    /// 

    [SugarTable(null, "物流收货单")]
    [SysTable]
    public class LogisticsReceipt : EntityBase
    {
        /// <summary>
        /// 合同id 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同id")]
        [Required]
        public long ContractId { get; set; }
        /// <summary>
        /// 物流收货编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "物流收货编码", Length = 255)]
        [Required, MaxLength(255)]
        public string LogisticsReceiptSno { get; set; }
        /// <summary>
        /// 合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同编码", Length = 255)]
        [Required, MaxLength(255)]
        public string ContractSno { get; set; }
        /// <summary>
        /// 购方合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "购方合同编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PurchaserSno { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        [Required]
        public long GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [SugarColumn(ColumnDescription = "商品名称", Length = 255)]
        [MaxLength(255)]
        [Required]
        public string GoodsName { get; set; }
        /// <summary>
        /// 来货数量
        /// </summary>
        [SugarColumn(ColumnDescription = "来货数量")]
        public int Quantity { get; set; }
        /// <summary>
        /// 送货方式
        /// </summary>
        [SugarColumn(ColumnDescription = "送货方式", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Delivery { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        [SugarColumn(ColumnDescription = "快递单号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string TrackingNumber { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        [SugarColumn(ColumnDescription = "物流公司", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string LogisticsCompany { get; set; }
        /// <summary>
        /// 送货单号
        /// </summary>
        [SugarColumn(ColumnDescription = "送货单号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string DeliveryNoteNumber { get; set; }
        /// <summary>
        /// 类型 采购/加工
        /// </summary>
        [SugarColumn(ColumnDescription = "类型")]
        public int TypesOf { get; set; }
    }
}
