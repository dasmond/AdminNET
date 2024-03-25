namespace Admin.NET.Core.Entity.WFH_Entity
{

    /// <summary>
    /// 流程主表
    /// </summary>
    /// 

    [SugarTable(null, "流程主表")]
    [SysTable]
    public class FlowPathHost : EntityBase
    {
        /// <summary>
        /// 编码 唯一
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string StaTus { get; set; }
        /// <summary>
        /// 流程名
        /// </summary>
        [SugarColumn(ColumnDescription = "流程名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [SugarColumn(ColumnDescription = "分类")]

        public long Grouping { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(ColumnDescription = "版本", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Version { get; set; }

        /// <summary>
        /// 绑定表名
        /// </summary>
        [SugarColumn(ColumnDescription = "绑定表名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string TableName { get; set; }

    }
}
