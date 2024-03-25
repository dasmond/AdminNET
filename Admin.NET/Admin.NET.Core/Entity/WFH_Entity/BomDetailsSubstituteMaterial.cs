using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// BOM详情代替料表
    /// </summary>
    /// 
    [SugarTable(null, "BOM详情代替料表")]
    [SysTable]
    public class BomDetailsSubstituteMaterial : EntityBase
    {
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
        /// 当前物料id
        /// </summary>
        [SugarColumn(ColumnDescription = "当前物料id")]
        [Required]
        public long PartId { get; set; }
        /// <summary>
        /// 当前物料编码
        /// </summary>
        [SugarColumn(ColumnDescription = "当前物料编码", Length = 255)]
        [Required, MaxLength(255)]
        public string PartNo { get; set; }
        ///// <summary>
        ///// 完成状态 0:未完成 1：完成
        ///// </summary>
        //[Comment("完成状态")]
        //public int CompleteStatus { get; set; }
    }
}
