namespace Admin.NET.Application;

    /// <summary>
    /// 单片机上传信息输出参数
    /// </summary>
    public class UploadSinglechipDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long GoodsId { get; set; }
        
        /// <summary>
        /// 项目Id
        /// </summary>
        public long ProjectId { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string Sno { get; set; }
        
        /// <summary>
        /// 任务Id
        /// </summary>
        public long TaskId { get; set; }
        
        /// <summary>
        /// 开发工具
        /// </summary>
        public string DevelopmentTool { get; set; }
        
        /// <summary>
        /// 烧录工具
        /// </summary>
        public string BurnTool { get; set; }
        
        /// <summary>
        /// MCU型号
        /// </summary>
        public long MCUModel { get; set; }
        
        /// <summary>
        /// 烧录成品型号
        /// </summary>
        public long BurnFinishedProductsModel { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        public decimal Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        public decimal DefectRate { get; set; }
        
        /// <summary>
        /// 程序代码地址-Url
        /// </summary>
        public string ProgramCodeUrl { get; set; }
        
        /// <summary>
        /// EEPROM文件-Url
        /// </summary>
        public string EEPROMUrl { get; set; }
        
        /// <summary>
        /// 烧录说明文件-Url
        /// </summary>
        public string BurningInstructionsUrl { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int ReVision { get; set; }
        
    }
