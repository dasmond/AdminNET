namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 销售订单 详情
    /// </summary>
    /// 

    [SugarTable(null, "销售订单详情")]
    [SysTable]
    public class SaleOrderDetails : EntityBase
    {
        /// <summary>
        /// 订单id
        /// </summary>
        [SugarColumn(ColumnDescription = "订单id")]
        [Required]
        public long OrderId { get; set; }
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
        /// 数量
        /// </summary>
        [SugarColumn(ColumnDescription = "数量")]
        public int Quantity { get; set; }
    }
}
