namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 销售商品
    /// </summary>
    /// 

    [SugarTable(null, "销售商品")]
    [SysTable]
    public class SaleOfGoods: EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
    }
}
