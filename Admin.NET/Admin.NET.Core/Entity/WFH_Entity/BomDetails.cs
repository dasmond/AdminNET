using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// BOM资料表
    /// </summary>
    /// 

    [SugarTable(null, "BOM资料表明细表")]
    [SysTable]
    public class BomDetails : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// Bom主表id
        /// </summary>
        [SugarColumn(ColumnDescription = "Bom主表id")]
        [Required]
        public long BomId { get; set; }

        /// <summary>
        /// 上级物料id
        /// </summary>
        [SugarColumn(ColumnDescription = "上级物料id")]
        [Required]
        public long ParentPartId { get; set; }
        /// <summary>
        /// 上级物料编码
        /// </summary>
        [SugarColumn(ColumnDescription = "上级物料编码", Length = 255)]
        [Required, MaxLength(255)]
        public string ParentPartNo { get; set; }
        /// <summary>
        /// 当前物料编码
        /// </summary>
        [SugarColumn(ColumnDescription = "当前物料编码", Length = 255)]
        [Required, MaxLength(255)]
        public string PartNo { get; set; }
        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnDescription = "用量")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Qty { get; set; }
        /// <summary>
        /// 不良率
        /// </summary>
        [SugarColumn(ColumnDescription = "不良率")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal DefectRate { get; set; }
        /// <summary>
        /// 工序号
        /// </summary>
        [SugarColumn(ColumnDescription = "工序号", Length = 255)]
        [Required, MaxLength(255)]
        public string Locator { get; set; }
        /// <summary>
        /// 不发料
        /// </summary>
        [SugarColumn(ColumnDescription = "不发料")]
        public bool NoPur { get; set; } = false;
        /// <summary>
        /// 位号
        /// </summary>
        [SugarColumn(ColumnDescription = "位号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Rem { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(ColumnDescription = "版本", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Ver { get; set; }
        /// <summary>
        ///层级
        /// </summary>
        [SugarColumn(ColumnDescription = "层级")]
        [Required]
        public int Level { get; set; }
        /// <summary>
        /// 完成状态 0:未完成 1：完成
        /// </summary>
        [SugarColumn(ColumnDescription = "完成状态")]
        public int CompleteStatus { get; set; }

    }
}
