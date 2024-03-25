namespace Admin.NET.Core.Entity.WFH_Entity
{

    /// <summary>
    /// 上位机程序
    /// </summary>
    /// 
    [SugarTable(null, "上位机程序")]
    [SysTable]
    public class UpperComputerProgram : EntityBase
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
        /// <summary>
        /// 编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 开发工具
        /// </summary>
        [SugarColumn(ColumnDescription = "开发工具", Length = 255)]
        [Required, MaxLength(255)]
        public string DevelopmentTool { get; set; }
        /// <summary>
        /// 项目Id
        /// </summary>
        [SugarColumn(ColumnDescription = "项目Id")]
        [Required]
        public long ProjectId { get; set; }
        /// <summary>
        /// 任务Id
        /// </summary>
        [SugarColumn(ColumnDescription = "任务Id")]
        [Required]
        public long TaskId { get; set; }
        /// <summary>
        /// 程序代码地址-Url
        /// </summary>
        [SugarColumn(ColumnDescription = "程序代码地址-Url", Length = 255)]
        [Required]
        public string ProgramCodeUrl { get; set; }
    }
}
