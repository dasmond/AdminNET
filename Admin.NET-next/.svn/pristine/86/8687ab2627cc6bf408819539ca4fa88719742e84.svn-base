namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 客户名片
    /// </summary>

    [SugarTable(null, "客户名片")]
    [SysTable]
    public class CustomerBusinessCard : EntityBase
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
        /// 所属表id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属表id")]
        public long DbId { get; set; }
        /// <summary>
        /// 名片名称
        /// </summary>
        [SugarColumn(ColumnDescription = "名片名称", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 名片在线地址1
        /// </summary>
        [SugarColumn(ColumnDescription = "名片在线地址1", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Imang_1 { get; set; }
        /// <summary>
        /// 文件物理路径1
        /// </summary>
        [SugarColumn(ColumnDescription = "文件物理路径1", Length = 255)]
        [Required, MaxLength(255)]
        public string Path1 { get; set; }

        /// <summary>
        /// 名片在线地址2
        /// </summary>
        [SugarColumn(ColumnDescription = "名片在线地址2", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Imang_2 { get; set; }
        /// <summary>
        /// 文件物理路径2
        /// </summary>
        [SugarColumn(ColumnDescription = "文件物理路径2", Length = 255)]
        [Required, MaxLength(255)]
        public string Path2 { get; set; }
    }
}
