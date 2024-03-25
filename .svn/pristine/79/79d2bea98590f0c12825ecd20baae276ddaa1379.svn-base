namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 销售关系表
    /// </summary>
    /// 

    [SugarTable(null, "销售关系表")]
    [SysTable]
    public class SalesRelationship : EntityBase
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
        [MaxLength(255)]
        public long GoodsId { get; set; }
        /// <summary>
        /// 替代品id
        /// </summary>
        [SugarColumn(ColumnDescription = "替代品id")]
        public long SimilarGoodsId { get; set; }
        /// <summary>
        /// 设置默认
        /// </summary>
        [SugarColumn(ColumnDescription = "设置默认")]
        public int Priority { get; set; }
    }
}
