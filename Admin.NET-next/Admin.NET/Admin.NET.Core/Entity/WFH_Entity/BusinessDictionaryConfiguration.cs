namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 业务字典配置表
    /// </summary>
    /// 

    [SugarTable(null, "业务字典配置表")]
    [SysTable]
    public class BusinessDictionaryConfiguration : EntityBase
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        [SugarColumn(ColumnDescription = "字典名称", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 字典编码
        /// </summary>
        [SugarColumn(ColumnDescription = "字典编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Code { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(ColumnDescription = "排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(100)]
        public string MeMo { get; set; }
    }
}
