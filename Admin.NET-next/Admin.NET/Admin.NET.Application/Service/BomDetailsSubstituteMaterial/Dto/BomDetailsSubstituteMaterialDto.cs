namespace Admin.NET.Application;

    /// <summary>
    /// BOM详情代替料表输出参数
    /// </summary>
    public class BomDetailsSubstituteMaterialDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Bom主表id
        /// </summary>
        public long BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        public long ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        public string ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料id
        /// </summary>
        public long PartId { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        public string PartNo { get; set; }
        
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
