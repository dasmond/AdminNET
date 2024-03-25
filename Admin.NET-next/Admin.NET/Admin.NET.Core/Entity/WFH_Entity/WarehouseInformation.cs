namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 仓库资料表
    /// </summary>
    /// 

    [SugarTable(null, "仓库资料表")]
    [SysTable]
    public class WarehouseInformation : EntityBase
    {
        /// <summary>
        /// 仓库名
        /// </summary>
        [SugarColumn(ColumnDescription = "仓库名", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 公司名id
        /// </summary>
        [SugarColumn(ColumnDescription = "公司名id")]
        public long CompanyNameId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnDescription = "地址", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Location { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Memo { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(ColumnDescription = "负责人", Length = 255)]
        public long? UserId { get; set; }
    }
}
