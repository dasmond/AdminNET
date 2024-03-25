using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 商品资料表
    /// </summary>
    /// 

    [SugarTable(null, "商品资料表")]
    [SysTable]
    public class GoodsInformation : EntityBase
    {
        /// <summary>
        /// 编码 唯一
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 内部编码
        /// </summary>
        [SugarColumn(ColumnDescription = "内部编码", Length = 255, IsNullable = true)]
        public string PN { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        [SugarColumn(ColumnDescription = "品名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string CnName { get; set; }
        /// <summary>
        /// 英文品名
        /// </summary>
        [SugarColumn(ColumnDescription = "英文品名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string EnName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [SugarColumn(ColumnDescription = "规格", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Model { get; set; }
        /// <summary>
        /// 助记码
        /// </summary>
        [SugarColumn(ColumnDescription = "助记码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ShortcutCode { get; set; }
        /// <summary>
        /// 制造商 制造商表(manufacturer_information) name
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Mfr { get; set; }
        /// <summary>
        /// 制造商型号 制造商表(manufacturer_information) moel
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商型号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MfrModel { get; set; }
        /// <summary>
        /// 存货类别
        /// </summary>
        [SugarColumn(ColumnDescription = "存货类别", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string InventoryCategory { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnDescription = "单位", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Unit { get; set; }
        /// <summary>
        /// 最小包装量
        /// </summary>
        [SugarColumn(ColumnDescription = "最小包装量")]

        public int MPQ { get; set; }
        /// <summary>
        /// 最小订单量
        /// </summary>
        [SugarColumn(ColumnDescription = "最小订单量")]

        public int MOQ { get; set; }

        /// <summary>
        /// 分类父id
        /// </summary>
        [SugarColumn(ColumnDescription = "分类父id")]

        public long ParentCategoryId { get; set; }
        /// <summary>
        /// 分类子id
        /// </summary>
        [SugarColumn(ColumnDescription = "分类子id")]

        public long SubclassificationId { get; set; }

        /// <summary>
        /// 库存上限
        /// </summary>
        [SugarColumn(ColumnDescription = "库存上限")]

        public int UpperLimit { get; set; }
        /// <summary>
        ///库存下限
        /// </summary>   
        [SugarColumn(ColumnDescription = "库存下限")]
        public int LowerLimit { get; set; }
        /// <summary>
        ///条码
        /// </summary>
        [SugarColumn(ColumnDescription = "条码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Barcode { get; set; }
        /// <summary>
        ///限制批数
        /// </summary>
        [SugarColumn(ColumnDescription = "限制批数")]
        public int RestrictedLots { get; set; }
        /// <summary>
        ///生产状态
        /// </summary>
        [SugarColumn(ColumnDescription = "生产状态")]
        public int Statuses { get; set; }
        /// <summary>
        ///含税指导价
        /// </summary>
        [SugarColumn(ColumnDescription = "含税指导价")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal GuidePrice { get; set; }
        /// <summary>
        ///未税指导价
        /// </summary>
        [SugarColumn(ColumnDescription = "未税指导价")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal NoGuidePrice { get; set; }
        /// <summary>
        ///可销售
        /// </summary>
        [SugarColumn(ColumnDescription = "可销售")]
        public int Marketable { get; set; }
        /// <summary>
        ///可生产
        /// </summary>
        [SugarColumn(ColumnDescription = "可生产")]
        public int Burnable { get; set; }
        /// <summary>
        ///可采购
        /// </summary>
        [SugarColumn(ColumnDescription = "可采购")]
        public int Purchasable { get; set; }
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [SugarColumn(ColumnDescription = "审核信息提示")]
        [Required, MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 完成状态 0:未完成 1：完成
        /// </summary>
        [SugarColumn(ColumnDescription = "完成状态")]
        public int CompleteStatus { get; set; }
        /// <summary>
        /// 供应商名
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string SupplierName { get; set; }
        /// <summary>
        /// 加工厂名
        /// </summary>
        [SugarColumn(ColumnDescription = "加工厂名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ProcessingPlantName { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        [SugarColumn(ColumnDescription = "交期")]
        public DateTime? DeliveryTime { get; set; }
    }
}
