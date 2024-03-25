namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 任务表
    /// </summary>
    /// 

    [SugarTable(null, "任务表")]
    [SysTable]
    public class Assignment : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 前置任务id
        /// </summary>

        [SugarColumn(ColumnDescription = "前置任务")]

        public long PredecessorTaskId { get; set; }
        /// <summary>
        /// 前置任务名称
        /// </summary>
        [SugarColumn(ColumnDescription = "前置任务名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PredecessorTaskName { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [SugarColumn(ColumnDescription = "任务名称", Length = 255)]
        [Required, MaxLength(255)]
        public string AssignmentName { get; set; }
        /// <summary>
        /// 所属项目id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属项目id")]
        public long ProjectId { get; set; }
        /// <summary>
        /// 编码 唯一
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 任务所属人
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "任务所属人")]
        public long BelongtoId { get; set; }
        /// <summary>
        /// 紧急程度 1表示高,2表示中,3表示低
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "紧急程度")]
        public int Prioriry { get; set; }
        /// <summary>
        /// 重要程度 1表示高,2表示中,3表示低
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "重要程度")]
        public int Instancy { get; set; }
        /// <summary>
        /// 任务内容
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "任务内容", Length = 255, IsNullable = true)]
        [MaxLength(1000)]
        public string ConTent { get; set; }
        /// <summary>
        /// 状态 0计划 1开始 2进行 3结束 4成功 5失败
        /// </summary>
        [SugarColumn(ColumnDescription = "状态")]
        public int Status { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "开始时间", IsNullable = true)]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 预计完成天数
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "预计完成天数")]
        public int ProjectedCompletionTime { get; set; }
        /// <summary>
        /// 已用天数
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "已用天数")]
        public int DaysUsed { get; set; }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "实际完成时间", IsNullable = true)]
        public DateTime ActyalTime { get; set; }
        /// <summary>
        /// 任务完成评价
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "任务完成评价", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Appraise { get; set; }
        /// <summary>
        /// 效率评价等级 1表示卓越,2表示良好,3表示合格,4表示待改进
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "效率评价等级")]
        public int EfficiencyLevel { get; set; }
        /// <summary>
        /// 质量评价等级 1表示卓越,2表示良好,3表示合格,4表示待改进
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "质量评价等级")]
        public int QualityLevel { get; set; }
    }
}
