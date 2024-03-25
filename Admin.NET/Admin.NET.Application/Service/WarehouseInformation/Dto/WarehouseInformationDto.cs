namespace Admin.NET.Application;

    /// <summary>
    /// 仓库资料表输出参数
    /// </summary>
    public class WarehouseInformationDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 仓库名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 公司名id
        /// </summary>
        public long CompanyNameId { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        
        /// <summary>
        /// 负责人
        /// </summary>
        public long? UserId { get; set; }
        
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
