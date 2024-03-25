namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 流程部署表
    /// </summary>
    /// 

    [SugarTable(null, "流程部署详情")]
    [SysTable]
    public class FlowPathArrange : EntityBase
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        [SugarColumn(ColumnDescription = "功能编号", Length = 255)]
        [Required, MaxLength(255)]
        public string FunctionNumber { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        [SugarColumn(ColumnDescription = "流程id")]
        [Required]
        public long FlowPathID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 绑定表名
        /// </summary>
        [SugarColumn(ColumnDescription = "绑定表名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string TableName { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        [SugarColumn(ColumnDescription = "流程类型")]
        public int typesOf { get; set; }
    }
}
