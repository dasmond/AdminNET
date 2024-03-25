using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 标签池
    /// </summary>
    /// 

    [SugarTable(null, "标签池")]
    [SysTable]
    public class CkTagPool : EntityBase
    {
        /// <summary>
        /// 订单单据编码
        /// </summary>
        [SugarColumn(ColumnDescription = "订单单据编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string OrderSno { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        [SugarColumn(ColumnDescription = "库位", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string WarehouseLocation { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        [Required]
        public long GoodsId { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
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

        public int Quantity { get; set; }
        /// <summary>
        /// 二维码内容
        /// </summary>
        [SugarColumn(ColumnDescription = "二维码内容", Length = 255, IsNullable = true)]

        public string Qrcode { get; set; }
        /// <summary>
        /// 标签模板文件名
        /// </summary>
        [SugarColumn(ColumnDescription = "标签模板文件名", Length = 255, IsNullable = true)]

        public string ModuleName { get; set; }
        /// <summary>
        /// 货架位
        /// </summary>
        [SugarColumn(ColumnDescription = "货架位", Length = 255, IsNullable = true)]

        public string ShelfSpace { get; set; }
        /// <summary>
        /// 兼容旧系统字段(传id)
        /// </summary>
        [SugarColumn(ColumnDescription = "兼容旧系统字段", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string CompatibleWithOldSystems { get; set; }
    }
}
