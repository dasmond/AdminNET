namespace Admin.NET.Application;

    /// <summary>
    /// 上传硬件Layout输出参数
    /// </summary>
    public class LayoutDto
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
        /// 任务Id
        /// </summary>
        public long TaskId { get; set; }
        
        /// <summary>
        /// 开发工具
        /// </summary>
        public string DevelopmentTool { get; set; }
        
        /// <summary>
        /// PCB文件
        /// </summary>
        public string PCBUrl { get; set; }
        
        /// <summary>
        /// 原理图
        /// </summary>
        public string SchematicDiagramImageUrl { get; set; }
        
        /// <summary>
        /// 贴片图
        /// </summary>
        public string SMTImageUrl { get; set; }
        
        /// <summary>
        /// Gerber文件
        /// </summary>
        public string GerberUrl { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string Sno { get; set; }
        
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
