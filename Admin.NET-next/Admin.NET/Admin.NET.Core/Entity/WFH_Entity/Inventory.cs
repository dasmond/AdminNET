using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 库存表
    /// </summary>
    /// 

    [SugarTable(null, "库存表")]
    [SysTable]
    public class Inventory : EntityBase
    {

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }

        /// <summary>
        /// 仓库id
        /// </summary>
        [SugarColumn(ColumnDescription = "仓库id")]
        public long StorageId { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "商品编码", Length = 255)]
        [Required]
        public string GoodsSno { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
        /// <summary>
        /// 现有数量
        /// </summary>
        [SugarColumn(ColumnDescription = "现有数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal OnhandNumber { get; set; }
        /// <summary>
        /// 采购在途数量
        /// </summary>
        [SugarColumn(ColumnDescription = "采购在途数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal ProcureNumber { get; set; }
        /// <summary>
        /// 加工在途
        /// </summary>
        [SugarColumn(ColumnDescription = "加工在途")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal ProcessingIntransit { get; set; }
        /// <summary>
        /// 冻结量
        /// </summary>
        [SugarColumn(ColumnDescription = "冻结量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal FrozenNumber { get; set; }
    }
}
