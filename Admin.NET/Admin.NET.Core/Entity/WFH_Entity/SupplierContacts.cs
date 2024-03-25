namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 供应商联系人资料
    /// </summary>
    /// 
    [SugarTable(null, "供应商联系人资料")]
    [SysTable]
    public class SupplierContacts : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        [SugarColumn(ColumnDescription = "上级ID")]
        [MaxLength(255)]
        public long ParentId { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnDescription = "联系人", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Contact { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnDescription = "电话", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Phone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnDescription = "传真", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Fax { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnDescription = "地址", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Address { get; set; }
        /// <summary>
        /// 职位关系
        /// </summary>
        [SugarColumn(ColumnDescription = "职位关系", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Post { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "经纬度", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Center { get; set; }
        /// <summary>
        /// 设置默认联系人
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "设置默认联系人")]
        public bool DefaultValue { get; set; }
    }

}
