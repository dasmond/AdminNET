namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 客户反馈表
    /// </summary>
    /// 

    [SugarTable(null, "客户反馈表")]
    [SysTable]
    public class ConnectionFeedback : EntityBase
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
        /// <summary>
        /// 跟进类型
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "跟进类型", Length = 255)]
        [Required, MaxLength(255)]
        public string Type { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "业务员", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string BelongtoName { get; set; }
        /// <summary>
        /// 助理
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "助理", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string AssistantName { get; set; }
        /// <summary>
        /// 下次跟进时间
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "下次跟进时间", IsNullable = true)]
        [MaxLength(255)]
        public DateTime? NextFollowUpTime { get; set; }
    }
}
