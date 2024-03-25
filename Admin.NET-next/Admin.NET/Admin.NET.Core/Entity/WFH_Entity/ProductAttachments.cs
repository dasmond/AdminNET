namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 商品附件
    /// </summary>
    /// 


    [SugarTable(null, "商品附件")]
    [SysTable]
    public class ProductAttachments : EntityBase
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
        /// <summary>
        /// 附件标题
        /// </summary>
        [SugarColumn(ColumnDescription = "附件标题", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PhotoTitle { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [SugarColumn(ColumnDescription = "商品描述", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        [SugarColumn(ColumnDescription = "Url", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Url { get; set; }
    }
}
