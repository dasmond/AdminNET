namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 产品图片
    /// </summary>
    /// 

    [SugarTable(null, "产品图片")]
    [SysTable]
    public class ProductImages : EntityBase
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
        /// <summary>
        /// 相片标题
        /// </summary>
        [SugarColumn(ColumnDescription = "相片标题", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PhotoTitle { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        [SugarColumn(ColumnDescription = "Url", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Url { get; set; }
    }
}
