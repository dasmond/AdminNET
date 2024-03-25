using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 单片机上传信息
    /// </summary>
    /// 


    [SugarTable(null, "单片机上传信息")]
    [SysTable]
    public class UploadSinglechip : EntityBase
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        [Required]
        public long GoodsId { get; set; }
        /// <summary>
        /// 项目Id
        /// </summary>
        [SugarColumn(ColumnDescription = "项目Id")]
        [Required]
        public long ProjectId { get; set; }

        /// <summary>
        /// 编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
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
        /// 烧录工具
        /// </summary>
        [SugarColumn(ColumnDescription = "烧录工具", Length = 255)]
        [Required, MaxLength(255)]
        public string BurnTool { get; set; }
        /// <summary>
        /// MCU型号
        /// </summary>
        [SugarColumn(ColumnDescription = "MCU型号")]
        [Required]
        public long MCUModel { get; set; }
        /// <summary>
        /// 烧录成品型号
        /// </summary>
        [SugarColumn(ColumnDescription = "烧录成品型号")]
        [Required]
        public long BurnFinishedProductsModel { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnDescription = "用量")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Qty { get; set; }
        /// <summary>
        /// 不良率
        /// </summary>
        [SugarColumn(ColumnDescription = "不良率")]
        [Required]
        [Column(TypeName = "decimal(24,6)")]
        public decimal DefectRate { get; set; }
        /// <summary>
        /// 程序代码地址-Url
        /// </summary>
        [SugarColumn(ColumnDescription = "程序代码地址-Url", Length = 255)]
        [Required]
        public string ProgramCodeUrl { get; set; }
        /// <summary>
        /// EEPROM文件-Url
        /// </summary>
        [SugarColumn(ColumnDescription = "EEPROM文件-Url", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string EEPROMUrl { get; set; }
        /// <summary>
        /// 烧录说明文件-Url
        /// </summary>
        [SugarColumn(ColumnDescription = "烧录说明文件-Url", Length = 255)]
        [Required]
        public string BurningInstructionsUrl { get; set; }
    }
}
