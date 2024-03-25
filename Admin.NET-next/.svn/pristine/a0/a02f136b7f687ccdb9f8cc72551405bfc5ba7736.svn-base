namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 数据权限
    /// </summary>
    /// 

    [SugarTable(null, "数据权限")]
    [SysTable]

    public class TAclFunction : EntityBase
    {
        /// <summary>
        /// 父级id 自己为父级 id为0
        /// </summary>
        [SugarColumn(ColumnDescription = "父级id")]
        public long PId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnDescription = "名称", Length = 255)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(ColumnDescription = "排序")]
        [Required]
        public long SortCode { get; set; }
    }
}
