namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 业务字典配置详情表
    /// </summary>
    /// 

    [SugarTable(null, "业务字典配置详情表")]
    [SysTable]
    public class BusinessDictionaryConfigurationDetails : EntityBase
    {
        /// <summary>
        /// 主表id
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "主表id")]
        [Required]
        public long ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnDescription = "名称", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
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
        [SugarColumn(ColumnDescription = "备注", IsNullable = true)]
        [MaxLength(100)]
        public string MeMo { get; set; }
    }
}
