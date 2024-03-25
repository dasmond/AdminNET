using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 调度库详情
    /// </summary>
    /// 
    [SugarTable(null, "调度库详情")]
    [SysTable]
    public class DispatchLibraryDetails : EntityBase
    {
        /// <summary>
        /// 调度id
        /// </summary>
        [SugarColumn(ColumnDescription = "调度id")]
        public long DispatchId { get; set; }
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
        /// 数量
        /// </summary>
        [SugarColumn(ColumnDescription = "数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Quantity { get; set; }
    }
}
