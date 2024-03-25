namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 导出记录表
    /// </summary>
    /// 

    [SugarTable(null, "导出记录表")]
    [SysTable]
    public class ExportRecord : EntityBase
    {
        /// <summary>
        /// 销售合同id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "销售合同id")]
        [Required]
        public long AgreementId { get; set; }
        /// <summary>
        /// 发货内容
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "发货内容", Length = 255)]
        [Required]
        public string ExportRecordContent { get; set; }
    }
}
