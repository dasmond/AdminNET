namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 项目表
    /// </summary>
    /// 

    [SugarTable(null, "项目表")]
    [SysTable]
    public class ProjectData : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        ///  编码 唯一
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [SugarColumn(ColumnDescription = "项目名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [SugarColumn(ColumnDescription = "公司名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司名称id
        /// </summary>
        [SugarColumn(ColumnDescription = "公司名称id")]
        public long CompanyNameId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态")]
        public int Status { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        [SugarColumn(ColumnDescription = "项目类型")]
        [MaxLength(255)]
        public int Type { get; set; }
        /// <summary>
        /// 项目需求描述
        /// </summary>
        [SugarColumn(ColumnDescription = "项目需求描述", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Desc { get; set; }

    }
}
