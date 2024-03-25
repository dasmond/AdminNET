using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// BOM主表
    /// </summary>
    ///
    [SugarTable(null, "BOM主表")]
    [SysTable]

    public class BomMaster : EntityBase
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        [SugarColumn(ColumnDescription = "物料编码", Length = 255)]
        [Required, MaxLength(255)]
        public string PartNo { get; set; }
        /// <summary>
        /// 生命周期阶段：【提交:0】-【归档:1】-【发布:2】-【冻结:3】-【报废:4】
        /// </summary>
        [SugarColumn(ColumnDescription = "生命周期阶段")]
        public int Cycle { get; set; }
        /// <summary>
        ///工程变更通知书
        /// </summary>
        [SugarColumn(ColumnDescription = "工程变更通知书", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Ecn { get; set; }
        /// <summary>
        ///限制批数
        /// </summary>
        [SugarColumn(ColumnDescription = "限制批数")]
        public int RestrictedLots { get; set; }
        /// <summary>
        ///生产状态  限批/量产
        /// </summary>
        [SugarColumn(ColumnDescription = "生产状态")]
        public int Statuses { get; set; }
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [SugarColumn(ColumnDescription = "审核信息提示", Length = 255)]
        [Required, MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 完成状态 0:未完成 1：完成
        /// </summary>
        [SugarColumn(ColumnDescription = "完成状态")]
        public int CompleteStatus { get; set; }
    }
}
