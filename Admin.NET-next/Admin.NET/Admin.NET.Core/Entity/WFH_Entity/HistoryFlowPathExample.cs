namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 流程实例表
    /// </summary>
    /// 


    [SugarTable(null, "流程实例表")]
    [SysTable]
    public class HistoryFlowPathExample : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string StaTus { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        [SugarColumn(ColumnDescription = "流程ID")]
        [Required]
        public long FlowId { get; set; }
        /// <summary>
        /// 业务ID
        /// </summary>
        [SugarColumn(ColumnDescription = "业务ID")]
        [Required]
        public long BusinessKey { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [SugarColumn(ColumnDescription = "开始时间")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [SugarColumn(ColumnDescription = "结束时间")]
        public DateTime EntTime { get; set; }
        /// <summary>
        /// 耗时
        /// </summary>
        [SugarColumn(ColumnDescription = "耗时")]
        public int Duration { get; set; }
        /// <summary>
        /// 发起人
        /// </summary>
        [SugarColumn(ColumnDescription = "发起人")]
        public long StartUserId { get; set; }

        /// <summary>
        /// 流程类型
        /// </summary>
        [SugarColumn(ColumnDescription = "流程类型")]
        public int TypesOf { get; set; }
        /// <summary>
        /// 当前流程任务id 详情表
        /// </summary>
        [SugarColumn(ColumnDescription = "当前流程任务id")]
        public long FlowTaskId { get; set; }

    }
}
