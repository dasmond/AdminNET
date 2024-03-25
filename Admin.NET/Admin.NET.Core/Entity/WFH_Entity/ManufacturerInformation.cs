namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 制造商资料
    /// </summary>
    /// 


    [SugarTable(null, "制造商资料")]
    [SysTable]
    public class ManufacturerInformation : EntityBase
    {
        /// <summary>
        /// 制造商
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        [SugarColumn(ColumnDescription = "品牌", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Brand { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "经纬度", Length = 255, IsNullable = true)]
        [MaxLength(100)]
        public string Center { get; set; }
    }
}
