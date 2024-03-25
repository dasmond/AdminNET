namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 上传硬件Layout
    /// </summary>
    /// 

    [SugarTable(null, "上传硬件Layout")]
    [SysTable]
    public class Layout : EntityBase
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        public long GoodsId { get; set; }
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
        /// 开发工具
        /// </summary>
        [SugarColumn(ColumnDescription = "开发工具", Length = 255)]
        [Required, MaxLength(255)]
        public string DevelopmentTool { get; set; }
        /// <summary>
        /// PCB文件
        /// </summary>
        [SugarColumn(ColumnDescription = "PCB文件", Length = 255)]
        [Required]
        public string PCBUrl { get; set; }
        /// <summary>
        /// 原理图
        /// </summary>
        [SugarColumn(ColumnDescription = "原理图", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string SchematicDiagramImageUrl { get; set; }
        /// <summary>
        /// 贴片图
        /// </summary>
        [SugarColumn(ColumnDescription = "贴片图", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string SMTImageUrl { get; set; }
        /// <summary>
        /// Gerber文件
        /// </summary>
        [SugarColumn(ColumnDescription = "Gerber文件", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string GerberUrl { get; set; }
        /// <summary>
        /// 编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }


    }
}
