namespace Admin.NET.Application;

    /// <summary>
    /// 客户名片输出参数
    /// </summary>
    public class CustomerBusinessCardDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string Sno { get; set; }
        
        /// <summary>
        /// 所属表id
        /// </summary>
        public long DbId { get; set; }
        
        /// <summary>
        /// 名片名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 名片在线地址1
        /// </summary>
        public string Imang_1 { get; set; }
        
        /// <summary>
        /// 文件物理路径1
        /// </summary>
        public string Path1 { get; set; }
        
        /// <summary>
        /// 名片在线地址2
        /// </summary>
        public string Imang_2 { get; set; }
        
        /// <summary>
        /// 文件物理路径2
        /// </summary>
        public string Path2 { get; set; }
        
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
