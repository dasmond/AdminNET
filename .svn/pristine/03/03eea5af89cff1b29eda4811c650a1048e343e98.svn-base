namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 反馈表
    /// </summary>
    /// 

    [SugarTable(null, "反馈表")]
    [SysTable]
    public class Feedback : EntityBase
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
        /// 反馈内容
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "反馈内容", Length = 255)]
        [Required, MaxLength(255)]
        public string Content { get; set; }
    }
}
