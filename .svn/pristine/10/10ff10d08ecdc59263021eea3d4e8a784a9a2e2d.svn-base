namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 文件目录
    /// </summary>
    /// 
    [SugarTable(null, "文件目录")]
    [SysTable]
    public class FileDirectory : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }

        /// <summary>
        /// 上层id-自己为顶级则不传
        /// </summary>
        [SugarColumn(ColumnDescription = "上层id")]
        [Required]
        public long UpperLevelsId { get; set; }
        /// <summary>
        /// 文件夹名称
        /// </summary>
        [SugarColumn(ColumnDescription = "文件夹名称", Length = 255)]
        [Required, MaxLength(255)]
        public string FolderName { get; set; }
        /// <summary>
        ///层级
        /// </summary>
        [SugarColumn(ColumnDescription = "层级")]
        [Required]
        public int Level { get; set; }
    }
}
