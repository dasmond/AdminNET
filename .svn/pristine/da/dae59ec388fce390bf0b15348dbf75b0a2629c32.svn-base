namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 项目附件版本打包表
    /// </summary>
    /// 
    [SugarTable(null, "项目附件版本打包表")]
    [SysTable]
    public class AppendixVersions : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>

        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 编码 唯一
        /// </summary>

        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 所属项目id
        /// </summary>

        [SugarColumn(ColumnDescription = "所属项目id")]
        [Required]
        public long DbId { get; set; }
    }
}
