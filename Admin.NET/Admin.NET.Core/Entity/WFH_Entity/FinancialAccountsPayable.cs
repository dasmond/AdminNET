using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 财务应付表
    /// </summary>
    /// 
    [SugarTable(null, "财务应付表")]
    [SysTable]
    public class FinancialAccountsPayable : EntityBase
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属表id")]
        [Required]
        public long DbId { get; set; }
        /// <summary>
        /// 类型 各种订单类型
        /// </summary>
        [SugarColumn(ColumnDescription = "类型", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Type { get; set; }
        /// <summary>
        /// 财务应付价格
        /// </summary>
        [SugarColumn(ColumnDescription = "财务应付价格")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal FinancialPrice { get; set; }
        /// <summary>
        /// 财务实付价格
        /// </summary>
        [SugarColumn(ColumnDescription = "财务实付价格")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal FinancialConfirmPrice { get; set; }
        /// <summary>
        /// 财务未税价格
        /// </summary>
        [SugarColumn(ColumnDescription = "财务未税价格")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal FinancialNoPrice { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        [SugarColumn(ColumnDescription = "付款状态")]
        public bool Status { get; set; }
    }
}
