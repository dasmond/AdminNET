namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 出库/入历史表
    /// </summary>
    /// 

    [SugarTable(null, "出库历史表")]
    [SysTable]
    public class CkTagHistory : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 订单单据编码
        /// </summary>
        [SugarColumn(ColumnDescription = "订单单据编码", Length = 255)]
        [Required, MaxLength(255)]
        public string OrderSno { get; set; }
        /// <summary>
        /// 标签池id
        /// </summary>
        [SugarColumn(ColumnDescription = "标签池id")]
        [Required]
        public long LabelId { get; set; }
    }
}
